using System;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Services
{
    public class ViewsTrackingService
    {
        public static List<ViewsTracking> get(string rel_type, int rel_id)
        {
            using (var db = new DBContext())
            {
                db.ViewsTracking.Where(table => table.RelId == rel_id && table.RelType == rel_type)
                    .OrderByDescending(table => new {table.Date}).ToList();
            }

            return null;
        }

        public static bool create(string rel_type, int rel_id)
        {
            if (!"".is_staff_logged_in())
            {
                ViewsTracking row = null;
                using (var db = new DBContext())
                {
                    row = db.ViewsTracking.Where(table => table.RelId == rel_id && table.RelType == rel_type)
                        .OrderByDescending(table => new {table.ViewsTrackingId})
                        .Take(1)
                        .FirstOrDefault();
                }


                if (row != null)
                {
                    var dateFromDatabase = row.Date;
                    var date1HourAgo = DateTime.Parse("-1 hours");
                    if (dateFromDatabase >= date1HourAgo)
                    {
                        return false;
                    }
                }
            }
            else
            {
                // Staff logged in, nothing to do here
                return false;
            }

            hooks().DoAction("before_insert_views_tracking", new
            {
                rel_id = rel_id,
                rel_type = rel_type,
            });

            var notifiedUsers = new { };
            var members = new { };
            var notification_data = new { };

            if (rel_type == "invoice" || rel_type == "proposal" || rel_type == "estimate")
            {
                var notification_link = "proposals/list_proposals/" + rel_id;
                if (rel_type == "invoice")
                {
                    notification_link = "invoices/list_invoices/" + rel_id;
                }

                else if (rel_type == "estimate")
                {
                    notification_link = "estimates/list_estimates/" + rel_id;
                }


                //                notification_data = Newtonsoft.Json.JsonConvert.DeserializeObject(notification_data);


                //                CI.db.select("addedfrom," + responsible_column)
                //                    .where("id", rel_id);
                //
                //                var rel = CI.db.get(table).row();
                //
                //
                //
                //                CI.db.select("staffid")
                //                    .where("staffid", rel.addedfrom)
                //                    .or_where("staffid", rel.{
                //                    responsible_column
                //                });
                //
                //                members = CI.db.get("staff").result_array();
                //                SharePoint.DbContext
                //                    .Users //.Select(table=>table.user_id)
                //                    .Where(table => table.user_id == rel.addedfrom)
                // 
            }

            var newdata = new ViewsTracking()
            {
                RelId = rel_id,
                RelType = rel_type,
                Date = DateTime.Now,
                // ViewIp = Input.Instance.ip_address()
            };
            using (var db = new DBContext())
            {
                db.Add(newdata);
                db.SaveChanges();
            }

            var view_id = newdata.ViewsTrackingId;
            if (view_id > 0)
            {
                //                foreach (var member in members)
                //                {
                //                    // E.q. had permissions create not don"t have, so we must re-check this
                ////                    if (! canViewFunction(rel_id, member["staffid"]))
                ////                    {
                ////                        continue;
                ////                    }
                //
                //                    var notification = new Notifications()
                //                    {
                //                        from_company = true,
                //                        to_user_id = member.user_id,
                //                        description = notification_description
                ////                        link = notification_link,
                ////                        additional_data = notification_data
                //                    }
                //
                //
                //                    if ("".is_client_logged_in())
                //                    {
                //                        notification.from_company = false;
                //                    }
                //
                //                    var notified = "".add_notification(notification);
                //                    if (notified)
                //                    {
                ////                        array_push(notifiedUsers, member["staffid"]);
                //                    }
                //                }

                //                "".pusher_trigger_notification(notifiedUsers);
            }

            return false;
        }
    }
}