using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace Shared.Libraries.Extensions
{
    public static class UrlExtension
    {
        public static string url(this object source, string route, dynamic args = default(ExpandoObjectExtensions),
            bool secure = false)
        {
            var output = string.Empty;
            var @params = new List<string>();
            if (args != default(ExpandoObject))
                foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(args))
                    @params.Add(desc.Name + "=" + desc.GetValue(args));
            output = route + "?" + string.Join("&", @params);
            return output;
        }
    }
}