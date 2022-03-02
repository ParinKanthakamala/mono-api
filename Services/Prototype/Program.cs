using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Prototype
{
    internal class Program
    {
        public static void Example()
        {
            var factory = new ConnectionFactory {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("connection", false, false, false,
                    null);
                channel.BasicQos(0, 1, false);
                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("connection", false, consumer);
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
                        var json = JsonConvert.DeserializeObject<DataMessage>(message);
                        if (string.IsNullOrEmpty(json.Route))
                        {
                            Console.WriteLine("not found route");
                        }
                        else
                        {
                            var parts = json.Route.Split('/');
                            // var result = Routing.Handle(parts);
                            // var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));
                            // channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps,
                            //     body: responseBytes);
                            // channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }


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

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }


        private static async Task Main(string[] args)
        {
            // var server = new RpcServer(name: "connection", host: "localhost");
            // server.Start();
            // MainSubCommands.Example();
            // var list = new List<string>();
            // list.Add("Test");
            // list.Add("Message");
            // list.Add("maxx");
            // var result = Routing.Handle(list.ToArray());
            // Console.WriteLine(JsonConvert.SerializeObject(result));
            // Run with console or service


            var asService = !(Debugger.IsAttached || args.ToList().Contains("--console"));
            // asService = false;
            Console.WriteLine("asService : " + asService);
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                    services.AddHostedService<Service>()
                );

            builder.UseEnvironment(asService ? EnvironmentName.Production : EnvironmentName.Development);
            builder.UseEnvironment("Development");
            if (asService) await builder.RunAsServiceAsync();
            else await builder.RunConsoleAsync();

            Console.WriteLine("test message");
        }
    }
}