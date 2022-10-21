using System;
using System.Collections.Generic;

namespace ApiGateway.Library.Services.Utilities
{
    public class Date
    {
        public static string timeAgoString(string date,
            Dictionary<string, string> localization = default(Dictionary<string, string>))
        {
            var defaultLocalization = new Dictionary<string, string>();
            defaultLocalization["time_ago_just_now"] = "Just now";
            defaultLocalization["time_ago_minute"] = "one minute ago";
            defaultLocalization["time_ago_minutes"] = "{0} minutes ago";
            defaultLocalization["time_ago_hour"] = "an hour ago";
            defaultLocalization["time_ago_hours"] = "{0} hrs ago";
            defaultLocalization["time_ago_yesterday"] = "yesterday";
            defaultLocalization["time_ago_days"] = "{0} days ago";
            defaultLocalization["time_ago_week"] = "a week ago";
            defaultLocalization["time_ago_weeks"] = "{0} weeks ago";
            defaultLocalization["time_ago_month"] = "a month ago";
            defaultLocalization["time_ago_months"] = "{0} months ago";
            defaultLocalization["time_ago_year"] = "one year ago";
            defaultLocalization["time_ago_years"] = "{0} years ago";

            localization = (Dictionary<string, string>) Merger.Merge(defaultLocalization, localization);

            var time_ago = DateTimeOffset.Parse(date).ToUnixTimeSeconds();
            var cur_time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var time_elapsed = (cur_time - time_ago);
            var seconds = time_elapsed;
            var minutes = Math.Round((decimal) time_elapsed / 60);
            var hours = Math.Round((decimal) time_elapsed / 3600);
            var days = Math.Round((decimal) time_elapsed / 86400);
            var weeks = (double) Math.Round((decimal) time_elapsed / 604800);
            var months = Math.Round((decimal) time_elapsed / 2600640);
            var years = Math.Round((decimal) time_elapsed / 31207680);

            // Seconds
            if (seconds <= 60)
            {
                return localization["time_ago_just_now"];
            }

            //Minutes
            else if (minutes <= 60)
            {
                if (minutes == 1)
                {
                    return localization["time_ago_minute"];
                }

                return String.Format(localization["time_ago_minutes"], minutes);
            }

            //Hours
            else if (hours <= 24)
            {
                if (hours == 1)
                {
                    return localization["time_ago_hour"];
                }

                return String.Format(localization["time_ago_hours"], hours);
            }

            //Days
            else if (days <= 7)
            {
                if (days == 1)
                {
                    return localization["time_ago_yesterday"];
                }

                return String.Format(localization["time_ago_days"], days);
            }
            //Weeks
            else if (weeks <= 4.3)
            {
                if (weeks == 1)
                {
                    return localization["time_ago_week"];
                }

                return String.Format(localization["time_ago_weeks"], weeks);
            }
            //Months
            else if (months <= 12)
            {
                if (months == 1)
                {
                    return localization["time_ago_month"];
                }

                return String.Format(localization["time_ago_months"], months);
            }

            //Years
            if (years == 1)
            {
                return localization["time_ago_year"];
            }

            return String.Format(localization["time_ago_years"], years);
        }
    }
}