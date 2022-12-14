using System;
using System.Linq;
using Molecular.Attributes;
using Molecular.Parameters;
using Molecular.Routing;

namespace Molecular.Arguments
{
    public static class ArgumentsExtensions
    {
        public static Parameters.Arguments WithoutCommands(this Parameters.Arguments arguments, Route route)
        {
            var offset = route.Nodes.Count();
            var args = arguments.Skip(offset);
            return new Parameters.Arguments(args);
        }

        public static Parameters.Arguments WithoutCapture(this Parameters.Arguments arguments, Capture capture)
        {
            return new Parameters.Arguments(arguments.Where(a => !capture.Match(a)));
        }

        //public static Arguments WithoutCommands(this Arguments arguments)
        //{
        //    return new Arguments(arguments.Skip(arguments.Commands));
        //}

        public static bool TryGetText(this Parameters.Arguments args, int index, out Text literal)
        {
            return args.TryGet(index, out literal);
        }

        public static bool TryGetEnum(this Parameters.Arguments args, int index, Parameter param, out object value)
        {
            if (args.TryGetText(index, out var literal))
                try
                {
                    value = Enum.Parse(param.Type, literal, true);
                    return true;
                }
                catch
                {
                }

            value = null;
            return false;
        }

        public static bool TryGetInt(this Parameters.Arguments args, int index, out int value)
        {
            if (args.TryGet(index, out Text s)) return int.TryParse(s, out value);
            value = default;
            return false;
        }

        public static bool TryGetAssignment(this Parameters.Arguments args, string name, out Assignment assignment)
        {
            var matches = args.OfType<Text>();

            foreach (var m in matches)
                if (m.TryGetAssignment(name, out assignment))
                    return true;
            assignment = Assignment.NotProvided;
            return false;
        }

        public static bool TryGet<T>(this Parameters.Arguments args, string name, out T item) where T : IArgument
        {
            var items = args.Match<T>(name);
            item = items.FirstOrDefault();
            return items.Count == 1;
        }

        public static bool TryGet<T>(this Parameters.Arguments args, Parameter parameter, out T item)
            where T : IArgument
        {
            var items = args.Match<T>(parameter);
            item = items.FirstOrDefault();
            return items.Count == 1;
        }

        public static bool TryGet<T>(this Parameters.Arguments args, int index, out T item) where T : IArgument
        {
            if (index < args.Count && args[index] is T arg)
            {
                item = arg;
                return true;
            }

            item = default;
            return false;
        }

        public static bool TryGetFollowing<T>(this Parameters.Arguments args, IArgument arg, out T item)
            where T : IArgument
        {
            var index = args.IndexOf(arg);
            if (index >= 0)
                if (TryGet(args, index + 1, out item))
                    return true;

            item = default;
            return false;
        }

        public static bool TryGetOptionString(this Parameters.Arguments args, Parameter parameter, out string value)
        {
            if (args.TryGet(parameter, out Flag flag))
                if (args.TryGetFollowing(flag, out Text text))
                {
                    value = text.Value;
                    return true;
                }

            value = null;
            return false;
        }
    }
}