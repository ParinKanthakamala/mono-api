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

namespace Users
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var asService = !(Debugger.IsAttached || args.ToList().Contains("--console"));
            Console.WriteLine("asService : " + asService);
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    //
                    services.AddHostedService<Service>();
                });
            //
            builder.UseEnvironment(asService ? EnvironmentName.Production : EnvironmentName.Development);
            if (asService) await builder.RunAsServiceAsync();
            else await builder.RunConsoleAsync();
        }
    }
}