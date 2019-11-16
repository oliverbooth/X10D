﻿namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Represents the Unix epoch - midnight on January 1, 1970.
        /// </summary>
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// Calculates someone's age based on a date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        public static int Age(this DateTime dateOfBirth) =>
            (int)(((DateTime.Today - TimeSpan.FromDays(1) - dateOfBirth.Date).TotalDays + 1) / 365.2425);

        /// <summary>
        /// Gets a DateTime representing the first specified day in the current month
        /// </summary>
        /// <param name="current">The current day</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns></returns>
        public static DateTime First(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime first = current.FirstDayOfMonth();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.Next(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the first day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        public static DateTime FirstDayOfMonth(this DateTime current) =>
            current.AddDays(1 - current.Day);

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the last day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        public static DateTime LastDayOfMonth(this DateTime current)
        {
            int daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);

            DateTime last = current.FirstDayOfMonth().AddDays(daysInMonth - 1);
            return last;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the last specified day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="dayOfWeek">The current day of week.</param>
        public static DateTime Last(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime last = current.LastDayOfMonth();

            last = last.AddDays(Math.Abs(dayOfWeek - last.DayOfWeek) * -1);
            return last;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing midnight on the current date.
        /// </summary>
        /// <param name="current">The current date.</param>
        public static DateTime Midnight(this DateTime current) =>
            new DateTime(current.Year, current.Month, current.Day);

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the first date following the current date which falls on the
        /// given day of the week.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="dayOfWeek">The day of week for the next date to get.</param>
        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - current.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            DateTime result = current.AddDays(offsetDays);
            return result;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing noon on the current date.
        /// </summary>
        /// <param name="current">The current date.</param>
        public static DateTime Noon(this DateTime current) =>
            new DateTime(current.Year, current.Month, current.Day, 12, 0, 0);

        /// <summary>
        /// Sets the time of the current date with minute precision.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        public static DateTime SetTime(this DateTime current, int hour, int minute) =>
            current.SetTime(hour, minute, 0, 0);

        /// <summary>
        /// Sets the time of the current date with second precision.
        /// </summary>
        /// <param name="current">The current date</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour, int minute, int second) =>
            current.SetTime(hour, minute, second, 0);

        /// <summary>
        /// Sets the time of the current date with millisecond precision.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        /// <param name="millisecond">The millisecond.</param>
        public static DateTime SetTime(this DateTime current, int hour, int minute, int second, int millisecond) =>
            new DateTime(current.Year, current.Month, current.Day, hour, minute, second, millisecond);

        /// <summary>
        /// Converts the <see cref="DateTime"/> to a Unix timestamp.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> instance.</param>
        /// <param name="useMillis">Optional. Whether or not the return value should be represented as milliseconds.
        /// Defaults to <see langword="false"/>.</param>
        /// <returns>Returns a Unix timestamp representing the provided <see cref="DateTime"/>.</returns>
        public static long ToUnixTimeStamp(this DateTime time, bool useMillis = false)
        {
            TimeSpan difference = time - UnixEpoch;
            return (long)(useMillis ? difference.TotalMilliseconds : difference.TotalSeconds);
        }

        /// <summary>
        /// Returns the <see cref="DateTime"/> with the year set to the provided value.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to copy.</param>
        /// <param name="year">The year to set.</param>
        /// <returns>Returns a <see cref="DateTime"/>.</returns>
        public static DateTime WithYear(this DateTime date, int year) =>
            new DateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
    }
}
