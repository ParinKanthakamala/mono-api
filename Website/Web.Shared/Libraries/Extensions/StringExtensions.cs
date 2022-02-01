using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Web.Shared.Libraries.Extensions
{
    public static class StringExtensions
    {
        private static readonly Random Random = new();


        public static string Nl2Br(this string input, bool isXhtml)
        {
            return input.Replace("\r\n", isXhtml ? "<br />\r\n" : "<br>\r\n");
        }

        public static bool IsEmail(this string source)
        {
            try
            {
                var m = new MailAddress(source);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

// maxx : is not a number
        public static bool IsNan(this string source)
        {
            return !source.IsNumber();
        }

        public static bool IsNumber(this string source)
        {
            var result = 0;
            return int.TryParse(source, out result);
        }

        public static bool preg_match(this string pattern, string input)
        {
            try
            {
                var match = Regex.Match(pattern, input);
                return match.Success;
            }
            catch
            {
            }

            return false;
        }

        public static string preg_replace(this string pattern, string oldChar, string newChar)
        {
            var regex = new Regex(pattern);
            return regex.Replace(oldChar, newChar);
        }

        public static bool Find(this string input, string pattern, ref Match match)
        {
            match = Regex.Match(input, pattern);
            return match.Groups.Count > 0;
        }

        public static bool preg_match(this string pattern, string input, ref MatchCollection matches)
        {
            matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            return matches.Count > 0;
        }

        public static bool preg_match_all(this string pattern, string input, ref MatchCollection matches)
        {
            matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            return matches.Count > 0;
        }


        public static string RandomString(this string source, int length)
        {
            var pattern = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (!string.IsNullOrEmpty(source)) pattern = source;

            //            const string chars = pattern.ToCharArray();
            return new string(Enumerable.Repeat(pattern, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }


        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static int ToInt32(this string source)
        {
            return Convert.ToInt32(source);
        }


        public static string RemoveSuffix(this string source, string str)
        {
            var output = source;
            var checker = source.Substring(source.Length - str.Length);
            if (checker == str) output = source.Substring(0, source.Length - str.Length);

            return output;
        }

        public static string RemoveSuffix(this string source, int lengthFromLast)
        {
            if (source.Length < lengthFromLast) return "";
            var output = source;
            if (source.Length > lengthFromLast) output = source.Substring(0, source.Length - lengthFromLast);

            return output;
        }


        public static string Nl2Br(this string source)
        {
            new List<string>
            {
                "\r\n",
                "\n"
            }.ForEach(row => { source = source.Replace(row, "<br/>"); });
            return source;
        }

        public static string Ucfirst(this string source)
        {
            return source.First().ToString().ToUpper() + source.Substring(1);
        }

        public static bool CompareIgnoreCase(this string source, string search)
        {
            return source.ToLower() == search.ToLower();
        }

        public static string StripTags(this string source)
        {
            var regHtml = new Regex("<[^>]*>");
            var s = regHtml.Replace(source, "");
            return s;
        }


        public static bool IsValidJson(this string source)
        {
            source = source.Trim();
            if (source.StartsWith("{") && source.EndsWith("}") || //For object
                source.StartsWith("[") && source.EndsWith("]")) //For array
                try
                {
                    var obj = JToken.Parse(source);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            return false;
        }

        public static string Between(this string source, string firstString, string lastString)
        {
            string finalString;
            var pos1 = source.IndexOf(firstString) + firstString.Length;
            var pos2 = source.IndexOf(lastString);
            finalString = source.Substring(pos1, pos2 - pos1);
            return finalString;
        }
    }
}