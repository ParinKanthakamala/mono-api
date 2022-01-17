using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gateway;
using Microsoft.Extensions.Hosting;
using Molecular.Routing;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Connection
{
    public class Service : IHostedService, IDisposable
    {
        public Sharepoint sharepoint = Sharepoint.sharepoint;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var text = $"{DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")}, Testing write." + Environment.NewLine;
            // File.WriteAllText(@"./Service.Write.txt", text);
            Console.WriteLine($"[{nameof(Service)}] has been started.....");
            var server = new RpcServer(host: sharepoint.config.RabbitMQ.host, name: sharepoint.config.RabbitMQ.name);
            server.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // File.Delete(@"./Service.Write.txt");
            Console.WriteLine($"[{nameof(Service)}] has been stopped.....");
            Thread.Sleep(1000);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Console.WriteLine("Service.Dispose");
        }
    }
}