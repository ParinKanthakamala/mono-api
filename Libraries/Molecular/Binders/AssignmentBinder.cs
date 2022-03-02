using System;
using Molecular.Arguments;
using Molecular.Binding;
using Molecular.Parameters;

namespace Molecular.Binders
{
    public class AssignmentBinder : IBinder
    {
        public bool Optional => true;

        public bool Match(Type type)
        {
            return type == typeof(Assignment);
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            if (arguments.TryGetAssignment(param.Name, out var assignment))
            {
                used++;
                result = assignment;
                return BindStatus.Success;
            }

            result = Assignment.NotProvided;
            return BindStatus.NotFound;
        }
    }
}