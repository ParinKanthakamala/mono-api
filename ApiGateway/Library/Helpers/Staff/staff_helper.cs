using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Models;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Url;
using static ApiGateway.System.Language;
using static ApiGateway.Core.AppObjectCache;
using static ApiGateway.Core.Extensions.ModelPointExtension;


namespace ApiGateway.Library.Helpers.Staff
{
    public static class staff_helper
    {
        public static dynamic get_available_staff_permissions(this object source, dynamic data = default(ExpandoObject))
        {
            var viewGlobalName = label("permission_view") + "(" + label("permission_global") + ")";


            var allPermissionsArray = new
            {
                view_own = label("permission_view_own"),
                view = viewGlobalName,
                create = label("permission_create"),
                edit = label("permission_edit"),
                delete = label("permission_delete"),
            };
            var withoutViewOwnPermissionsArray = new
            {
                view = viewGlobalName,
                create = label("permission_create"),
                edit = label("permission_edit"),
                delete = label("permission_delete"),
            };
            var withNotApplicableViewOwn = Merger.Merge(new
            {
                view_own = new {not_applicable = true, name = label("permission_view_own")}
            }, withoutViewOwnPermissionsArray);
            var corePermissions = new
            {
                bulk_pdf_exporter = new
                {
                    name = label("bulk_pdf_exporter"),
                    capabilities = new
                    {
                        view = viewGlobalName,
                    },
                },
                contracts = new
                {
                    name = label("contracts"),
                    capabilities = allPermissionsArray,
                },
                credit_notes = new
                {
                    name = label("credit_notes"),
                    capabilities = allPermissionsArray,
                },
                customers = new
                {
                    name = label("clients"),
                    capabilities = withNotApplicableViewOwn,
                    help = new
                    {
                        view_own = label("permission_customers_based_on_admins"),
                    },
                },
                email_templates = new
                {
                    name = label("email_templates"),
                    capabilities = new
                    {
                        view = viewGlobalName,
                        edit = label("permission_edit"),
                    },
                },
                estimates = new
                {
                    name = label("estimates"),
                    capabilities = allPermissionsArray,
                },
                expenses = new
                {
                    name = label("expenses"),
                    capabilities = allPermissionsArray,
                },
                invoices = new
                {
                    name = label("invoices"),
                    capabilities = allPermissionsArray,
                },
                items = new
                {
                    name = label("items"),
                    capabilities = withoutViewOwnPermissionsArray,
                },
                knowledge_base = new
                {
                    name = label("knowledge_base"),
                    capabilities = withoutViewOwnPermissionsArray,
                },
                payments = new
                {
                    name = label("payments"),
                    capabilities = withNotApplicableViewOwn,
                    help = new
                    {
                        view_own = label("permission_payments_based_on_invoices"),
                    },
                },
                projects = new
                {
                    name = label("projects"),
                    capabilities = withNotApplicableViewOwn,
                    help = new
                    {
                        view = label("help_project_permissions"),
                        view_own = label("permission_projects_based_on_assignee"),
                    },
                },
                proposals = new
                {
                    name = label("proposals"),
                    capabilities = allPermissionsArray,
                },
                reports = new
                {
                    name = label("reports"),
                    capabilities = new
                    {
                        view = viewGlobalName,
                    },
                },
                roles = new
                {
                    name = label("roles"),
                    capabilities = withoutViewOwnPermissionsArray,
                },
                settings = new
                {
                    name = label("settings"),
                    capabilities = new
                    {
                        view = viewGlobalName,
                        edit = label("permission_edit"),
                    },
                },
                staff = new
                {
                    name = label("staff"),
                    capabilities = withoutViewOwnPermissionsArray,
                },
                subscriptions = new
                {
                    name = label("subscriptions"),
                    capabilities = allPermissionsArray,
                },
                tasks = new
                {
                    name = label("tasks"),
                    capabilities = withNotApplicableViewOwn,
                    help = new
                    {
                        view = label("help_tasks_permissions"),
                        view_own = label("permission_tasks_based_on_assignee"),
                    },
                },
                checklist_templates = new
                {
                    name = label("checklist_templates"),
                    capabilities = new
                    {
                        create = label("permission_create"),
                        delete = label("permission_delete"),
                    },
                },
            };

            hooks().ApplyFilters("staff_permissions", new {core_permission = corePermissions, data});
            return null;
        }

        public static Users get_staff(this object source, int id = 0)
        {
            if (id == 0 && model_point().current_user != null)
            {
                return model_point().current_user;
            }

            return id == 0 ? null : source.users_model().Get(id);
        }

        public static string staff_profile_image_url(this object source, int userId, string type = "small")
        {
            var url = base_url("assets/images/user-placeholder.jpg");

            Users user;
            using (var db = new DBContext())
            {
                if (userId == source.get_staff_user_id() && model_point().current_user != null)
                {
                    user = model_point().current_user;
                }
                else
                {
                    user = db.Users.FirstOrDefault(table => table.UserId == userId);
                }
            }


            if (user == null) return url;
            if (string.IsNullOrEmpty(user.ProfileImage)) return url;


            var profileImagePath = "uploads/staff_profile_images/" + userId + "/" + type + "_" + user.ProfileImage;
            if (File.Exists(profileImagePath))
            {
                url = base_url(profileImagePath);
            }

            return url;
        }


        public static string get_staff_fullname(this object source, int userId = 0)
        {
            var tmpStaffuserId = source.get_staff_user_id();
            if (userId > 0 || userId == tmpStaffuserId)
            {
                if (model_point().current_user != null)
                {
                    return model_point().current_user.Firstname + " " +
                           model_point().current_user.Lastname;
                }

                userId = tmpStaffuserId;
            }

            var staff = app_object_cache().get("staff-full-name-data-" + userId);
            if (staff == null) return "";
            using (var db = new DBContext())
            {
                staff = db.Users.FirstOrDefault(table => table.UserId == userId);
            }

            app_object_cache().add("staff-full-name-data-" + userId, staff);

            return "";
        }

        public static string get_staff_default_language(this object source, int userId = 0)
        {
            if (userId == 0)
            {
                if (model_point().current_user != null)
                {
                    return model_point().current_user.DefaultLanguage;
                }
            }

            var staffId = source.get_staff_user_id();

            using (var db = new DBContext())
            {
                var user = db.Users.FirstOrDefault(table => table.UserId == staffId);
                if (user != null)
                {
                    return user.DefaultLanguage;
                }
            }

            return "";
        }

        public static List<UserMeta> get_staff_recent_search_history(this object source, int staffId = 0)
        {
            var recentSearches =
                source.get_staff_meta(staffId > 0 ? staffId : source.get_staff_user_id(), "recent_searches");
            if (recentSearches == null)
            {
                recentSearches = new List<UserMeta>();
            }
            else
            {
            }

            return recentSearches;
        }

        public static string update_staff_recent_search_history(this object source, string history, int staffId = 0)
        {
            var totalRecentSearches = hooks().ApplyFilters("total_recent_searches", 5);
            return history;
        }

        public static bool is_staff_member(this object source, int staffId = 0)
        {
            if (staffId == 0)
            {
                if (model_point().current_user != null)
                {
                    return model_point().current_user.IsNotStaff == 0;
                }

                staffId = source.get_staff_user_id();
            }

            var db = new DBContext();
            var users = db.Users.Where(table => table.UserId == staffId && table.IsNotStaff == 0).ToList();
            return (users.Count > 0);
        }
    }
}