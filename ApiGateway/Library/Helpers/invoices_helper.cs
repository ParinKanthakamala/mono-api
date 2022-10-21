using System;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Library.Services.Utilities;
using ApiGateway.Models;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;

namespace ApiGateway.Library.Helpers
{
    public static class invoices_helper
    {
        public static void get_invoice_total_left_to_pay(this object source, int id, int invoice_total = 0)
        {
        }

        public static bool is_invoices_email_overdue_notice_enabled(this object source)
        {
            using (var db = new DBContext())
            {
                return db.EmailTemplates
                    .Where(table => table.Slug == "invoice-overdue-notice" && table.Active == 1)
                    .ToList().Count > 0;
            }
        }

        public static bool is_invoices_overdue_reminders_enabled(this object source)
        {
            return source.is_invoices_email_overdue_notice_enabled()
                ;
        }

        public static void check_invoice_restrictions(this object source, int id, string hash)
        {
            if (!source.is_client_logged_in() && !source.is_staff_logged_in())
            {
                if (source.get_option<bool>("view_invoice_only_logged_in"))
                {
                }
            }

            var invoice_model = new InvoicesModel();

            var invoice = invoice_model.Get(id).FirstOrDefault();
            if (invoice != null || (invoice.Hash != hash))
            {
            }

            if (!source.is_staff_logged_in())
            {
                if (source.get_option<bool>("view_invoice_only_logged_in"))
                {
                    if (invoice.ClientId != source.get_client_user_id())
                    {
                    }
                }
            }
        }

        public static string format_invoice_status(this object source, object status, string classes = "",
            bool _label = true)
        {
            var id = Convert.ToInt32(status + "");

            var label_class = source.get_invoice_STATUS_label(id);
            var status_str = "";
            if (id == InvoicesModel.STATUS_UNPAID)
            {
                status_str = label("invoice_STATUS_unpaid");
            }
            else if (id == InvoicesModel.STATUS_PAID)
            {
                status_str = label("invoice_STATUS_paid");
            }
            else if (id == InvoicesModel.STATUS_PARTIALLY)
            {
                status_str = label("invoice_STATUS_not_paid_completely");
            }
            else if (id == InvoicesModel.STATUS_OVERDUE)
            {
                status_str = label("invoice_STATUS_overdue");
            }
            else if (id == InvoicesModel.STATUS_CANCELLED)
            {
                status_str = label("invoice_STATUS_cancelled");
            }
            else
            {
                status_str = label("invoice_STATUS_draft");
            }

            if (_label)
            {
                return "<span class='label label-" + label_class + " " + classes + " s-status invoice-status-" + id +
                       "'>" + status + "</span>";
            }

            return status_str;
        }

        public static string get_invoice_STATUS_label(this object source, int status)
        {
            var label_class = "";
            if (status == InvoicesModel.STATUS_UNPAID)
            {
                label_class = "danger";
            }
            else if (status == InvoicesModel.STATUS_PAID)
            {
                label_class = "success";
            }
            else if (status == InvoicesModel.STATUS_PARTIALLY)
            {
                label_class = "warning";
            }
            else if (status == InvoicesModel.STATUS_OVERDUE)
            {
                label_class = "warning";
            }
            else if (status == InvoicesModel.STATUS_CANCELLED || status == InvoicesModel.STATUS_DRAFT)
            {
                label_class = "default";
            }
            else
            {
            }

            return label_class;
        }

        public static string invoice_STATUS_color_pdf(this object source, int STATUS_id)
        {
            var statusColor = "";
            if (STATUS_id == InvoicesModel.STATUS_UNPAID)
            {
                statusColor = "252, 45, 66";
            }
            else if (STATUS_id == InvoicesModel.STATUS_PAID)
            {
                statusColor = "0, 191, 54";
            }
            else if (STATUS_id == InvoicesModel.STATUS_PARTIALLY)
            {
                statusColor = "255, 111, 0";
            }
            else if (STATUS_id == InvoicesModel.STATUS_OVERDUE)
            {
                statusColor = "255, 111, 0";
            }
            else if (STATUS_id == InvoicesModel.STATUS_CANCELLED || STATUS_id == InvoicesModel.STATUS_DRAFT)
            {
                statusColor = "114, 123, 144";
            }

            return statusColor;
        }

        public static bool update_invoice_status(this object source, int id, bool force_update = false,
            bool prevent_logging = false)
        {
            var invoice_model = new InvoicesModel();
            var invoice = invoice_model.Get(id).FirstOrDefault();

            var original_status = invoice.Status;
            if ((original_status == InvoicesModel.STATUS_DRAFT && force_update == false)
                || (original_status == InvoicesModel.STATUS_CANCELLED && force_update == false))
            {
                return false;
            }

            using (var db = new DBContext())
            {
                var payments = db.InvoicePaymentRecords.Where(table => table.InvoiceId == id)
                    .OrderBy(table => table.Id)
                    .ToList();
            }

            var credit_notes_model = new CreditNotesModel();
            var credits = credit_notes_model.GetAppliedInvoiceCredits(id);
            var status = InvoicesModel.STATUS_UNPAID;

            var affected_rows = 0;
            using (var db = new DBContext())
            {
                var entry = db.Invoices.FirstOrDefault(table => table.InvoiceId == id);
                if (entry != null)
                {
                    db.Entry(entry).CurrentValues.SetValues(entry);
                    affected_rows = db.SaveChanges();
                }
            }

            if (affected_rows > 0)
            {
                hooks().DoAction("invoice_STATUS_changed", new {invoice_id = id, status = status});
                if (prevent_logging)
                {
                }

                var additional_activity = new
                {
                };
            }

            return false;
        }


        public static bool is_last_invoice(this object source, int id)
        {
            var invoice = new Invoices();
            using (var db = new DBContext())
            {
                invoice = db.Invoices
                    .OrderByDescending(table => table.InvoiceId)
                    .Take(1)
                    .FirstOrDefault();
            }

            var last_invoice_id = invoice.InvoiceId;
            return (last_invoice_id == id);
        }

        public static dynamic format_invoice_number(this object source, int id)
        {
            var invoice = new Invoices();
            using (var db = new DBContext())
            {
                invoice = db.Invoices.FirstOrDefault(table => table.InvoiceId == id);
                if (invoice != null)
                {
                    return "";
                }
            }

            var number = source.sales_number_format(invoice.Number, invoice.NumberFormat, invoice.Prefix, invoice.Date);
            return hooks().ApplyFilters("format_invoice_number", new
            {
                id = id,
                number = number,
                invoice = invoice
            });
        }

        public static List<ItemTax> get_invoice_item_taxes(this object source, int itemid)
        {
            var taxes = new List<ItemTax>();
            using (var db = new DBContext())
            {
                taxes =
                    db.ItemTax
                        .Where(table => table.Itemid == itemid && table.RelType == "invoice")
                        .ToList();
            }

            var i = 0;
            taxes.ForEach((tax) => { taxes[i++].TaxName = tax.TaxName + "|" + tax.TaxRate; });
            return taxes;
        }

        public static bool is_payment_mode_allowed_for_invoice(this object source, int id, int invoiceid)
        {
            return false;
        }

        public static void found_invoice_mode(this object source, List<object> modes, int invoiceid,
            bool offline = true, bool show_on_pdf = false)
        {
        }

        public static void get_invoices_percent_by_status(this object source, string status)
        {
        }

        public static bool staff_has_assigned_invoices(this object source, int staff_id = 0)
        {
            staff_id = (staff_id > 0) ? staff_id : source.get_staff_user_id();
            // var cache = app_object_cache().get("staff-total-assigned-invoices-" + staff_id);
            var result = 0;
            // if (cache.GetType() == typeof(int))
            // {
            //     result = Convert.ToInt32(cache);
            // }
            // else
            // {
            //     using (var db = new DBContext())
            //     {
            //         result = db.Invoices.Where(table => table.SaleAgent == staff_id).ToList().Count;
            //         // app_object_cache().Add("staff-total-assigned-invoices-" + staff_id, result);
            //     }
            // }

            return result > 0 ? true : false;
        }

        public static void load_invoices_total_template(this object source)
        {
        }

        public static void get_invoices_where_sql_for_staff(this object source, int staff_id)
        {
            var has_permission_view_own = Permission.CanViewOwn("invoices");
            var allow_staff_view_invoices_assigned = source.get_option<bool>("allow_staff_view_invoices_assigned");
            if (has_permission_view_own)
            {
            }
            else
            {
            }
        }

        public static bool user_can_view_invoice(this object source, int id, int staff_id = 0)
        {
            staff_id = staff_id > 0 ? staff_id : source.get_staff_user_id();

            if (Permission.Id(staff_id, "invoices", Permission.View))
            {
                return true;
            }

            using (var db = new DBContext())
            {
                var invoice = db.Invoices.FirstOrDefault(table => table.InvoiceId == id);
                if ((Permission.Id(staff_id, "invoices", Permission.ViewOwn) && invoice.AddedFrom == staff_id)
                    || (invoice.SaleAgent == staff_id && source.get_option<bool>("allow_staff_view_invoices_assigned")))
                {
                    return true;
                }
            }

            return false;
        }
    }
}