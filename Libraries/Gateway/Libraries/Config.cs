using System.Dynamic;

namespace Gateway.Libraries
{
    public class RMQP
    {
        public string name { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public string account { get; set; }
        public string password { get; set; }
    }

    public class Database
    {
        public string connection { get; set; }
    }

    public class Config
    {
        public RMQP RabbitMQ { get; set; }
        public Database Database { get; set; }
    }
}