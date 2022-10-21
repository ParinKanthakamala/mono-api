using System.IO;
using System.Linq;
using ApiGateway.Entities;
using static ApiGateway.System.Language;

namespace ApiGateway.Library.Helpers
{
    public static class leads_helper
    {
        public static bool load_lead_language(this object source, int? lead_id)
        {
            using (var db = new DBContext())
            {
                var lead = db.Leads.FirstOrDefault(table => table.LeadId == lead_id);
                if (lead == null || string.IsNullOrEmpty(lead.DefaultLanguage))
                {
                    return false;
                }

                var language = lead.DefaultLanguage;
                var path = "";
                // var path = Path.Combine(SharePoint.Environment.ContentRootPath,
                //     "wwwroot",
                //     "language",
                //     language
                // );

                if (!Directory.Exists(path))
                {
                    return false;
                }

                // SharePoint.Language = language;
                if (File.Exists(path + "/default.lang"))
                {
                    label().load(path + "/default.lang");
                }
            }


            return true;
        }
    }
}