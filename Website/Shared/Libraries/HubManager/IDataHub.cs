using System.Threading.Tasks;

namespace Shared.Libraries.HubManager
{
    public interface IDataHub
    {
        Task Added(DataSummary survey);
        Task Updated(Data survey);
    }
}