using Microsoft.AspNetCore.Builder;

namespace Server.Middlewares
{
    public static class BaseMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BaseMiddleware>();
        }
    }
}