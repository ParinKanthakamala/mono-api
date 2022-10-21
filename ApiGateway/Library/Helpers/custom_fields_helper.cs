using System.Collections.Generic;
using System.Dynamic;

namespace ApiGateway.Library.Helpers
{
    public static class custom_fields_helper
    {
        /**
 * Get custom fields
 * @param  string  field_to
 * @param  array   where
 * @param  boolean exclude_only_admin
 * @return array
 */
        public static List<string> get_custom_fields(this object source, string field_to, dynamic where = default(ExpandoObject), bool exclude_only_admin = false)
        {
            var is_admin = source.is_admin();
            // CI.db.where('fieldto', field_to);
            // if ((is_array(where) && count(where) > 0) || (!is_array(where) && where != ''))
            // {
            //     CI.db.where(where);
            // }
            //
            // if (!is_admin || exclude_only_admin == true)
            // {
            //     CI.db.where('only_admin', 0);
            // }
            //
            // CI.db.where('active', 1);
            // CI.db.order_by('field_order', 'asc');
            //
            // results = CI.db.get(db_prefix(). 'customfields').result_array();
            //
            // foreach (results as key => result) {
            //     results[key]['name'] = _maybe_translate_custom_field_name(result['name'], result['slug']);
            // }
            //
            // return results;
            return default(List<string>);
        }
    }
}