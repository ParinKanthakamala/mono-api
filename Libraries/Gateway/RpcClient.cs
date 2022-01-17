using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Gateway
{
    public class RpcClient
    {
        private IConnection connection;
        private IModel channel;
        private string replyQueueName;
        private EventingBasicConsumer consumer;

        private ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper =
            new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public RpcClient(string host = "localhost")
        {
            //var factory = new ConnectionFactory() {HostName = "localhost"};
            var factory = new ConnectionFactory() {HostName = host};
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new EventingBasicConsumer(channel);
        }

        public string CallAsync(DataMessage message,
            CancellationToken cancellationToken = default(CancellationToken)
            // EventHandler<BasicDeliverEventArgs> callback = default(EventHandler<BasicDeliverEventArgs>)
        )
        {
            try
            {
                consumer.Received += (model, ea) =>
                {
                    if (!_callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    {
                        return;
                    }

                    var response = Encoding.UTF8.GetString(ea.Body.ToArray());
                    tcs.TrySetResult(response);
                };


                var props = channel.CreateBasicProperties();
                var correlationId = Guid.NewGuid().ToString();
                props.CorrelationId = correlationId;
                message.From = props.ReplyTo = replyQueueName;
                var messageBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                var tcs = new TaskCompletionSource<string>();
                _callbackMapper.TryAdd(correlationId, tcs);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: message.To,
                    basicProperties: props,
                    body: messageBytes
                );

                channel.BasicConsume(
                    consumer: consumer,
                    queue: replyQueueName,
                    autoAck: false
                );

                cancellationToken.Register(() =>
                {
                    //
                    _callbackMapper.TryRemove(correlationId, out var tmp);
                });
                return tcs.Task.Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Close()
        {
            try
            {
                // channel.Close();
                // connection.Close();
                // channel?.Abort();
                // channel?.Close();
                // connection?.Abort();
                connection?.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}