using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System.Collections.Generic;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class InvoiceItemsModel : MyModel
    {
        public void Get(int id = 0)
        {
        }

        public void GetGrouped()
        {
        }

        public int Add(Items data)
        {
            return 0;
        }

        public void Edit(dynamic data)
        {
            int itemid = data.item_id;


        }

        public void search(string q)
        {
        }

        public bool Delete(int id)
        {
            int affected_rows = 0;

            if (affected_rows > 0)
            {
                this.log_activity("Invoice Item Deleted [ID: " + id + "]");
                this.hooks().DoAction("item_deleted", id);

                return true;
            }

            return false;
        }

        public List<ItemsGroups> GetGroups()
        {
            return null;
        }

        public int AddGroup(ItemsGroups data)
        {
            int insert_id = 0;
            this.log_activity("Items Group Created [Name: " + data.Name + "]");
            return insert_id;
        }

        public bool EditGroup(int id, dynamic data)
        {
            int affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteGroup(int id)
        {
            var group = new ItemsGroups();
            if (group != default(ItemsGroups))
            {
                this.log_activity("Item Group Deleted [Name: " + group.Name + "]");
                return true;
            }

            return false;
        }
    }
}