using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ApiGateway.Models
{
    public class TaxesModel : MyModel
    {
        public List<Taxes> Get(int id = 0)
        {
            return null;
        }

        public bool Add(Taxes data)
        {
            data.Name = data.Name.Trim();
            int effected = 0;

            if (effected > 0)
            {
                return true;
            }

            return false;
        }

        public bool Edit(Taxes data)
        {
            using (var db = new DBContext())
            {
                var row_count = db.Expenses.Where(table => table.Tax == data.Id).ToList().Count;

                if (row_count > 0)
                {
                    return true;
                }

            }

            return false;
        }

        public bool Delete(int id)
        {
            if (
                this.is_reference_in_table("tax", "items", id)
            )
            {
                return true;
            }

            int affected_rows = 0;

            if (affected_rows > 0)
            {
                this.log_activity("Tax Deleted [ID: " + id + "]");
                return true;
            }

            return false;
        }
    }
}