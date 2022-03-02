using System;
using System.Collections.Generic;
using System.Linq;

namespace Molecular.Binding
{
    public static class BinderExtensions
    {
        public static IBinder FindMatch(this IEnumerable<IBinder> binders, Type type)
        {
            return binders.FirstOrDefault(b => b.Match(type));
        }
    }
}