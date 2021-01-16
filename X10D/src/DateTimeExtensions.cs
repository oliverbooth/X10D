using System;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="DateTime" />.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Returns a rounded integer of the number of years since a given date as of today.
        /// </summary>
        /// <param name="date">The date from which to start.</param>
        /// <returns>Returns the number of years since <paramref name="date" /> as of today.</returns>
        public static int Age(this DateTime date)
        {
            return date.Age(DateTime.Today);
        }

        /// <summary>
        ///     Returns a rounded integer of the number of years since a given date as of another given date.
        /// </summary>
        /// <param name="date">The date from which to start.</param>
        /// <param name="asOf">The date at which to stop counting.</param>
        /// <returns>
        ///     Returns the integer number of years since <paramref name="date" /> as of
        ///     <paramref name="asOf" />.
        /// </returns>
        public static int Age(this DateTime date, DateTime asOf)
        {
            return (int)(((asOf.Date - TimeSpan.FromDays(1) - date.Date).TotalDays + 1) / 365.2425);
        }

        /// <summary>
        ///     Gets a DateTime representing the first occurence of a specified day in the current month.
        /// </summary>
        /// <param name="current">The current day.</param>
        /// <param name="dayOfWeek">The current day of week.</param>
        /// <returns>Returns a date representing the first occurence of <paramref name="dayOfWeek" />.</returns>
        public static DateTime First(this DateTime current, DayOfWeek dayOfWeek)
        {
            var first = current.FirstDayOfMonth();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.Next(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        ///     Gets a <see cref="DateTime" /> representing the first day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <returns>Returns a date representing the first day of the month>.</returns>
        public static DateTime FirstDayOfMonth(this DateTime current)
        {
            return current.AddDays(1 - current.Day);
        }

        /// <summary>
        ///     Gets a <see cref="DateTime" /> representing the last specified day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="dayOfWeek">The current day of week.</param>
        /// <returns>Returns a date representing the final occurence of <paramref name="dayOfWeek" />.</returns>
        public static DateTime Last(this DateTime current, DayOfWeek dayOfWeek)
        {
            var last = current.LastDayOfMonth();
            var lastDayOfWeek = last.DayOfWeek;

            var diff = dayOfWeek - lastDayOfWeek;
            var offset = diff > 0 ? diff - 7 : diff;

            return last.AddDays(offset);
        }

        /// <summary>
        ///     Gets a <see cref="DateTime" /> representing the last day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <returns>Returns a date representing the last day of the month>.</returns>
        public static DateTime LastDayOfMonth(this DateTime current)
        {
            var daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);
            return new DateTime(current.Year, current.Month, daysInMonth);
        }

        /// <summary>
        ///     Gets a <see cref="DateTime" /> representing the first date following the current date which falls on the
        ///     given day of the week.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="dayOfWeek">The day of week for the next date to get.</param>
        /// <returns>Returns a date representing the next occurence of <paramref name="dayOfWeek" />.</returns>
        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            var offsetDays = dayOfWeek - current.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            return current.AddDays(offsetDays);
        }

        /// <summary>
        ///     Converts the <see cref="DateTime" /> to a Unix timestamp.
        /// </summary>
        /// <param name="time">The <see cref="DateTime" /> instance.</param>
        /// <param name="useMillis">
        ///     Optional. Whether or not the return value should be represented as milliseconds.
        ///     Defaults to <see langword="false" />.
        /// </param>
        /// <returns>Returns a Unix timestamp representing the provided <see cref="DateTime" />.</returns>
        public static long ToUnixTimeStamp(this DateTime time, bool useMillis = false)
        {
            DateTimeOffset offset = time;
            return useMillis ? offset.ToUnixTimeMilliseconds() : offset.ToUnixTimeSeconds();
        }
    }
}
