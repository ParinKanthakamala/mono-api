using System.Linq;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;

namespace ApiGateway.Library.Helpers
{
    public static class estimates_helper
    {
        public static string format_estimate_number(this object source, int? id)
        {
            using (var db = new DBContext())
            {
                var estimate = db.Estimates
                    .FirstOrDefault(table => table.EstimateId == id);
                if (estimate == null)
                {
                    return null;
                }

                var number = source.sales_number_format(
                    estimate.Number,
                    estimate.NumberFormat,
                    estimate.Prefix,
                    estimate.Date);
                var output = new
                {
                    id = id,
                    number = number,
                    estimate = estimate,
                };
                hooks().ApplyFilters("format_estimate_number", output);
                return "";
            }
        }


        public static string check_estimate_restrictions(this object source, int? id, string hash = "")
        {
            if (string.IsNullOrEmpty(hash) || !id.HasValue)
            {
                // source.Show404();
            }

            if (!source.is_client_logged_in() && !source.is_staff_logged_in())
            {
                if (source.get_option<bool>("view_estimate_only_logged_in"))
                {
                    // source.Redirect(base_url("authentication/login"));
                }
            }

            // var estimate = estimates_model().Get(id).FirstOrDefault();
            // if (estimate == null || (estimate.Hash != hash))
            // {
            //     // source.Show404();
            // }
            //
            // if (!source.is_staff_logged_in() && source.get_option<bool>("view_estimate_only_logged_in") &&
            //     estimate.ClientId != source.get_client_user_id())
            // {
            //     // Show404();
            // }

            return null;
        }

        public static bool staff_has_assigned_estimates(this object source, int staff_id = 0)
        {
            staff_id = staff_id > 0 ? staff_id : source.get_staff_user_id();
            // var cache = app_object_cache().get("staff-total-assigned-estimates-" + staff_id);
            var result = 0;
            // if (cache.GetType() == typeof(int))
            // {
            //     result = Convert.ToInt32(cache);
            // }
            // else
            // {
            //     using (var db = new DBContext())
            //     {
            //         result = db.Estimates.Where(table => table.SaleAgent == staff_id).ToList().Count;
            //         app_object_cache().Add("staff-total-assigned-estimates-" + staff_id, result);
            //     }
            // }

            return result > 0 ? true : false;
        }


        public static string format_estimate_status(this object source, int status, string classes = "",
            bool label = true)
        {
            var id = status;
            var label_class = source.estimate_status_color_class(status);

            if (label)
            {
                return "<span class='label label-" + label_class + " " + classes + " s-status estimate-status-" + id +
                       " estimate-status-" + label_class + "'>" + source.estimate_status_by_id(status) + "</span>";
            }

            return status + "";
        }


        public static string estimate_status_color_class(this object source, int id,
            bool replace_default_by_muted = false)
        {
            var @class = "";
            if (id == 1)
            {
                @class = "default";
                if (replace_default_by_muted)
                {
                    @class = "muted";
                }
            }
            else if (id == 2)
            {
                @class = "info";
            }
            else if (id == 3)
            {
                @class = "danger";
            }
            else if (id == 4)
            {
                @class = "success";
            }
            else if (id == 5)
            {
                @class = "warning";
            }
            else
            {
            }

            return @class;
        }


        public static string estimate_status_by_id(this object source, int id)
        {
            var status = label("not_sent_indicator");
            switch (id)
            {
                case 1:
                    status = label("estimate_status_draft");
                    break;
                case 2:
                    status = label("estimate_status_sent");
                    break;
                case 3:
                    status = label("estimate_status_declined");
                    break;
                case 4:
                    status = label("estimate_status_accepted");
                    break;
                case 5:
                    status = label("estimate_status_expired");
                    break;
            }

            return status;
        }
    }
}