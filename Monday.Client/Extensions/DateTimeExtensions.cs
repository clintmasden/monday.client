using System;

namespace Monday.Client.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetStartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}