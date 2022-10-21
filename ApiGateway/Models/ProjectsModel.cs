using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using JamfahCrm.Library.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WiseSystem.Libraries;
using WiseSystem.Libraries.Core;
using WiseSystem.Libraries.Helpers;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class ProjectStatus
    {
        public int id = 0;
        public string color = "";
        public string name = "";
        public int order = 0;
        public bool filter_default = false;
    }

    public class ProjectsModel : MyModel
    {
        private List<string> project_settings;

        public List<dynamic> GetProjectStatuses()
        {
            var statuses = new List<dynamic>()
            {
                new ProjectStatus()
                {
                    id = 1,
                    color = "#989898",
                    name = this.label("project_status_1"),
                    order = 1,
                    filter_default = true,
                },
                new ProjectStatus()
                {
                    id = 2,
                    color = "#03a9f4",
                    name = this.label("project_status_2"),
                    order = 2,
                    filter_default = true,
                },
                new ProjectStatus()
                {
                    id = 3,
                    color = "#ff6f00",
                    name = this.label("project_status_3"),
                    order = 3,
                    filter_default = true,
                },
                new ProjectStatus()
                {
                    id = 4,
                    color = "#84c529",
                    name = this.label("project_status_4"),
                    order = 100,
                    filter_default = false,
                },
                new ProjectStatus()
                {
                    id = 5,
                    color = "#989898",
                    name = this.label("project_status_5"),
                    order = 4,
                    filter_default = false,
                }
            };
            this.hooks().ApplyFilters("before_get_project_statuses", statuses);

            return statuses;
        }

        public void get_distinct_tasks_timesheets_staff(int project_id)
        {
        }

        public void get_distinct_projects_members()
        {
        }

        public void get_most_used_billing_type()
        {
        }

        public void timers_started_for_project(int project_id, dynamic where = default(ExpandoObject))
        {
        }

        public bool pin_action(int id)
        {
            using (var db = new DBContext())
            {
                int total_rows = db.PinnedProjects
                    .Where(table => table.UserId == this.get_staff_user_id() && table.ProjectId == id).ToList().Count;

                if (total_rows == 0)
                {
                    return true;
                }
            }

            return true;
        }

        public Currencies GetCurrency(int id)
        {
            var clients_model = new ClientsModel();
            var currencies_model = new CurrenciesModel();
            var customer_currency = clients_model.GetCustomerDefaultCurrency(this.get_client_id_by_project_id(id));
            var currency = currencies_model.GetBaseCurrency();
            if (customer_currency != 0)
            {
                currency = currencies_model.Get(customer_currency).First();
            }

            return currency;
        }

        public int calc_progress(int id)
        {
            var project = new Projects();
            if (project.Status == 4)
            {
                return 100;
            }

            if (project.ProgressFromTasks == 1)
            {
                return this.calc_progress_by_tasks(id);
            }

            return (int)project.Progress;
        }

        public int calc_progress_by_tasks(int id)
        {
            int percent = 0;
            using (var db = new DBContext())
            {
                int total_project_tasks = db.Tasks.Where(table => table.RelType == "project" && table.RelId == id)
                    .ToList().Count;

                int total_finished_tasks = db.Tasks
                    .Where(table => table.RelType == "project" && table.RelId == id && table.Status == 5).ToList()
                    .Count;

                if (total_finished_tasks >= total_project_tasks)
                {
                    percent = 100;
                }
                else
                {
                    if (total_project_tasks != 0)
                    {
                    }
                }
            }

            return percent;
        }

        public object get_last_project_settings()
        {
            return new { };
        }

        public List<string> get_settings()
        {
            return this.project_settings;
        }

        public object Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public void calculate_total_by_project_hourly_rate(int seconds, int hourly_rate)
        {
        }

        public dynamic calculate_total_by_task_hourly_rate(List<Tasks> tasks)
        {
            int total_money = 0;
            int _total_seconds = 0;
            foreach (var task in tasks)
            {
            }

            return new
            {
                TotalMoney = total_money,
                TotalSeconds = _total_seconds
            };
        }

        public object get_tasks(int id, dynamic where = default(ExpandoObject), bool apply_restrictions = false,
            bool count = false)
        {
            var has_permission = Permission.CanView("Tasks");
            var show_all_tasks_for_project_member = this.get_option<bool>("show_all_tasks_for_project_member");
            if (this.is_client_logged_in())
            {
            }

            return null;
        }

        public void cancel_RecurringTasks(int id)
        {
        }

        public void do_milestones_kanban_query(int milestone_id, int project_id, int page = 1,
            dynamic where = default(ExpandoObject), bool count = false)
        {
        }

        public List<ProjectFiles> get_files(int project_id)
        {
            return null;
        }

        public ProjectFiles GetFile(int id, int project_id = 0)
        {
            return null;
        }

        public void update_file_data(ProjectFiles data)
        {
        }

        public void change_file_visibility(int id, bool visible)
        {
        }

        public void change_activity_visibility(int id, bool visible)
        {
        }

        public bool remove_file(int id, bool logActivity = true)
        {
            this.hooks().DoAction("before_remove_project_file", id);
            return false;
        }

        public void get_project_overview_weekly_chart_data(int id, DateTime type)
        {
            if (type == default(DateTime))
            {
            }
        }

        public void get_gantt_data(int project_id, string type = "milestones", object taskStatus = null)
        {
        }

        public void get_all_projects_gantt_data(List<string> filters = default(List<string>))
        {
        }

        public void calc_milestone_logged_time(int id, int project_id)
        {
        }

        public void total_logged_time(int id)
        {
        }

        public void get_milestones(int project_id)
        {
        }

        public int add_milestone(Milestones data)
        {
            data.DateCreated = DateTime.Now;
            data.Description = data.Description.nl2br();

            int insert_id = 0;
            if (insert_id > 0)
            {
                var milestone = new Milestones();
                var project = (Projects)this.Get(milestone.ProjectId);
                this.log_activity("Project Milestone Created [ID:" + insert_id + "]");

                return insert_id;
            }

            return 0;
        }

        public bool update_milestone(int id, Milestones data)
        {
            var milestone = new Milestones();
            data.Description = data.Description.nl2br();

            int affected_rows = 0;

            if (affected_rows > 0)
            {
                var project = this.Get(milestone.ProjectId);

                this.log_activity("Project Milestone Updated [ID:" + id + "]");

                return true;
            }

            return false;
        }

        public void update_task_milestone(dynamic data)
        {
        }

        public void update_milestones_order(dynamic data)
        {
        }

        public void update_milestone_color(dynamic data)
        {
        }

        public bool delete_milestone(int id)
        {
            var milestone = new Milestones();

            int affected_rows = 0;
            if (affected_rows > 0)
            {
                var project = this.Get(milestone.ProjectId);
                this.log_activity("Project Milestone Deleted [" + id + "]");

                return true;
            }

            return false;
        }

        public bool Add(Projects data)
        {
            return false;
        }

        public bool Update(int id, dynamic data)
        {
            using (var db = new DBContext())
            {
                var old_status = db.Projects.FirstOrDefault(table => table.ProjectId == id);
            }


            return false;
        }

        public bool send_project_customer_email(int id, string template)
        {
            int clientid = 0;

            var sent = false;
            var contacts = this.clients_model().GetContacts(clientid, new { Active = true, ProjectEmails = true });

            foreach (var contact in contacts)
            {
                sent = true;
                clientid = contact.ContactId;
            }

            return sent;
        }

        public bool MarkAs(dynamic data)
        {
            return false;
        }

        private void _notify_project_members_status_change(int id, string old_status, string new_status)
        {
        }

        private void _mark_all_project_tasks_as_completed(int id)
        {
            var tasks = (List<Tasks>)this.get_tasks(id);
            foreach (var task in tasks)
            {
            }
        }

        public bool add_edit_members(int id, dynamic data)
        {
            return false;
        }

        public bool is_member(int project_id, int staff_id = 0)
        {
            if (staff_id > 0)
            {
                staff_id = this.get_staff_user_id();
            }

            int member = 0;
            using (var db = new DBContext())
            {
                member = db.ProjectMembers
                    .Where(table => table.UserId == staff_id && table.ProjectId == project_id)
                    .ToList().Count;
            }

            return (member > 0);
        }

        public object get_projects_for_ticket(int client_id)
        {
            return this.Get(0, new
            {
                ClientId = client_id,
            });
        }

        public List<ProjectSettings> get_project_settings(int project_id)
        {
            return null;
        }

        public List<dynamic> get_project_members(int id)
        {
            return null;
        }

        public bool remove_team_member(int project_id, int staff_id)
        {
            int affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public void get_timesheets(int project_id, List<int> tasks_ids = default(List<int>))
        {
        }

        public ProjectDiscussions get_discussion(int id, int project_id = 0)
        {
            return null;
        }

        public ProjectDiscussionComments get_discussion_comment(int id)
        {
            var comment = new ProjectDiscussionComments();
            if (comment.ContactId != 0)
            {
            }
            else
            {
                if (this.is_client_logged_in())
                {
                }
                else
                {
                    if (this.is_staff_logged_in())
                    {
                    }
                    else
                    {
                    }
                }
            }

            return comment;
        }

        public List<ProjectDiscussionComments> get_discussion_comments(int id, string type)
        {
            var comments = new List<ProjectDiscussionComments>();
            return comments;
        }

        public object get_discussions(int project_id)
        {
            return null;
        }

        public bool add_discussion_comment(int discussion_id, ProjectDiscussionComments _data, string type)
        {
            var discussion = this.get_discussion(discussion_id);
            _data.DiscussionId = discussion_id;
            _data.DiscussionType = type;
            return false;
        }

        public ProjectDiscussionComments update_discussion_comment(ProjectDiscussionComments data)
        {
            var comment = this.get_discussion_comment(data.ProjectDiscussionCommentId);

            int affected_rows = 0;
            if (affected_rows > 0)
            {
                this._update_discussion_last_activity(comment.DiscussionId, comment.DiscussionType);
            }

            return this.get_discussion_comment(data.ProjectDiscussionCommentId);
        }

        public bool delete_discussion_comment(int id, bool logActivity = true)
        {
            var comment = this.get_discussion_comment(id);

            int affected_rows = 0;
            if (affected_rows > 0)
            {
                this.delete_discussion_comment_attachment(comment.FileName, comment.DiscussionId);
                if (logActivity)
                {
                    var additional_data = "";

                    if (comment.DiscussionType == "regular")
                    {
                        var discussion = this.get_discussion(comment.DiscussionId);
                        additional_data += discussion.Subject + "<br/>" + comment.Content;
                    }
                    else
                    {
                        var discussion = this.GetFile(comment.DiscussionId);
                        additional_data += discussion.Subject + "<br/>" + comment.Content;
                    }

                    if (!string.IsNullOrEmpty(comment.FileName))
                    {
                        additional_data += comment.FileName;
                    }
                }
            }

            if (affected_rows > 0 && logActivity)
            {
                this._update_discussion_last_activity(comment.DiscussionId, comment.DiscussionType);
            }

            return true;
        }

        public void delete_discussion_comment_attachment(string file_name, int discussion_id)
        {
        }

        public bool add_discussion(ProjectDiscussions data)
        {
            return false;
        }

        public bool edit_discussion(int id, dynamic data)
        {
            return false;
        }

        public bool delete_discussion(int id, bool logActivity = true)
        {
            var discussion = this.get_discussion(id);
            int affected_rows = 0;
            if (affected_rows > 0)
            {
                if (logActivity)
                {
                }

                this._delete_discussion_comments(id, "regular");
                return true;
            }

            return false;
        }

        public bool Copy(int project_id, dynamic data)
        {
            var project = this.Get(project_id);
            var settings = this.get_project_settings(project_id);
            return false;
        }

        public string get_staff_notes(int project_id)
        {
            var notes = new Notes();
            return "";
        }

        public bool save_note(int project_id, dynamic data)
        {
            return false;
        }

        public bool Delete(int project_id)
        {
            return false;
        }

        public object GetActivity(int id = 0, int limit = 0, bool only_project_members_activity = false)
        {
            return null;
        }

        public void new_project_file_notification(int project_id, int file_id)
        {
        }

        public bool add_external_file(Files data)
        {
            return false;
        }

        public void send_project_eMailTemplate(int project_id, string staff_template, string customer_template,
            string action_visible_to_customer, dynamic additional_data = default(ExpandoObject))
        {
        }

        private Projects _get_project_billing_data(int id)
        {
            return null;
        }

        public void total_logged_time_by_billing_type(int id, dynamic conditions = default(ExpandoObject))
        {
        }

        public dynamic data_billable_time(int id)
        {
            return this._get_data_total_logged_time(id, new
            {
                BillAble = 1
            });
        }

        public dynamic data_billed_time(int id)
        {
            return this._get_data_total_logged_time(id, new
            {
                Billable = true,
                Billed = true
            });
        }

        public dynamic data_unbilled_time(int id)
        {
            return this._get_data_total_logged_time(id, new
            {
                Billable = true,
                Billed = false,
            });
        }

        private void _delete_discussion_comments(int id, string type)
        {
        }

        private dynamic _get_data_total_logged_time(int id, dynamic conditions = default(ExpandoObject))
        {
            var project_data = this._get_project_billing_data(id);
            var tasks = this.get_tasks(id, conditions);
            dynamic data = new ExpandoObject();
            return data;
        }

        private void _update_discussion_last_activity(int id, string type)
        {
            var table = (type == "file")
                ? "ProjectFiles"
                : (type == "regular")
                    ? "ProjectDiscussions"
                    : "";
        }

        public ProjectsModel() : base()
        {
            this.project_settings = new List<string>()
            {
                "available_features",
                "view_tasks",
                "create_tasks",
                "edit_tasks",
                "comment_on_tasks",
                "view_task_comments",
                "view_task_attachments",
                "view_task_checklist_items",
                "upload_on_tasks",
                "view_task_total_logged_time",
                "view_finance_overview",
                "upload_files",
                "open_discussions",
                "view_milestones",
                "view_gantt",
                "view_timesheets",
                "view_activity_log",
                "view_team_members",
                "hide_tasks_on_main_tasks_table"
            };
            this.hooks().ApplyFilters("project_settings", project_settings);
        }
    }

    public static class ProjectsModelExtension
    {
        private static ProjectsModel _instance = null;

        public static ProjectsModel projects_model(this object source)
        {
            return _instance ??= new ProjectsModel();
        }
    }
}