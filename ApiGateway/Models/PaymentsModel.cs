using Entities.Models;
using JamfahCrm.Controllers.Core;

namespace ApiGateway.Models
{
    public class PaymentsModel : MyModel
    {
        public object Get(int id)
        {
            return null;
        }

        public object get_invoice_payments(int invoiceid)
        {
            return null;
        }

        public bool process_payment(PaymentModes data, int invoiceid = 0)
        {
            return false;
        }

        public int Add(InvoicePaymentRecords data, bool subscription = false)
        {
            return 0;
        }

        public bool Update(int id, dynamic data)
        {
            var payment = (InvoicePaymentRecords)this.Get(id);
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }
    }

    public static class PaymentsModelExtension
    {
        private static PaymentsModel _instance = null;

        public static PaymentsModel payments_model(this object source)
        {
            return _instance ??= new PaymentsModel();
        }
    }
}