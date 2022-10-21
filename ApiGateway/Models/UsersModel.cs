using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using JamfahCrm.Library.Helpers.Staff;
using WiseSystem.Libraries;
using WiseSystem.Libraries.Core.Compat;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class UsersModel : MyModel
    {
        public bool Delete(int id, int transfer_data_to)
        {
            if (id == transfer_data_to)
            {
                return false;
            }

            this.hooks().DoAction("before_delete_user_member", new { id = id, transfer_data_to = transfer_data_to });
            var name = this.get_staff_fullname(id);
            var transferred_to = this.get_staff_fullname(transfer_data_to);

            var web_to_leads = new List<WebToLead>();
            foreach (var form in web_to_leads)
            {
                if (!string.IsNullOrEmpty(form.NotifyIds))
                {
                    var user = Newtonsoft.Json.JsonConvert.DeserializeObject(form.NotifyIds);
                }
            }

            var leads_email_integration = new LeadsEmailIntegration();
            if (leads_email_integration.NotifyType == "specific_user")
            {
                if (!string.IsNullOrEmpty(leads_email_integration.NotifyIds))
                {
                    var user = Newtonsoft.Json.JsonConvert.DeserializeObject(leads_email_integration.NotifyIds);
                }
            }

            this.log_activity("Staff Member Deleted [Name: " + name + ", Data Transferred To: " + transferred_to + "]");

            return true;
        }

        public Users Get(int user_id)
        {
            using (var db = new DBContext())
            {
                return db.Users.FirstOrDefault(table => table.UserId == user_id);
            }
        }

        public void GetStaffPermissions(int id)
        {
        }

        public int Add(Users data)
        {
            using (var db = new DBContext())
            {
                var user = db.Users.SingleOrDefault(table => table.Email == data.Email);
                if (user != null)
                {
                }
            }

            data.Admin = this.is_admin() ? 1 : 0;

            bool send_welcome_email = true;
            var original_password = data.Password;

            data.Password = PasswordHandler.CreatePasswordHash(data.Password);
            data.DateCreated = SharePoint.Now;

            var user_id = 0;

            if (user_id > 0)
            {
                var slug = data.Firstname + " " + data.Lastname;

                if (slug == " ")
                {
                    slug = "unknown-" + user_id;
                }

                if (send_welcome_email == true)
                {
                }

                this.log_activity("New Staff Member Added [ID: " + user_id + ", " + data.Firstname + " " + data.Lastname + "]");

                List<Announcements> announcements = new List<Announcements>();
                announcements.ForEach((announcement) =>
                {
                    var newdata = new DismissedAnnouncements()
                    {
                        AnnouncementId = announcement.AnnouncementId,
                        Staff = 1,
                        UserId = user_id
                    };
                    using (var db = new DBContext())
                    {
                        db.DismissedAnnouncements.Add(newdata);
                        user_id = db.SaveChanges();
                    }
                });

                this.hooks().DoAction("user_member_created", user_id);

                return user_id;
            }

            return 0;
        }

        public bool Update(Users data, int id)
        {
            this.hooks().ApplyFilters("before_update_user_member", data);

            if (this.is_admin())
            {
                if (id != this.get_staff_user_id())
                {
                    if (id == 1)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }

                data.Admin = 0;
            }

            int affectedRows = 0;
            if (affectedRows > 0)
            {
                this.hooks().DoAction("user_member_updated", id);
                this.log_activity("Staff Member Updated [ID: " + id + ", " + data.Firstname + " " + data.Lastname + "]");

                return true;
            }

            return false;
        }

        public bool UpdatePermissions(int id, dynamic _permissions)
        {
            var is_user_member = this.is_staff_member(id);

            foreach (PropertyDescriptor kvp in TypeDescriptor.GetProperties(_permissions))
            {
                var feature = kvp.Name;
                var capabilities = kvp.GetValue(_permissions);
                foreach (var capability in capabilities)
                {
                    if (feature == "leads" && !is_user_member)
                    {
                        continue;
                    }

                }
            }

            return true;
        }

        public bool update_profile(Users data)
        {
            this.hooks().ApplyFilters("before_user_update_profile", data);

            if (string.IsNullOrEmpty(data.Password))
            {
                data.Password = String.Empty;
            }
            else
            {
                data.Password = PasswordHandler.CreatePasswordHash(data.Password);
                data.LastPasswordChange = SharePoint.Now;
            }

            int affected_rows = 0;
            using (var db = new DBContext())
            {
                db
                    .Entry(db.Users.Single(table => table.UserId == data.UserId))
                    .CurrentValues
                    .SetValues(data);
                affected_rows = db.SaveChanges();
            }

            if (affected_rows > 0)
            {
                this.hooks().DoAction("user_member_profile_updated", data);
                this.log_activity("Staff Profile Updated [Staff: " + this.get_staff_fullname(data.UserId) + "]");
                return true;
            }

            return false;
        }

        public bool ChangePassword(Users data)
        {
            this.hooks().ApplyFilters("before_user_change_password", data);
            var member = this.Get(data.UserId);
            if (member.Active == 0)
            {
                return true;
            }

            int affected_rows = 0;
            using (var db = new DBContext())
            {
                db
                    .Entry(db.Users.SingleOrDefault(table => table.UserId == data.UserId))
                    .CurrentValues
                    .SetValues(new Users()
                    {
                        Password = data.NewPassKey,
                        LastPasswordChange = DateTime.Now
                    });

                affected_rows = db.SaveChanges();
            }

            if (affected_rows > 0)
            {
                this.log_activity("Staff Password Changed [" + data.UserId + "]");
                return true;
            }

            return false;
        }

        public void change_user_status(int id, int status)
        {
            this.hooks().ApplyFilters("before_user_status_change", status);

            var user = this.Get(id);
            using (var db = new DBContext())
            {
                db
                    .Entry(db.Users.SingleOrDefault(table => table.UserId == id))
                    .CurrentValues
                    .SetValues(new Users()
                    {
                        Active = status
                    });
            }

            this.log_activity("Staff Status Changed [StaffID: " + id + " - Status(Active/Inactive): " + status + "]");
        }

        public bool get_logged_time_data(int id = 0, dynamic filter_data = default(ExpandoObject))
        {
            if (id == 0)
            {
                id = this.get_staff_user_id();
            }

            var result = new Dictionary<string, object>();

            result["timesheets"] = new List<string>();
            result["total"] = new List<string>();
            result["this_month"] = new List<string>();

            var first_day_this_month = DateTime.Now.ToString("Y-m-01");
            var last_day_this_month = DateTime.Now.ToString("Y-m-t 23:59:59");

            result["last_month"] = new List<string>();
            return false;
        }
    }

    public static class UsersModelExtension
    {
        private static UsersModel _instance = null;

        public static UsersModel users_model(this object source)
        {
            return _instance ??= new UsersModel();
        }
    }
}