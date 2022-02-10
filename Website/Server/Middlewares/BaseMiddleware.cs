using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Server.Middlewares
{
    public class BaseMiddleware
    {
        private readonly RequestDelegate _next;

        public BaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            Console.WriteLine(context.Request.Path);
            return _next(context);
        }
    }
}