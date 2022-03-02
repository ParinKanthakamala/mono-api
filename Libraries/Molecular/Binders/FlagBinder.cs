using System;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
{
    public class FlagBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type)
        {
            return type == typeof(Flag);
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            if (arguments.TryGet(param, out Flag flag))
            {
                used++;
                result = flag;
                return BindStatus.Success;
            }

            result = new Flag(param.Name, false);
            return BindStatus.NotFound;
        }
    }
}