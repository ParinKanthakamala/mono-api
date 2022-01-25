using System;
using System.Threading;
using System.Threading.Tasks;
using Gateway;
using Gateway.Libraries.Common;
using Gateway.Libraries.RabbitMQ;
using Microsoft.Extensions.Hosting;

namespace Users
{
    public class Service : IHostedService, IDisposable
    {
        public Sharepoint sharepoint = Sharepoint.sharepoint;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var text = $"{DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")}, Testing write." + Environment.NewLine;
            // File.WriteAllText(@"./Service.Write.txt", text);
            Console.WriteLine($"[{nameof(Service)}] has been started.....");
            var appsettings = this.appsettings();
            Console.WriteLine(appsettings.RabbitOptions.Name);
            var rabbitmq = appsettings.RabbitOptions;
            var server = new RpcServer(host: rabbitmq.Connection.HostName, name: rabbitmq.Name);
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