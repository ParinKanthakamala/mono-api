using System.Linq;
using ApiGateway.Models;

namespace ApiGateway.Library.Helpers
{
    public static class contracts_helper
    {
        public static void check_contract_restrictions(this object source, int? id, string hash)
        {
            if (string.IsNullOrEmpty(hash) || !id.HasValue)
            {
            }

            if (!source.is_client_logged_in() && !source.is_staff_logged_in())
            {
                if (source.get_option<bool>("view_contract_only_logged_in"))
                {
                    source.redirect_after_login_to_current_url();
                }
            }

            var contract = source.contracts_model().Get(id).FirstOrDefault();
            if (contract == null || (contract.Hash != hash))
            {
            }

            if (!source.is_staff_logged_in())
            {
                if (source.get_option<bool>("view_contract_only_logged_in"))
                {
                    if (contract.Client != source.get_client_user_id())
                    {
                    }
                }
            }
        }
    }
}