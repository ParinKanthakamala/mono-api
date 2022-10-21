using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using ApiGateway.Core;
using ApiGateway.Entities;

namespace ApiGateway.Models
{
    public class SpamFiltersModel : MyModel
    {
        public List<SpamFilters> Get(string rel_type)
        {
            return null;
        }

        public int Add(dynamic data, string type)
        {
            data["rel_type"] = type;
            var insert_id = 0;

            return insert_id > 0 ? insert_id : 0;
        }

        public bool Edit(dynamic data)
        {
            return false;
        }

        public bool Delete(int id, string type)
        {
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Spam Filter Deleted");
                return true;
            }

            return false;
        }

        public string Check(string email, string subject, string message, string rel_type)
        {
            string status = null;
            var spam_filters = this.Get(rel_type);

            foreach (var filter in spam_filters)
            {
            }

            return status;
        }
    }
    public static class SpamFiltersModelExtension
    {
        private static SpamFiltersModel _instance = null;
        public static SpamFiltersModel spam_filters_model(this object source)
        {
            return _instance ??= new SpamFiltersModel();
        }
    }
}