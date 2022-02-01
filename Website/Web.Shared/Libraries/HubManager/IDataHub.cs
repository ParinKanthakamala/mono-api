using System.Threading.Tasks;

namespace Web.Shared.Libraries.HubManager
{
    public interface IDataHub
    {
        Task Added(DataSummary survey);
        Task Updated(Data survey);
    }
}