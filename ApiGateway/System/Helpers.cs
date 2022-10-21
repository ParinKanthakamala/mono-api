namespace ApiGateway.System
{
    public class Url
    {
        public static string base_url(string route = "")
        {
            return "";
        }

        public static string site_url(string route = "")
        {
            return "";
        }

        public static Session session()
        {
            Session _session = Session.getInstance();
            return _session;
        }

        public static Input input()
        {
            return Input.getInstance;
        }


        public static string session(string route = "")
        {
            return "";
        }
    }
}