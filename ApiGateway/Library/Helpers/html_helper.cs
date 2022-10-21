using ApiGateway.Library.Services.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace ApiGateway.Library.Helpers
{
    public static class html_helper
    {
        // public static string Lang(this IHtmlHelper source, string line, params object[] values)
        // {
        //     var lang = Language.GetInstance();
        //     var output = lang[line];
        //     return string.Format(output, values);
        // }

        public static T Option<T>(this IHtmlHelper source, string key)
        {
            return source.get_option<T>(key);
        }

        public static string AdminUrl(this IHtmlHelper source, string route)
        {
            return source.admin_url(route);
        }

        public static bool has_permission(this IHtmlHelper source, string route, string action)
        {
            return true;
        }

        public static Permission Permission(this IHtmlHelper source)
        {
            return default(Permission);
        }

        public static bool has_permission(this IHtmlHelper source, int user_id, string action)
        {
            return true;
        }
    }
}