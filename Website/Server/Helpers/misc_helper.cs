using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Server.Helpers
{
    public static class misc_helper
    {
        /**
 * CHeck missing key from the main english language
 * @param  string language language to check
 * @return void
 */
        public static void check_missing_language_strings(this Helper helper, string language)
        {
            // langs = array();
            //
            // CI.lang.load("english_lang", "english");
            // english       = CI.lang.language;
            // langs[]       = array(
            //     "english" => english,
            // );
            // original      = english;
            // keys_original = array();
            // foreach (original as k => val) {
            //     keys_original[k] = true;
            // }
            // CI.lang.ishelper.labeloaded = array();
            // CI.lang.language  = array();
            // CI.lang.load(language . "_lang", language);
            // language           = CI.lang.language;
            // langs[]             = array(
            //     language => language,
            // );
            // CI.lang.ishelper.labeloaded = array();
            // CI.lang.language  = array();
            // missing_keys        = array();
            // for (i = 0; i < count(langs); i++) {
            //     foreach (langs[i] as lang => data) {
            //         if (lang != "english") {
            //             keys_current = array();
            //             foreach (data as k => v) {
            //                 keys_current[k] = true;
            //             }
            //             foreach (keys_original as k_original => val_original) {
            //                 if (!array_key_exists(k_original, keys_current)) {
            //                     keys_missing = true;
            //                     array_push(missing_keys, k_original);
            //                      "<b>Missing language key</b> from language:" . lang . " - <b>key</b>:" . k_original . "<br />";
            //                 }
            //             }
            //         }
            //     }
            // }
            // if (isset(keys_missing)) {
            //      "<br />--<br />Language keys missing please create <a href="https://help.perfexcrm.com/overwrite-translation-text/" target="_blank">custom_lang.php</a> and add the keys listed above.";
            //      "<br /> Here is how you should add the keys (You can just copy paste this text above and add your translations)<br /><br />";
            //     foreach (missing_keys as key) {
            //          "lang[\"" . key . "\"] = \"Add your translation\";<br />";
            //     }
            // } else {
            //      "<h1>No Missing Language Keys Found</h1>";
            // }
            // die;
        }

        /**
 * Return locale for media usafe plugin
 * @param  string locale current locale
 * @return string
 */
        public static string get_media_locale(string locale)
        {
            var lng = locale;
            if (lng == "ja")
                lng = "jp";
            else if (lng == "pt")
                lng = "pt_BR";
            else if (lng == "ug")
                lng = "ug_CN";
            else if (lng == "zh") lng = "zh_TW";

            return lng;
        }

        /**
 * Get system favourite colors
 * @return array
 */
        public static List<string> get_system_favourite_colors(this Helper helper)
        {
            // don"t delete any of these colors are used all over the system
            var colors = new List<string>
            {
                "#28B8DA",
                "#03a9f4",
                "#c53da9",
                "#757575",
                "#8e24aa",
                "#d81b60",
                "#0288d1",
                "#7cb342",
                "#fb8c00",
                "#84C529",
                "#fb3b3b"
            };

            // colors = do_action("system_favourite_colors", colors);

            return colors;
        }

        /**
 * Get goal types for the goals feature
 * @return array
 */
        public static void get_goal_types()
        {
            // var types = array(
            //      array(
            //          "key" => 1,
            //          "lang_key" => "goal_type_total_income",
            //          "subtext" => "goal_type_income_subtext",
            //      ),
            //      array(
            //          "key" => 2,
            //          "lang_key" => "goal_type_converthelper.labeleads",
            //      ),
            //      array(
            //          "key" => 3,
            //          "lang_key" => "goal_type_increase_customers_withouthelper.labeleads_conversions",
            //          "subtext" => "goal_type_increase_customers_withouthelper.labeleads_conversions_subtext",
            //      ),
            //      array(
            //          "key" => 4,
            //          "lang_key" => "goal_type_increase_customers_withhelper.labeleads_conversions",
            //          "subtext" => "goal_type_increase_customers_withhelper.labeleads_conversions_subtext",
            //      ),
            //      array(
            //          "key" => 5,
            //          "lang_key" => "goal_type_make_contracts_by_type_calc_database",
            //          "subtext" => "goal_type_make_contracts_by_type_calc_database_subtext",
            //      ),
            //      array(
            //          "key" => 7,
            //          "lang_key" => "goal_type_make_contracts_by_type_calc_date",
            //          "subtext" => "goal_type_make_contracts_by_type_calc_date_subtext",
            //      ),
            //      array(
            //          "key" => 6,
            //          "lang_key" => "goal_type_total_estimates_converted",
            //          "subtext" => "goal_type_total_estimates_converted_subtext",
            //      ),
            //  );
            //
            //  return do_action("get_goal_types", types);
        }

        /**
 * Translate goal type based on passed key
 * @param  mixed key
 * @return string
 */
        public static string format_goal_type(this Helper helper, string key)
        {
            // foreach (var type in get_goal_types() ) {
            //     if (type["key"] == key) {
            //         return helper.label(type["lang_key"]);
            //     }
            // }
            //
            // return type;
            return "";
        }

        /**
 * Used for estimate and proposal acceptance info array
 * @param  boolean empty should the array values be empty or taken from _POST
 * @return array
 */
        public static void get_acceptance_info_array(this Helper helper, bool empty = false)
        {
            // var  data = new{
            //       "acceptance_firstname"=>!empty ? CI.input.post("acceptance_firstname") : null,
            //       "acceptancehelper.labelastname"=>!empty ? CI.input.post("acceptancehelper.labelastname") : null,
            //       "acceptance_email"=>!empty ? CI.input.post("acceptance_email"): null,
            //       "acceptance_date"=>!empty ? date("Y-m-d H:i:s") : null,
            //       "acceptance_ip"=> !empty ? CI.input.ip_address() : null,
            //   };
            //
            //   hook_data = do_action("acceptance_info_array", array("data"=>data, "empty"=>empty));
            //
            //   return hook_data["data"];
        }

        /**
 * Check if the user is lead creator
 * @since  Version 1.0.4
 * @param  mixed  leadid leadid
 * @param  mixed  staff_id staff id (Optional)
 * @return boolean
 */
        public static bool is_lead_creator(this Helper helper, int lead_id, string staff_id = "")
        {
            // if (!is_numeric(staff_id)) {
            //     staff_id = get_staff_user_id();
            // }
            //
            // is = total_rows("tblleads", array(
            //     "addedfrom" => staff_id,
            //     "id" => lead_id,
            // ));
            //
            // if (is > 0) {
            //     return true;
            // }

            return false;
        }

        /**
 * Get available locaes predefined for the system
 * If you add a language and the locale do not exist in this array you can use action hook to add new locale
 * @return array
 */
        public static void get_locales()
        {
            // var   locales = array(
            //        "Arabic" => "ar",
            //        "Bulgarian" => "bg",
            //        "Catalan" => "ca",
            //        "Czech" => "cs",
            //        "Danish" => "da",
            //        "Albanian" => "sq",
            //        "German" => "de",
            //        "Deutsch" => "de",
            //        "Dutch" => "nl",
            //        "Greek" => "el",
            //        "English" => "en",
            //        "Finland" => "fi",
            //        "Spanish" => "es",
            //        "Persian" => "fa",
            //        "Finnish" => "fi",
            //        "French" => "fr",
            //        "Hebrew" => "he",
            //        "Hindi" => "hi",
            //        "Indonesian" => "id",
            //        "Hindi" => "hi",
            //        "Croatian" => "hr",
            //        "Hungarian" => "hu",
            //        "Icelandic" => "is",
            //        "Italian" => "it",
            //        "Japanese" => "ja",
            //        "Korean" => "ko",
            //        "Lithuanian" => "lt",
            //        "Latvian" => "lv",
            //        "Norwegian" => "nb",
            //        "Netherlands" => "nl",
            //        "Polish" => "pl",
            //        "Portuguese" => "pt",
            //        "Romanian" => "ro",
            //        "Russian" => "ru",
            //        "Slovak" => "sk",
            //        "Slovenian" => "sl",
            //        "Serbian" => "sr",
            //        "Swedish" => "sv",
            //        "Thai" => "th",
            //        "Turkish" => "tr",
            //        "Ukrainian" => "uk",
            //        "Vietnamese" => "vi",
            //    );
            //
            //    locales = do_action("before_gethelper.labelocales", locales);
            //
            //    return locales;
        }

        /**
 * Tinymce language set can be complicated and this public static void  will scan the available languages
 * Will return lang filename in the tinymce plugins folder if found or if locale is en will return just en
 * @param  [type] locale [description]
 * @return [type]         [description]
 */
        public static void get_tinymce_language(this Helper helper, string locale)
        {
            // var   av_lang = list_files(FCPATH . "assets/plugins/tinymce/langs/");
            //    var _lang   = "";
            //    if (locale == "en") {
            //        return _lang;
            //    }
            //
            //    if (locale == "hi") {
            //        return "hi_IN";
            //    } else if (locale == "he") {
            //        return "he_IL";
            //    } else if (locale == "sv") {
            //        return "sv_SE";
            //    }
            //
            //    foreach (av_lang as lang) {
            //        _temp_lang = explode(".", lang);
            //        if (locale == _temp_lang[0]) {
            //            return locale;
            //        } else if (locale . "_" . strtoupper(locale) == _temp_lang[0]) {
            //            return locale . "_" . strtoupper(locale);
            //        }
            //    }
            //
            //    return _lang;
        }

        /**
 * All permissions available in the app with conditions
 * @return array
 */
        public static void get_permission_conditions()
        {
            // return do_action("staff_permissions_conditions", array(
            //     "contracts" => array(
            //         "view" => true,
            //         "view_own" => true,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "leads" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => false,
            //         "create" => false,
            //         "delete" => true,
            //         "help" => helper.label("helphelper.labeleads_permission_view"),
            //         "help_create" => helper.label("helphelper.labeleads_create_permission"),
            //         "help_edit" => helper.label("helphelper.labeleads_edit_permission"),
            //     ),
            //     "tasks" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //         "help" => helper.label("help_tasks_permissions"),
            //     ),
            //     "checklist_templates" => array(
            //         "view" => false,
            //         "view_own" => false,
            //         "edit" => false,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "reports" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => false,
            //         "create" => false,
            //         "delete" => false,
            //     ),
            //     "settings" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => false,
            //         "delete" => false,
            //     ),
            //     "projects" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //         "help" => helper.label("help_project_permissions"),
            //     ),
            //     "surveys" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "staff" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "customers" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "email_templates" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => false,
            //         "delete" => false,
            //     ),
            //     "roles" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "expenses" => array(
            //         "view" => true,
            //         "view_own" => true,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "bulk_pdf_exporter" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => false,
            //         "create" => false,
            //         "delete" => false,
            //     ),
            //     "goals" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "knowledge_base" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "proposals" => array(
            //         "view" => true,
            //         "view_own" => true,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "estimates" => array(
            //         "view" => true,
            //         "view_own" => true,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "payments" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "invoices" => array(
            //         "view" => true,
            //         "view_own" => true,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "credit_notes" => array(
            //         "view" => true,
            //         "view_own" => true,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            //     "items" => array(
            //         "view" => true,
            //         "view_own" => false,
            //         "edit" => true,
            //         "create" => true,
            //         "delete" => true,
            //     ),
            // ));
        }

        /**
 * Feature that will render all JS necessary data in admin head
 * @return void
 */
        public static void render_admin_js_variables()
        {
            // date_format = get_option("dateformat");
            // date_format = explode("|", date_format);
            // date_format = date_format[0];
            //
            //
            // js_vars     = array(
            //     "site_url" => site_url(),
            //     "admin_url" => admin_url(),
            //     "max_php_ini_upload_size_bytes" => file_upload_max_size(),
            //     "google_api" => "",
            //     "calendarIDs" => "",
            //     "is_admin" => is_admin(),
            //     "is_staff_member" => is_staff_member(),
            //     "has_permission_tasks_checklist_items_delete" => has_permission("checklist_templates", "", "delete"),
            //     "app_language" => get_staff_default_language(),
            //     "app_is_mobile" => is_mobile(),
            //     "app_user_browser"=>strtolower(CI.agent.browser()),
            //     "app_date_format" => date_format,
            //     "app_decimal_places"=>get_decimal_places(),
            //     "app_scroll_responsive_tables" => get_option("scroll_responsive_tables"),
            //     "app_company_is_required" => get_option("company_is_required"),
            //     "app_default_view_calendar"=>get_option("default_view_calendar"),
            //     "app_show_table_columns_visibility" => do_action("show_table_columns_visibility", 0),
            //     "app_maximum_allowed_ticket_attachments" => get_option("maximum_allowed_ticket_attachments"),
            //     "app_show_setup_menu_item_only_on_hover" => get_option("show_setup_menu_item_only_on_hover"),
            //     "app_calendar_eventshelper.labelimit" => get_option("calendar_eventshelper.labelimit"),
            //     "app_tables_paginationhelper.labelimit" => get_option("tables_paginationhelper.labelimit"),
            //     "app_newsfeed_maximum_files_upload" => get_option("newsfeed_maximum_files_upload"),
            //     "app_time_format" => get_option("time_format"),
            //     "app_decimal_separator" => get_option("decimal_separator"),
            //     "app_thousand_separator" => get_option("thousand_separator"),
            //     "app_currency_placement" => get_option("currency_placement"),
            //     "app_timezone" => get_option("default_timezone"),
            //     "app_calendar_first_day" => get_option("calendar_first_day"),
            //     "app_allowed_files" => get_option("allowed_files"),
            //     "app_show_table_export_button" => get_option("show_table_export_button"),
            //     "app_desktop_notifications" => get_option("desktop_notifications"),
            //     "app_dismiss_desktop_not_after" => get_option("auto_dismiss_desktop_notifications_after"),
            // );
            //
            // lang = array(
            //     "invoice_task_billable_timers_found" => helper.label("invoice_task_billable_timers_found"),
            //     "validation_extension_not_allowed" => helper.label("validation_extension_not_allowed"),
            //     "tag"=>helper.label("tag"),
            //     "options" => helper.label("options"),
            //     "no_items_warning" => helper.label("no_items_warning"),
            //     "item_forgotten_in_preview" => helper.label("item_forgotten_in_preview"),
            //     "email_exists" => helper.label("email_exists"),
            //     "new_notification" => helper.label("new_notification"),
            //     "estimate_number_exists" => helper.label("estimate_number_exists"),
            //     "invoice_number_exists" => helper.label("invoice_number_exists"),
            //     "confirm_action_prompt" => helper.label("confirm_action_prompt"),
            //     "calendar_expand" => helper.label("calendar_expand"),
            //     "proposal_save" => helper.label("proposal_save"),
            //     "contract_save" => helper.label("contract_save"),
            //     "media_files" => helper.label("media_files"),
            //     "credit_note_number_exists" => helper.label("credit_note_number_exists"),
            //     "item_field_not_formatted" => helper.label("numbers_not_formatted_while_editing"),
            //     "filter_by" => helper.label("filter_by"),
            //     "you_can_not_upload_any_more_files" => helper.label("you_can_not_upload_any_more_files"),
            //     "cancel_upload" => helper.label("cancel_upload"),
            //     "remove_file" => helper.label("remove_file"),
            //     "browser_not_support_drag_and_drop" => helper.label("browser_not_support_drag_and_drop"),
            //     "drop_files_here_to_upload" => helper.label("drop_files_here_to_upload"),
            //     "file_exceeds_max_filesize" => helper.label("file_exceeds_max_filesize") . " (".bytesToSize("", file_upload_max_size()).")",
            //     "file_exceeds_maxfile_size_in_form" => helper.label("file_exceeds_maxfile_size_in_form"). " (".bytesToSize("", file_upload_max_size()).")",
            //     "unit" => helper.label("unit"),
            //     "dthelper.labelength_menu_all" => helper.label("dthelper.labelength_menu_all"),
            //     "dt_button_column_visibility" => helper.label("dt_button_column_visibility"),
            //     "dt_button_reload" => helper.label("dt_button_reload"),
            //     "dt_button_excel" => helper.label("dt_button_excel"),
            //     "dt_button_csv" => helper.label("dt_button_csv"),
            //     "dt_button_pdf" => helper.label("dt_button_pdf"),
            //     "dt_button_print" => helper.label("dt_button_print"),
            //     "dt_button_export" => helper.label("dt_button_export"),
            //     "search_ajax_empty"=>helper.label("search_ajax_empty"),
            //     "search_ajax_initialized"=>helper.label("search_ajax_initialized"),
            //     "search_ajax_searching"=>helper.label("search_ajax_searching"),
            //     "not_results_found"=>helper.label("not_results_found"),
            //     "search_ajax_placeholder"=>helper.label("search_ajax_placeholder"),
            //     "currently_selected"=>helper.label("currently_selected"),
            //     "task_stop_timer"=>helper.label("task_stop_timer"),
            //     "note"=>helper.label("note"),
            //     "search_tasks"=>helper.label("search_tasks"),
            //     "confirm"=>helper.label("confirm"),
            //     "showing_billable_tasks_from_project"=>helper.label("showing_billable_tasks_from_project"),
            //     "invoice_task_item_project_tasks_not_included"=>helper.label("invoice_task_item_project_tasks_not_included"),
            //     "credit_amount_bigger_then_invoice_balance"=>helper.label("credit_amount_bigger_then_invoice_balance"),
            //     "credit_amount_bigger_then_credit_note_remaining_credits"=>helper.label("credit_amount_bigger_then_credit_note_remaining_credits"),
            // );
            //
            // js_vars     = do_action("before_render_app_js_vars_admin", js_vars);
            // lang        = do_action("before_render_app_js_lang_admin", lang);
            //
            //  "<script>";
            //
            // firstKey = key(js_vars);
            //
            // vars = "var " . firstKey . "="" . js_vars[firstKey] . "",";
            //
            // unset(js_vars[firstKey]);
            //
            // foreach (js_vars as var => val) {
            //     vars .= var . "="" . val . "",";
            // }
            //
            //  rtrim(vars, ",") . ";";
            //
            //  "var appLang = {};";
            // foreach (lang as key=>val) {
            //      "appLang["".key.""] = "".val."";";
            // }
            //
            //  "</script>";
        }

        /**
 * For html5 form accepted attributes
 * This public static void  is used for the form attachments
 * @return string
 */
        public static void get_form_accepted_mimes()
        {
            // allowed_extensions  = get_option("allowed_files");
            // _allowed_extensions = explode(",", allowed_extensions);
            // all_form_ext = "";
            //
            // // Chrome doing conflict when the regular extensions are appended to the accept attribute which cause top popup
            // // to select file to stop opening
            // if (CI.agent.browser() != "Chrome") {
            //     all_form_ext        .= allowed_extensions;
            // }
            // if (is_array(_allowed_extensions)) {
            //     if (all_form_ext != "") {
            //         all_form_ext .= ", ";
            //     }
            //     foreach (_allowed_extensions as ext) {
            //         all_form_ext .= get_mime_by_extension(ext) . ", ";
            //     }
            // }
            //
            // all_form_ext = rtrim(all_form_ext, ", ");
            //
            // return all_form_ext;
        }

        /**
 * CLear the session for the setup menu to be open
 * @return null
 */
        public static void close_setup_menu()
        {
            // get_instance().session.set_userdata(array(
            //     "setup-menu-open" => "",
            // ));
        }

        /**
 * Add http to url
 * @param  string url url to add http
 * @return string
 */
        public static void maybe_add_http(string url)
        {
            // if (!preg_match("~^(?:f|ht)tps?://~i", url)) {
            //     url = "http://" . url;
            // }
            //
            // return url;
        }

        /**
 * Return specific alert bootstrap class
 * @return string
 */
        public static void get_alert_class()
        {
            // var  alert_class = "";
            //  if (CI.session.flashdata("message-success")) {
            //      alert_class = "success";
            //  } else if (CI.session.flashdata("message-warning")) {
            //      alert_class = "warning";
            //  } else if (CI.session.flashdata("message-info")) {
            //      alert_class = "info";
            //  } else if (CI.session.flashdata("message-danger")) {
            //      alert_class = "danger";
            //  }
            //
            //  return alert_class;
        }

        /**
 * Generate random alpha numeric string
 * @param  integer length the length of the string
 * @return string
 */
        public static void generate_two_factor_auth_key()
        {
            // key = "";
            // keys = array_merge(range(0, 9), range("a", "z"));
            //
            // for (i = 0; i < 16; i++) {
            //     key .= keys[array_rand(keys)];
            // }
            //
            // key .= uniqid();
            //
            // return key;
        }

        /**
 * public static void  that will replace the dropbox link size for the images
 * This public static void  is used to preview dropbox image attachments
 * @param  string url
 * @param  string bounding_box
 * @return string
 */
        public static void optimize_dropbox_thumbnail(string url, string bounding_box = "800")
        {
            // url = str_replace("bounding_box=75", "bounding_box=" . bounding_box, url);
            // return url;
        }

        /**
 * Prepare label when splitting weeks for charts
 * @param  array weeks week
 * @param  mixed week  week day - number
 * @return string
 */
        public static void split_weeks_chart_label(dynamic weeks, object week)
        {
            // week_start = weeks[week][0];
            // end(weeks[week]);
            // key = key(weeks[week]);
            // week_end = weeks[week][key];
            //
            // week_start_year = date("Y", strtotime(week_start));
            // week_end_year = date("Y", strtotime(week_end));
            //
            // week_start_month = date("m", strtotime(week_start));
            // week_end_month = date("m", strtotime(week_end));
            //
            // label = "";
            //
            // label .= date("d", strtotime(week_start));
            //
            // if (week_start_month != week_end_month && week_start_year == week_end_year) {
            //     label .= " " . helper.label(date("F", mktime(0, 0, 0, week_start_month, 1)));
            // }
            //
            // if (week_start_year != week_end_year) {
            //     label .=  " " . helper.label(date("F", mktime(0, 0, 0, date("m", strtotime(week_start)), 1))) . " " . date("Y", strtotime(week_start));
            // }
            //
            // label .= " - ";
            // label .= date("d", strtotime(week_end));
            // if (week_start_year != week_end_year) {
            //     label .=  " " . helper.label(date("F", mktime(0, 0, 0, date("m", strtotime(week_end)), 1))) ." " . date("Y", strtotime(week_end));
            // }
            //
            // if (week_start_year == week_end_year) {
            //     label .=  " " . helper.label(date("F", mktime(0, 0, 0, date("m", strtotime(week_end)), 1)));
            //     label .= " " . date("Y", strtotime(week_start));
            // }
            //
            // return label;
        }

        /**
 * Get ranges weeks between 2 dates
 * @param  object start_time date object
 * @param  objetc end_time   date object
 * @return array
 */
        public static void get_weekdays_between_dates(DateTime start_time, DateTime end_time)
        {
            // interval = new DateInterval("P1D");
            // end_time = end_time.modify("+1 day");
            // dateRange = new DatePeriod(start_time, interval, end_time);
            // weekNumber = 1;
            // weeks = array();
            //
            // foreach (dateRange as date) {
            //     weeks[weekNumber][] = date.format("Y-m-d");
            //     if (date.format("w") == 0) {
            //         weekNumber++;
            //     }
            // }
            //
            // return weeks;
        }

        public static void render_leads_status_select(string statuses, string selected = "",
            string lang_key = "", string name = "status", dynamic select_attrs = default(ExpandoObject))
        {
            // if (is_admin() || get_option("staff_members_create_inlinehelper.labelead_status") == "1") {
            //     return render_select_with_input_group(name, statuses, array("id", "name"), lang_key, selected, "<a href="#" onclick="newhelper.labelead_status_inline();return false;" class="inline-field-new"><i class="fa fa-plus"></i></a>", select_attrs);
            // } else {
            //     return render_select(name, statuses, array("id", "name"), lang_key, selected, select_attrs);
            // }
        }

        public static void render_leads_source_select(object sources, string selected = "",
            string lang_key = "", string name = "source", dynamic select_attrs = default(ExpandoObject))
        {
            // if (is_admin() || get_option("staff_members_create_inlinehelper.labelead_source") == "1") {
            //      render_select_with_input_group(name, sources, array("id", "name"), lang_key, selected, "<a href="#" onclick="newhelper.labelead_source_inline();return false;" class="inline-field-new"><i class="fa fa-plus"></i></a>", select_attrs);
            // } else {
            //      render_select(name, sources, array("id", "name"), lang_key, selected, select_attrs);
            // }
        }

        /**
 * public static void  that will search possible contracts templates in applicaion/views/admin/contracts/templates
 * Will return any found files and user will be able to add new template
 * @return array
 */
        public static void get_contract_templates()
        {
            // contract_templates = array();
            // if (is_dir(VIEWPATH . "admin/contracts/templates")) {
            //     foreach (list_files(VIEWPATH . "admin/contracts/templates") as template) {
            //         contract_templates[] = template;
            //     }
            // }
            //
            // return contract_templates;
        }
    }
}