using System;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
{
    public class EnumBinder : IBinder
    {
        public bool Optional => false;

        public bool Match(Type type)
        {
            return type.IsEnum;
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            if (arguments.TryGetEnum(index, param, out var value))
            {
                used++;
                result = value;
                return BindStatus.Success;
            }

            result = null;
            return BindStatus.Failed;
        }
    }
}