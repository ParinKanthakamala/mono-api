using System;
using System.Globalization;
using System.Linq;
using ApiGateway.Entities;

namespace ApiGateway.Library.Helpers
{
    public static class settings_helper
    {
        public static DBContext db = new DBContext();


        public static bool add_option(this object source, string name, object value = null, double autoload = 1)
        {
            if (!source.option_exists(name))
            {
                db.Options.Add(new Options()
                {
                    Name = name,
                    Value = Convert.ToString(value),
                    Autoload = autoload
                });

                var affected_row = db.SaveChanges();
                return (affected_row > 0);
            }

            return false;
        }

        public static T get_option<T>(this object source, string name, string section = "system")
        {
            try
            {
                var row = db.Options.FirstOrDefault(
                    table =>
                        table.Name == name
                );
                if (row != null)
                {
                    var value = row.Value;
                    return (T) Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
                }

                return default(T);
            }
            catch
            {
            }

            return default(T);
        }

        public static bool update_option(this object source, string name, object value, double autoload = 0)
        {
            if (!source.option_exists(name))
            {
                return source.add_option(name, value, autoload);
            }

            db.Entry(db.Options.SingleOrDefault(table => table.Name == name))
                .CurrentValues
                .SetValues(new Options()
                {
                    Value = Convert.ToString(value),
                    Autoload = autoload
                });
            return db.SaveChanges() > 0;
        }

        public static bool delete_option(this object source, string name)
        {
            db.Remove(db.Options.SingleOrDefault(table => table.Name == name));
            return db.SaveChanges() > 0;
        }

        public static bool option_exists(this object source, string name)
        {
            return (db.Options.SingleOrDefault(table => table.Name == name) != null);
        }

        public static void app_init_settings_tabs(this object source)
        {
            // source.app_tabs().add_settings_tab("general", new Tab()
            // {
            //     name = label("settings_group_general"),
            //     view = "admin/settings/includes/general",
            //     position = 5
            // });
            //
            // source.app_tabs().add_settings_tab("company", new Tab()
            // {
            //     name = label("company_information"),
            //     view = "admin/settings/includes/company",
            //     position = 10
            // });
            //
            // source.app_tabs().add_settings_tab("localization", new Tab()
            // {
            //     name = label("settings_group_localization"),
            //     view = "admin/settings/includes/localization",
            //     position = 15
            // });
            //
            // source.app_tabs().add_settings_tab("email", new Tab()
            // {
            //     name = label("settings_group_email"),
            //     view = "admin/settings/includes/email",
            //     position = 20
            // });
            //
            // source.app_tabs().add_settings_tab("sales", new Tab()
            // {
            //     name = label("settings_group_sales"),
            //     view = "admin/settings/includes/sales",
            //     position = 25
            // });
            //
            // source.app_tabs().add_settings_tab("subscriptions", new Tab()
            // {
            //     name = label("subscriptions"),
            //     view = "admin/settings/includes/subscriptions",
            //     position = 30
            // });
            //
            // source.app_tabs().add_settings_tab("payment_gateways", new Tab()
            // {
            //     name = label("settings_group_online_payment_modes"),
            //     view = "admin/settings/includes/payment_gateways",
            //     position = 35
            // });
            //
            // source.app_tabs().add_settings_tab("clients", new Tab()
            // {
            //     name = label("settings_group_clients"),
            //     view = "admin/settings/includes/clients",
            //     position = 40
            // });
            //
            // source.app_tabs().add_settings_tab("tasks", new Tab()
            // {
            //     name = label("tasks"),
            //     view = "admin/settings/includes/tasks",
            //     position = 45
            // });
            //
            // source.app_tabs().add_settings_tab("tickets", new Tab()
            // {
            //     name = label("support"),
            //     view = "admin/settings/includes/tickets",
            //     position = 50
            // });
            //
            // source.app_tabs().add_settings_tab("leads", new Tab()
            // {
            //     name = label("leads"),
            //     view = "admin/settings/includes/leads",
            //     position = 55
            // });
            //
            // source.app_tabs().add_settings_tab("calendar", new Tab()
            // {
            //     name = label("settings_calendar"),
            //     view = "admin/settings/includes/calendar",
            //     position = 60
            // });
            //
            // source.app_tabs().add_settings_tab("pdf", new Tab()
            // {
            //     name = label("settings_pdf"),
            //     view = "admin/settings/includes/pdf",
            //     position = 65
            // });
            // source.app_tabs().add_settings_tab("e_sign", new Tab()
            // {
            //     name = "E-Sign",
            //     view = "admin/settings/includes/e_sign",
            //     position = 70
            // });
            //
            // source.app_tabs().add_settings_tab("cronjob", new Tab()
            // {
            //     name = label("settings_group_cronjob"),
            //     view = "admin/settings/includes/cronjob",
            //     position = 75
            // });
            //
            //
            // source.app_tabs().add_settings_tab("tags", new Tab()
            // {
            //     name = label("tags"),
            //     view = "admin/settings/includes/tags",
            //     position = 80
            // });
            // source.app_tabs().add_settings_tab("pusher", new Tab()
            // {
            //     name = "Pusher.com",
            //     view = "admin/settings/includes/pusher",
            //     position = 85
            // });
            //
            // source.app_tabs().add_settings_tab("google", new Tab()
            // {
            //     name = "Google",
            //     view = "admin/settings/includes/google",
            //     position = 90
            // });
            //
            // source.app_tabs().add_settings_tab("misc", new Tab()
            // {
            //     name = label("settings_group_misc"),
            //     view = "admin/settings/includes/misc",
            //     position = 95
            // });
        }
    }
}