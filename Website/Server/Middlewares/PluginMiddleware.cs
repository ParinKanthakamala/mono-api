using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.Entities;

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