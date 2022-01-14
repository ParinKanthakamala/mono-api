using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace Gateway
{
    public class RpcServer
    {
        private readonly string host;
        private readonly string name;
        private EventingBasicConsumer consumer;
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        private BasicDeliverEventArgs args;
        private IBasicProperties props;
        private IBasicProperties replyProps;
        private Sharepoint sharepoint = Sharepoint.sharepoint;

        private void OnMessage(object sender, BasicDeliverEventArgs ea)
        {
            this.args = ea;
            var response = string.Empty;
            this.props = ea.BasicProperties;
            this.replyProps = channel.CreateBasicProperties();
            this.replyProps.CorrelationId = props.CorrelationId;

            try
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                var json = JsonConvert.DeserializeObject<DataMessage>(message);
                sharepoint.props = this.props;
                if (string.IsNullOrEmpty(json.Route)) return;
                sharepoint.message = json;
                var result = Routing.Routing.Handle(json.Route.Split('/').ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(" [.] " + e.Message);
            }
        }


        public void Send(string message = "", string exchange = "", bool kick = false)
        {
            // var response = JsonConvert.SerializeObject(message);
            var responseBytes = Encoding.UTF8.GetBytes(message);
            this.channel.BasicPublish(
                exchange: exchange,
                routingKey: sharepoint.props.ReplyTo,
                basicProperties: this.replyProps,
                body: responseBytes
            );
            this.channel.BasicAck(
                deliveryTag: this.args.DeliveryTag,
                multiple: false
            );
        }

        public void Start(
            bool durable = true,
            bool exclusive = false,
            bool autoDelete = true,
            dynamic arguments = default(ExpandoObject)
        )
        {
            this.factory = new ConnectionFactory() {HostName = this.host};

            this.connection = this.factory.CreateConnection();
            this.channel = connection.CreateModel();

            this.channel.QueueDeclare(
                queue: this.name,
                durable: durable,
                exclusive: exclusive,
                autoDelete: autoDelete,
                arguments: null
            );
            this.channel.BasicQos(0, 1, false);
            this.consumer = new EventingBasicConsumer(channel);
            this.channel.BasicConsume(queue: this.name, autoAck: false, consumer: consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");
            this.consumer.Received += this.OnMessage;
        }

        public RpcServer(string host = "localhost", string name = "test")
        {
            this.host = host;
            this.name = name;
            sharepoint.server = this;
        }
    }
}