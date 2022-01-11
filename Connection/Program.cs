using System;
using Gateway;

namespace Connection
{
    class Program
    {
        public static void Main()
        {
            var server = new RpcServer(host: "host.docker.internal", name: "connection");
            server.Start();
            // var factory = new ConnectionFactory() {HostName = "host.docker.internal"};
            // using var connection = factory.CreateConnection();
            // using var channel = connection.CreateModel();
            // channel.QueueDeclare(
            //     queue: "rpc_queue",
            //     durable: false,
            //     exclusive: false,
            //     autoDelete: true,
            //     arguments: null
            // );
            // channel.BasicQos(0, 1, false);
            // var consumer = new EventingBasicConsumer(channel);
            // channel.BasicConsume(queue: "rpc_queue", autoAck: false, consumer: consumer);
            // Console.WriteLine(" [x] Awaiting RPC requests");
            //
            // consumer.Received += (model, ea) =>
            // {
            //     string response = null;
            //     var props = ea.BasicProperties;
            //     var replyProps = channel.CreateBasicProperties();
            //     replyProps.CorrelationId = props.CorrelationId;
            //
            //     try
            //     {
            //         var message = Encoding.UTF8.GetString(ea.Body.ToArray());
            //         var json = JsonConvert.DeserializeObject<DataMessage>(message);
            //         json.Message = "message from connection";
            //         response = JsonConvert.SerializeObject(json);
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(" [.] " + e.Message);
            //         response = "";
            //     }
            //     finally
            //     {
            //         var responseBytes = Encoding.UTF8.GetBytes(response);
            //         channel.BasicPublish(
            //             exchange: "",
            //             routingKey: props.ReplyTo,
            //             basicProperties: replyProps,
            //             body: responseBytes
            //         );
            //         channel.BasicAck(
            //             deliveryTag: ea.DeliveryTag,
            //             multiple: false
            //         );
            //     }
            // };

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}