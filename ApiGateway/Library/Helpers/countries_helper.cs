using System.Collections.Generic;
using System.Linq;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class countries_helper
    {
        public static List<Countries> get_all_countries(this object source)
        {
            using (var db = new DBContext())
            {
                var entry = db.Countries.ToList();
                hooks().ApplyFilters("all_countries", entry);
                return entry;
            }
        }

        public static Countries get_country(this object source, int id)
        {
            // Countries country = (Countries) app_object_cache().get("db-country-" + id);
            // if (country != null)
            // {
            //     using (var db = new DBContext())
            //     {
            //         country = db.Countries.FirstOrDefault(table => table.CountryId == id);
            //
            //         // app_object_cache().Add("db-country-" + id, country);
            //     }
            // }
            return null;
            // return country;
        }

        public static string get_country_short_name(this object source, int id)
        {
            var country = source.get_country(id);
            if (country != null)
            {
                return country.Iso2;
            }

            return "";
        }

        public static string get_country_name(this object source, int id)
        {
            var country = source.get_country(id);
            if (country != null)
            {
                return country.ShortName;
            }

            return "";
        }
    }
}