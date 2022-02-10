using System.Collections.Generic;
using System.Dynamic;

namespace Server.Helpers
{
    public static class database_helper
    {
        public static bool is_reference_in_table(this Helper helper, string field, string table, int? id)
        {
            return false;
        }


        public static void add_views_tracking(this Helper helper, string rel_type, int rel_id)
        {
        }


        public static void total_rows(string table, dynamic where = default(ExpandoObject))
        {
        }

        public static void sum_from_table(this Helper helper, string table, dynamic attr = default(ExpandoObject))
        {
        }

        public static void prefixed_table_fields_wildcard(this Helper helper, string table, string alias, string field)
        {
        }

        public static void prefixed_table_fields_array(this Helper helper, string table, bool @string = false,
            List<string> exclude = default)
        {
        }

        public static void prefixed_table_fields_string(this Helper helper, string table,
            List<string> exclude = default)
        {
        }


        public static void add_foreign_key(string table, string foreign_key, string references,
            string on_delete = "RESTRICT", string on_update = "RESTRICT")
        {
        }

        public static void drop_foreign_key(string table, string foreign_key)
        {
        }


        public static void add_trigger(string trigger_name, string table, string statement, string time = "BEFORE",
            string @event = "INSERT", string type = "FOR EACH ROW")
        {
        }


        public static void drop_trigger(string trigger_name)
        {
        }

        public static void table_exists(string table)
        {
        }
    }
}