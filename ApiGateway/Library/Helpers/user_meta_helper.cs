using System.Collections.Generic;
using System.Linq;
using ApiGateway.Entities;

namespace ApiGateway.Library.Helpers
{
    public static class user_meta_helper
    {
        public static int add_staff_meta(this object source, int user_id, string meta_key, string meta_value = "")
        {
            return source.add_meta("staff", user_id, meta_key, meta_value);
        }

        public static int update_staff_meta(this object source, int user_id, string meta_key, string meta_value)
        {
            return source.update_meta("staff", user_id, meta_key, meta_value);
        }

        public static List<UserMeta> get_staff_meta(this object source, int user_id, string meta_key = "")
        {
            return source.get_meta("staff", user_id, meta_key);
        }

        public static bool delete_staff_meta(this object source, int user_id, string meta_key)
        {
            return source.delete_meta("staff", user_id, meta_key);
        }

        public static int add_contact_meta(this object source, int user_id, string meta_key, string meta_value = "")
        {
            return source.add_meta("contact", user_id, meta_key, meta_value);
        }

        public static int update_contact_meta(this object source, int user_id, string meta_key, string meta_value)
        {
            return source.update_meta("contact", user_id, meta_key, meta_value);
        }

        public static List<UserMeta> get_contact_meta(this object source, int user_id, string meta_key = "")
        {
            return source.get_meta("contact", user_id, meta_key);
        }

        public static bool delete_contact_meta(this object source, int user_id, string meta_key)
        {
            return source.delete_meta("contact", user_id, meta_key);
        }

        public static int add_customer_meta(this object source, int user_id, string meta_key, string meta_value = "")
        {
            return source.add_meta("customer", user_id, meta_key, meta_value);
        }

        public static int update_customer_meta(this object source, int user_id, string meta_key, string meta_value)
        {
            return source.update_meta("customer", user_id, meta_key, meta_value);
        }

        public static List<UserMeta> get_customer_meta(this object source, int user_id, string meta_key = "")
        {
            return source.get_meta("customer", user_id, meta_key);
        }

        public static bool delete_customer_meta(this object source, int user_id, string meta_key)
        {
            return source.delete_meta("customer", user_id, meta_key);
        }

        public static int add_meta(this object source, string @for, int user_id, string meta_key,
            string meta_value = "")
        {
            if (source.meta_key_exists(@for, user_id, meta_key))
            {
                return 0;
            }

            var column = source._get_meta_key_query_column_for(@for);
            if (column == null)
            {
                return 0;
            }

            var usermeta = new UserMeta()
            {
                UserId = user_id,
                MetaKey = meta_key,
                MetaValue = meta_value
            };
            using (var db = new DBContext())
            {
                db.Add(usermeta);
                db.SaveChanges();
            }

            return usermeta.UserId;
        }

        public static int update_meta(this object source, string @for, int user_id, string meta_key, string meta_value)
        {
            if (!source.meta_key_exists(@for, user_id, meta_key))
            {
                return source.add_meta(@for, user_id, meta_key, meta_value);
            }

            var usermeta = new UserMeta();
            var column = source._get_meta_key_query_column_for(@for);
            if (column == null)
            {
                return 0;
            }

            var affected_rows = 0;
            using (var db = new DBContext())
            {
                usermeta = db.UserMeta.FirstOrDefault(table => table.MetaKey == meta_key);
                db.Entry(usermeta).CurrentValues.SetValues(new UserMeta()
                {
                    MetaValue = meta_value
                });
                affected_rows = db.SaveChanges();
            }

            return affected_rows;
        }

        public static bool meta_key_exists(this object source, string @for, int user_id, string meta_key)
        {
            var column = source._get_meta_key_query_column_for(@for);
            if (column == null)
            {
                return false;
            }

            using (var db = new DBContext())
            {
                return db.UserMeta.Where(table => table.MetaKey == meta_key).ToList().Count > 0;
            }
        }

        public static bool delete_meta(this object source, string @for, int user_id, string meta_key)
        {
            var affected_rows = 0;
            using (var db = new DBContext())
            {
                var entry = db.UserMeta.Where(table => table.MetaKey == meta_key).FirstOrDefault();
                if (entry != null)
                {
                    db.Remove(entry);
                    affected_rows = db.SaveChanges();
                }
            }

            return affected_rows > 0;
        }

        public static List<UserMeta> get_meta(this object source, string @for, int user_id, string meta_key = "")
        {
            var metas = new List<UserMeta>();
            var column = source._get_meta_key_query_column_for(@for);
            if (column != null)
            {
                return metas;
            }

            using (var db = new DBContext())
            {
                metas = db.UserMeta.ToList();
                var flat = new Dictionary<string, string>();
                foreach (var m in metas)
                {
                    flat[m.MetaKey] = m.MetaValue;
                }

                if (flat.Keys.Count == 0)
                {
                    return string.IsNullOrEmpty(meta_key) ? null : new List<UserMeta>();
                }

                // app_object_cache().Add(@for + "-meta-" + user_id, flat);
            }

            return source.get_meta(@for, user_id, meta_key);
        }

        public static string _get_meta_key_query_column_for(this object source, string @for)
        {
            if (@for == "staff")
            {
                return "staff_id";
            }
            else if (@for == "contact")
            {
                return "contact_id";
            }
            else if (@for == "customer")
            {
                return "client_id";
            }

            return null;
        }
    }
}