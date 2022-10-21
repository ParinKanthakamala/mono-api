using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;

namespace ApiGateway.Models
{
    public class GdprModel : MyModel
    {
        public int add_request(GdprRequests data)
        {
            return 0;
        }

        public bool add_removal_request(GdprRequests data)
        {
            data.RequestType = "account_removal";
            return this.add_request(data) > 0;
        }

        public bool Update(int id, dynamic data)
        {
            return false;
        }

        public List<GdprRequests> get_removal_requests()
        {
            return null;
        }

        public List<ConsentPurposes> get_consent_purposes(int user_id = 0, string @for = "")
        {
            var db = new DBContext();
            var purposes = db.ConsentPurposes.OrderByDescending(table => table.Name).ToList();

            return purposes;
        }

        public void get_consent_purpose(int id)
        {
        }

        public int add_consent_purpose(ConsentPurposes data)
        {
            // data.DateCreated = SharePoint.Now;
            return 0;
        }

        public bool update_consent_purpose(int id, dynamic data)
        {
            return false;
        }

        public bool delete_consent_purpose(int id)
        {
            return false;
        }

        public int add_consent(Consents data)
        {
            return 0;
        }

        public List<dynamic> get_consents(dynamic where = default(ExpandoObject))
        {
            return null;
        }
    }

    public static class GdprModelExtension
    {
        private static GdprModel _instance = null;

        public static GdprModel gdpr_model(this object source)
        {
            return _instance ??= new GdprModel();
        }
    }
}