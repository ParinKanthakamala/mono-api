using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Molecular.Arguments;
using Molecular.Attributes;
using Molecular.Parameters;
using Molecular.Utils;

namespace Molecular.Routing
{
    public static class RouteExtensions
    {
        public static IEnumerable<Route> NonDefault(this IEnumerable<Route> routes)
        {
            return routes.Where(r => !r.Default);
        }

        public static IEnumerable<Parameter> AsRoutingParameters(this IEnumerable<ParameterInfo> parameters)
        {
            foreach (var parameterInfo in parameters)
                yield return parameterInfo.AsRoutingParameter();
        }

        public static Parameter AsRoutingParameter(this ParameterInfo info)
        {
            return new Parameter
            {
                Name = info.Name.ToLower(),
                Type = info.ParameterType,
                AltName = info.GetCustomAttribute<Alt>()?.Name,
                Optional = info.IsOptionalParameter()
            };
        }

        public static Parameter AsRoutingParameter(this MemberInfo info)
        {
            return new Parameter
            {
                Name = info.Name.ToLower(),
                Type = info.GetMemberType(),
                AltName = info.GetCustomAttribute<Alt>()?.Name,
                Optional = true // for now.
            };
        }

        public static bool IsOptionalParameter(this ParameterInfo parameter)
        {
            var hasAttr = parameter.HasAttribute<Optional>();
            var maybenull = parameter.IsNullable();
            var hasdefault = parameter.IsOptional;

            return hasAttr || maybenull || hasdefault;
        }

        public static IEnumerable<Parameter> GetRoutingParameters(this Route route)
        {
            var paraminfo = route.Method.GetParameters();
            var parameters = AsRoutingParameters(paraminfo);
            return parameters;
        }

        public static Parameters.Parameters GetRoutingParameters(this MethodInfo method)
        {
            var parameters = method.GetParameters().AsRoutingParameters();
            return new Parameters.Parameters(parameters);
        }

        public static string AsText(this Route route)
        {
            var parameters = route.GetRoutingParameters();
            return string.Join(" ", parameters.Select(p => AsText(p)));
        }

        public static string ParametersAsText(this MethodInfo method)
        {
            var parameters = method.GetParameters().AsRoutingParameters();
            return string.Join(" ", parameters.Select(p => AsText(p)));
        }

        public static string AsText(this Parameter parameter)
        {
            var type = parameter.Type;
            var name = parameter.Name;

            string rep;

            if (type == typeof(Flag) || type == typeof(bool))
                rep = $"--{name}";
            else if (type == typeof(Assignment))
                rep = $"{name}=<value>";
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Flag<>))
                rep = $"--{name} <value>";
            else if (type == typeof(Parameters.Arguments))
                rep = $"<{name}>...";
            else if (type == typeof(string))
                rep = $"<{name}>";
            else
                rep = $"{name}";

            if (parameter.Optional) rep = $"({rep})";

            return rep;
        }


        public static Parameters.Arguments Parse(this Router router, string text)
        {
            return router.Parser.Parse(text);
        }

        public static Parameters.Arguments Parse(this Router router, params string[] args)
        {
            return router.Parser.Parse(args);
        }
    }
}