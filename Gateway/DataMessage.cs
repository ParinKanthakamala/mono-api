using System.Dynamic;

namespace Gateway
{
    public class DataMessage
    {
        public string User;
        public string Method;
        public string Message = "";
        public string From = "api-gateway";
        public string To;
        public string Route;
        public string Host;
        public string Type;
        public dynamic Body = new ExpandoObject();
        public dynamic Query = new ExpandoObject();
        public string Token = "";
    }
}