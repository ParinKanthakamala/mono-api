using RabbitMQ.Client;

namespace Gateway
{
    public class Sharepoint
    {
        private static Sharepoint instance = null;
        public DataMessage message { get; set; }

        public static Sharepoint sharepoint
        {
            get { return instance ??= new Sharepoint(); }
        }

        public RpcServer server { get; set; }
        public IBasicProperties props { get; set; }


        private Sharepoint()
        {
        }
    }
}