using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Shared.Libraries.RabbitMQ
{
    public class RMQP
    {
        private readonly ConnectionFactory factory;
        private readonly string name = "not set";

        public RMQP()
        {
            var host = "amqps: //xtzqztjn:URBCuxJ2jGJrgH2s1xnE7x4Vnjh1WERe@baboon.rmq.cloudamqp.com/xtzqztjn";
            var uri = new Uri(host);
            factory = new ConnectionFactory {Uri = uri};
        }

        public void Send(string message)
        {
        }

        public void Start()
        {
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("rpc_queue", false,
                false, false, null);
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            //channel.BasicConsume(queue: "rpc_queue", autoAck: false, consumer: consumer);
            channel.BasicConsume(name, false, consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");

            consumer.Received += (model, ea) =>
            {
                string response = null;

                var body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {
                    var message = Encoding.UTF8.GetString(body);
                    var n = int.Parse(message);
                    // Console.WriteLine(" [.] fib({0})", message);
                    // response = fib(n).ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(" [.] " + e.Message);
                    response = "";
                }
                finally
                {
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    channel.BasicPublish("", props.ReplyTo, replyProps,
                        responseBytes);
                    channel.BasicAck(ea.DeliveryTag, false);
                }
            };
        }
    }
}