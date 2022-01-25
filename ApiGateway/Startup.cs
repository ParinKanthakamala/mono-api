using ApiGateway.Library.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApplication", Version = "v1"});
            });
            services.AddRabbit(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));
            }


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            // app.Use(async (context, next) =>
            // {
            //     if (context.Request.Path.Value == "/favicon.ico")
            //     {
            //         // Favicon request, return 404
            //         context.Response.StatusCode = StatusCodes.Status404NotFound;
            //         return;
            //     }
            //
            //     // No favicon, call next middleware
            //     await next.Invoke();
            // });
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapHub<DataHub>("/api/gateway");
                // endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    "areas",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                // endpoints.MapHub<DataHub>("/api/gateway");
                // endpoints.MapHub<ChatHub>("/chat");
            });
            // app.UseEndpoints(endpoints =>
            // {
            // endpoints.MapControllerRoute(
            //     "default",
            //     "{controller=Home}/{action=Index}/{id?}");

            //     endpoints.MapHub<DataHub>("/api/gateway");
            //     endpoints.MapHub<ChatHub>("/chat");
            // });
        }
    }
}