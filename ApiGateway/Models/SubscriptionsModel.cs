using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;

namespace ApiGateway.Models
{
    public class SubscriptionsModel : MyModel
    {
        private InvoicesModel invoices_model;

        public List<Subscriptions> Get(
            dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public Subscriptions GetById(int id, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public Subscriptions GetByHash(string hash, dynamic where = default(ExpandoObject))
        {
            using (var db = new DBContext())
            {
                return db.Subscriptions.FirstOrDefault(table => table.Hash == hash);
            }
        }

        public List<Invoices> GetChildInvoices(int id)
        {
            return null;
        }

        public int Create(Subscriptions data)
        {
            return 0;
        }

        public bool Update(int id, Subscriptions data)
        {
            using (var db = new DBContext())
            {
                var entry = db.Subscriptions.FirstOrDefault(table => table.SubscriptionId == id);
                if (entry == null) return false;
                db.Entry(entry).CurrentValues.SetValues(data);
                var affected_rows = db.SaveChanges();
                return (affected_rows > 0);
            }
        }

        public bool SendEmailTemplate(int id, string cc = "", string template = "subscription_send_to_customer")
        {
            return false;
        }

        public bool Delete(int id, bool simpleDelete = false)
        {
            var affected_rows = 0;
            using (var db = new DBContext())
            {
                var entry = db.Subscriptions.FirstOrDefault(table => table.DescriptionInItem);
                db.Subscriptions.Remove(entry);
            }

            if (affected_rows > 0)
            {
                this.delete_tracked_emails(id, "subscription");
                return true;
            }

            return false;
        }

        public SubscriptionsModel() : base()
        {
            this.invoices_model = new InvoicesModel();
        }
    }

    public static class SubscriptionsModelExtension
    {
        private static SubscriptionsModel _instance = null;

        public static SubscriptionsModel subscriptions_model(this object source)
        {
            return _instance ??= new SubscriptionsModel();
        }
    }
}