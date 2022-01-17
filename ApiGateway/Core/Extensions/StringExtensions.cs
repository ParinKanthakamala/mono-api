using System;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiGateway.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetLocalIPAddress(this string source)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static bool IsValidJson(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            source = source.Trim();
            if ((source.StartsWith("{") && source.EndsWith("}")) || //For object
                (source.StartsWith("[") && source.EndsWith("]"))) //For array
            {
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
            }
            else
            {
                return false;
            }
        }
    }
}