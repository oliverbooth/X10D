﻿using System;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="DateTime" />.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <inheritdoc cref="DateTimeOffsetExtensions.Age(DateTimeOffset)" />
        public static int Age(this DateTime value)
        {
            return value.Age(DateTime.Today);
        }

        /// <inheritdoc cref="DateTimeOffsetExtensions.Age(DateTimeOffset, DateTimeOffset)" />
        public static int Age(this DateTime value, DateTime asOf)
        {
            return ((DateTimeOffset)value).Age(asOf);
        }

        /// <inheritdoc cref="DateTimeOffsetExtensions.First(DateTimeOffset, DayOfWeek)" />
        /// <returns>A <see cref="DateTime" /> representing the first occurence of <paramref name="dayOfWeek" />.</returns>
        public static DateTime First(this DateTime value, DayOfWeek dayOfWeek)
        {
            return ((DateTimeOffset)value).First(dayOfWeek).DateTime;
        }

        /// <inheritdoc cref="DateTimeOffsetExtensions.FirstDayOfMonth(DateTimeOffset)" />
        /// <returns>A <see cref="DateTime" /> representing the first day of the current month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return ((DateTimeOffset)value).FirstDayOfMonth().DateTime;
        }

        /// <inheritdoc cref="DateTimeOffsetExtensions.Last(DateTimeOffset, DayOfWeek)" />
        /// <returns>A <see cref="DateTimeOffset" /> representing the final occurence of <paramref name="dayOfWeek" />.</returns>
        public static DateTime Last(this DateTime value, DayOfWeek dayOfWeek)
        {
            return ((DateTimeOffset)value).Last(dayOfWeek).DateTime;
        }

        /// <inheritdoc cref="DateTimeOffsetExtensions.LastDayOfMonth(DateTimeOffset)" />
        /// <returns>A <see cref="DateTimeOffset" /> representing the last day of the current month.</returns>
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return ((DateTimeOffset)value).LastDayOfMonth().DateTime;
        }

        /// <inheritdoc cref="DateTimeOffsetExtensions.Next(DateTimeOffset, DayOfWeek)" />
        /// <returns>A <see cref="DateTimeOffset" /> representing the next occurence of <paramref name="dayOfWeek" />.</returns>
        public static DateTime Next(this DateTime value, DayOfWeek dayOfWeek)
        {
            return ((DateTimeOffset)value).Next(dayOfWeek).DateTime;
        }

        /// <summary>
        ///     Returns the number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.
        /// </summary>
        /// <param name="value">The current date.</param>
        /// <returns>The number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.</returns>
        public static long ToUnixTimeMilliseconds(this DateTime value)
        {
            return ((DateTimeOffset)value).ToUnixTimeMilliseconds();
        }

        /// <summary>
        ///     Returns the number of seconds that have elapsed since 1970-01-01T00:00:00.000Z.
        /// </summary>
        /// <param name="value">The current date.</param>
        /// <returns>The number of seconds that have elapsed since 1970-01-01T00:00:00.000Z.</returns>
        public static long ToUnixTimeSeconds(this DateTime value)
        {
            return ((DateTimeOffset)value).ToUnixTimeSeconds();
        }
    }
}
