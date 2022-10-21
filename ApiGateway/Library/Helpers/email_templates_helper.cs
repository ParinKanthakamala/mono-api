using System;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Models;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class email_templates_helper
    {
        public static dynamic prepare_mail_preview_data(this object source, string template,
            object customer_id_or_email, List<string> mailClassParams = default(List<string>))
        {
            var email = "";
            if (Int32.TryParse(Convert.ToString(customer_id_or_email), out var result))
            {
                var clients_model = new ClientsModel();
                var contact = clients_model.GetContact(source.get_primary_contact_user_id(result));
                if (contact != null)
                {
                    email = contact.Email;
                }
            }
            else
            {
                email = Convert.ToString(customer_id_or_email);
            }

            using (var db = new DBContext())
            {
                var template_result =
                    db.EmailTemplates.FirstOrDefault(table => table.Slug == "slug" && table.Language == "english");
                if (template_result == null)
                {
                    return null;
                }
            }

            return new
            {
            };
        }

        public static dynamic parse_email_template(this object source, string template,
            List<string> merge_fields = default(List<string>))
        {
            template = source.parse_email_template_merge_fields(template, merge_fields);
            return hooks().ApplyFilters("email_template_parsed", new {template = template});
        }

        public static string parse_email_template_merge_fields(this object source, string template,
            List<string> merge_fields)
        {
            return "";
        }

        public static object send_mail_template(this object source, params string[] args)
        {
            return null;
        }

        public static void mail_template(this object source, string className)

        {
        }

        public static void get_mail_template_path(string className, ref object @params)

        {
        }

        public static int create_email_template(this object source, string subject, string message, string type,
            string name, string slug, int active = 1)
        {
            var email = new EmailTemplates()
            {
                Subject = subject,
                Message = message,
                Type = type,
                Name = name,
                Slug = slug,
                Language = "english",
                Active = active,
                Plaintext = 0,
            };
            var email_model = new EmailsModel();
            return email_model.AddTemplate(email);
        }
    }
}