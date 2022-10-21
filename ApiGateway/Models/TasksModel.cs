using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using JamfahCrm.Library.Services.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WiseSystem.Libraries;
using WiseSystem.Libraries.Core;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class TasksModel : MyModel
    {
        private readonly int STATUS_NOT_STARTED = 1;
        private readonly int STATUS_AWAITING_FEEDBACK = 2;
        private readonly int STATUS_TESTING = 3;
        private readonly int STATUS_IN_PROGRESS = 4;
        private readonly int STATUS_COMPLETE = 5;

        public List<Tasks> GetUserTasksAssigned()
        {
            using (var db = new DBContext())
            {
                return
                    db.Tasks.Where(table => table.Status != 5)
                        .OrderBy(table => table.DueDate)
                        .ToList();
            }

        }

        public List<dynamic> GetStatuses()
        {
            List<dynamic> statuses = new List<dynamic>()
            {
                new
                {
                    id = STATUS_NOT_STARTED,
                    color = "#989898",
                    name = this.label("task_status_1"),
                    order = 1,
                    filter_default = true,
                },
                new
                {
                    id = STATUS_IN_PROGRESS,
                    color = "#03A9F4",
                    name = this.label("task_status_4"),
                    order = 2,
                    filter_default = true,
                },
                new
                {
                    id = STATUS_TESTING,
                    color = "#2d2d2d",
                    name = this.label("task_status_3"),
                    order = 3,
                    filter_default = true,
                },
                new
                {
                    id = STATUS_AWAITING_FEEDBACK,
                    color = "#adca65",
                    name = this.label("task_status_2"),
                    order = 4,
                    filter_default = true,
                },
                new
                {
                    id = STATUS_COMPLETE,
                    color = "#84c529",
                    name = this.label("task_status_5"),
                    order = 100,
                    filter_default = false,
                }
            };

            this.hooks().ApplyFilters("before_get_task_statuses", statuses);
            return statuses;
        }

        public Tasks Get(int id, dynamic where = default(ExpandoObject))
        {
            var db = new DBContext();
            bool is_admin = this.is_admin();
            var task = db.Tasks.SingleOrDefault(table => table.TaskId == id);

            if (task != null)
            {
            }

            this.hooks().ApplyFilters("get_task", task);
            return task;
        }

        public Milestones get_milestone(int id)
        {
            return null;
        }

        public int DoKanbanQuery(string status, string search = "", int page = 1, bool count = false, dynamic where = default(ExpandoObject))
        {
            if (!Permission.CanView("tasks"))
            {
            }

            return 0;
        }

        public void UpdateOrder(params Tasks[] data)
        {
        }

        public void GetDistinctTasksYears(string get_from)
        {
        }

        public bool IsTaskBilled(int id)
        {
            var db = new DBContext();
            var total = db.Tasks.Where(table => table.TaskId == id && table.Billed == true).ToList().Count;
            return (total > 0 ? true : false);
        }

        public int Copy(dynamic data, params string[] overwrites)
        {
            return 0;
        }

        public void CopyTaskFollowers(int from_task, int to_task)
        {
            var followers = this.GetTaskFollowers(from_task);

            foreach (var follower in followers)
            {
                using (var db = new DBContext())
                {
                    db.TaskFollowers.Add(new TaskFollowers()
                    {
                        TaskId = to_task,
                    });
                    db.SaveChanges();
                }
            }
        }

        public void CopyTaskAssignees(int from_task, int to_task)
        {
            var assignees = this.GetTaskAssignees(from_task);
            assignees.ForEach((assignee) =>
            {
            });
        }

        public void copy_task_checklist_items(int from_task, int to_task)
        {
        }

        public void copy_task_custom_fields(int from_task, int to_task)
        {
        }

        public void get_billable_tasks(int customer_id = 0, int project_id = 0)
        {
        }

        public void get_billable_amount(int task_id)
        {
        }

        public void get_billable_task_data(int task_id)
        {
        }

        public List<Tasks> get_tasks_by_staff_id(int id, dynamic where = default(ExpandoObject))
        {
            using (var db = new DBContext())
            {
                return db.Tasks
                    .ToList();
            }
        }

        public bool Add(Tasks data, bool clientRequest = false)
        {
            return false;
        }

        public bool Update(int id, dynamic data, bool clientRequest = false)
        {
            int affectedRows = 0;
            return (affectedRows > 0);
        }

        public TaskChecklistItems get_checklist_item(int id)
        {
            return null;
        }

        public List<TaskChecklistItems> get_checklist_items(int task_id)
        {
            return null;
        }

        public int add_checklist_template(string description)
        {
            return 0;
        }

        public bool remove_checklist_item_template(int id)
        {
            return false;
        }

        public List<TasksChecklistTemplates> get_checklist_templates()
        {
            return null;
        }

        public TasksChecklistTemplates get_checklist_template(int id)
        {
            return null;
        }

        public bool add_checklist_item(TaskChecklistItems data)
        {
            return false;
        }

        public bool delete_checklist_item(int id)
        {
            return false;
        }

        public void update_checklist_order(params TaskChecklistItems[] data)
        {
        }

        public void update_checklist_item(int id, string description)
        {
        }

        public bool make_public(int task_id)
        {
            return false;
        }

        public void get_task_creator_id(int task_id)
        {
        }

        public int add_task_comment(TaskComments data)
        {
            if (this.is_client_logged_in())
            {
            }
            else
            {
            }

            int insert_id = 0;
            if (insert_id > 0)
            {
            }

            return 0;
        }

        public bool add_task_followers(TaskFollowers data)
        {
            int affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public int add_task_assignees(TaskAssigned data, bool cronOrIntegration = false, bool clientRequest = false)
        {
            var
                assignData = new TaskAssigned()
                {
                    TaskId = data.TaskId,
                    UserId = data.UserId
                };
            if (cronOrIntegration)
            {
                assignData.AssignedFrom = data.UserId;
            }
            else if (clientRequest)
            {
                assignData.IsAssignedFromContact = true;
                assignData.AssignedFrom = this.get_contact_user_id();
            }
            else
            {
                assignData.AssignedFrom = this.get_staff_user_id();
            }

            int assigneeId = 0;
            if (assigneeId > 0)
            {
                var task = new Tasks();
            }

            return 0;
        }

        public void get_task_attachments(int task_id, dynamic where = default(ExpandoObject))
        {
            if (where != default(ExpandoObject))
            {
            }

        }

        public dynamic remove_task_attachment(int id)
        {
            int comment_removed = 0;
            bool deleted = false;
            var attachment = new Files();
            if (attachment != null)
            {
                if (string.IsNullOrEmpty(attachment.External))
                {
                }

                var affected_rows = 0;
                if (affected_rows > 0)
                {
                    deleted = true;
                    this.log_activity("Task Attachment Deleted [TaskID: " + attachment.RelId + "]");
                }

            }

            if (deleted)
            {
                if (attachment.TaskCommentId != 0)
                {
                    using (var db = new DBContext())
                    {
                        var total_comment_files = db.Files.Where(table => table.TaskCommentId == attachment.TaskCommentId).ToList().Count;
                        if (total_comment_files == 0)
                        {
                            var comment = new TaskComments();
                            if (comment != null)
                            {
                                if (string.IsNullOrEmpty(comment.Content) || comment.Content == "[task_attachment]")
                                {
                                    comment_removed = comment.TaskCommentId;
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }

            }

            return new { success = deleted, comment_removed = comment_removed };
        }

        public bool AddAttachmentToDatabase(int rel_id, string attachment, bool external = false, bool notification = true)
        {
            var misc_model = new MiscModel();
            var file_id = misc_model.AddAttachmentToDatabase(rel_id, "task", attachment, external);
            if (file_id > 0)
            {
                var task = new Tasks();

                if (task.RelType == "project")
                {
                }

                if (notification == true)
                {
                    var description = "not_task_new_attachment";
                    this._SendTaskResponsibleUsersNotification(description, rel_id, 0, "task_new_attachment_to_staff");
                    this._SendCustomerContactsNotification(rel_id, "task_new_attachment_to_customer");
                }

                var task_attachment_as_comment = true;

                this.hooks().ApplyFilters("add_task_attachment_as_comment", task_attachment_as_comment);
                if (task_attachment_as_comment)
                {
                    var file = misc_model.GetFile(file_id);
                }

                return true;
            }

            return false;
        }

        public IList GetTaskFollowers(int id)
        {
            using (var db = new DBContext())
            {
                return db.TaskFollowers
                    .Select(table => new { table.TaskFollowerId, table.UserId })
                    .Join(
                        db.Users,
                        taskfollowers => taskfollowers.UserId,
                        users => users.UserId,
                        (taskfollowers, users) => new { taskfollowers, users })
                    .ToList();
            }
        }

        public List<TaskAssigned> GetTaskAssignees(int id)
        {
            return null;
        }

        public void GetTaskComments(int id)
        {
        }

        public bool EditComment(TaskComments data)
        {
            return false;
        }

        public bool RemoveComment(int id, bool force = false)
        {
            return false;
        }

        public bool RemoveAssignee(int id, int task_id)
        {
            return false;
        }

        public bool RemoveFollower(int id, int task_id)
        {
            return false;
        }

        public bool MarkAs(string status, int task_id)
        {
            return false;
        }

        public bool UnmarkComplete(int id, bool force_to_status = false)
        {
            return false;
        }

        public bool DeleteTask(int id, bool log_activity = true)
        {
            return false;
        }

        private void _SendTaskResponsibleUsersNotification(string description, int task_id, int exclude_id = 0,
            string email_template = "", string additional_notification_data = "", bool comment_id = false)
        {
            using (var db = new DBContext())
            {
                var users = db.Users.Where(table => table.Active == 1).ToList();
                var notified_users = new List<dynamic>();
                foreach (var member in users)
                {
                    if (exclude_id == member.UserId)
                    {
                        continue;
                    }

                    if (!this.is_client_logged_in())
                    {
                        if (member.UserId == this.get_staff_user_id())
                        {
                            continue;
                        }
                    }

                    if (this.ShouldStaffReceiveNotification(member.UserId, task_id))
                    {
                        var link = "#task_id=" + task_id;
                        if (comment_id)
                        {
                            link += "#comment_" + comment_id;
                        }

                        var notified =
                            this.add_notification(new Notifications()
                            {
                                Description = description,
                                ToUserId = member.UserId,
                                Link = link,
                                AdditionalData = additional_notification_data
                            });
                        if (notified)
                        {
                            this.pusher_trigger_notification(member.UserId);
                        }

                        if (email_template != "")
                        {
                        }
                    }
                }
            }
        }

        public void _SendCustomerContactsNotification(int task_id, string template_name)
        {
        }

        public bool StaffHasCommentedOnTask(int user_id, int task_id)
        {
            using (var db = new DBContext())
            {
                return (db.TaskComments.Where(table => table.StaffId == user_id && table.TaskId == task_id).ToList().Count > 0);
            }
        }

        public bool is_task_follower(int user_id, int task_id)
        {
            using (var db = new DBContext())
            {
                return (db.TaskFollowers.Where(table => table.UserId == user_id && table.TaskId == task_id).ToList().Count > 0);
            }
        }

        public bool IsTaskAssignee(int user_id, int task_id)
        {
            using (var db = new DBContext())
            {
                return db.TaskAssigned.Where(table => table.UserId == user_id && table.TaskId == task_id).ToList().Count > 0;
            }
        }

        public bool IsTaskCreator(int user_id, int task_id)
        {
            using (var db = new DBContext())
            {
                return db.Tasks.Where(table => table.TaskId == task_id && table.AddedFrom == user_id && table.IsAddedFromContact == false).ToList().Count > 0;
            }
        }

        public bool TimerTracking(string task_id = "", string timer_id = "", string note = "", bool admin_stop = false)
        {
            if (task_id == "" && timer_id == "")
            {
                return false;
            }

            return true;
        }

        public bool Timesheet(dynamic data)
        {
            return false;
        }

        public List<TasksTimers> GetTimers(int task_id,
            dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public TasksTimers GetTaskTimer(dynamic where)
        {
            return null;
        }

        public TasksTimers IsTimerStarted(int task_id, int staff_id = 0)
        {
            if (staff_id == 0)
            {
                staff_id = this.get_staff_user_id();
            }

            TasksTimers timer = this.GetLastTimer(task_id, staff_id);
            if (timer != null)
            {
                return null;
            }

            if (timer.EndTime != null)
            {
                return null;
            }

            return timer;
        }

        public bool IsTimerStartedForTask(int id,
            dynamic where = default(ExpandoObject))
        {
            return false;
        }

        public TasksTimers GetLastTimer(int task_id, int staff_id = 0)
        {
            return null;
        }

        public void TaskTrackingStats(int id)
        {
        }

        public void GetTimesheets(int task_id)
        {
        }

        public decimal GetTimeSpent(decimal seconds)
        {
            var minutes = seconds / 60;
            var hours = minutes / 60;
            if (minutes >= 60)
            {
                return Math.Round(hours, 2);
            }
            else if (seconds > 60)
            {
                return Math.Round(minutes, 2);
            }

            return seconds;
        }

        public int CalcTaskTotalTime(int task_id, dynamic where = default(ExpandoObject))
        {
            return 0;
        }

        public List<TasksTimers> GetUniqueMemberLoggedTaskIds(int staff_id, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        private void _CalTotalLoggedArrayFromTimers(TasksTimers timers)
        {
        }

        public bool DeleteTimesheet(int id)
        {
            return false;
        }

        public List<Reminders> GetReminders(int task_id)
        {
            return null;
        }

        public bool CanStaffAccessTask(int staff_id, int task_id)
        {
            bool retVal = false;
            List<Users> staffCanAccessTasks = this.GetStaffMembersThatCanAccessTask(task_id);
            foreach (var staff in staffCanAccessTasks)
            {
                if (staff.UserId == staff_id)
                {
                    retVal = true;
                    break;
                }
            }

            return retVal;
        }

        public List<Users> GetStaffMembersThatCanAccessTask(int task_id)
        {
            return null;
        }

        private bool ShouldStaffReceiveNotification(int staff_id, int task_id)
        {
            if (!this.CanStaffAccessTask(staff_id, task_id))
            {
                return false;
            }

            return (this.IsTaskAssignee(staff_id, task_id)
                    || this.is_task_follower(staff_id, task_id)
                    || this.IsTaskCreator(staff_id, task_id)
                    || this.StaffHasCommentedOnTask(staff_id, task_id));
        }
    }

    public static class TasksModelExtension
    {
        private static TasksModel _instance = null;

        public static TasksModel tasks_model(this object source)
        {
            return _instance ??= new TasksModel();
        }
    }
}