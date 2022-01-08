using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ApiGateway.Hubs
{
    public class DataHub : Hub
    {
        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}