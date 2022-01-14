using System;
using Gateway.Arguments;
using Gateway.Binding;
using Gateway.Parameters;

namespace Gateway.Binders
{
    public class AssignmentBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type) => type == typeof(Assignment);

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used, out object result)
        {
            if (arguments.TryGetAssignment(param.Name, out Assignment assignment))
            {
                used++;
                result = assignment;
                return BindStatus.Success;
            }
            else
            {
                result = Assignment.NotProvided;
                return BindStatus.NotFound;
            }
            
        }
    }

}
