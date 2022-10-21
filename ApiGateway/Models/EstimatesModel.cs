using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using JamfahCrm.Library.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using JamfahCrm.Library.Helpers.Staff;
using WiseSystem.Libraries;

namespace ApiGateway.Models
{
    public class EstimatesModel : MyModel
    {
        private List<int> statuses;

        private List<string> shipping_fields = new List<string>()
            {"shipping_street", "shipping_city", "shipping_city", "ShippingState", "ShippingZip", "ShippingCountry"};

        public List<Estimates> GetSaleAgents()
        {
            return null;
        }

        public List<Estimates> Get(int? id, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public List<int> GetStatuses()
        {
            return this.statuses;
        }

        public bool ClearSignature(int id)
        {
            Estimates estimate = new Estimates();
            if (estimate != default(Estimates))
            {
                if (!string.IsNullOrEmpty(estimate.Signature))
                {
                }

                return true;
            }

            return false;
        }

        public List<dynamic> DoKanbanQuery(object status, string search = "", int page = 1, List<string> sort = default(List<string>), bool count = false)
        {
            return null;
        }

        public int ConvertToInvoice(int id, bool client = false, bool draft_invoice = false)
        {
            var _estimate = this.Get(id).FirstOrDefault();

            var new_invoice_data = new Invoices();
            if (draft_invoice == true)
            {
            }

            new_invoice_data.ClientId = _estimate.ClientId;
            new_invoice_data.ProjectId = _estimate.ProjectId;
            new_invoice_data.Number = Convert.ToInt32(this.get_option<string>("next_invoice_number"));
            if (this.get_option<bool>("invoice_due_after"))
            {
            }

            new_invoice_data.ShowQuantityAs = _estimate.ShowQuantityAs;
            new_invoice_data.Currency = _estimate.Currency;
            new_invoice_data.Subtotal = _estimate.Subtotal;
            new_invoice_data.Total = _estimate.Total;
            new_invoice_data.Adjustment = _estimate.Adjustment;
            new_invoice_data.DiscountPercent = _estimate.DiscountPercent;
            new_invoice_data.DiscountTotal = _estimate.DiscountTotal;
            new_invoice_data.DiscountType = _estimate.DiscountType;
            new_invoice_data.SaleAgent = _estimate.SaleAgent;
            new_invoice_data.BillingCity = _estimate.BillingCity;
            new_invoice_data.BillingState = _estimate.BillingState;
            new_invoice_data.BillingZip = _estimate.BillingZip;
            new_invoice_data.BillingCountry = _estimate.BillingCountry;
            new_invoice_data.ShippingCity = _estimate.ShippingCity;
            new_invoice_data.ShippingState = _estimate.ShippingState;
            new_invoice_data.ShippingZip = _estimate.ShippingZip;
            new_invoice_data.ShippingCountry = _estimate.ShippingCountry;

            if (_estimate.IncludeShipping)
            {
                new_invoice_data.IncludeShipping = true;
            }

            new_invoice_data.ShowShippingOnInvoice = _estimate.ShowShippingOnEstimate;
            new_invoice_data.Terms = this.get_option<string>("predefined_terms_invoice");
            new_invoice_data.ClientNote = this.get_option<string>("predefined_clientnote_invoice");
            new_invoice_data.Status = 1;
            new_invoice_data.AdminNote = "";

            return id;
        }

        public object Copy(int id)
        {
            var _estimate = this.Get(id).FirstOrDefault();
            var new_estimate_data = new Estimates();
            new_estimate_data.ClientId = _estimate.ClientId;
            new_estimate_data.ProjectId = _estimate.ProjectId;
            new_estimate_data.Number = Convert.ToInt32(this.get_option<string>("next_estimate_number"));
            new_estimate_data.Date = DateTime.Now;
            new_estimate_data.ExpiryDate = null;

            if (_estimate.ExpiryDate != null && this.get_option<bool>("estimate_due_after"))
            {
            }

            new_estimate_data.ShowQuantityAs = _estimate.ShowQuantityAs;
            new_estimate_data.Currency = _estimate.Currency;
            new_estimate_data.Subtotal = _estimate.Subtotal;
            new_estimate_data.Total = _estimate.Total;
            new_estimate_data.AdminNote = _estimate.AdminNote;
            new_estimate_data.Adjustment = _estimate.Adjustment;
            new_estimate_data.DiscountPercent = _estimate.DiscountPercent;
            new_estimate_data.DiscountTotal = _estimate.DiscountTotal;
            new_estimate_data.DiscountType = _estimate.DiscountType;
            new_estimate_data.Terms = _estimate.Terms;
            new_estimate_data.SaleAgent = _estimate.SaleAgent;
            new_estimate_data.ReferenceNo = _estimate.ReferenceNo;
            new_estimate_data.BillingCity = _estimate.BillingCity;
            new_estimate_data.BillingState = _estimate.BillingState;
            new_estimate_data.BillingZip = _estimate.BillingZip;
            new_estimate_data.BillingCountry = _estimate.BillingCountry;
            new_estimate_data.ShippingCity = _estimate.ShippingCity;
            new_estimate_data.ShippingState = _estimate.ShippingState;
            new_estimate_data.ShippingZip = _estimate.ShippingZip;
            new_estimate_data.ShippingCountry = _estimate.ShippingCountry;
            if (_estimate.IncludeShipping == true)
            {
                new_estimate_data.IncludeShipping = _estimate.IncludeShipping;
            }

            new_estimate_data.ShowShippingOnEstimate = _estimate.ShowShippingOnEstimate;
            new_estimate_data.Status = 1;
            new_estimate_data.ClientNote = _estimate.ClientNote;
            new_estimate_data.AdminNote = "";
            return false;
        }

        public void GetEstimatesTotal(dynamic data)
        {
            statuses = this.GetStatuses();
            bool has_permission_view = Permission.CanView("estimates");
        }

        public bool Add(Estimates data)
        {
            data.DateCreated = SharePoint.Now;
            data.AddedFrom = this.get_staff_user_id();
            data.Prefix = this.get_option<string>("estimate_prefix");

            return false;
        }

        public List<Itemable> GetEstimateItem(int id)
        {
            return null;
        }

        public bool Update(int id, dynamic data)
        {

            return false;
        }

        public Estimates mark_action_status(int id, int action = 0, bool client = false)
        {
            using (var db = new DBContext())
            {
                var entry = db.Estimates.FirstOrDefault(table => table.EstimateId == id);
                db.Entry(entry).CurrentValues.SetValues(new Estimates()
                {
                    Status = action
                });

                int affected_rows = db.SaveChanges();
                List<Users> notified_users = new List<Users>();
                if (affected_rows > 0)
                {
                    var estimate = this.Get(id).FirstOrDefault();
                    if (client)
                    {
                        var staff_estimate = db.Users.Where(table => table.UserId == estimate.AddedFrom || table.UserId == estimate.SaleAgent).ToList();
                        var invoice_id = 0;
                        int contact_id = !this.is_client_logged_in()
                            ? this.get_primary_contact_user_id(estimate.ClientId)
                            : this.get_contact_user_id();
                        if (action == 4)
                        {
                            if (this.get_option<bool>("estimate_auto_convert_to_invoice_on_client_accept"))
                            {
                                invoice_id = this.ConvertToInvoice(id, true);
                                var invoice = this.invoices_model().Get(invoice_id);
                            }
                            else
                            {
                                this.log_estimate_activity(id, "estimate_activity_client_accepted", true);
                            }

                            var contacts = this.clients_model().GetContacts(estimate.ClientId, new { active = true, estimate_emails = true });
                            contacts.ForEach((contact) =>
                            {
                            });

                            staff_estimate.ForEach((member) =>
                            {
                                var notified = this.add_notification(new Notifications()
                                {
                                    FromCompany = 1,
                                    ToUserId = member.UserId,
                                    Description = "not_estimate_customer_accepted",
                                    Link = "estimates/list_estimates/" + id,
                                    AdditionalData = this.format_estimate_number(estimate.EstimateId),
                                });

                                if (notified)
                                {
                                }

                            });
                        }
                    }
                }
            }

            return default(Estimates);
        }

        public object GetAttachments(int estimate_id, int id = 0)
        {
            return null;
        }

        public bool DeleteAttachment(int id)
        {
            var attachment = (Files)this.GetAttachments(0, id);
            bool deleted = false;
            if (attachment != null)
            {
                if (string.IsNullOrEmpty(attachment.External))
                {
                }

                int affected_rows = 0;

                if (affected_rows > 0)
                {
                    deleted = true;
                    this.log_activity("Estimate Attachment Deleted [EstimateID: " + attachment.RelId + "]");
                }

            }

            return deleted;
        }

        public bool Delete(int id, bool simpleDelete = false)
        {
            return false;
        }

        public void set_estimate_sent(int id, params string[] emails_sent)
        {
        }

        public bool send_expiry_reminder(int id)
        {
            var estimate = this.Get(id).FirstOrDefault();
            return false;
        }

        public bool send_estimate_to_client(int id, string template_name = "", bool attachpdf = true, string cc = "",
            bool manually = false)
        {
            var estimate = this.Get(id).FirstOrDefault();

            if (template_name == "")
            {
                if (estimate.Sent == false)
                {
                    template_name = "estimate_send_to_customer";
                }
                else
                {
                    template_name = "estimate_send_to_customer_already_sent";
                }
            }

            return false;
        }

        public List<SalesActivity> get_estimate_activity(int id)
        {
            return null;
        }

        public int log_estimate_activity(int id, string description = "", bool client = false, string additional_data = "")
        {
            var staffid = this.get_staff_user_id();
            var full_name = this.get_staff_fullname(this.get_staff_user_id());
            return 0;
        }

        public void update_pipeline(dynamic data)
        {
        }

        public void get_estimates_years()
        {
        }

        private void MapShippingColumns(dynamic data)
        {
        }
    }

    public static class EstimatesModelExtension
    {
        private static EstimatesModel _instance = null;

        public static EstimatesModel estimates_model(this object source)
        {
            return _instance ??= new EstimatesModel();
        }
    }
}