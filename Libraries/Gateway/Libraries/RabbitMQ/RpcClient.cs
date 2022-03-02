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
        private static RpcClient _instance;
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper = new();
        private readonly List<string> correlations = new();
        private ConnectionFactory factory;

        private RpcClient()
        {
        }

        public RabbitOptions rabbitOptions { get; set; }
        public static RpcClient rpc_client => _instance ??= new RpcClient();

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
                correlations.Add(correlationId);
                consumer.Received += (model, ea) =>
                {
                    Console.WriteLine("income message");
                    if (!_callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    {
                        return;
                    }

                    if (correlations.Contains(ea.BasicProperties.CorrelationId))
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
                    rabbitOptions.Options.Exchange,
                    replyQueueName,
                    props,
                    messageBytes
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
            factory = new ConnectionFactory
            {
                HostName = rabbitOptions.Connection.HostName,
                UserName = rabbitOptions.Connection.UserName,
                Password = rabbitOptions.Connection.Password,
                Port = rabbitOptions.Connection.Port,
                VirtualHost = rabbitOptions.Connection.VHost
            };
            return this;
        }
    }
}