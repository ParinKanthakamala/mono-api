using System;
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

        public void start()
        {
            var factory = new ConnectionFactory() {HostName = this.host};
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: this.name,
                durable: false,
                exclusive: false,
                autoDelete: true,
                arguments: null
            );
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: this.name, autoAck: false, consumer: consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");

            consumer.Received += (model, ea) =>
            {
                string response = null;
                var props = ea.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {
                    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var json = JsonConvert.DeserializeObject<DataMessage>(message);
                    json.Message = "message from connection";
                    response = JsonConvert.SerializeObject(json);
                }
                catch (Exception e)
                {
                    Console.WriteLine(" [.] " + e.Message);
                    response = "";
                }
                finally
                {
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
            };
        }

        public RpcServer(string host, string name)
        {
            this.host = host;
            this.name = name;
        }
    }
}