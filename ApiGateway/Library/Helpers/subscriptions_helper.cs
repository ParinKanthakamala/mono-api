using System.Collections.Generic;

namespace ApiGateway.Library.Helpers
{
    public static class subscriptions_helper
    {
        // public static List<Html> get_subscriptions_statuses(this object source)
        public static List<object> get_subscriptions_statuses(this object source)
        {
            return null;
            // return hooks().ApplyFilters("subscription_statuses", new List<Html>()
            // {
            //     new Html()
            //     {
            //         color = "#84c529",
            //         id = "active",
            //         filter_default = true
            //     },
            //     new Html()
            //     {
            //         color = "#84c529",
            //         id = "future",
            //         filter_default = true
            //     },
            //     new Html()
            //     {
            //         color = "#ff6f00",
            //         id = "past_due",
            //         filter_default = true
            //     },
            //     new Html()
            //     {
            //         color = "#fc2d42",
            //         id = "unpaid",
            //         filter_default = true
            //     },
            //     new Html()
            //     {
            //         color = "#777",
            //         id = "canceled",
            //         filter_default = false
            //     }
            // });
        }


        // public static List<Html> subscriptions_summary(this object source)
        // {
        //     var statuses = source.get_subscriptions_statuses();
        //     var has_permission_view = Permission.CanView("subscriptions");
        //     var summary = new List<Html>();
        //     foreach (var status in statuses)
        //     {
        //         using (var db = new DBContext())
        //         {
        //             var total_rows = 0;
        //             total_rows = (Permission.CanView("subscriptions"))
        //                 ? db.Subscriptions.Where(table => table.Status == status.id).ToList().Count
        //                 : db.Subscriptions.Where(table =>
        //                         table.Status == status.id && table.CreatedFrom == source.get_staff_user_id()).ToList()
        //                     .Count;
        //
        //
        //             // summary.Add(new Html()
        //             // {
        //             //     total = total_rows,
        //             //     color = status.color,
        //             //     id = status.id
        //             // });
        //         }
        //     }
        //
        //     return summary;
        // }

        public static bool can_logged_in_contact_view_subscriptions(this object source)
        {
            if (!source.is_client_logged_in())
            {
                return false;
            }

            // return source.get_option<bool>("show_subscriptions_in_customers_area")
            //        && ((Contacts) SharePoint.GLOBALS["contact"]).IsPrimary == 1
            //        && source.customer_has_subscriptions(((Contacts) SharePoint.GLOBALS["contact"]).UserId);
            return false;
        }

        public static bool can_logged_in_contact_update_credit_card(this object source)
        {
            return source.is_client_logged_in();
        }
    }
}