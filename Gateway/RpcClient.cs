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
        private IConnection _connection;
        private IModel _channel;
        private string _replyQueueName;
        private EventingBasicConsumer _consumer;

        private ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper =
            new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public RpcClient()
        {
            var server_ip = "1.1.1.84";
            //var factory = new ConnectionFactory() {HostName = "localhost"};
            var factory = new ConnectionFactory() {HostName = server_ip};
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            // _replyQueueName = _channel.QueueDeclare().QueueName;
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

        public Task<string> CallAsync(DataMessage message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var props = _channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = _replyQueueName;
            var messageBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            var tcs = new TaskCompletionSource<string>();
            _callbackMapper.TryAdd(correlationId, tcs);

            _channel.BasicPublish(
                exchange: "",
                routingKey: message.To,
                basicProperties: props,
                body: messageBytes
            );

            _channel.BasicConsume(
                consumer: _consumer,
                queue: _replyQueueName,
                autoAck: true
            );

            cancellationToken.Register(() => _callbackMapper.TryRemove(correlationId, out var tmp));
            return tcs.Task;
        }

        public void Close()
        {
            try
            {
                // while (_channel.IsOpen)
                // {
                _channel.Close();
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}