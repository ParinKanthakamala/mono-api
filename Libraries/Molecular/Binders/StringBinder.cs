using System;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
{
    public class StringBinder : IBinder
    {
        public bool Optional => false;

        public bool Match(Type type)
        {
            return type == typeof(string);
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            if (arguments.TryGetText(index, out var Text))
            {
                used++;
                result = Text.Value;
                return BindStatus.Success;
            }

            result = null;
            return BindStatus.NotFound;
        }
    }
}