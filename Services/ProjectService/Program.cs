using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProjectService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Run with console or service
            var asService = !(Debugger.IsAttached || args.ToList().Contains("--console"));
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) => { services.AddHostedService<Service>(); });
            //
            builder.UseEnvironment(asService ? EnvironmentName.Production : EnvironmentName.Development);
            if (asService) await builder.RunAsServiceAsync();
            else await builder.RunConsoleAsync();
        }
    }
}