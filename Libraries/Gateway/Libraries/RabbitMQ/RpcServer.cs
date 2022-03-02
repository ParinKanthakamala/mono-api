using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using Gateway.Libraries.Common;
using Molecular.Routing;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RestSharp;

namespace Gateway.Libraries.RabbitMQ
{
    public class RpcServer
    {
        private readonly string host;
        private readonly string name;
        private BasicDeliverEventArgs args;
        private IModel channel;
        private IConnection connection;
        private EventingBasicConsumer consumer;
        private ConnectionFactory factory;
        private readonly Sharepoint sharepoint = Sharepoint.sharepoint;

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

        private IBasicProperties props { get; set; }
        public IBasicProperties replyProps { get; set; }

        private void OnMessage(object sender, BasicDeliverEventArgs ea)
        {
            Console.WriteLine(" [x] Get message");
            var response = string.Empty;
            var body = ea.Body.ToArray();
            props = ea.BasicProperties;
            replyProps = channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;
            Console.WriteLine("message from : " + props.CorrelationId);

            try
            {
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("message is : " + message);
                var json = JsonConvert.DeserializeObject<DataMessage>(message);
                json.From = props.ReplyTo;
                var parts = json.Route.Split('/').ToList();
                var result = Routing.Handle(parts.ToArray());
                if (!result.Ok) return;
                // Console.WriteLine("result is : ");
                // Console.WriteLine(result.Value);
                response = Convert.ToString(result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(" [.] " + e.Message);
                response = e.Message;
            }
            finally
            {
                if (response != null) Send(props.CorrelationId, response);
            }
        }


        // public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        // {
        //     var client = new RestClient();
        // client.BaseUrl = BaseUrl;
        // client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
        // request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment);
        // IRestResponse<T> response = await client.ExecuteAsync<T>(request);
        // return response.Data;
        // }

        public ExpandoObject Queues()
        {
            var client = new RestClient("http://guest:guest@localhost:15672/api/queues");
            var request = new RestRequest("/", Method.GET)
            {
                AlwaysMultipartFormData = true
            };
            dynamic response = client.ExecuteAsync<ExpandoObject>(request);
            Console.WriteLine(response.Content);
            return response;
        }


        public void Send(string to, string message = "", string exchange = "")
        {
            try
            {
                // var response = JsonConvert.SerializeObject(message);
                Console.WriteLine("send message to : ");
                Console.WriteLine(message);
                Console.WriteLine(to);
                var responseBytes = Encoding.UTF8.GetBytes(message);
                // this.channel.BasicPublish(exchange, to, this.replyProps, responseBytes);

                channel.BasicPublish(
                    exchange,
                    to,
                    props,
                    responseBytes
                );
                channel.BasicAck(
                    args.DeliveryTag,
                    false
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Start(dynamic arguments = default(ExpandoObject)
        )
        {
            Console.WriteLine(host);
            factory = new ConnectionFactory {HostName = host};

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            var appsettings = this.appsettings();
            var options = appsettings.RabbitOptions.Options;
            channel.QueueDeclare(
                name,
                options.Durable,
                options.Exclusive,
                options.AutoDelete,
                null
            );
            // this.channel.BasicQos(0, 1, false);
            channel.BasicQos(options.PrefetchSize, options.PrefetchCount, options.Global);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(name, false, consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");
            consumer.Received += OnMessage;
        }
    }
}