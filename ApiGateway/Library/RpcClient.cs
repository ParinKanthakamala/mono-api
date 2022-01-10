using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ApiGateway.Library
{
    class RpcClient
    {
        private const string QUEUE_NAME = "rpc_queue";

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _replyQueueName;
        private readonly EventingBasicConsumer _consumer;

        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper =
            new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public RpcClient()
        {
            var server_ip = "159.138.230.118";
            //var factory = new ConnectionFactory() {HostName = "localhost"};
            var factory = new ConnectionFactory() {HostName = server_ip};

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _replyQueueName = _channel.QueueDeclare().QueueName;
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += (model, ea) =>
            {
                if (!_callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                {
                    return;
                }

                var response = Encoding.UTF8.GetString(ea.Body.ToArray());
                tcs.TrySetResult(response);
            };
        }

        public Task<string> CallAsync(string message, CancellationToken cancellationToken = default(CancellationToken))
        {
            var props = _channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = _replyQueueName;
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var tcs = new TaskCompletionSource<string>();
            _callbackMapper.TryAdd(correlationId, tcs);

            _channel.BasicPublish(
                exchange: "",
                routingKey: QUEUE_NAME,
                basicProperties: props,
                body: messageBytes
            );

            _channel.BasicConsume(
                consumer: _consumer,
                queue: _replyQueueName,
                autoAck: false
            );

            cancellationToken.Register(() => _callbackMapper.TryRemove(correlationId, out var tmp));
            return tcs.Task;
        }

        public void Close()
        {
            try
            {
                _connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}