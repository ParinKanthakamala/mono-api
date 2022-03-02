using System;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
{
    public class IntBinder : IBinder
    {
        public bool Optional => false;

        public bool Match(Type type)
        {
            return type == typeof(int);
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            if (arguments.TryGetInt(index, out var i))
            {
                used++;
                result = i;
                return BindStatus.Success;
            }

            result = null;
            return BindStatus.NotFound;
        }
    }
}