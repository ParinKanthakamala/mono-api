using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ApiGateway.Entities;
using Microsoft.AspNetCore.Mvc;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;

namespace ApiGateway.Library.Helpers
{
    public static class general_helper
    {
        public static bool is_rtl(this object source, bool client_area = false)
        {
            if (source.is_client_logged_in())
            {
                var direction = "";
                using (var db = new DBContext())
                {
                    direction = db.Contacts.FirstOrDefault(table => table.ContactId == source.get_contact_user_id())
                        .Direction;
                }

                if (direction == "rtl")
                {
                    return true;
                }
                else if (direction == "ltr")
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(direction))
                {
                    if (source.get_option<bool>("rtl_support_client"))
                    {
                        return true;
                    }
                }

                return false;
            }
            else if (client_area)
            {
                if (source.get_option<bool>("rtl_support_client"))
                {
                    return true;
                }
            }
            else if (source.is_staff_logged_in())
            {
                var direction = "";
                using (var db = new DBContext())
                {
                    // direction = model_point().current_user != null
                    //     ? model_point().current_user.Direction
                    //     : db.Users.FirstOrDefault(table => table.UserId == source.get_staff_user_id())?.Direction;
                }

                if (direction == "rtl")
                {
                    return true;
                }
                else if (direction == "ltr")
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(direction))
                {
                    if (source.get_option<bool>("rtl_support_admin"))
                    {
                        return true;
                    }
                }

                return false;
            }
            else if (client_area == false)
            {
                if (source.get_option<bool>("rtl_support_admin"))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool is_data_for_customer(this object source)
        {
            return source.is_client_logged_in()
                   || (!source.is_staff_logged_in() && !source.is_client_logged_in())
                ;
        }

        public static string generate_encryption_key(this object source)
        {
            return "";
        }

        public static string get_app_version(this object source)
        {
            return "";
        }

        public static void redirect_after_login_to_current_url(this object source)
        {
        }

        public static void maybe_redirect_to_previous_url(this object source)
        {
        }

        public static bool do_recaptcha_validation(this object source, string str = "")
        {
            return false;
        }

        public static string get_current_date_format(this object source, bool first = false)
        {
            try
            {
                var date_format = source.get_option<string>("date_format");
                var formats = date_format.Split("|").ToList();
                hooks().ApplyFilters("get_current_date_format", new {format = formats, first = first});

                if (!first)
                {
                    try
                    {
                        return formats[1];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                return formats[0];
            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }

        public static bool is_logged_in(this object source)
        {
            return (source.is_client_logged_in() || source.is_staff_logged_in());
        }

        public static bool is_client_logged_in(this object source)
        {
            return false;
        }

        public static bool is_staff_logged_in(this object source)
        {
            return false;
        }

        public static int get_staff_user_id(this object source)
        {
            if (!source.is_staff_logged_in())
            {
                return 0;
            }

            return 0;
        }

        public static int get_client_user_id(this object source)
        {
            if (!source.is_client_logged_in())
            {
                return 0;
            }

            return 0;
        }

        public static int get_contact_user_id(this object source)
        {
            return 0;
        }

        public static ReadOnlyCollection<TimeZoneInfo> get_timezones_list(this object source)
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        public static bool is_mobile(this object source)
        {
            if (source.is_mobile())
            {
                return true;
            }

            return false;
        }


        public static IActionResult ajax_access_denied(this Controller source)
        {
            return source.StatusCode(401);
        }

        public static void set_debug_alert(this object source, string message)
        {
        }

        public static bool set_system_popup(this object source, string message)
        {
            if (!source.is_admin())
            {
                return false;
            }

            return false;
        }

        public static dynamic get_available_date_formats(this object source)
        {
            var date_formats = new Dictionary<string, string>()
            {
                {"d-m-Y|%d-%m-%Y", "d-m-Y"},
                {"d/m/Y|%d/%m/%Y", "d/m/Y"},
                {"m-d-Y|%m-%d-%Y", "m-d-Y"},
                {"m.d.Y|%m.%d.%Y", "m.d.Y"},
                {"m/d/Y|%m/%d/%Y", "m/d/Y"},
                {"Y-m-d|%Y-%m-%d", "Y-m-d"},
                {"d.m.Y|%d.%m.%Y", "d.m.Y"}
            };

            return hooks().ApplyFilters("available_date_formats", new {date_formats = date_formats});
        }

        public static List<string> get_weekdays(this object source)
        {
            return new List<string>()
            {
                label("wd_monday"),
                label("wd_tuesday"),
                label("wd_wednesday"),
                label("wd_thursday"),
                label("wd_friday"),
                label("wd_saturday"),
                label("wd_sunday")
            };
        }

        public static List<string> get_weekdays_original(this object source)
        {
            return new List<string>()
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
        }


        public static string _d(this object source, DateTime? date)
        {
            var formatted = "";

            var format = source.get_current_date_format();
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            hooks().ApplyFilters("after_format_date", new {formatted = formatted, date = date});
            return "";
        }

        public static string _dt(this object source, DateTime? date, bool is_timesheet = false)
        {
            var original = date;

            hooks().ApplyFilters("after_format_datetime",
                new {date = date, original = original, is_timesheet = is_timesheet});
            return "";
        }

        public static void to_sql_date(this object source, DateTime date, bool datetime = false)
        {
        }

        public static void _simplify_date_fix(this object source, DateTime date, string from_format)
        {
        }

        public static DateTime is_date(this object source, string date)
        {
            if (date.Length < 10)
            {
                return DateTime.Now;
            }

            return DateTime.Parse(date);
        }

        public static void get_locales(this object source)
        {
        }

        public static string get_locale_key(this object source, string language = "english")
        {
            return "";
        }

        public static string current_full_url(this object source)
        {
            return null;
        }

        public static void pusher_trigger_notification(this object source, params int[] users)
        {
            if (!source.get_option<bool>("pusher_realtime_notifications"))
            {
            }
        }


        public static string app_generate_hash(this object source)
        {
            return "";
        }

        public static void get_csrf_for_ajax(this object source)
        {
        }

        public static void csrf_jquery_token(this object source)
        {
        }

        public static string app_happy_text(this object source, string text)
        {
            return text;
        }

        public static string get_temp_dir(this object source)
        {
            return "/tmp/";
        }


        public static void app_hasher(this object source)
        {
        }

        public static string app_hash_password(this object source, string password)
        {
            return PasswordHandler.CreatePasswordHash(password);
        }

        public static DateTime round_timesheet_time(this object source, DateTime datetime)
        {
            var dt = datetime;
            //int r = 15;
            return datetime;
        }

        public static void roundUpToMinuteInterval(this object source, DateTime dateTime, int minuteInterval = 10)
        {
        }

        public static void roundDownToMinuteInterval(this object source, DateTime dateTime, int minuteInterval = 10)
        {
        }

        public static void roundToNearestMinuteInterval(this object source, DateTime dateTime, int minuteInterval = 10)
        {
        }

        public static object get_last_upgrade_copy_data(this object source)
        {
            var lastUpgradeCopyData = source.get_option<string>("last_upgrade_copy_data");
            if (!string.IsNullOrEmpty(lastUpgradeCopyData))
            {
            }

            return null;
        }
    }
}