using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Models;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class credit_notes_helper
    {
        public static decimal total_credits_applied_to_invoice(this object source, int id)
        {
            using (var db = new DBContext())
            {
                return db.Credits.Where(table => table.InvoiceId == id).Sum(table => table.Amount);
            }
        }

        public static string credit_note_STATUS_color_pdf(this object source, int STATUS_id)
        {
            var statusColor = "";

            if (STATUS_id == 1)
            {
                statusColor = "3, 169, 244";
            }
            else if (STATUS_id == 2)
            {
                statusColor = "132, 197, 41";
            }
            else
            {
                statusColor = "119, 119, 119";
            }

            return statusColor;
        }

        public static List<int> invoices_statuses_available_for_credits(this object source)
        {
            var output = new List<int>()
            {
                InvoicesModel.STATUS_UNPAID,
                InvoicesModel.STATUS_PARTIALLY,
                InvoicesModel.STATUS_DRAFT,
                InvoicesModel.STATUS_OVERDUE
            };

            hooks().ApplyFilters("invoices_statuses_available_for_credits");
            return output;
        }

        public static bool credits_can_be_applied_to_invoice(this object source, int STATUS_id)
        {
            return source.invoices_statuses_available_for_credits().Contains(STATUS_id);
        }

        public static bool is_last_credit_note(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var last_credit_note = db.CreditNotes.OrderByDescending(table => table.CreditNoteId).Take(1)
                    .SingleOrDefault();
                return (last_credit_note != null && last_credit_note.CreditNoteId == id);
            }
        }

        public static dynamic format_credit_note_number(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var credit_note = db.CreditNotes.FirstOrDefault(table => table.CreditNoteId == id);

                if (credit_note == null)
                {
                    return "";
                }

                var number = source.sales_number_format(credit_note.Number,
                    credit_note.NumberFormat,
                    credit_note.Prefix,
                    credit_note.Date);

                var output = new
                {
                    id = id,
                    number = number,
                    credit_note = credit_note
                };
                return hooks().ApplyFilters("format_credit_note_number", output);
            }
        }

        public static string format_credit_note_status(this object source, int status, bool text = false)
        {
            var credit_notes_model = new CreditNotesModel();
            var statuses = credit_notes_model.GetStatuses();
            dynamic statusArray = new ExpandoObject();
            foreach (var s in statuses)
            {
                if (s.id == status)
                {
                    statusArray = s;
                    break;
                }
            }

            if (text)
            {
                return statusArray.name;
            }

            var @class = "";

            var style = "border: 1px solid " + statusArray.color + ";color:" + statusArray.color +
                        ";class='label s-status'";
            return "<span class='" + @class + "' style='" + style + "'>" + statusArray.name + "</span>";
        }

        public static List<ItemTax> get_credit_note_item_taxes(this object source, int itemid)
        {
            using (var db = new DBContext())
            {
                var taxes = db.ItemTax.Where(table => table.Itemid == itemid && table.RelType == "credit_note")
                    .ToList();

                var i = 0;
                foreach (var tax in taxes)
                {
                    taxes[i++].TaxName = tax.TaxName + "|" + tax.TaxRate;
                }

                return taxes;
            }
        }
    }
}