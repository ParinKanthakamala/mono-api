using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Shared.Helpers
{
    public static class string_helper
    {
        private static readonly Random random = new();

        public static string BreakUpString(this string value)
        {
            return Regex.Replace(value,
                "((?<=[a-z])[A-Z]|[A-Z](?=[a-z]))",
                " $1",
                RegexOptions.Compiled).Trim();
        }

        public static Dictionary<string, string> ParseQueryString(string queryString)
        {
            var nvc = HttpUtility.ParseQueryString(queryString);
            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }

        public static string CreateQueryString(Dictionary<string, string> parameters)
        {
            return string.Join("&",
                parameters.Select(kvp => string.Format("{0}={1}", kvp.Key, HttpUtility.UrlEncode(kvp.Value))));
        }

        public static string nl2br(this string input)
        {
            return input.nl2br(true);
        }

        public static string nl2br(this string input, bool is_xhtml)
        {
            return input.Replace("\r\n", is_xhtml ? "<br />\r\n" : "<br>\r\n");
        }


        public static string GetStringBetween(this string source, string start, string end)
        {
            source = " " + source;
            var ini = source.IndexOf(start);
            if (ini == 0) return "";

            ini += start.Length;
            var len = source.IndexOf(end, ini) - ini;

            return source.Substring(ini, len);
        }

        public static string StrAfter(this string source, string search)
        {
            var pos = source.IndexOf(search);
            if (pos == 0) return source;

            return source.Substring(pos + source.Length);
        }

        public static string RandomString(this string source, int length)
        {
            var pattern = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            if (!string.IsNullOrEmpty(source)) pattern = source;

            //            const string chars = pattern.ToCharArray();
            return new string(Enumerable.Repeat(pattern, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string preg_replace(this object source, string pattern, string oldChar, string newChar)
        {
            var regex = new Regex(pattern);
            return regex.Replace(oldChar, newChar);
        }

        public static bool IsEmpty(this string stringValue)
        {
            return string.IsNullOrEmpty(stringValue);
        }
    }
}