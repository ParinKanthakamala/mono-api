using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;

namespace ApiGateway.Models
{
    public class ContractsTypesModel : MyModel
    {
        public int Add(ContractsTypes data)
        {
            using (var db = new DBContext())
            {
                db.ContractsTypes.Add(data);
                db.SaveChanges();

                int insert_id = data.ContractsTypeId;
                if (insert_id > 0)
                {
                    this.log_activity("New Contract Type Added[" + data.Name + "]");
                    return insert_id;
                }
            }

            return 0;
        }

        public bool Update(int id, ContractsTypes data)
        {
            int affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Contract Type Updated [" + data.Name + ", ID:" + id + "]");
                return true;
            }

            return false;
        }

        public ContractsTypes Get(int id = 0)
        {
            return null;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public dynamic GetChartData()
        {
            return null;
        }

        public dynamic GetValuesChartData()
        {
            return null;
        }
    }

    public static class ContractsTypesModelExtension
    {
        private static ContractsTypesModel _instance = null;

        public static ContractsTypesModel contract_types_model(this object source)
        {
            return _instance ??= new ContractsTypesModel();
        }
    }
}