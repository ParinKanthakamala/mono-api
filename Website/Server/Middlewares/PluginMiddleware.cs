using System;
using System.Threading.Tasks;
using Shared.Entities;
using Microsoft.AspNetCore.Http;

namespace Server.Middlewares
{
    public class PluginMiddleware
    {
        private readonly RequestDelegate _next;
        public MyContext context = new();

        public PluginMiddleware(RequestDelegate next)
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