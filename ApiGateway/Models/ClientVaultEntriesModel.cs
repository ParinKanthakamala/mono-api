using Entities.Models;
using JamfahCrm.Controllers.Core;
using System;
using System.Dynamic;

namespace ApiGateway.Models
{
    public class ClientVaultEntriesModel : MyModel
    {
        public Vault Get(int id)
        {
            return null;
        }

        public Vault GetByCustomerId(int customer_id, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public int Create(int customer_id, Vault data)
        {
            data.DateCreated = DateTime.Now;
            data.CustomerId = customer_id;
            data.ShareInProjects = data.ShareInProjects == true ? true : false;
            return 0;
        }

        public bool Update(int id, Vault data)
        {
            Vault vault = this.Get(id);
            string last_updated_from = data.LastUpdatedFrom;
            data.ShareInProjects = data.ShareInProjects;
            int affected = 0;

            if (affected > 0)
            {
                vault = new Vault();
                vault.LastUpdated = DateTime.Now;
                vault.LastUpdatedFrom = last_updated_from;

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            Vault vault = this.Get(id);
            int affected = 0;

            if (affected > 0)
            {
                return true;
            }

            return false;
        }
    }
}