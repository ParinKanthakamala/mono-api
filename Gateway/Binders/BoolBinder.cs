using System;
using Gateway.Arguments;
using Gateway.Binding;
using Gateway.Parameters;

namespace Gateway.Binders
{
    public class BoolBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type) => type == typeof(bool);

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used, out object result)
        {
            if (arguments.TryGet(param, out Flag _))
            {
                used++;
                result = true;
                return BindStatus.Success;
            }
            else
            {
                result = false;
                return BindStatus.NotFound;
            }
        }
    }

}
