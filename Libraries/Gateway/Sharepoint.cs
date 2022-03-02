using System.Collections.Generic;
using Gateway.Libraries.RabbitMQ;
using RabbitMQ.Client;

namespace Gateway
{
    public class Sharepoint
    {
        private static Sharepoint instance;

        public Dictionary<string, dynamic> Queues = new();
        public IBasicProperties replyProps;


        private Sharepoint()
        {
        }

        public DataMessage message { get; set; }


        public static Sharepoint sharepoint
        {
            get { return instance ??= new Sharepoint(); }
        }

        public RpcServer server { get; set; }
    }
}