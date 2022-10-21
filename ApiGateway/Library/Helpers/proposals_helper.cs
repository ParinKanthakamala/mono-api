using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Library.Services.Utilities;
using ApiGateway.Models;
using static ApiGateway.System.Language;

namespace ApiGateway.Library.Helpers
{
    public static class proposals_helper
    {
        public static void check_proposal_restrictions(this object source, int id = 0, string hash = null)
        {
            if (string.IsNullOrEmpty(hash) || id == 0)
            {
            }

            var proposals_model = new ProposalsModel();
            var proposal = proposals_model.Get(id).FirstOrDefault();
            if (proposal == null || (proposal.Hash != hash))
            {
            }
        }

        public static bool is_proposals_email_expiry_reminder_enabled(this object source)
        {
            var total_rows = 0;
            using (var db = new DBContext())
            {
                total_rows = db
                    .EmailTemplates
                    .Where(table => table.Slug == "proposal-expiry-reminder" && table.Active == 1).ToList().Count;
            }


            return (total_rows > 0);
        }

        public static bool is_proposals_expiry_reminders_enabled(this object source)
        {
            return (bool) source.is_proposals_email_expiry_reminder_enabled()
                ;
        }

        public static string proposal_status_color_class(this object source, int id,
            bool replace_default_by_muted = false)
        {
            var className = "";
            if (id == 1)
            {
                className = "default";
            }
            else if (id == 2)
            {
                className = "danger";
            }
            else if (id == 3)
            {
                className = "success";
            }
            else if (id == 4 || id == 5)
            {
                className = "info";
            }
            else if (id == 6)
            {
                className = "default";
            }

            if (className == "default")
            {
                if (replace_default_by_muted)
                {
                    className = "muted";
                }
            }

            return className;
        }

        public static string format_proposal_status(this object source, object _status, string classes = "",
            bool _label = true)
        {
            var status = Convert.ToInt32(_status + "");
            var label_class = "";
            var status_str = "";
            if (status == 1)
            {
                status_str = label("proposal_status_open");
                label_class = "default";
            }
            else if (status == 2)
            {
                status_str = label("proposal_status_declined");
                label_class = "danger";
            }
            else if (status == 3)
            {
                status_str = label("proposal_status_accepted");
                label_class = "success";
            }
            else if (status == 4)
            {
                status_str = label("proposal_status_sent");
                label_class = "info";
            }
            else if (status == 5)
            {
                status_str = label("proposal_status_revised");
                label_class = "info";
            }
            else if (status == 6)
            {
                status_str = label("proposal_status_draft");
                label_class = "default";
            }

            if (_label)
            {
                return "<span class='label label-" + label_class + " " + classes + " s-status proposal-status-" +
                       status + "'>" + status_str + "</span>";
            }

            return status_str;
        }

        public static string format_proposal_number(this object source, int id)
        {
            var proposal_number_prefix = source.get_option<string>("proposal_number_prefix");
            return proposal_number_prefix;
        }

        public static List<ItemTax> get_proposal_item_taxes(this object source, int itemid)
        {
            var taxes = new List<ItemTax>();
            using (var db = new DBContext())
            {
                taxes = db.ItemTax
                    .Where(table => table.Itemid == itemid && table.RelType == "proposal")
                    .ToList();
            }

            var i = 0;
            foreach (var tax in taxes)
            {
                taxes[i++].TaxName = tax.TaxName + "|" + tax.TaxRate;
            }

            return taxes;
        }

        public static IList get_proposals_percent_by_status(this object source, int status, string total_proposals = "")
        {
            var has_permission_view = Permission.CanView("proposals");
            var has_permission_view_own = Permission.CanViewOwn("proposals");
            var allow_staff_view_proposals_assigned = source.get_option<bool>("allow_staff_view_proposals_assigned");
            var staffId = source.get_staff_user_id();
            //var whereUser = "";
            return null;
        }

        public static List<string> get_proposal_templates(this object source)
        {
            var proposal_templates = new List<string>();
            if (Directory.Exists("admin/proposals/templates"))
            {
            }

            return proposal_templates;
        }

        public static bool user_can_view_proposal(this object source, int id, int staff_id = 0)
        {
            staff_id = staff_id > 0 ? staff_id : source.get_staff_user_id();
            if (Permission.Id(staff_id, "proposals", Permission.View))
            {
                return true;
            }

            using (var db = new DBContext())
            {
                var proposal = db.Proposals.FirstOrDefault(table => table.ProposalId == id);

                if ((Permission.Id(staff_id, "proposals", Permission.ViewOwn)
                     && proposal.AddedFrom == staff_id)
                    || (proposal.Assigned == staff_id
                        && source.get_option<bool>("allow_staff_view_proposals_assigned")))
                {
                    return true;
                }
            }

            return false;
        }

        public static void parse_proposal_content_merge_fields(this object source, Proposals proposal)
        {
            var id = proposal.ProposalId;
        }

        public static bool staff_has_assigned_proposals(this object source, int staff_id = 0)
        {
            staff_id = staff_id > 0 ? staff_id : source.get_staff_user_id();
            var result = 0;
            // var cache = app_object_cache().get("staff-total-assigned-proposals-" + staff_id);
            // if (cache.GetType() == typeof(int))
            // {
            //     result = Convert.ToInt32(cache);
            // }
            // else
            // {
            //     using (var db = new DBContext())
            //     {
            //         result = db.Proposals.Where(table => table.Assigned == staff_id).ToList().Count;
            //         app_object_cache().Add("staff-total-assigned-proposals-" + staff_id, result);
            //     }
            // }

            return result > 0 ? true : false;
        }

        public static string get_proposals_sql_where_staff(this object source, int staff_id)
        {
            var has_permission_view_own = Permission.CanViewOwn("proposals");
            var allow_staff_view_invoices_assigned = source.get_option<bool>("allow_staff_view_proposals_assigned");
            var whereUser = "";
            if (has_permission_view_own)
            {
            }
            else
            {
            }

            return whereUser;
        }
    }
}