using System.Dynamic;
using RestSharp;

namespace Gateway
{
    public class DataMessage
    {
        public dynamic Body = new ExpandoObject();
        public string From = "api-gateway";
        public string Host;
        public string Message = "";
        public Method Method;
        public dynamic Query = new ExpandoObject();
        public string Route;
        public string To;
        public string Token = "";
        public string Type;
        public string User;
    }
}