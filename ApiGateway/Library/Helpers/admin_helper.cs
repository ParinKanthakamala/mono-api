using System.IO;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers.Staff;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Url;

namespace ApiGateway.Library.Helpers
{
    public static class admin_helper
    {
        public static void app_admin_head(this object source)
        {
            hooks().DoAction("app_admin_head");
        }

        public static void app_admin_footer(this object source)
        {
            hooks().DoAction("app_admin_footer");
        }

        public static void init_head(this object source, bool aside = true)
        {
            if (aside)
            {
            }
        }

        public static void init_tail()
        {
        }


        public static string admin_url(this object source, string url = "")
        {
            return base_url("admin/" + url);
        }

        public static bool staff_can(this object source, string capability, object feature = null, int staff_id = 0)
        {
            staff_id = staff_id == 0 ? source.get_staff_user_id() : staff_id;

            if (source.is_admin(staff_id))
            {
                return true;
            }


            return false;
        }

        public static bool has_role_permission(this object source, int role_id, string capability, string feature)
        {
            using (var db = new DBContext())
            {
                var roles = db.Roles.ToList();
                roles.ForEach((role) => { });
            }

            return false;
        }

        public static string load_admin_language(this object source, int staff_id = 0)
        {
            var language = source.get_option<string>("active_language");
            if (source.is_staff_logged_in() || staff_id > 0)
            {
                var staff_language = source.get_staff_default_language(staff_id);
                if (!string.IsNullOrEmpty(staff_language) && File.Exists("language/" + staff_language))
                {
                    language = staff_language;
                }
            }

            if (File.Exists("language/" + language + "/custom_lang.lang"))
            {
            }

            // SharePoint.Language = language;
            // SharePoint.Local = source.get_locale_key(language);

            hooks().DoAction("after_load_admin_language", language);

            return language;
        }


        public static string get_admin_uri(this object source)
        {
            return "admin/";
        }

        public static bool is_admin(this object source, int staff_id = 0)
        {
            if (staff_id > 0)
            {
                // if (model_point().current_user != null)
                // {
                //     return model_point().current_user.Admin == 1;
                // }

                staff_id = source.get_staff_user_id();
            }

            using (var db = new DBContext())
            {
                return (db.Users.Where(
                    table => table.Admin == 1
                             && table.UserId == staff_id
                ).ToList().Count > 0);
            }
        }

        public static void admin_body_class(this object source, string className = "")
        {
        }

        public static void get_admin_body_class(this object source, string className = "")

        {
        }


        public static void render_admin_js_variables()
        {
        }

        public static void _maybe_system_setup_warnings(this object source)
        {
        }
    }
}