using System;
using System.Collections.Generic;
using System.Linq;
using Molecular.Attributes;
using Molecular.Binding;
using Molecular.Parameters;
using Molecular.Routing;
using Molecular.Utils;

namespace Molecular.Binders
{
    public class PocoBinder : IBinder
    {
        private readonly List<IBinder> binders;

        public PocoBinder(List<IBinder> binders)
        {
            this.binders = binders;
        }

        public bool Optional => true;

        public bool Match(Type type)
        {
            return type.HasAttribute<Bucket>();
        }

        public BindStatus TryUse(Parameters.Arguments arguments, Parameter param, int index, ref int used,
            out object result)
        {
            var type = param.Type;
            // check for: parameterless constructor.

            result = Activator.CreateInstance(param.Type);

            var members = type.GetFieldsAndProperties().ToList();

            foreach (var member in members)
            {
                var membertype = member.GetMemberType();
                var binder = binders.FindMatch(membertype);
                if (binder is null) continue;
                var memberAsParam = member.AsRoutingParameter();

                var status = binder.TryUse(arguments, memberAsParam, index, ref used, out var value);
                if (status is BindStatus.Failed) return status;

                member.SetValue(result, value);
            }

            return BindStatus.Success;
        }
    }
}