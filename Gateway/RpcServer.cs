using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using Molecular.Routing;
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

        public void Write(string queueName, string message = "", string exchange = "")
        {
            var responseBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: exchange,
                routingKey: queueName,
                basicProperties: replyProps,
                body: responseBytes
            );
            channel.BasicAck(
                deliveryTag: args.DeliveryTag,
                multiple: false
            );
        }


        private void OnMessage(object sender, BasicDeliverEventArgs ea)
        {
            Console.WriteLine(" [x] Get message");
            var response = string.Empty;
            var body = ea.Body.ToArray();
            var props = ea.BasicProperties;
            var replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;
            sharepoint.channel = channel;
            try
            {
                var message = Encoding.UTF8.GetString(body);

                var json = JsonConvert.DeserializeObject<DataMessage>(message);
                json.From = props.ReplyTo;
                // var parts = ("test/message/maxx").Split('/').ToList();
                var parts = json.Route.Split('/').ToList();
                var result = (RoutingResult) Routing.Handle(parts.ToArray());
                if (result.Ok)
                {
                    Console.WriteLine("result ok");
                    // Console.WriteLine(result.Value);
                    response = Convert.ToString(result.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" [.] " + e.Message);
                response = "";
            }
            finally
            {
                Console.WriteLine(props.ReplyTo);
                var responseBytes = Encoding.UTF8.GetBytes(response);
                channel.BasicPublish(
                    exchange: "",
                    routingKey: props.ReplyTo,
                    basicProperties: replyProps,
                    body: responseBytes
                );
                channel.BasicAck(
                    deliveryTag: ea.DeliveryTag,
                    multiple: false
                );
            }
        }

        public void Send(string message = "", string exchange = "", bool kick = false)
        {
            // var response = JsonConvert.SerializeObject(message);
            Console.WriteLine("reply to : ");
            Console.WriteLine(sharepoint.props.ReplyTo);
            var responseBytes = Encoding.UTF8.GetBytes(message);
            // channel.BasicPublish(exchange, sharepoint.props.ReplyTo, null, responseBytes);
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

        public RpcServer(
            string name = "test",
            string host = "localhost",
            string account = "guest",
            string password = "guest"
        )
        {
            // this.host = "amqp://" + account + ":" + password + "@" + host;
            this.host = host;
            this.name = name;
            sharepoint.server = this;
        }
    }
}