using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Gateway.Libraries.RabbitMQ
{
    public class RpcClient
    {
        private ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper = new();
        private List<string> correlations = new List<string>();
        public RabbitOptions rabbitOptions { get; set; }

        private static RpcClient _instance = null;
        private ConnectionFactory factory;
        public static RpcClient rpc_client => _instance ??= new RpcClient();

        private RpcClient()
        {
        }

        public string CallAsync(string message)
        {
            try
            {
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                var replyQueueName = channel.QueueDeclare().QueueName;
                var consumer = new EventingBasicConsumer(channel);
                var cancellationToken = new CancellationToken();
                var correlationId = Guid.NewGuid().ToString();
                this.correlations.Add(correlationId);
                consumer.Received += (model, ea) =>
                {
                    Console.WriteLine("income message");
                    if (!_callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    {
                        return;
                    }
                    else if (correlations.Contains(ea.BasicProperties.CorrelationId))
                    {
                        var response = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine(response);
                        tcs.TrySetResult(response);
                        connection.Close();
                    }

                    Console.WriteLine("process message complete.");
                };

                var props = channel.CreateBasicProperties();

                props.CorrelationId = correlationId;
                props.ReplyTo = replyQueueName;
                var messageBytes = Encoding.UTF8.GetBytes(message);
                var tcs = new TaskCompletionSource<string>();
                _callbackMapper.TryAdd(correlationId, tcs);

                channel.BasicPublish(
                    exchange: this.rabbitOptions.Options.Exchange,
                    routingKey: replyQueueName,
                    basicProperties: props,
                    body: messageBytes
                );

                channel.BasicConsume(
                    consumer: consumer,
                    queue: replyQueueName,
                    autoAck: false
                );

                cancellationToken.Register(() => _callbackMapper.TryRemove(correlationId, out var tmp));
                return tcs.Task.Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public RpcClient SetConfig(RabbitOptions rabbitOptions)
        {
            this.rabbitOptions = rabbitOptions;
            Console.WriteLine(rabbitOptions.Connection.HostName);
            this.factory = new ConnectionFactory()
            {
                HostName = rabbitOptions.Connection.HostName,
                UserName = rabbitOptions.Connection.UserName,
                Password = rabbitOptions.Connection.Password,
                Port = rabbitOptions.Connection.Port,
                VirtualHost = rabbitOptions.Connection.VHost,
            };
            return this;
        }
    }
}