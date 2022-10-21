using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class func_helper
    {
        public static bool is_html(string @string)
        {
            return false;
        }


        public static bool strafter(string @string, string substring)
        {
            return false;
        }


        public static bool strbefore(string @string, string substring)
        {
            return false;
        }

        public static bool is_connected(string domain = "www.google.com")
        {
            return false;
        }


        public static bool str_lreplace(string search, string replace, string subject)
        {
            return false;
        }


        public static bool get_string_between(string @string, string start, string end)
        {
            return false;
        }


        public static bool time_ago_specific(DateTime date, DateTime? from = null)
        {
            return false;
        }


        public static bool sec2qty(object sec)
        {
            var qty = "";
            hooks().ApplyFilters("sec2qty_formatted", new {qty = qty, sec = sec});
            return false;
        }


        public static string seconds_to_time_format(int seconds = 0, bool include_seconds = false)
        {
            return null;
        }


        public static bool hours_to_seconds_format(object hours)
        {
            return false;
        }


        public static bool ip_in_range(string ip, string range)
        {
            return false;
        }


        public static bool array_merge_recursive_distinct(ref Array array1, ref Array array2)
        {
            return false;
        }

        public static bool array_flatten(Array array)
        {
            return false;
        }

        public static bool value_exists_in_array_by_key(Dictionary<string, object> array, string key, object val)
        {
            return false;
        }

        public static bool in_array_multidimensional(Dictionary<string, object> array, string key, object val)
        {
            return false;
        }

        public static bool in_object_multidimensional(Dictionary<string, object> @object, string key, object val)
        {
            return false;
        }

        public static bool array_pluck(Array array, string key)
        {
            return false;
        }

        public static bool adjust_color_brightness(string hex, int steps)
        {
            return false;
        }

        public static bool hex2rgb(string color)
        {
            return false;
        }

        public static bool check_for_links(string ret)
        {
            return false;
        }

        public static bool time_ago(DateTime date)
        {
            return false;
        }

        public static bool slug_it(string str, params object[] options)
        {
            return false;
        }


        public static bool similarity(string str1, string str2)
        {
            return false;
        }


        // public static List<Html> app_sort_by_position(this object source, dynamic array, bool keepIndex = false)
        // {
        //     return Services.Utilities.Array.SortBy(array, "position", keepIndex);
        // }
        //
        // public static Html app_fill_empty_common_attributes(this Html html)
        // {
        //     html.icon = string.IsNullOrEmpty(html.icon) ? html.icon : "";
        //     html.href = string.IsNullOrEmpty(html.href) ? html.href : "#";
        //     return html;
        // }

        public static string strip_html_tags(this string str, string allowed = "")
        {
            var pattern = @"<[^>]+>";
            var expression = new Regex(pattern);
            return expression.Replace(str, String.Empty);
        }
    }
}