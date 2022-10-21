using ApiGateway.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;
namespace ApiGateway.Models
{
    public class CreditNotesModel : MyModel
    {
        private InvoicesModel invoices_model;

        private List<string> shipping_fields = new List<string>()
        {
            "shipping_street",
            "shipping_city",
            "shipping_city",
            "shipping_state",
            "shipping_zip",
            "shipping_country"
        };

        public List<dynamic> GetStatuses()
        {
            var output = new List<dynamic>()
            {
                new
                {
                    id = 1,
                    color = "#03a9f4",
                    name = label("credit_note_status_open"),
                    order = 1,
                    filter_default = true,
                },
                new
                {
                    id = 2,
                    color = "#84c529",
                    name = label("credit_note_status_closed"),
                    order = 2,
                    filter_default = true,
                },
                new
                {
                    id = 3,
                    color = "#777",
                    name = label("credit_note_status_void"),
                    order = 3,
                    filter_default = false,
                }
            };
            hooks().ApplyFilters("before_get_credit_notes_statuses", output);
            return output;
        }

        public void GetAvailableCreditableInvoices(int credit_note_id)
        {
        }

        public bool SendCreditNoteToClient(int id, bool attachpdf = true, string cc = "", bool manually = false)
        {
            var clients_model = new ClientsModel();
            var credit_note = this.Get(id);
            int number = this.format_credit_note_number(credit_note.CreditNoteId);
            var sent = false;

            if (manually)
            {
                var contacts = clients_model
                    .GetContacts(credit_note.ClientId, new { active = 1, credit_note_emails = 1 });
                foreach (var contact in contacts)
                {
                }
            }

            if (sent == false) return false;

            hooks().DoAction("credit_note_sent", id);

            return true;
        }

        public CreditNotes Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public bool Add(CreditNotes data)
        {
            return false;
        }

        public bool Update(int id, CreditNotes data)
        {
            return false;
        }

        public bool DeleteAttachment(int id)
        {
            var misc_model = new MiscModel();
            var attachment = misc_model.GetFile(id);
            var deleted = false;
            if (attachment != default(Files))
            {
                if (string.IsNullOrEmpty(attachment.External))
                {
                }

                var affected_rows = 0;
                if (affected_rows > 0)
                {
                    deleted = true;
                }

            }

            return deleted;
        }

        public List<Files> GetAttachments(int credit_note_id)
        {
            return null;
        }

        public bool Delete(int id, bool simple_delete = false)
        {
            hooks().DoAction("before_credit_note_deleted", id);
            var affected_rows = 0;

            if (affected_rows > 0)
            {
                var current_credit_note_number = Convert.ToInt32(this.get_option<string>("next_credit_note_number"));

                hooks().DoAction("after_credit_note_deleted", id);

                return true;
            }

            return false;
        }

        public bool Mark(int id, string status)
        {
            var affected_rows = 0;
            return affected_rows > 0 ? true : false;
        }

        public void TotalRemainingCreditsByCustomer(int customer_id)
        {
        }

        public void TotalRemainingCreditsByCreditNote(int credit_note_id)
        {
        }

        private void CalcRemainingCredits(int credits)
        {
        }

        public void DeleteAppliedCredit(int id, int credit_id, int invoice_id)
        {
        }

        public void CreditNoteFromInvoice(int invoice_id)
        {
        }

        public int CreateRefund(int id, CreditNoteRefunds data)
        {
            if (data.Amount == 0)
            {
                return 0;
            }

            data.Note = data.Note.Trim();

            var insert_id = 0;
            if (insert_id > 0)
            {
                this.UpdateCreditNoteStatus(id);

                hooks().DoAction("credit_note_refund_created", new { data = data, credit_note_id = id });
            }

            return insert_id;
        }

        public void EditRefund(int id, dynamic data)
        {
        }

        public CreditNoteRefunds GetRefund(int id)
        {
            return null;
        }

        public void GetRefunds(int credit_note_id)
        {
        }

        public bool DeleteRefund(int refund_id, int credit_note_id)
        {
            var affected_rows = 0;

            if (affected_rows > 0)
            {
                this.UpdateCreditNoteStatus(credit_note_id);
                hooks().DoAction("credit_note_refund_deleted",
                    new { refund_id = refund_id, credit_note_id = credit_note_id });

                return true;
            }

            return false;
        }

        private decimal TotalRefundsByCreditNote(int id)
        {
            using (var db = new DBContext())
            {
                return db.CreditNoteRefunds.Where(table => table.CreditNoteId == id).Sum(table => table.Amount);
            }
        }

        public int ApplyCredits(int id, Credits data)
        {
            if (data.Amount == 0) return 0;


            return 0;
        }

        private void TotalCreditsUsedByCreditNote(int id)
        {
        }

        public void UpdateCreditNoteStatus(int id)
        {
        }

        public void GetOpenCredits(int customer_id)
        {
        }

        public List<Credits> GetAppliedInvoiceCredits(int invoice_id)
        {
            using (var db = new DBContext())
            {
                return db.Credits
                    .Where(table => table.InvoiceId == invoice_id)
                    .OrderBy(table => table.Date)
                    .ToList();
            }
        }

        public Credits GetAppliedCredits(int credit_id)
        {
            using (var db = new DBContext())
            {
                return db.Credits
                    .Where(table => table.CreditId == credit_id)
                    .OrderByDescending(table => table.Date)
                    .FirstOrDefault();
            }
        }

        private decimal CalculateAvailableCredits(int credit_id, decimal credit_amount = 0)
        {
            if (credit_amount == 0)
            {
            }

            var available_total = credit_amount;
            return available_total;
        }

        public void GetCreditsYears()
        {
        }

        private dynamic MapShippingColumns(dynamic data)
        {
            return data;
        }

        public CreditNotesModel() : base()
        {
            this.invoices_model = new InvoicesModel();
        }
    }
}