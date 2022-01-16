using System;
using System.Dynamic;
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
            try
            {
                args = ea;
                var response = string.Empty;
                props = ea.BasicProperties;
                replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                var json = JsonConvert.DeserializeObject<DataMessage>(message);
                sharepoint.props = props;
                if (string.IsNullOrEmpty(json.Route))
                {
                    this.Send("not found route.");
                    return;
                }

                sharepoint.message = json;
                // var result = Routing.Handle(json.Route.Split('/').ToArray());
                this.Send("complete");
            }
            catch (Exception e)
            {
                Console.WriteLine(" [.] " + e.Message);
                this.Send(e.Message);
            }
        }

        public void Send(string message = "", string exchange = "", bool kick = false)
        {
            // var response = JsonConvert.SerializeObject(message);
            var responseBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: exchange,
                routingKey: sharepoint.props.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes
            );
            channel.BasicAck(
                deliveryTag: args.DeliveryTag,
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
            factory = new ConnectionFactory() {HostName = host};

            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: name,
                durable: durable,
                exclusive: exclusive,
                autoDelete: autoDelete,
                arguments: null
            );
            channel.BasicQos(0, 1, false);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: name, autoAck: false, consumer: consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");
            consumer.Received += OnMessage;
        }

        public RpcServer(string host = "localhost", string name = "test")
        {
            this.host = host;
            this.name = name;
            sharepoint.server = this;
        }
    }
}