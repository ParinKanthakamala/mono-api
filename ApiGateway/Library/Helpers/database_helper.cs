using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers.Staff;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class database_helper
    {
        public static bool is_reference_in_table(this object source, string field, string table, int? id)
        {
            return false;
        }


        public static void add_views_tracking(this object source, string rel_type, int rel_id)
        {
        }

        public static List<ViewsTracking> get_views_tracking(this object source, string rel_type, int rel_id)
        {
            using (var db = new DBContext())
            {
                return db.ViewsTracking.Where(
                        table =>
                            table.RelId == rel_id
                            && table.RelType == rel_type)
                    .OrderByDescending(table => new {table.Date})
                    .ToList();
            }
        }

        public static void log_activity(this object source, string description, int user_id = 0)
        {
            var log = new ActivityLog()
            {
                Description = description,
                Date = DateTime.Now
            };


            using (var db = new DBContext())
            {
                db.ActivityLog.Add(log);
                db.SaveChanges();
            }
        }

        public static ActivityLog get_last_system_activity_id(this object source)
        {
            using (var db = new DBContext())
            {
                return db.ActivityLog
                    .OrderByDescending(table => table.ActivityLogId)
                    .Take(1)
                    .FirstOrDefault();
            }
        }

        public static bool add_notification(this object source, Notifications data)
        {
            if (source.is_client_logged_in())
            {
                data.FromUserId = 0;
                data.FromClientId = source.get_contact_user_id();
                data.FromFullname = source.get_contact_full_name(source.get_contact_user_id());
            }
            else
            {
                data.FromUserId = source.get_staff_user_id();
                data.FromClientId = 0;
                data.FromFullname = source.get_staff_fullname(source.get_staff_user_id());
            }

            data.Date = DateTime.Now;
            hooks().ApplyFilters("notification_data", data);

            if (data.ToUserId != 0)
            {
                using (var db = new DBContext())
                {
                    var user = db.Users.FirstOrDefault(table => table.UserId == data.ToUserId);

                    if (user != null && user.Active == 0)
                    {
                        return false;
                    }
                }
            }

            using (var db = new DBContext())
            {
                db.Notifications.Add(data);
                db.SaveChanges();
            }

            hooks().DoAction("notification_created", data.NotificationId);
            return true;
        }

        public static void total_rows(string table, dynamic where = default(ExpandoObject))
        {
        }

        public static void sum_from_table(this object source, string table, dynamic attr = default(ExpandoObject))
        {
        }

        public static void prefixed_table_fields_wildcard(this object source, string table, string alias, string field)
        {
        }

        public static void prefixed_table_fields_array(this object source, string table, bool @string = false,
            List<string> exclude = default(List<string>))
        {
        }

        public static void prefixed_table_fields_string(this object source, string table,
            List<string> exclude = default(List<string>))
        {
        }

        public static string get_department_email(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var department = db.Departments.FirstOrDefault(table => table.DepartmentId == id);
                return (department != null) ? department.Email : "";
            }
        }


        public static void add_foreign_key(string table, string foreign_key, string references,
            string on_delete = "RESTRICT", string on_update = "RESTRICT")
        {
        }

        public static void drop_foreign_key(string table, string foreign_key)
        {
        }


        public static void add_trigger(string trigger_name, string table, string statement, string time = "BEFORE",
            string @event = "INSERT", string type = "FOR EACH ROW")
        {
        }


        public static void drop_trigger(string trigger_name)
        {
        }

        public static void table_exists(string table)
        {
        }
    }
}