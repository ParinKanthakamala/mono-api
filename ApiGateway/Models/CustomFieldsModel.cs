using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System.Collections.Generic;

namespace ApiGateway.Models
{
    public class CustomFieldsModel : MyModel
    {
        private List<string> pdf_fields = new List<string>() { "estimate", "invoice", "credit_note", "items" };

        private List<string> client_portal_fields = new List<string>()
        {
            "customers", "estimate", "invoice", "proposal", "contracts",
            "tasks", "projects", "contacts", "tickets",
            "company", "credit_note"
        };

        private List<string> client_editable_fields = new List<string>() { "customers", "contacts", "tasks" };

        public object Get(int id = 0)
        {
            if (id > 0)
            {
                return null;
            }

            return null;
        }

        public bool Add(CustomFields data)
        {
            return false;
        }

        public bool Update(int id, dynamic data)
        {
            var original_field = this.Get(id);

            if (data["fieldto"] == "company")
            {
                data["show_on_pdf"] = 1;
                data["show_on_client_portal"] = 1;
                data["show_on_table"] = 1;
                data["only_admin"] = 0;
                data["disalow_client_to_edit"] = 0;
            }
            else if (data["fieldto"] == "items")
            {
                data["show_on_pdf"] = 1;
                data["show_on_client_portal"] = 1;
                data["show_on_table"] = 1;
                data["only_admin"] = 0;
                data["disalow_client_to_edit"] = 0;
            }

            int affected_rows = 0;
            if (affected_rows > 0)
            {
                if (data["type"] == "checkbox" || data["type"] == "select" || data["type"] == "multiselect")
                {
                }

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            int affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Custom Field Deleted [" + id + "]");
                return true;
            }

            return false;
        }

        public void ChangeCustomFieldStatus(int id, string status)
        {
        }

        public List<string> GetPdfAllowedFields()
        {
            return this.pdf_fields;
        }

        public List<string> GetClientPortalAllowedFields()
        {
            return this.client_portal_fields;
        }

        public List<string> GetClientEditableFields()
        {
            return this.client_editable_fields;
        }
    }
}