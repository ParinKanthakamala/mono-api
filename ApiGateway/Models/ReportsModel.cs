using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ApiGateway.Models
{
    public class ReportsModel : MyModel
    {
        private UsersModel staff_model;

        public void leads_monthly_report(object month)
        {
        }

        public void get_stats_chart_data(string label, dynamic where, dynamic dataset_options, string year)
        {
        }

        public void get_expenses_vs_income_report(string year = "")
        {
        }

        public void leads_this_week_report()
        {
        }

        public void leads_staff_report()
        {
        }

        public void leads_sources_report()
        {
        }

        public void report_by_customer_groups()
        {
        }

        public void report_by_payment_modes()
        {
        }

        public void total_income_report()
        {
        }

        public void get_distinct_payments_years()
        {
        }

        public List<Invoices> get_distinct_customer_invoices_years()
        {
            using (var db = new DBContext())
            {
                return db.Invoices.Where(table => table.ClientId == this.get_client_user_id()).ToList();
            }

        }

        public ReportsModel() : base()
        {
            this.staff_model = new UsersModel();
        }
    }

    public static class ReportModelExtension
    {
        private static ReportsModel _instance = null;

        public static ReportsModel reports_model(this object source)
        {
            return _instance ??= new ReportsModel();
        }
    }
}