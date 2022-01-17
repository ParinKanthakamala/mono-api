using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Gateway
{
    public class Sharepoint
    {
        private static Sharepoint instance = null;
        public IModel channel;
        public IBasicProperties replyProps;
        public DataMessage message { get; set; }
        private Dictionary<string, RpcServer> datas = new Dictionary<string, RpcServer>();

        public RpcServer this[string key]
        {
            get => this.datas.ContainsKey(key) ? this.datas[key] : null;
            set
            {
                if (this.datas.ContainsKey(key))
                {
                    this.datas.Remove(key);
                }

                this.datas.Add(key, value);
            }
        }

        public static Sharepoint sharepoint
        {
            get { return instance ??= new Sharepoint(); }
        }

        public RpcServer server { get; set; }
        public IBasicProperties props { get; set; }
        public Dictionary<string, dynamic> Queues = new Dictionary<string, dynamic>();


        

        private Sharepoint()
        {
        }
    }
}