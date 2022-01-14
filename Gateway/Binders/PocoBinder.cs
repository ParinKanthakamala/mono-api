using System;
using System.Collections.Generic;
using System.Linq;
using Gateway.Attributes;
using Gateway.Binding;
using Gateway.Parameters;
using Gateway.Routing;
using Gateway.Utils;

namespace Gateway.Binders
{
    public class PocoBinder : IBinder
    {
        public bool Optional => true;

        private List<IBinder> binders;

        public PocoBinder(List<IBinder> binders)
        {
            this.binders = binders;
        }

        public bool Match(Type type) => type.HasAttribute<Bucket>();

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used, out object result)
        {
            Type type = param.Type;
            // check for: parameterless constructor.

            result = Activator.CreateInstance(param.Type);

            var members = type.GetFieldsAndProperties().ToList();

            foreach (var member in members)
            {
                var membertype = member.GetMemberType();
                var binder = binders.FindMatch(membertype);
                if (binder is null) continue;
                var memberAsParam = member.AsRoutingParameter();

                var status = binder.TryUse(arguments, memberAsParam, index, ref used, out object value);
                if (status is BindStatus.Failed) return status;

                member.SetValue(result, value);
                
            }

            return BindStatus.Success;
        }

    }

}
