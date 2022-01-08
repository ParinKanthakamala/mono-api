using System.Threading.Tasks;

namespace ApiGateway.Hubs.Connection
{
    // event message for client
    public interface IDataConnection
    {
        Task ReceiveMessage(DataConnection message);
    }
}