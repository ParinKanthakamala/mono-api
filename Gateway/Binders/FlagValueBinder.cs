using System;
using Gateway.Arguments;
using Gateway.Binding;
using Gateway.Parameters;

namespace Gateway.Binders
{
    public class FlagValueBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Flag<>);
    
        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used, out object result)
        {
            Type innertype = param.Type.GetGenericArguments()[0];

            if (arguments.TryGet(param, out Flag flag))
            {
                if (arguments.TryGetFollowing(flag, out Text text))
                {
                    var value = FlagActivator.CreateValueFlag(innertype, param.Name, text.Value);
                    if (value is not null)
                    {
                        used += 2;
                        result = value;
                        return BindStatus.Success;
                    }
                } 

                // we do not increment, because it's not a valid parameter.
                // used++;
                result = FlagActivator.CreateUnsetValueFlag(innertype, param.Name);
                return BindStatus.Failed;
            }
            else
            {
                result = FlagActivator.CreateUnsetValueFlag(innertype, param.Name);
                return BindStatus.NotFound;
            }
        }

       
    }

}
