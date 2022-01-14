using System;
using Gateway.Arguments;
using Gateway.Binding;
using Gateway.Parameters;

namespace Gateway.Binders
{
    public class EnumBinder : IBinder
    {
        public bool Optional => false;

        public bool Match(Type type) => type.IsEnum;

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used, out object result)
        {
            if (arguments.TryGetEnum(index, param, out var value))
            {
                used++;
                result = value;
                return BindStatus.Success;
            }
            else
            {
                result = null;
                return BindStatus.Failed;
            }
        }
    }

}
