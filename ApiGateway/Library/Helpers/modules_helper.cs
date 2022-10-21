using System;
using System.Collections.Generic;
using ApiGateway.Core;
using ApiGateway.Models;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Library.Helpers
{
    public static class modules_helper
    {
        public static void register_activation_hook(this object source, string module, Func<dynamic, dynamic> function)
        {
            hooks().AddAction("activate_" + module + "_module", function);
        }

        public static void register_deactivation_hook(this object source, string module,
            Func<dynamic, dynamic> function)
        {
            hooks().AddAction("deactivate_" + module + "_module", function);
        }

        public static void register_uninstall_hook(this object source, string module, Func<dynamic, dynamic> function)
        {
            hooks().AddAction("uninstall_" + module + "_module", function);
        }

        public static void register_merge_fields(this object source, string @for)
        {
        }

        public static void add_module_support(this object source, string module_name, dynamic feature)
        {
            // source.app_modules().add_supports_feature(module_name, feature);
        }

        public static bool module_supports(this object source, string module_name, dynamic feature)
        {
            // return source.app_modules().supports_feature(module_name, feature);
            return false;
        }

        public static void register_cron_task(this object source, Func<dynamic, dynamic> function)
        {
            hooks().AddAction("after_cron_run", function);
        }

        public static void register_staff_capabilities(this object source, int feature_id, string config,
            string name = null)
        {
        }

        public static string modules_list_url(this object source)
        {
            return source.admin_url("modules");
        }

        public static void register_payment_gateway(this object source, int id, string module)
        {
            var payment_modes_model = new PaymentModesModel();
            payment_modes_model.AddPaymentGateway(id, module);
        }

        public static bool register_theme_assets_hook(this object source, Func<dynamic, dynamic> function)
        {
            if (hooks().HasAction("app_client_assets", function))
            {
                return false;
            }

            hooks().AddAction("app_client_assets", function);
            return true;
        }

        public static string module_views_path(this object source, string module, string concat = "")
        {
            return source.module_dir_path(module) + "views/" + concat;
        }

        public static string module_libs_path(this object source, string module, string concat = "")
        {
            return source.module_dir_path(module) + "libraries/" + concat;
        }

        public static string module_dir_path(this object source, string module, string concat = "")
        {
            return Constants.APP_MODULES_PATH + module + "/" + concat;
        }

        public static string module_dir_url(this object source, string module, string segment = "")
        {
            return "#modules_helper.module_dir_url";
        }


        public static void register_language_files(this object source, string module, params string[] languages)
        {
        }

        public static List<string> uninstallable_modules(this object source)
        {
            return new List<string>()
            {
                "theme_style", "menu_setup", "backup", "surveys", "goals"
            };
        }

        public static void do_action_deprecated(this object source, string tag, List<string> args, string version,
            string replacement = null, string message = null)
        {
            if (!hooks().HasAction(tag))
            {
                return;
            }

            source._deprecated_hook(tag, version, replacement, message);
            hooks().DoActionRefArray(tag, args);
        }

        public static string apply_filters_deprecated(this object source, string tag, List<string> args, string version,
            string replacement = null, string message = null)
        {
            if (!hooks().HasFilter(tag))
            {
                return args[0];
            }

            source._deprecated_hook(tag, version, replacement, message);
            return hooks().ApplyFiltersRefArray(tag, args);
        }
    }
}