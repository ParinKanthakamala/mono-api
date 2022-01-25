using Gateway.Libraries.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Gateway.Libraries.RabbitMQ.RpcClient;

namespace ApiGateway.Library.RabbitMQ
{
    public static class RabbitServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            var appsettings = services.appsettings();
            rpc_client.SetConfig(appsettings.RabbitOptions);

            return services;
        }
    }
}