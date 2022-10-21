using System;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class emails_tracking_helper
    {
        public static EmailTemplates email_tracking_inject_in_body(this object source, EmailTemplates template)
        {
            using (var db = new DBContext())
            {
                if (source.get_available_tracking_templates_slugs().Contains(template.Slug))
                {
                }
            }

            return template;
        }

        public static void add_email_tracking(this object source, dynamic data)
        {
            if (source.get_available_tracking_templates_slugs().Contains(data.template.slug)
                && !string.IsNullOrEmpty(data.template.has_tracking)
                && data.template.has_tracking
            )
            {
                using (var db = new DBContext())
                {
                    db.Add(new TrackedMails()
                    {
                        Uid = data.template.tmp_id,
                        Subject = data.template.subject,
                        Date = DateTime.Now,
                        Email = data.email
                    });
                    db.SaveChanges();
                }
            }
        }

        public static List<TrackedMails> get_tracked_emails(this object source, int rel_id, string rel_type)
        {
            using (var db = new DBContext())
            {
                return
                    db.TrackedMails.Where(table => table.RelId == rel_id && table.RelType == rel_type)
                        .OrderByDescending(table => table.Date)
                        .ToList();
            }
        }

        public static int delete_tracked_emails(this object source, int rel_id, string rel_type)
        {
            using (var db = new DBContext())
            {
                var entry = db.TrackedMails.FirstOrDefault(table => table.RelId == rel_id && table.RelType == rel_type);
                if (entry != null)
                {
                    db.Remove(entry);
                    return db.SaveChanges();
                }
            }

            return 0;
        }

        public static List<string> get_available_tracking_templates_slugs(this object source)
        {
            var slugs = new List<string>()
            {
                "invoice-send-to-client",
                "invoice-already-send",
                "invoice-overdue-notice",
                "estimate-send-to-client",
                "estimate-already-send",
                "estimate-expiry-reminder",
                "proposal-send-to-customer",
                "proposal-expiry-reminder",
                "proposal-comment-to-client",
                "credit-note-send-to-client",
                "send-contract",
                "send-subscription",
                "subscription-payment-failed",
            };

            hooks().ApplyFilters("available_tracking_templates", slugs);
            return slugs;
        }
    }
}