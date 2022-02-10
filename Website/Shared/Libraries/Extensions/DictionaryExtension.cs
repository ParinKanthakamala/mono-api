using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Libraries.Extensions
{
    public static class DictionaryExtension
    {
        public static string GetString(this Dictionary<string, object> source, string key, string @default = "")
        {
            foreach (var kvp in source.Where(kvp => kvp.Key == key)) return Convert.ToString(kvp.Value);

            return @default;
        }

        public static int GetInt(this Dictionary<string, object> source, string key, int @default = 0)
        {
            var temp = source.GetString(key, 0 + "");

            return Convert.ToInt32(temp);
        }

        // public static void AddFormat<TKey>(this Dictionary<TKey, string> dictionary, TKey key, string formatString,
        //     params object[] argList)
        // {
        //     dictionary.Add(key, string.Format(formatString, argList));
        // }
    }
}