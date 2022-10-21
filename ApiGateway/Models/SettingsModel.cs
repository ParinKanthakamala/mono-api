using JamfahCrm.Controllers.Core;
using System.Collections.Generic;

namespace ApiGateway.Models
{
    public class SettingsModel : MyModel
    {
        private List<string> encrypted_fields = new List<string>() { "smtp_password" };
        private PaymentModesModel payment_modes_model;

        public bool Update(dynamic data)
        {
            return false;
        }

        public bool add_new_company_pdf_field(dynamic data)
        {
            return false;
        }

        public SettingsModel() : base()
        {
            this.payment_modes_model = new PaymentModesModel();
        }
    }
}