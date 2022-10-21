using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.System;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Url;

namespace ApiGateway.Library.Helpers
{
    public static class misc_helper
    {
        public static bool process_digital_signature_image(this object source, string partBase64, string path)
        {
            if (string.IsNullOrEmpty(partBase64))
            {
                return false;
            }

            source._maybe_create_upload_path(path);
            var filename = source.unique_filename(path, "signature.png");

            var decoded_image = Convert.FromBase64String(partBase64);

            var retval = false;

            path = path.TrimEnd('/') + "/" + filename;
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(decoded_image, 0, decoded_image.Length);
                retval = true;
                // SharePoint.processed_digital_signature = filename;
            }

            return retval;
        }

        public static Proposals get_acceptance_info_array(this object source)
        {
            var input = Url.input();
            var data = new Proposals();
            // data.Signature = SharePoint.processed_digital_signature;
            // data.AcceptanceFirstname = input.post["acceptance_firstname"];
            // data.AcceptanceLastname = input.post["acceptance_lastname"];
            // data.AcceptanceEmail = input.post["acceptance_email"];
            data.AcceptanceDate = DateTime.Now;
            data.AcceptanceIp = input.ip_address();
            hooks().ApplyFilters("acceptance_info_array", data);
            return data;
        }

        public static bool is_knowledge_base_viewable(this object source, bool excludeStaff = false)
        {
            return (source.get_option<bool>("use_knowledge_base")
                    && !source.is_client_logged_in()
                    && source.get_option<bool>("knowledge_base_without_registration"))
                   || (source.get_option<bool>("use_knowledge_base")
                       && source.is_client_logged_in())
                   || (excludeStaff == false
                       && source.is_staff_logged_in());
        }

        public static string get_alert_class(this object source)
        {
            var alert_class = "";
            if (session().Flashdata("message-success"))
            {
                alert_class = "success";
            }
            else if (session().Flashdata("message-warning"))
            {
                alert_class = "warning";
            }
            else if (session().Flashdata("message-info"))
            {
                alert_class = "info";
            }
            else if (session().Flashdata("message-danger"))
            {
                alert_class = "danger";
            }

            hooks().ApplyFilters("alert_class", alert_class);
            return alert_class;
        }

        public static List<Announcements> get_announcements_for_user(this object source, bool staff = true)
        {
            if (!source.is_logged_in())
            {
                return null;
            }

            var db = new DBContext();


            if (staff)
            {
            }
            else
            {
                var contact_id = source.get_contact_user_id();
                if (!source.is_client_logged_in())
                {
                    return default(List<Announcements>);
                }

                if (contact_id > 0)
                {
                }
                else
                {
                    return default(List<Announcements>);
                }
            }

            var announcements = db.Announcements.OrderByDescending(table => table.DateAdded).ToList();
            return (announcements != null)
                ? announcements
                : default(List<Announcements>);
        }

        public static string optimize_dropbox_thumbnail(this object source, string url, string bounding_box = "800")
        {
            url = url.Replace("bounding_box=75", "bounding_box=" + bounding_box);
            return url;
        }
    }
}