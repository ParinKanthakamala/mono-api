using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Server.Hubs.Schema;

namespace Server.Hubs
{
    public abstract class MyHub : Hub
    {
        public string jsonString;
        public HubData json => JsonConvert.DeserializeObject<HubData>(jsonString);

        public async Task Load(string jsonstring)
        {
            dynamic json = JsonConvert.DeserializeObject(jsonstring);
            var connectionId = json.connectionId;
            var data = json.data;
            var callback = json.callback;


            await Clients.Client(connectionId).SendAsync(callback, data);
        }

        public async Task Fetch(string jsonstring)
        {
            dynamic json = JsonConvert.DeserializeObject(jsonstring);
            var connectionId = json.connectionId;
            var data = json.data;
            var callback = json.callback;
            await Clients.Client(connectionId).SendAsync(callback, data);
        }
    }
}