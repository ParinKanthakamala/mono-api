using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System.Collections.Generic;
using System.Linq;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class ClientGroupsModel : MyModel
    {
        public int Add(CustomersGroups data)
        {
            using (var db = new DBContext())
            {
                db.Add(data);
                db.SaveChanges();
                if (data.CustomersGroupId > 0)
                {
                    this.log_activity("New Customer Group Created [ID : " + data.CustomersGroupId + ", Name : " + data.Name + "]");
                    return data.CustomersGroupId;
                }
            }

            return 0;
        }

        public CustomerGroups GetCustomerGroups(int? id)
        {
            using (var db = new DBContext())
            {
                return db.CustomerGroups.FirstOrDefault(table => table.CustomerId == id);
            }
        }

        public List<CustomerGroups> GetCustomerGroups()
        {
            using (var db = new DBContext())
            {
                return db.CustomerGroups.ToList();
            }
        }

        public List<CustomersGroups> GetGroups(int id = 0)
        {
            using (var db = new DBContext())
            {
                return db.CustomersGroups.Where(table => table.CustomersGroupId == id).OrderBy(table => table.Name).ToList();
            }
        }

        public bool Edit(CustomersGroups customerGroups)
        {
            using (var db = new DBContext())
            {
                int affected = 0;
                var entry = db.CustomersGroups.FirstOrDefault(table => table.CustomersGroupId == customerGroups.CustomersGroupId);
                db.Entry(entry).CurrentValues.SetValues(customerGroups);
                affected = db.SaveChanges();
                return (affected > 0);
            }
        }

        public bool Delete(int? id)
        {
            using (var db = new DBContext())
            {
                var entry = db.CustomerGroups.FirstOrDefault(table => table.GroupId == id);
                if (entry != null)
                {
                    db.Remove(entry);
                    int affected = db.SaveChanges();
                    if (affected > 0)
                    {
                        this.hooks().DoAction("customer_group_deleted", id);
                        this.log_activity("Customer Group Deleted [ID:" + id + "]");
                        return true;
                    }
                }
            }

            return false;
        }

        public bool SyncCustomerGroups(int id, List<int> groups_in = default(List<int>))
        {
            if (groups_in == default(List<int>)) groups_in.Clear();
            int affectedRows = 0;
            var customer_groups = this.GetCustomerGroups(id);

            return (affectedRows > 0);
        }
    }

    public static class ClientGroupsModelExtension
    {
        private static ClientGroupsModel _instance;

        public static ClientGroupsModel client_groups_model(this object source)
        {
            return _instance ??= new ClientGroupsModel();
        }
    }
}