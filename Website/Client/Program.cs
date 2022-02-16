using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using Append.Blazor.Notifications;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tools.Label;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            
            /// info : my custom
            builder.Services.AddBlazorContextMenu();

            // builder.Services.AddScoped<LeftPanelService>();
            builder.Services.AddLanguageContainer<EmbeddedResourceKeysProvider>(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddNotifications(); // maxx : system notification
            builder.Services.AddBlazoredModal(); // maxx : float modal
            builder.Services.AddBlazoredToast(); // maxx : toast 
            // 
            // builder.Services.AddRazorPages();
            // builder.Services.AddServerSideBlazor();
            // builder.Services.AddSingleton<WeatherForecastService>();
            await builder.Build().RunAsync();
        }
    }
}