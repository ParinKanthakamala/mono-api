using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Shared.Libraries
{
    public class GeneticAlgorithm
    {
        public GeneticAlgorithm(string code = "")
        {
            if (string.IsNullOrEmpty(code)) return;
            var temp =
                isbin(code)
                    ? Split(reverse(code))
                    : ishex(code)
                        ? Split(reverse(hex2bin(code)))
                        : new List<string>();
            if (temp.Count != 4) return;
        }

        private static bool Boolean(string data)
        {
            return data == "1";
        }

        private static List<string> Split(string code)
        {
            return code.Select(c => Convert.ToString(c)).ToList();
        }

        private bool isbin(string s)
        {
            return s.All(c => c == '0' || c == '1');
        }

        private bool ishex(string test)
        {
            return Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        //
        private string bin(bool val)
        {
            return val ? "1" : "0";
        }

        private string hex2bin(string hex)
        {
            hex = hex.ToLower();
            var hexCharacterToBinary = new Dictionary<char, string>
            {
                {'0', "0000"}, {'1', "0001"}, {'2', "0010"}, {'3', "0011"},
                {'4', "0100"}, {'5', "0101"}, {'6', "0110"}, {'7', "0111"},
                {'8', "1000"}, {'9', "1001"}, {'a', "1010"}, {'b', "1011"},
                {'c', "1100"}, {'d', "1101"}, {'e', "1110"}, {'f', "1111"}
            };
            var result = new StringBuilder();
            foreach (var c in hex) // This will crash for non-hex characters. You might want to handle that differently.
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            return result.ToString();
        }

        private string bin2hex(string binStr)
        {
            var count = 0;
            var sbHex = new StringBuilder();
            count = binStr.Length / 4;
            // First determine the length, less than 4 times when the front is 0
            if (binStr.Length % 4 != 0) binStr = binStr.PadLeft(++count * 4, '0');
            for (var i = 0; i < count; i++)
            {
                var a = Convert.ToInt32(binStr.Substring(i * 4, 4), 2); //2 to 10
                sbHex.Append(a.ToString("X")); //10 hex to hex
            }

            return sbHex.ToString();
        }

        public string reverse(string str)
        {
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            var output = new string(charArray);
            return output;
        }

        // maxx : 
        public string Encrypt(string bin_str)
        {
            bin_str = reverse(bin_str);
            var value = bin2hex(bin_str);
            return value;
        }

        public string Decrypt(string hex_str)
        {
            var value = hex2bin(hex_str);
            return reverse(value);
        }

        private string getbin()
        {
            // return bin(add) + bin(view) + bin(edit) + bin(delete);
            return null;
        }

        public string build()
        {
            var output = getbin();
            output = reverse(output);
            output = bin2hex(output);
            return output;
        }
    }
}