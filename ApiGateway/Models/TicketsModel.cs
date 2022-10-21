using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WiseSystem.Libraries;
using WiseSystem.Libraries.Core;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class TicketsModel : MyModel
    {

        public string InsertPipedTicket(dynamic data)
        {
            this.hooks().ApplyFilters("piped_ticket_data", data);

            var attachments = data.attachments;
            string subject = data["subject"];
            var system_blocked_subjects = new List<string>()
            {
                "Mail delivery failed",
                "failure notice",
                "Returned mail: see transcript for details",
                "Undelivered Mail Returned to Sender"
            };

            bool subject_blocked = false;

            foreach (string sb in system_blocked_subjects)
            {
                if (sb.Contains("x" + subject))
                {
                    subject_blocked = true;
                    break;
                }
            }

            if (subject_blocked == true) return null;

            string message = data["body"];
            string name = data["fromname"];

            string email = data["email"];
            string to = data["to"];

            string mailstatus = this.spam_filters_model().Check(email, subject, message, "tickets");

            if (string.IsNullOrEmpty(mailstatus))
            {
            }

            if (mailstatus == "")
            {
                mailstatus = "Ticket Import Failed";
            }

            return mailstatus;
        }

        private void ProcessPipeAttachments(List<TicketAttachments> attachments, int ticket_id, int reply_id = 0)
        {
            if (attachments.Count > 0)
            {
            }
        }

        public object Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public Tickets GetTicketById(int? id, int user_id = 0)
        {
            return null;
        }

        public void InsertTicketAttachmentsToDatabase(List<TicketAttachments> attachments, int ticket_id,
            bool replyid = false)
        {
            foreach (var attachment in attachments)
            {
                attachment.TicketId = ticket_id;
                attachment.DateAdded = DateTime.Now;
            }
        }

        public List<TicketAttachments> GetTicketAttachments(int id, object replyid = null)
        {
            return null;
        }

        public int AddReply(int id, object data, bool admin = false, bool pipe_attachments = false)
        {
            return 0;
        }

        public bool DeleteTicketReply(int ticket_id, int reply_id)
        {
            return false;
        }

        public bool DeleteTicketAttachment(int id)
        {
            bool deleted = false;
            return deleted;
        }

        public TicketAttachments GetTicketAttachment(int id)
        {
            return null;
        }

        public void GetUserOtherTickets(int user_id, int id)
        {
        }

        public List<Tickets> GetTicketReplies(int? id)
        {
            var ticket_replies_order = this.get_option<string>("ticket_replies_order");
            this.hooks().ApplyFilters("ticket_replies_order", ticket_replies_order);

            return default(List<Tickets>);
        }

        public bool Add(object data, bool admin = false, bool pipe_attachments = false)
        {
            if (!admin)
            {
            }

            return false;
        }

        public void GetClientLatestsTicket(int limit = 5, int user_id = 0)
        {
        }

        public bool Delete(int ticket_id)
        {
            int affectedRows = 0;
            this.hooks().DoAction("before_ticket_deleted", ticket_id);
            if (affectedRows > 0)
            {
                affectedRows++;
            }

            if (affectedRows > 0)
            {
                affectedRows++;
            }

            if (affectedRows > 0)
            {
                this.log_activity("Ticket Deleted [ID: " + ticket_id + "]");

                return true;
            }

            return false;
        }

        public bool UpdateSingleTicketSettings(Tickets data)
        {
            this.hooks().ApplyFilters("before_ticket_settings_updated", data);
            var ticketBeforeUpdate = this.GetTicketById(data.TicketId);

            return false;
        }

        public dynamic ChangeTicketStatus(int id, int status)
        {
            using (var db = new DBContext())
            {
                var tickets = db.Tickets.SingleOrDefault(table => table.TicketId == id);
                tickets.Status = status;
                int affectedRows = db.SaveChanges();

                string alert = "warning";
                string message = this.label("ticket_status_changed_fail");
                if (affectedRows > 0)
                {
                    alert = "success";
                    message = this.label("ticket_status_changed_successfully");
                    this.hooks().DoAction("after_ticket_status_changed", new
                    {
                        Id = id,
                        status = status
                    });
                }

                return new
                {
                    alert = alert,
                    message = message
                };
            }
        }

        public object GetPriority(int id = 0)
        {
            using (var db = new DBContext())
            {
                if (id > 0)
                {
                    return db.TicketsPriorities.Where(table => table.TicketsPriorityId == id).ToList();
                }

                return db.TicketsPriorities.ToList();
            }
        }

        public int AddPriority(TicketsPriorities data)
        {
            using (var db = new DBContext())
            {
                db.TicketsPriorities.Add(data);
                int insertId = db.SaveChanges();

                if (insertId > 0)
                {
                    this.log_activity("New Ticket Priority Added [ID: " + insertId + ", Name: " + data.Name + "]");
                }

                return insertId;
            }
        }

        public bool UpdatePriority(int id, dynamic data)
        {
            int affectedRows = 0;

            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeletePriority(int id)
        {
            Tickets current = (Tickets)this.Get(id);
            if (this.is_reference_in_table("Priority", "tickets", id))
            {
                return true;
            }

            int affectedRows = 0;

            if (affectedRows > 0)
            {
                if (this.get_option<int>("email_piping_default_priority") == id)
                {
                    this.update_option("email_piping_default_priority", "");
                }

                this.log_activity("Ticket Priority Deleted [ID: " + id + "]");

                return true;
            }

            return false;
        }

        public object GetPredefinedReply(int id = 0)
        {
            if (id > 0)
            {
            }

            return null;
        }

        public int AddPredefinedReply(TicketsPredefinedReplies data)
        {
            int insertid = 0;

            this.log_activity("New Predefined Reply Added [ID: " + insertid + ", " + data.Name + "]");

            return insertid;
        }

        public bool UpdatePredefinedReply(int id, dynamic data)
        {
            int affectedRows = 0;

            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeletePredefinedReply(int id)
        {
            int affectedRows = 0;

            if (affectedRows > 0)
            {
                this.log_activity("Predefined Reply Deleted [" + id + "]");

                return true;
            }

            return false;
        }

        public List<TicketsStatus> GetTicketStatus(int id = 0)
        {
            using (var db = new DBContext())
            {
                if (id > 0)
                {
                    return db.TicketsStatus.Where(table => table.TicketStatusId == id).ToList();
                }

                return db.TicketsStatus.OrderBy(table => table.StatusOrder).ToList();
            }
        }

        public int AddTicketStatus(TicketsStatus data)
        {
            int insert_id = 0;
            if (insert_id > 0)
            {
                this.log_activity("New Ticket Status Added [ID: " + insert_id + ", " + data.Name + "]");
                return insert_id;
            }

            return 0;
        }

        public bool UpdateTicketStatus(int id, dynamic data)
        {
            int affectedRows = 0;
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteTicketStatus(int id)
        {
            TicketsStatus current = this.GetTicketStatus(id).FirstOrDefault();
            if (current.IsDefault == 1)
            {
                return true;
            }
            else if (this.is_reference_in_table("status", "tickets", id))
            {
                return true;
            }

            int affectedRows = 0;
            if (affectedRows > 0)
            {
                this.log_activity("Ticket Status Deleted [ID: " + id + "]");
                return true;
            }

            return false;
        }

        public object GetService(int id = 0)
        {
            return null;
        }

        public int AddService(Services data)
        {
            int insert_id = 0;
            if (insert_id > 0)
            {
                this.log_activity("New Ticket Service Added [ID: " + insert_id + "." + data.Name + "]");
            }

            return insert_id;
        }

        public bool UpdateService(int id, dynamic data)
        {
            int affectedRows = 0;
            if (affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteService(int id)
        {
            if (this.is_reference_in_table("service", "tickets", id))
            {
                return true;
            }

            int affectedRows = 0;
            if (affectedRows > 0)
            {
                this.log_activity("Ticket Service Deleted [ID: " + id + "]");
                return true;
            }

            return false;
        }

        public void GetWeeklyTicketsOpeningStatistics()
        {
        }

        public List<Tickets> GetTicketsAssignesDisctinct()
        {
            return null;
        }

        public bool TransferEmailTicketsToContact(int contact_id, string email = null)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            int customer_id = this.get_user_id_by_contact_id(contact_id);

            return true;
        }
    }

    public static class TicketsModelExtension
    {
        private static TicketsModel _instance = null;

        public static TicketsModel tickets_model(this object source)
        {
            return _instance ??= new TicketsModel();
        }
    }
}