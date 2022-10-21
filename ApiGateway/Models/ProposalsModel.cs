using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WiseSystem.Libraries;
using WiseSystem.Libraries.Helpers;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class ProposalsModel : MyModel
    {
        private List<int> statuses;

        private bool copy = false;

        public List<int> GetStatuses()
        {
            return this.statuses;
        }

        public void GetSaleAgents()
        {
        }

        public void Get_proposals_years()
        {
        }

        public void DoKanbanQuery(string status, string search = "", int page = 1,
            List<string> sort = default(List<string>), bool count = false)
        {
        }

        public int Add(Proposals data)
        {
            data.Address = data.Address.Trim().nl2br();
            data.DateCreated = DateTime.Now;
            data.AddedFrom = this.get_staff_user_id();
            if (string.IsNullOrEmpty(data.RelType))
            {
                data.RelType = null;
                data.RelId = null;
            }
            else
            {
            }

            var items = new List<string>();

            if (this.copy == false)
            {
                data.Content = "{proposal_items}";
            }

            var hook = new { Data = data, Items = items };
            this.hooks().ApplyFilters("before_create_proposal", hook);

            var insert_id = 0;

            if (insert_id > 0)
            {
            }

            return 0;
        }

        public bool Update(int id, Proposals data)
        {
            int affectedRows = 0;

            var current_proposal = this.Get(id).First();

            if (string.IsNullOrEmpty(data.RelType))
            {
                data.RelId = null;
                data.RelType = "";
            }
            else
            {
                if (data.RelId == 0)
                {
                    data.RelId = null;
                    data.RelType = "";
                }
            }

            if (affectedRows > 0)
            {
                this.hooks().DoAction("after_proposal_updated", id);

                return true;
            }

            return false;
        }

        public List<Proposals> Get(int id = 0, dynamic where = default(ExpandoObject), bool for_editor = false)
        {
            return null;
        }

        public bool ClearSignature(int id)
        {
            var proposal = new Proposals();

            if (proposal != null)
            {
                if (!string.IsNullOrEmpty(proposal.Signature))
                {
                }

                return true;
            }

            return false;
        }

        public void update_pipeline(dynamic data)
        {
        }

        public List<Files> GetAttachments(int proposal_id, int id = 0)
        {
            return null;
        }

        public bool DeleteAttachment(int id)
        {
            var attachment = this.GetAttachments(0, id).FirstOrDefault();
            bool deleted = false;
            if (attachment != null)
            {
                if (string.IsNullOrEmpty(attachment.External))
                {
                }

                int affected_rows = 0;
                if (affected_rows > 0)
                {
                    deleted = true;
                    this.log_activity("Proposal Attachment Deleted [ID: " + attachment.RelType + "]");
                }

            }

            return deleted;
        }

        public bool add_comment(ProposalComments data, bool client = false)
        {
            if (this.is_staff_logged_in())
            {
                client = false;
            }

            data.DateAdded = SharePoint.Now;
            if (client == false)
            {
                data.UserId = this.get_staff_user_id();
            }

            data.Content = data.Content.nl2br();
            int insert_id = 0;
            if (insert_id > 0)
            {
                var proposal = this.Get(data.ProposalId).First();

                if (proposal.Status == '6' && client == false)
                {
                    return true;
                }

                return true;
            }

            return false;
        }

        public bool EditComment(int id, dynamic data)
        {
            int affected_rows = 0;
            return (affected_rows > 0);
        }

        public List<ProposalComments> GetComments(int id)
        {
            return null;
        }

        public ProposalComments GetComment(int id)
        {
            return null;
        }

        public bool RemoveComment(int id)
        {
            var comment = this.GetComment(id);

            int affected_rows = 0;

            if (affected_rows > 0)
            {
                this.log_activity("Proposal Comment Removed [ProposalID:" + comment.ProposalId + ", Comment Content: " +
                                  comment.Content + ']');
                return true;
            }

            return false;
        }

        public int Copy(int id)
        {
            this.copy = true;
            var proposal = this.Get(id, null, true);
            var not_copy_fields = new List<string>()
            {
                "addedfrom", "id", "datecreated", "hash", "status",
                "invoice_id",
                "estimate_id",
                "is_expiry_notified",
                "date_converted",
                "signature",
                "acceptance_firstname",
                "acceptance_lastname",
                "acceptance_email",
                "acceptance_date",
                "acceptance_ip"
            };
            return 0;
        }

        public bool mark_action_status(int id, int status, bool client = false)
        {
            var original_proposal = this.Get(id).First();

            int affected_rows = 0;
            if (affected_rows > 0)
            {
                if (client == true)
                {
                    bool revert = false;
                    var message = "";
                    if (status == 2)
                    {
                        message = "not_proposal_proposal_declined";
                    }
                    else if (status == 3)
                    {
                        message = "not_proposal_proposal_accepted";
                    }
                    else
                    {
                        revert = true;
                    }

                    if (revert == true)
                    {
                        return false;
                    }

                    var staff_proposal = new List<Users>();
                    using (var db = new DBContext())
                    {
                        staff_proposal = db.Users.Where(
                                table =>
                                    table.UserId == original_proposal.AddedFrom || table.UserId == original_proposal.Assigned)
                            .ToList();
                    }

                    staff_proposal.ForEach((member) =>
                    {
                        var notified = this.add_notification(new Notifications()
                        {
                            FromCompany = 1,
                            ToUserId = member.UserId,
                            Description = message,
                            Link = "proposals/list_proposals" + id,
                        });

                        if (notified)
                        {
                            this.pusher_trigger_notification(member.UserId);
                        }
                    });

                    if (status == 3)
                    {
                        staff_proposal.ForEach((member) => { this.send_mail_template("proposal_accepted_to_staff", original_proposal.Email, member.Email); });
                        this.send_mail_template("proposal_accepted_to_customer", original_proposal.Email);
                        this.hooks().DoAction("proposal_accepted", id);
                    }
                    else
                    {
                        foreach (var member in staff_proposal)
                        {
                            this.send_mail_template("proposal_declined_to_staff", original_proposal.Email, member.Email);
                        }

                        this.hooks().DoAction("proposal_declined", id);
                    }
                }
                else
                {
                }

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            this.ClearSignature(id);
            var proposal = this.Get(id);
            var tasks_model = new TasksModel();
            int affected_rows = 0;
            using (var db = new DBContext())
            {
                db.Remove(proposal);
                affected_rows = db.SaveChanges();
            }

            if (affected_rows > 0)
            {
                using (var db = new DBContext())
                {
                    List<Tasks> tasks = db.Tasks.Where(table => table.RelType == "proposal" && table.RelId == id).ToList();
                    tasks.ForEach((task) => { tasks_model.DeleteTask(task.TaskId); });

                    var attachments = this.GetAttachments(id);
                    attachments.ForEach((attachment) => { this.DeleteAttachment(attachment.FileId); });

                    this.log_activity("Proposal Deleted [ProposalID:" + id + "]");

                    return true;
                }
            }

            return false;
        }

        public void get_relation_data_values(int rel_id, string rel_type)
        {
        }

        public bool send_expiry_reminder(int id)
        {
            var proposal = this.Get(id).First();

            return true;
        }

        public bool send_proposal_to_email(int id, bool attachpdf = true, string cc = "")
        {
            using (var db = new DBContext())
            {
                int total_rows = db.Proposals.Where(table => table.ProposalId == id && table.Status == 6).ToList().Count;

                if (total_rows > 0)
                {
                    var row = db.Proposals.FirstOrDefault(table => table.ProposalId == id);
                    db.Update(row);
                    db.SaveChanges();
                }

                var proposal = this.Get(id).First();
                return false;
            }
        }

        public ProposalsModel() : base()
        {
            this.statuses = new List<int>() { 6, 4, 1, 5, 2, 3 };
            this.hooks().ApplyFilters("before_set_proposal_statuses", this.statuses);
        }
    }

    public static class ProposalsModelExtension
    {
        private static ProposalsModel _instance = null;

        public static ProposalsModel proposals_model(this object source)
        {
            return _instance ??= new ProposalsModel();
        }
    }
}