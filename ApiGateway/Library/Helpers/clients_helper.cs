using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiGateway.Entities;
using ApiGateway.Library.Services.Utilities;
using ApiGateway.Models;
using Microsoft.AspNetCore.Mvc;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;
using static ApiGateway.System.Url;
using static ApiGateway.Core.AppObjectCache;

namespace ApiGateway.Library.Helpers
{
    public static class clients_helper
    {
        public static bool is_contact_email_verified(this object source, int id = 0)
        {
            id = id == 0 ? source.get_contact_user_id() : id;

            // if (model_point().contact != null && model_point().contact.ContactId == id)
            // {
            //     return !model_point().contact.EmailVerifiedAt.HasValue;
            // }
            //
            // using (var db = new DBContext())
            // {
            //     var contact = db.Contacts.FirstOrDefault(table => table.ContactId == id);
            //     if (contact != null)
            //     {
            //         return false;
            //     }
            // }
            //
            // return !model_point().contact.EmailVerifiedAt.HasValue;
            return false;
        }

        public static bool is_email_verification_enabled(this object source)
        {
            using (var db = new DBContext())
            {
                var rows = db.EmailTemplates
                    .Where(table => table.Slug == "contact-verification-email" && table.Active == 0).ToList();
                return (rows.Count == 0);
            }
        }

        public static void is_client_id_used(this object source, int id)
        {
        }

        public static bool customer_has_subscriptions(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var total_rows = db.Subscriptions
                    .Where(table => table.ClientId == id)
                    .ToList()
                    .Count;
                var output = total_rows > 0;
                hooks().ApplyFilters("customer_has_subscriptions", new {output = output});
                return output;
            }
        }

        public static Clients get_client(this object source, int id = 0)
        {
            // if (id == 0 && model_point().client != null)
            // {
            //     return model_point().client;
            // }
            //
            // if (id == 0)
            // {
            //     return null;
            // }
            //
            var clients_model = new ClientsModel();

            var client = clients_model.Get(id).FirstOrDefault();

            return client;
        }

        // public static AppTabs get_customer_profile_tabs(this object source)
        // {
        //     return source.app_tabs().get_customer_profile_tabs();
        // }

        // public static void filter_client_visible_tabs(this object source, List<Tab> tabs)
        // {
        // }

        public static void app_init_customer_profile_tabs(this object source)
        {
            var client_id = 0;
            var remindersText = label("client_reminders_tab");

            // source.app_tabs().add_customer_profile_tab("profile", new Tab()
            // {
            //     name = label("client_add_edit_profile"),
            //     icon = "fa fa-user-circle",
            //     view = "admin/clients/groups/profile",
            //     position = 5
            // });
            //
            // source.app_tabs().add_customer_profile_tab("contacts", new Tab()
            // {
            //     name = !source.is_empty_customer_company(client_id) || (client_id == 0)
            //         ? label("customer_contacts")
            //         : label("contact"),
            //     icon = "fa fa-users",
            //     view = "admin/clients/groups/contacts",
            //     position = 10
            // });
            //
            // source.app_tabs().add_customer_profile_tab("notes", new Tab()
            // {
            //     name = label("contracts_notes_tab"),
            //     icon = "fa fa-sticky-note-o",
            //     view = "admin/clients/groups/notes",
            //     position = 15
            // });
            //
            // source.app_tabs().add_customer_profile_tab("statement", new Tab()
            // {
            //     name = label("customer_statement"),
            //     icon = "fa fa-area-chart",
            //     view = "admin/clients/groups/statement",
            //     visible = (Permission.CanView("invoices") && Permission.CanView("payments")),
            //     position = 20
            // });
            //
            // source.app_tabs().add_customer_profile_tab("invoices", new Tab()
            // {
            //     name = label("client_invoices_tab"),
            //     icon = "fa fa-file-text",
            //     view = "admin/clients/groups/invoices",
            //     visible = (Permission.CanView("invoices") || Permission.CanViewOwn("invoices") ||
            //                (source.get_option<bool>("allow_staff_view_invoices_assigned") &&
            //                 source.staff_has_assigned_invoices())),
            //     position = 25
            // });
            //
            // source.app_tabs().add_customer_profile_tab("payments", new Tab()
            // {
            //     name = label("client_payments_tab"),
            //     icon = "fa fa-line-chart",
            //     view = "admin/clients/groups/payments",
            //     visible = (Permission.CanView("payments") || Permission.CanViewOwn("invoices") ||
            //                (source.get_option<bool>("allow_staff_view_invoices_assigned") &&
            //                 source.staff_has_assigned_invoices())),
            //     position = 30
            // });
            //
            // source.app_tabs().add_customer_profile_tab("proposals", new Tab()
            // {
            //     name = label("proposals"),
            //     icon = "fa fa-file-powerpoint-o",
            //     view = "admin/clients/groups/proposals",
            //     visible = (Permission.CanView("proposals") || Permission.CanViewOwn("proposals") ||
            //                (source.get_option<bool>("allow_staff_view_proposals_assigned") &&
            //                 source.staff_has_assigned_proposals())),
            //     position = 35
            // });
            //
            // source.app_tabs().add_customer_profile_tab("credit_notes", new Tab()
            // {
            //     name = label("credit_notes"),
            //     icon = "fa fa-sticky-note-o",
            //     view = "admin/clients/groups/credit_notes",
            //     visible = (Permission.CanView("credit_notes") || Permission.CanViewOwn("credit_notes")),
            //     position = 40
            // });
            //
            // source.app_tabs().add_customer_profile_tab("estimates", new Tab()
            // {
            //     name = label("estimates"),
            //     icon = "fa fa-clipboard",
            //     view = "admin/clients/groups/estimates",
            //     visible = (Permission.CanView("estimates") || Permission.CanViewOwn("estimates") ||
            //                (source.get_option<bool>("allow_staff_view_estimates_assigned") &&
            //                 source.staff_has_assigned_estimates())),
            //     position = 45
            // });
            //
            // source.app_tabs().add_customer_profile_tab("subscriptions", new Tab()
            // {
            //     name = label("subscriptions"),
            //     icon = "fa fa-repeat",
            //     view = "admin/clients/groups/subscriptions",
            //     visible = (Permission.CanView("subscriptions") || Permission.CanViewOwn("subscriptions")),
            //     position = 50
            // });
            //
            // source.app_tabs().add_customer_profile_tab("expenses", new Tab()
            // {
            //     name = label("expenses"),
            //     icon = "fa fa-file-text-o",
            //     view = "admin/clients/groups/expenses",
            //     visible = (Permission.CanView("expenses") || Permission.CanView("expenses")),
            //     position = 55
            // });
            //
            // source.app_tabs().add_customer_profile_tab("contracts", new Tab()
            // {
            //     name = label("contracts"),
            //     icon = "fa fa-file",
            //     view = "admin/clients/groups/contracts",
            //     visible = (Permission.CanView("contracts") || Permission.CanViewOwn("contracts")),
            //     position = 60
            // });
            //
            // source.app_tabs().add_customer_profile_tab("projects", new Tab()
            // {
            //     name = label("projects"),
            //     icon = "fa fa-bars",
            //     view = "admin/clients/groups/projects",
            //     position = 65
            // });
            //
            // source.app_tabs().add_customer_profile_tab("tasks", new Tab()
            // {
            //     name = label("tasks"),
            //     icon = "fa fa-tasks",
            //     view = "admin/clients/groups/tasks",
            //     position = 70
            // });
            //
            // source.app_tabs().add_customer_profile_tab("tickets", new Tab()
            // {
            //     name = label("tickets"),
            //     icon = "fa fa-ticket",
            //     view = "admin/clients/groups/tickets",
            //     visible =
            //         ((source.get_option<bool>("access_tickets_to_none_staff_members") && !source.is_staff_member()) ||
            //          source.is_staff_member()),
            //     position = 75
            // });
            //
            // source.app_tabs().add_customer_profile_tab("attachments", new Tab()
            // {
            //     name = label("customer_attachments"),
            //     icon = "fa fa-paperclip",
            //     view = "admin/clients/groups/attachments",
            //     position = 80
            // });
            //
            // source.app_tabs().add_customer_profile_tab("vault", new Tab()
            // {
            //     name = label("vault"),
            //     icon = "fa fa-lock",
            //     view = "admin/clients/groups/vault",
            //     position = 85
            // });
            //
            // source.app_tabs().add_customer_profile_tab("reminders", new Tab()
            // {
            //     name = remindersText,
            //     icon = "fa fa-clock-o",
            //     view = "admin/clients/groups/reminders",
            //     position = 90
            // });
            //
            // source.app_tabs().add_customer_profile_tab("map", new Tab()
            // {
            //     name = label("customer_map"),
            //     icon = "fa fa-map-marker",
            //     view = "admin/clients/groups/map",
            //     position = 95
            // });
        }

        public static int get_client_id_by_lead_id(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var row = db.Clients.FirstOrDefault(table => table.LeadId == id);
                return row.ClientId;
            }
        }

        public static bool is_primary_contact(this object source, int contact_id = 0)
        {
            if (contact_id > 0)
            {
                contact_id = source.get_contact_user_id();
            }

            using (var db = new DBContext())
            {
                return (db.Contacts.Where(
                    table =>
                        table.ContactId == contact_id
                        && table.IsPrimary == 1
                ).ToList().Count > 0);
            }
        }

        public static bool is_client_using_multiple_currencies(this object source, int client_id = 0,
            string table = null)
        {
            return true;
        }


        public static bool is_empty_customer_company(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var row = db.Clients.FirstOrDefault(table => table.ClientId == id);
                if (row != null)
                {
                    return string.IsNullOrEmpty(row.Company);
                }
            }

            return true;
        }

        public static IEnumerable<TSource> get_customer_profile_file_sharing<TSource>(this object source,
            Func<TSource, bool> where = default(Func<TSource, bool>))
        {
            return null;
        }

        public static int get_user_id_by_contact_id(this object source, int id)
        {
            var user_id = app_object_cache().get("user-id-by-contact-id-" + id);
            if (user_id != null)
            {
                using (var db = new DBContext())
                {
                    var client = db.Contacts.FirstOrDefault(table => table.ContactId == id);

                    if (client != null)
                    {
                        user_id = client.ContactId;
                        app_object_cache().add("user-id-by-contact-id-" + id, user_id);
                    }
                }
            }

            return Convert.ToInt32(user_id);
        }

        public static int get_primary_contact_user_id(this object source, int user_id)
        {
            using (var db = new DBContext())
            {
                var row = db.Contacts.FirstOrDefault(table => table.UserId == user_id && table.IsPrimary == 1);
                if (row != null)
                {
                    return row.ContactId;
                }
            }

            return 0;
        }

        public static string get_contact_full_name(this object source, int contact_id = 0)
        {
            contact_id = (contact_id == 0 ? source.get_contact_user_id() : contact_id);

            var contact = app_object_cache().get("contact-full-name-data-" + contact_id);

            if (contact != null)
            {
                using (var db = new DBContext())
                {
                    contact = db.Contacts.FirstOrDefault(table => table.ContactId == contact_id);
                    app_object_cache().add("contact-full-name-data-" + contact_id, contact);
                }
            }

            return "";
        }

        public static string contact_profile_image_url(this object source, int contact_id, string type = "small")
        {
            var url = base_url("assets/images/user-placeholder.jpg");
            var path = app_object_cache().get("contact-profile-image-path-" + contact_id) + "";

            if (path != null)
            {
                app_object_cache().add("contact-profile-image-path-" + contact_id, url);
                using (var db = new DBContext())
                {
                    var contact = db.Contacts.FirstOrDefault(table => table.ContactId == contact_id);


                    if (contact != null && !string.IsNullOrEmpty(contact.ProfileImage))
                    {
                        path = "uploads/client_profile_images/" + contact_id + "/" + type + "_" + contact.ProfileImage;
                        app_object_cache().set("contact-profile-image-path-" + contact_id, path);
                    }
                }
            }

            if (string.IsNullOrEmpty(path) && File.Exists(path))
            {
                url = base_url(path);
            }

            return url;
        }

        public static string get_company_name(this object source, int user_id = -1, bool prevent_empty_company = false)
        {
            var _user_id = source.get_client_user_id();
            if (user_id == -1)
            {
                _user_id = user_id;
            }


            using (var db = new DBContext())
            {
                var client = db.Clients.FirstOrDefault(table => table.ClientId == _user_id);

                if (client != null)
                {
                    return client.Company;
                }
            }

            return "";
        }


        public static string get_client_default_language(this object source, int? client_id)
        {
            if (client_id == 0)
            {
                client_id = source.get_client_user_id();
            }

            using (var db = new DBContext())
            {
                var client = db.Clients.FirstOrDefault(table => table.ClientId == client_id);

                if (client != null)
                {
                    return client.DefaultLanguage;
                }
            }

            return "";
        }

        public static bool is_customer_admin(this object source, int? id, int staff_id = 0)
        {
            staff_id = staff_id > 0 ? staff_id : source.get_staff_user_id();

            var cache = app_object_cache().get(id + "-is-customer-admin-" + staff_id);

            if (cache != null)
            {
            }

            using (var db = new DBContext())
            {
                var total = db.CustomerAdmins.Where(table => table.CustomerId == id && table.UserId == id).ToList()
                    .Count;
                var retval = total > 0 ? true : false;
                app_object_cache().add(id + "-is-customer-admin-" + staff_id, new {retval = retval});
            }

            return false;
        }

        public static bool have_assigned_customers(this object source, int staff_id = 0)
        {
            staff_id = staff_id > 0 ? staff_id : source.get_staff_user_id();
            var cache = app_object_cache().get("staff-total-assigned-customers-" + staff_id);
            var result = 0;
            if (Int32.TryParse(Convert.ToString(cache), out var value))
            {
                result = Convert.ToInt32(cache);
            }
            else
            {
                using (var db = new DBContext())
                {
                    result = db.CustomerAdmins.Where(table => table.UserId == staff_id).ToList().Count;
                    app_object_cache().add("staff-total-assigned-customers-" + staff_id, result);
                }
            }

            return result > 0 ? true : false;
        }

        public static bool has_contact_permission(this object source, string permission, int contact_id = 0)
        {
            var permissions = source.get_contact_permissions();

            if (contact_id == 0)
            {
                contact_id = source.get_contact_user_id();
            }

            try
            {
                foreach (var _permission in permissions)
                {
                    if (Convert.ToString(_permission["short_name"]) == permission)
                    {
                    }
                }
            }
            catch
            {
            }

            return false;
        }

        public static string load_client_language(this object source, int? customer_id)
        {
            var language = source.get_option<string>("active_language");

            if (source.is_client_logged_in() || customer_id > 0)
            {
                var client_language = source.get_client_default_language(customer_id);

                if (!string.IsNullOrEmpty(client_language) && File.Exists("language/" + client_language))
                {
                    language = client_language;
                }
            }

            if (File.Exists("language/" + language + "/custom_lang.php"))
            {
            }

            // SharePoint.Language = language;
            // SharePoint.Local = source.get_locale_key(language);

            hooks().DoAction("after_load_client_language", language);

            return language;
        }

        public static bool client_have_transactions(this object source, int id)
        {
            var total = 0;
            using (var db = new DBContext())
            {
                total += db.Invoices.Where(table => table.ClientId == id).ToList().Count;
                total += db.CreditNotes.Where(table => table.ClientId == id).ToList().Count;
                total += db.Estimates.Where(table => table.ClientId == id).ToList().Count;
                total += db.Expenses.Where(table => table.ClientId == id && table.Billable == 1).ToList().Count;
                total += db.Proposals.Where(table => table.RelId == id && table.RelType == "customer").ToList().Count;
            }

            hooks().ApplyFilters("customer_have_transactions", new {total = total > 0, id = id});
            return (total > 0);
        }


        public static List<Dictionary<string, object>> get_contact_permissions(this object source)
        {
            var permissions = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"id", 1},
                    {"name", label("customer_permission_invoice")},
                    {"short_name", "invoices"},
                },
                new Dictionary<string, object>()
                {
                    {"id", 2},
                    {"name", label("customer_permission_estimate")},
                    {"short_name", "estimates"}
                },
                new Dictionary<string, object>()
                {
                    {"id", 3},
                    {"name", label("customer_permission_contract")},
                    {"short_name", "contracts"}
                },
                new Dictionary<string, object>()
                {
                    {"id", 4},
                    {"name", label("customer_permission_proposal")},
                    {"short_name", "proposals"}
                },
                new Dictionary<string, object>()
                {
                    {"id", 5},
                    {"name", label("customer_permission_support")},
                    {"short_name", "support"}
                },
                new Dictionary<string, object>()
                {
                    {"id", 6},
                    {"name", label("customer_permission_projects")},
                    {"short_name", "projects"}
                }
            };

            hooks().ApplyFilters("get_contact_permissions", permissions);
            return permissions;
        }

        public static dynamic get_contact_permission(this object source, string name)
        {
            var permissions = source.get_contact_permissions();

            foreach (var permission in permissions)
            {
                if (Convert.ToString(permission["short_name"]) == name)
                {
                    return permission;
                }
            }

            return false;
        }

        public static void login_as_client(this Controller source, int id)
        {
            using (var db = new DBContext())
            {
                var primary = db.Contacts.FirstOrDefault(
                    table =>
                        table.UserId == id
                        && table.IsPrimary == 1
                );

                if (primary == null)
                {
                    // source.set_alert("danger", label("no_primary_contact"));
                }


                var announcements_model = new AnnouncementsModel();
                announcements_model.SetAnnouncementsAsReadExceptLastOne(primary.ContactId);
            }
        }

        public static void send_customer_registered_email_to_administrators(this object source, int client_id)
        {
            using (var db = new DBContext())
            {
                var admins = db.Users.Where(table => table.Active == 1 && table.Admin == 1).ToList();
                foreach (var admin in admins)
                {
                    source.send_mail_template("customer_new_registration_to_admins",
                        admin.Email,
                        client_id + "",
                        admin.UserId + ""
                    );
                }
            }
        }

        public static string contact_consent_url(this object source, int contact_id)
        {
            var consent_key = source.get_contact_meta(contact_id, "consent_key");

            return site_url("consent/contact/" + consent_key);
        }

        public static void get_all_customer_attachments(this object source, int id)
        {
            var has_permission_expenses_view = Permission.CanView("expenses");
            var has_permission_expenses_own = Permission.CanViewOwn("expenses");
            var has_permission_proposals_view = Permission.CanView("proposals");
            var has_permission_proposals_own = Permission.CanViewOwn("proposals");

            if (has_permission_proposals_view || has_permission_proposals_own ||
                source.get_option<bool>("allow_staff_view_proposals_assigned"))
            {
            }

            var permission_contracts_view = Permission.CanView("contracts");
            var permission_contracts_own = Permission.CanViewOwn("contracts");
            if (permission_contracts_view || permission_contracts_own)
            {
            }
        }

        public static void _check_vault_entries_visibility(this object source, params object[] entries)
        {
        }

        public static void get_sql_select_client_company()
        {
        }

        public static bool can_logged_in_contact_change_language(this object source)
        {
            // if (model_point().contact == default(Contacts))
            // {
            //     return false;
            // }
            //
            // return model_point().contact.IsPrimary == 1 && !source.get_option<bool>("disable_language");
            return false;
        }
    }
}