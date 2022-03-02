using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace Shared.Libraries.Extensions
{
    public static class ExpandoObjectExtensions
    {
        public static T Get<T>(this ExpandoObject source, string key)
        {
            foreach (var output in from PropertyDescriptor desc in TypeDescriptor.GetProperties(source)
                     where desc.Name == key
                     select desc.GetValue(source))
                return (T) Convert.ChangeType(output, typeof(T), CultureInfo.InvariantCulture);

            return default;
        }

        public static bool Empty(this ExpandoObject source)
        {
            var output = false;
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(source)) output = true;
            return output;
        }

        public static int Size(this ExpandoObject source)
        {
            return TypeDescriptor.GetProperties(source).Cast<PropertyDescriptor>().Count();
        }

        public static void Remove(this ExpandoObject source, string key)
        {
            ((IDictionary<string, object>) source).Remove(key);
        }


        public static string GetString(this ExpandoObject source, string key, string @default = "")
        {
            foreach (var desc in TypeDescriptor.GetProperties(source).Cast<PropertyDescriptor>()
                         .Where(desc => desc.Name == key))
                return Convert.ToString(desc.GetValue(source));

            return @default;
        }
    }
}