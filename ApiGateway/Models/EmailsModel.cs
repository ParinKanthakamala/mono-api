using Entities.Models;
using JamfahCrm.Controllers.Core;
using System.Collections.Generic;
using System.Dynamic;

namespace ApiGateway.Models
{
    public class EmailsModel : MyModel
    {
        private List<object> attachment = new List<object>();

        public EmailTemplates Get(dynamic where = default(ExpandoObject), string result_type = "result_array")
        {
            return null;
        }

        public EmailTemplates get_email_template_by_id(int id)
        {
            return null;
        }

        public int AddTemplate(EmailTemplates data)
        {
            using (var db = new DBContext())
            {
                db.EmailTemplates.Add(data);
                return (data.EmaiLtemplateId > 0) ? data.EmaiLtemplateId : 0;
            }
        }

        public bool Update(EmailTemplates data)
        {
           

            return false;
        }

        public bool MarkAs(string slug, bool enabled)
        {
            return false;
        }

        public bool MarkAsByType(string type, bool enabled)
        {
            int affected_rows = 0;
            return (affected_rows > 0);
        }

        public bool SendSimpleEmail(string email, string subject, string message)
        {
            return false;
        }

        public bool SendEmailTemplate(string template_slug, string email, List<string> merge_fields,
            string ticketid = "", object cc = null)
        {
            return false;
        }

        public void AddAttachment(string attachment)
        {
            this.attachment.Add(attachment);
        }

        private void clear_attachments()
        {
            this.attachment.Clear();
        }

        public EmailsModel() : base()
        {
        }
    }
}