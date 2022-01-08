using System.Threading.Tasks;

namespace ApiGateway.Hubs.Connection
{
    public class DataConnection : IDataConnection
    {
        public string User { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public string Method { get; set; }
        public string Route { get; set; }
        public string Message { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public object Body { get; set; }
        public object Query { get; set; }

        public string Token { get; set; }

        public Task ReceiveMessage(DataConnection message)
        {
            throw new System.NotImplementedException();
        }
    }
}