using ApiGateway.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class PaymentModesModel : MyModel
    {
        private List<object> payment_gateways = new List<object>();

        private List<object> gateways = null;

        public object Get(int id = 0,
            dynamic where = default(ExpandoObject),
            bool include_inactive = false, bool force = false)
        {
            if (include_inactive != true)
            {
            }

            return null;
        }

        public bool Add(PaymentModes data)
        {
            return false;
        }

        public bool Edit(dynamic data)
        {
            int id = data.Id;
            (new List<string>()
            {
                "active", "show_on_pdf", "selected_by_default", "invoices_only", "expenses_only"
            }).ForEach((check) => { data[check] = data.Contains(check) ? false : true; });

            var payment_modes = new PaymentModes()
            {
                Name = data.Name,
                Description = Convert.ToString(data.Description).nl2br_save_html(),
                Active = data.Active,
                ExpensesOnly = data.ExpensesOnly,
                InvoicesOnly = data.InvoicesOnly,
                ShowOnPdf = data.ShowOnPdf,
                SelectedByDefault = data.SelectedByDefault
            };
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.is_reference_in_table("PaymentModes", "InvoicePaymentRecords", id)
                || this.is_reference_in_table("PaymentMode", "Expenses", id))
            {
                return true;
            }

            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Payment Mode Deleted [" + id + "]");

                return true;
            }

            return false;
        }

        public object GetPaymentGateways(bool includeInactive = false)
        {
            if (this.gateways == null)
            {
                hooks().DoAction("before_get_payment_gateways");

                this.gateways = this.payment_gateways;
                hooks().ApplyFilters("app_payment_gateways", this.payment_gateways);
            }

            var modes = new List<dynamic>();
            return modes;
        }

        public object GetOnlinePaymentModes(bool all = false)
        {
            return this.GetPaymentGateways(all);
        }

        public bool change_payment_mode_status(int id, string status)
        {
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Payment Mode Status Changed [ModeID: " + id + " Status(Active/Inactive): " + status +
                                  "]");

                return true;
            }

            return false;
        }

        public bool change_payment_mode_show_to_client_status(int id, string status)
        {
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Payment Mode Show to Client Changed [ModeID: " + id + " Status(Active/Inactive): " +
                                  status + "]");
                return true;
            }

            return false;
        }

        public void AddPaymentGateway(object gateway, object module = null)
        {
            if (gateway.GetType() == typeof(string))
            {
                gateway = Convert.ToString(gateway).ToLower();
            }
            else
            {
                var className = gateway;
            }
        }

        public PaymentModesModel() : base()
        {
        }
    }

    public static class PaymentModesModelExtension
    {
        private static PaymentModesModel _instance = null;

        public static PaymentModesModel payment_modes_model(this object source)
        {
            return _instance ??= new PaymentModesModel();
        }
    }
}