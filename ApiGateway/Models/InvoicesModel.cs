using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library.Helpers.Staff;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class InvoicesModel : MyModel
    {
        public static readonly int STATUS_UNPAID = 1;
        public static readonly int STATUS_PAID = 2;
        public static readonly int STATUS_PARTIALLY = 3;
        public static readonly int STATUS_OVERDUE = 4;
        public static readonly int STATUS_CANCELLED = 5;
        public static readonly int STATUS_DRAFT = 6;

        private List<int> statuses = new List<int>()
        {
            InvoicesModel.STATUS_UNPAID,
            InvoicesModel.STATUS_PAID,
            InvoicesModel.STATUS_PARTIALLY,
            InvoicesModel.STATUS_OVERDUE,
            InvoicesModel.STATUS_CANCELLED,
            InvoicesModel.STATUS_DRAFT,
        };

        private List<string> shipping_fields = new List<string>()
        {
            "shipping_street",
            "shipping_city",
            "shipping_city",
            "shipping_state",
            "shipping_zip",
            "shipping_country",
        };

        public List<int> GetStatuses()
        {
            return this.statuses;
        }

        public void GetSaleAgents()
        {
        }

        public List<Invoices> Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            if (id > 0)
            {
                using (var db = new DBContext())
                {
                    return db.Invoices.Where(table => table.InvoiceId == id).ToList();
                }
            }

            return null;
        }

        public Itemable GetInvoiceItem(int id)
        {
            return null;
        }

        public bool mark_as_cancelled(int id)
        {
            var invoices = new Invoices();
            invoices.Status = InvoicesModel.STATUS_CANCELLED;
            invoices.Sent = true;
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_invoice_activity(id, "invoice_activity_marked_as_cancelled");
                hooks().DoAction("invoice_marked_as_cancelled", id);
                return true;
            }

            return false;
        }

        public bool UnmarkAsCancelled(int id)
        {
            var invoices = new Invoices();
            invoices.Status = InvoicesModel.STATUS_UNPAID;
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public void get_invoice_recurring_invoices(int id)
        {
        }

        public void get_invoices_total(dynamic data)
        {
        }

        public bool Add(Invoices data, bool expense = false)
        {
            return false;
        }

        public void get_expenses_to_bill(int clientid)
        {
        }

        public void check_for_merge_invoice(int client_id, string current_invoice = "")
        {
            if (!string.IsNullOrEmpty(current_invoice))
            {
            }

            statuses = new List<int>()
            {
                InvoicesModel.STATUS_UNPAID,
                InvoicesModel.STATUS_OVERDUE,
                InvoicesModel.STATUS_DRAFT
            };
        }

        public bool Copy(int id)
        {
            return false;
        }

        public bool Update(int id, dynamic data)
        {
            return false;
        }

        public void GetAttachments(int invoiceid, int id = 0)
        {
        }

        public void DeleteAttachment(int id)
        {
        }

        public bool Delete(int id, bool simpleDelete = false)
        {
            return false;
        }

        public void set_invoice_sent(int id, bool manually = false, List<string> emails_sent = default(List<string>),
            bool is_status_updated = false)
        {
        }

        public bool send_invoice_overdue_notice(int id)
        {
            return false;
        }

        public bool send_invoice_to_client(int id, string template_name = "", bool attachpdf = true, string cc = "",
            bool manually = false,
            List<object> attachStatement = default(List<object>))
        {
            return false;
        }

        public List<SalesActivity> get_invoice_activity(int id)
        {
            return null;
        }

        public void log_invoice_activity(int id, string description = "", bool client = false,
            string additional_data = "")
        {
            var staffid = this.get_staff_user_id();
            var fullname = this.get_staff_fullname(staffid);
        }

        public void get_invoices_years()
        {
        }

        private dynamic MapShippingColumns(dynamic data, bool expense = false)
        {
            return data;
        }
    }

    public static class InvoicesModelExtension
    {
        private static InvoicesModel _instance = null;

        public static InvoicesModel invoices_model(this object source)
        {
            return _instance ??= new InvoicesModel();
        }
    }
}