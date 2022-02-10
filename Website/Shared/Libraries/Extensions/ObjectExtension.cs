using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;

namespace Shared.Libraries.Extensions
{
    public static class ObjectExtension
    {
        public static Dictionary<string, object> ToDictionary(this object source)
        {
            return TypeDescriptor
                .GetProperties(source)
                .Cast<PropertyDescriptor>()
                .ToDictionary(
                    desc =>
                        desc.Name,
                    desc => desc.GetValue(source)
                );
        }

        public static bool ContainsKey(this object source, string name)
        {
            if (source is ExpandoObject)
                return ((IDictionary<string, object>) source).ContainsKey(name);

            return source.GetType().GetProperty(name) != null;
        }

        public static bool Remove(this object source, object name)
        {
            var temp = source;
            if (temp is ExpandoObject)
            {
                source = ((IDictionary<object, object>) temp).ContainsKey(name);
            }

            // return source.GetType().GetProperty(name) != null;
            return false;
        }
    }
}