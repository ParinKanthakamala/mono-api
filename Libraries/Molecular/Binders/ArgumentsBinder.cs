using System;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
{
    public class ArgumentsBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type)
        {
            return type == typeof(Parameters.Arguments);
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            used = arguments.Count;
            result = new Parameters.Arguments(arguments);
            return BindStatus.Success;
        }
    }
}