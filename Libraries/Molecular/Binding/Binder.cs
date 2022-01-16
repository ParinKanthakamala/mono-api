using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Molecular.Arguments;
using Molecular.Parameters;
using Molecular.Routing;
using Molecular.Utils;

namespace Molecular.Binding
{
    public class Binder 
    {
        private List<IBinder> binders;

        public Binder(IEnumerable<IBinder> binders)
        {
            this.binders = binders.ToList();
        }


        public IEnumerable<Bind> Bind(IEnumerable<Route> routes, Parameters.Arguments arguments)
        {
            foreach (var route in routes)
            {
                var args = arguments.WithoutCommands(route);
                if (TryCreateBind(route, args, out var bind))
                {
                    yield return bind;
                }
            }
        }

        public void Bind(IEnumerable<Type> types, Parameters.Arguments arguments)
        {
            if (types is null) return;

            foreach(var type in types)
            {
                Bind(type, arguments);
            }
        }

        
        public void Bind(Type type, Parameters.Arguments arguments)
        {
            if (type is null) return;

            var globals = new List<IArgument>();

            foreach (var arg in arguments)
            {
                if (arg is Flag f && type.GetProperty(typeof(bool), f.Name) is PropertyInfo pb)
                {
                    pb.SetValue(null, true);
                    globals.Add(arg);
                }
                else if (arg is Flag<string> s && type.GetProperty(typeof(string), s.Value) is PropertyInfo ps)
                {
                    ps.SetValue(null, s.Value);
                    globals.Add(arg);
                }
                
            }

            foreach (var a in globals) arguments.Remove(a);
        }

        public bool TryCreateBind(Route route, Parameters.Arguments arguments, out Bind bind)
        {
            if (TryBindParameters(route, arguments, out var values))
            {
                bind = new Bind(route, values);
                return true;
            }
            else
            {
                bind = null;
                return false;
            }
        }
      
        public bool TryBindParameters(Route route, Parameters.Arguments arguments, out object[] values)
        {
            Parameters.Parameters parameters = route.Method.GetRoutingParameters();
            return TryBindParameters(parameters, arguments, out values);
        }

        // Note that parameters here refer to the parameters of a C# method, and that arguments refer to the values
        // from the command line that will set those paremeters.
        private bool TryBindParameters(Parameters.Parameters parameters, Parameters.Arguments arguments, out object[] values)
        {
            values = new object[parameters.Count];

            //int offset = arguments.Commands;
            int index = 0; // index of parameters
            int used = 0; // arguments used;

            foreach (var param in parameters)
            {
                var binder = binders.FindMatch(param.Type);
                if (binder is null) return false;

                var status = binder.TryUse(arguments, param, index, ref used, out object value);
                if (status == BindStatus.Success)
                {
                    values[index++] = value;
                }
                else if (status == BindStatus.NotFound & (binder.Optional | param.Optional))
                {
                    values[index++] = value;
                }
                else // BindStatus.Failed | or NotFound non optional param.
                {
                    return false;
                }
            }
            return (arguments.Count == used);
        }

    }


}


