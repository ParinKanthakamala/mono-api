namespace Server.Hubs.Schema
{
    public class HubData
    {
        public string token { get; set; }
        public string callback { get; set; }
        public string type { get; set; }

        public dynamic data { get; set; }
    }
}