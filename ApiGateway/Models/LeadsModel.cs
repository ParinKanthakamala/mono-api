using ApiGateway.Library.Helpers;
using ApiGateway.Library.Services.Utilities;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers.Staff;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class LeadsModel : MyModel
    {
        private ProposalsModel proposals_model;

        public List<Leads> GetByHash(string hash)
        {
            using (var db = new DBContext())
            {
                return db.Leads.Where(table => table.Hash == hash).ToList();
            }
        }

        public List<Leads> Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public void DoKanbanQuery(string status, string search = "", int page = 1, string sort = "", bool count = false)
        {
        }

        public int Add(Leads data)
        {
            return 0;
        }

        public bool lead_assigned_member_notification(int lead_id, int assigned = 0, bool integration = false)
        {
            if (assigned > 0)
            {
                if (integration == false)
                {
                    if (assigned == this.get_staff_user_id())
                    {
                        return false;
                    }
                }

                var name = "";
                var notification_data = new Notifications()
                {
                    Description = (integration == false) ? "not_assigned_lead_to_you" : "not_lead_assigned_from_form",
                    ToUserId = assigned,
                    Link = "#leadid=" + lead_id,
                    AdditionalData =
                        Newtonsoft.Json.JsonConvert.SerializeObject(!integration
                            ? new List<string>() {name}
                            : new List<string>() { })
                };
                if (integration)
                {
                    notification_data.FromCompany = 1;
                }

                if (this.add_notification(notification_data))
                {
                    this.pusher_trigger_notification(assigned);
                }

                var not_additional_data = new List<string>()
                {
                    this.get_staff_fullname(),
                    "<a href='" + this.admin_url("profile / " + assigned) + "' target='_blank'>" +
                    this.get_staff_fullname(assigned) + "</a>"
                };
                if (integration)
                {
                }
            }

            return false;
        }

        public bool Update(int id, Leads data)
        {
            object current_status_id = 0;
            var current_lead_data = this.Get(id).FirstOrDefault();
            var current_status = (LeadsStatus) this.get_status(current_lead_data.Status);
            if (current_status != null)
            {
                current_status_id = current_status.LeadsStatusId;
            }
            else
            {
                if (current_lead_data.Junk == 1)
                {
                }
                else if (current_lead_data.Lost)
                {
                }
                else
                {
                }

                current_status_id = 0;
            }

            var affectedRows = 0;
            return (affectedRows > 0);
        }

        public bool Delete(int id)
        {
            return false;
        }

        public bool mark_as_lost(int id)
        {
            return false;
        }

        public bool unmark_as_lost(int id)
        {
            return false;
        }

        public bool mark_as_junk(int id)
        {
            return false;
        }

        public bool unmark_as_junk(int id)
        {
            var last_lead_status = new LeadsStatus();
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.LogLeadActivity(id, "not_lead_activity_unmarked_junk");
                this.log_activity("Lead Unmarked as Junk [ID: " + id + "]");
                return true;
            }

            return false;
        }

        public List<Files> get_lead_attachments(int id = 0, string attachment_id = "", dynamic where = default)
        {
            var query = new List<Files>();
            return null;
        }

        public void AddAttachmentToDatabase(int lead_id, string attachment, bool external = false,
            bool form_activity = false)
        {
            var misc_model = new MiscModel();
            misc_model.AddAttachmentToDatabase(lead_id, "lead", attachment, external);
        }

        public bool delete_lead_attachment(int id)
        {
            var attachment = this.get_lead_attachments(0, id + "").FirstOrDefault();
            var deleted = false;
            if (attachment != null)
            {
                if (string.IsNullOrEmpty(attachment.External))
                {
                }

                var affected_rows = 0;

                if (affected_rows > 0)
                {
                    deleted = true;
                    this.log_activity("Lead Attachment Deleted [ID: " + attachment.RelId + "]");
                }
            }

            return deleted;
        }

        public object get_source(int id = 0)
        {
            return null;
        }

        public int add_source(LeadsSources data)
        {
            var insert_id = 0;
            if (insert_id > 0)
            {
                this.log_activity("New Leads Source Added [SourceID: " + insert_id + ", Name: " + data.Name + "]");
            }

            return insert_id;
        }

        public bool update_source(int id, dynamic data)
        {
            return false;
        }

        public bool delete_source(int id)
        {
            var current = this.get_source(id);
            if (this.is_reference_in_table("source", "leads", id) ||
                this.is_reference_in_table("lead_source", "leads_email_integration", id))
            {
                return true;
            }

            var affected_rows = 0;
            if (affected_rows > 0)
            {
                if (this.get_option<int>("leads_default_source") == id)
                {
                    this.update_option("leads_default_source", "");
                }

                this.log_activity("Leads Source Deleted [SourceID: " + id + "]");
                return true;
            }

            return false;
        }

        public object get_status(int id = 0, dynamic where = default(ExpandoObject))
        {
            // var statuses = app_object_cache().get("leads-all-statuses");
            // if (statuses == null)
            // {
            // }
            return null;
            // return statuses;
        }

        public int add_status(LeadsStatus data)
        {
            if (data.Color == null)
            {
                data.Color = "#757575";
                hooks().ApplyFilters("default_lead_status_color", data.Color);
            }

            using (var db = new DBContext())
            {
                if (data.StatusOrder == null)
                {
                    data.StatusOrder = db.LeadsStatus.ToList().Count + 1;
                }

                db.LeadsStatus.Add(data);
                db.SaveChanges();
            }

            var insert_id = data.LeadsStatusId;
            if (insert_id > 0)
            {
                this.log_activity("New Leads Status Added [StatusID: " + insert_id + ", Name: " + data.Name + "]");
                return insert_id;
            }

            return 0;
        }

        public bool update_status(int id, dynamic data)
        {
            return false;
        }

        public bool delete_status(int id)
        {
            var current = this.get_status(id);
            if (this.is_reference_in_table("status", "leads", id) ||
                this.is_reference_in_table("lead_status", "leads_email_integration", id))
            {
                return true;
            }

            var affected_rows = 0;
            if (affected_rows > 0)
            {
                if (this.get_option<int>("leads_default_status") == id)
                {
                    this.update_option("leads_default_status", "");
                }

                this.log_activity("Leads Status Deleted [StatusID: " + id + "]");
                return true;
            }

            return false;
        }

        public bool update_lead_status(dynamic data)
        {
            return false;
        }

        public List<LeadActivityLog> get_lead_activity_log(int id)
        {
            return null;
        }

        public bool staff_can_access_lead(int id, int staff_id = 0)
        {
            staff_id = staff_id == 0 ? this.get_staff_user_id() : staff_id;
            if (Permission.Id(staff_id, "leads", Permission.View))
            {
                return true;
            }

            return false;
        }

        public int LogLeadActivity(int id, string description, bool integration = false, string additional_data = "")
        {
            var lead_activity_log = new LeadActivityLog()
            {
                // Date = SharePoint.Now,
                Description = description,
                LeadId = id,
                UserId = this.get_staff_user_id(),
                AdditionalData = additional_data,
                FullName = this.get_staff_fullname(this.get_staff_user_id())
            };
            if (integration)
            {
                lead_activity_log.UserId = 0;
                lead_activity_log.FullName = "[CRON]";
            }

            using (var db = new DBContext())
            {
                db.LeadActivityLog.Add(lead_activity_log);
                db.SaveChanges();
                return lead_activity_log.LeadActivityLogId;
            }
        }

        public LeadsEmailIntegration get_email_integration(int id = 0)
        {
            return null;
        }

        public List<LeadIntegrationEmails> get_mail_activity(int id)
        {
            using (var db = new DBContext())
            {
                return db.LeadIntegrationEmails.Where(table => table.LeadId == id)
                    .OrderBy(table => new {table.DateAdded}).ToList();
            }
        }

        public bool update_email_integration(dynamic data)
        {
            return false;
        }

        public void change_status_color(LeadsStatus data)
        {
        }

        public void update_status_order(params LeadsStatus[] datas)
        {
            datas.ToList().ForEach((data) => { });
        }

        public WebToLead get_form(dynamic where)
        {
            using (var db = new DBContext())
            {
                return db.WebToLead.FirstOrDefault();
            }
        }

        public int add_form(WebToLead data)
        {
            return 0;
        }

        public bool update_form(int id, WebToLead data)
        {
            data = this._do_lead_web_to_form_responsibles(data);
            // data.SuccessSubmitMsg = data.SuccessSubmitMsg.nl2br();
            return false;
        }

        public bool delete_form(int id)
        {
            using (var db = new DBContext())
            {
                var entry = db.WebToLead.FirstOrDefault(table => table.WebToLeadId == id);
                db.Remove(entry);
                var affected_rows = db.SaveChanges();
                if (affected_rows > 0)
                {
                    this.log_activity("Lead Form Deleted [" + id + "]");
                    return true;
                }
            }

            return false;
        }

        private dynamic _do_lead_web_to_form_responsibles(dynamic data)
        {
            if (data.ContainsKey("notify_lead_imported"))
            {
                data["notify_lead_imported"] = 1;
            }
            else
            {
                data["notify_lead_imported"] = 0;
            }

            if (data["responsible"] == "")
            {
                data["responsible"] = 0;
            }

            if (data["notify_lead_imported"] != 0)
            {
            }
            else
            {
            }

            return data;
        }

        public LeadsModel() : base()
        {
            this.proposals_model = new ProposalsModel();
        }
    }

    public static class LeadsModelExtension
    {
        private static LeadsModel _instance = null;

        public static LeadsModel leads_model(this object source)
        {
            return _instance ??= new LeadsModel();
        }
    }
}