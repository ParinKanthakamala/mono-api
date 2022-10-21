using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Helpers;
using System;
using System.Collections.Generic;
using WiseSystem.Libraries.Services;

namespace ApiGateway.Models
{
    public class CronModel : MyModel
    {
        public bool manually = false;

        private LeadsModel leads_model;

        public void Run(bool manually = false)
        {
            if (this.CanCronRun())
            {
                this.hooks().DoAction("before_cron_run", manually);
                this.update_option("last_cron_run", DateTime.Now.ToString(""));
                if (manually == true)
                {
                    this.manually = true;
                    this.log_activity("Cron Invoked Manually");
                }

                this.StaffReminders();
                this.Events();
                this.TasksReminders();
                this.RecurringTasks();
                this.Proposals();
                this.InvoiceOverdue();
                this.EstimateExpiration();
                this.ContractsExpirationCheck();
                this.autoclose_tickets();
                this.recurring_invoices();
                this.RecurringExpenses();
                this.auto_import_imap_tickets();
                this.check_leads_email_integration();
                this.delete_activity_log();
                this.hooks().DoAction("after_cron_run", manually);
                this.lockHandle();
            }
        }

        private void Events()
        {
        }

        private void autoclose_tickets()
        {
            var auto_close_after = Convert.ToInt32(this.get_option<string>("autoclose_tickets_after"));
            if (auto_close_after == 0)
            {
                return;
            }

        }

        public void ContractsExpirationCheck()
        {
            var contracts_auto_operations_hour = this.get_option<string>("contracts_auto_operations_hour");
            if (contracts_auto_operations_hour != null && string.IsNullOrEmpty(contracts_auto_operations_hour))
            {
                contracts_auto_operations_hour = "9";
            }

            contracts_auto_operations_hour = Convert.ToInt32(contracts_auto_operations_hour) + "";
            var hour_now = DateTime.Now.ToString("G");
            if (hour_now != contracts_auto_operations_hour && this.manually == false)
            {
                return;
            }

        }

        public void RecurringTasks()
        {
        }

        private void RecurringExpenses()
        {
            var expenses_hour_auto_operations = this.get_option<string>("expenses_auto_operations_hour");
            var expenses_hour_auto_operations_int = (string.IsNullOrEmpty(expenses_hour_auto_operations))
                ? 9
                : Convert.ToInt32(expenses_hour_auto_operations);
            var hour_now = Convert.ToInt32(DateTime.Now.ToString("G"));
            if (hour_now != expenses_hour_auto_operations_int && this.manually == false)
            {
                return;
            }

            var recurring_expenses = new List<Expenses>();
            var _renewals_ids_data = new List<string>();
            int total_renewed = 0;
            foreach (var expense in recurring_expenses)
            {
            }

            var send_recurring_expenses_email = true;
            this.hooks().ApplyFilters("send_recurring_system_expenses_email", send_recurring_expenses_email);
            if (total_renewed > 0 && send_recurring_expenses_email == true)
            {
            }
        }

        private void recurring_invoices()
        {
        }

        private void TasksReminders()
        {
            var reminder_before = this.get_option<string>("tasks_reminder_notification_before");
            var tasks = new List<Tasks>();
        }

        private void StaffReminders()
        {
            var reminders = new List<Reminders>();
            var notified_users = new List<string>();
            foreach (var reminder in reminders)
            {
            }
        }

        private void InvoiceOverdue()
        {
            var invoice_auto_operations_hour = this.get_option<string>("invoice_auto_operations_hour");
            if (string.IsNullOrEmpty(invoice_auto_operations_hour))
            {
                invoice_auto_operations_hour = "9";
            }

            var hour_now = DateTime.Now.ToString("G");
            if (hour_now != invoice_auto_operations_hour && this.manually == false)
            {
                return;
            }

        }

        public void Proposals()
        {
            var proposals_auto_operations_hour = this.get_option<string>("proposals_auto_operations_hour");
            if (string.IsNullOrEmpty(proposals_auto_operations_hour))
            {
                proposals_auto_operations_hour = "9";
            }

            proposals_auto_operations_hour = Convert.ToInt32(proposals_auto_operations_hour) + "";
            var hour_now = DateTime.Now.ToString("G");
            if (hour_now != proposals_auto_operations_hour && this.manually == false)
            {
                return;
            }

        }

        private void EstimateExpiration()
        {
            var estimates_auto_operations_hour = this.get_option<string>("estimates_auto_operations_hour");
            if (estimates_auto_operations_hour == "")
            {
                estimates_auto_operations_hour = "9";
            }

            var hour_now = DateTime.Now.ToString("G");
            if (hour_now != estimates_auto_operations_hour && this.manually == false)
            {
                return;
            }

        }

        public bool check_leads_email_integration()
        {
            var mail = this.leads_model.get_email_integration();
            if (mail.Active == 0)
            {
                return false;
            }

            return false;
        }

        public void auto_import_imap_tickets()
        {
        }

        public void delete_activity_log()
        {
        }

        private void _maybe_fix_duplicate_tasks_assignees_and_followers()
        {
        }

        private void _notification_lead_email_integration(string description, string mail, int lead_id)
        {
        }

        private void _check_lead_email_integration_attachments(string email, int lead_id, ref object imap, bool task_id = false)
        {
        }

        private void lockHandle()
        {
        }

        private bool CanCronRun()
        {
            return false;
        }

        private string PrepareImapEmailBodyHtml(string body)
        {
            return body;
        }

        public CronModel() : base()
        {
            this.leads_model = new LeadsModel();
        }
    }

    public static class CronModelExtension
    {
        private static CronModel _instance = null;

        public static CronModel cron_model(this object source)
        {
            return _instance ??= new CronModel();
        }
    }
}