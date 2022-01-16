using System;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
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
