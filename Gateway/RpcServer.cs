#nullable enable
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
        private EventingBasicConsumer consumer;
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        private BasicDeliverEventArgs args ;
        private IBasicProperties props;
        private IBasicProperties replyProps;

        private void OnMessage(object? sender, BasicDeliverEventArgs ea)
        {
            this.args = ea;
            string response = string.Empty;
            this.props = ea.BasicProperties;
            this.replyProps = channel.CreateBasicProperties();
            this.replyProps.CorrelationId = props.CorrelationId;

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
                response = string.Empty;
            }
            finally
            {
                this.Send(response);

                // var responseBytes = Encoding.UTF8.GetBytes(response);
                // channel.BasicPublish(
                //     exchange: "",
                //     routingKey: props.ReplyTo,
                //     basicProperties: replyProps,
                //     body: responseBytes
                // );
                // channel.BasicAck(
                //     deliveryTag: ea.DeliveryTag,
                //     multiple: false
                // );
            }
        }


        public void Send(string message, string exchange = "")
        {
            // var response = JsonConvert.SerializeObject(message);
            var responseBytes = Encoding.UTF8.GetBytes(message);
            this.channel.BasicPublish(
                exchange: exchange,
                routingKey: props.ReplyTo,
                basicProperties: replyProps,
                body: responseBytes
            );
            this.channel.BasicAck(
                deliveryTag: this.args.DeliveryTag,
                multiple: false
            );
        }


        public void Start()
        {
            this.factory = new ConnectionFactory() {HostName = this.host};
            // this.factory.Uri = new Uri("amqp://user:pass@hostName:port/vhost");
            // "guest"/"guest" by default, limited to localhost connections
            // this.factory.UserName = user;
            // this.factory.Password = pass;
            // this.factory.VirtualHost = vhost;
            // this.factory.HostName = hostName;

            this.connection = this.factory.CreateConnection();
            this.channel = connection.CreateModel();

            this.channel.QueueDeclare(
                queue: this.name,
                durable: false,
                exclusive: false,
                autoDelete: true,
                arguments: null
            );
            this.channel.BasicQos(0, 1, false);
            this.consumer = new EventingBasicConsumer(channel);
            this.channel.BasicConsume(queue: this.name, autoAck: false, consumer: consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");

            this.consumer.Received += this.OnMessage;

            // this.consumer.Received += (model, ea) =>
            // {
            //    
            // };
        }


        public RpcServer(string host = "localhost", string name = "test")
        {
            this.host = host;
            this.name = name;
        }
    }
}