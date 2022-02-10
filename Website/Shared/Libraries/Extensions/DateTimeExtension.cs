using System;

namespace Shared.Libraries.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static int Timestamp(this object source)
        {
            var unixTimestamp = (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTimestamp;
        }

        public static DateTime Test(this string stringValue)
        {
            DateTime dt;
            if (DateTime.TryParse(stringValue, out dt) &&
                dt.Date == DateTime.Today)
            {
                // do some stuff
            }

            return DateTime.Now;
        }
    }
}