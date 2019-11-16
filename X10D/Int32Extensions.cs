﻿namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Int32"/>.
    /// </summary>
    public static class Int32Extensions
    {
        #region DateTime Returns

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is January.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime January(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 1, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is February.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime February(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 2, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is March.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime March(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 3, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is April.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime April(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 4, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is May.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime May(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 5, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is June.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime June(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 6, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is July.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime July(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 7, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is August.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime August(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 8, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is September.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime September(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 9, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is October.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime October(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 10, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is November.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime November(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 11, day, hour, minute, second);

        /// <summary>
        /// Returns a <see cref="DateTime"/> where the month is December.
        /// </summary>
        /// <param name="day">The day of the month.</param>
        /// <param name="year">The year.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public static DateTime December(this int day, int year, int hour = 0, int minute = 0, int second = 0) =>
            new DateTime(year, 12, day, hour, minute, second);

        #endregion

        #region TimeSpan Returns

        // TODO change

        public static TimeSpan Days(this uint number) =>
            TimeSpan.FromDays(number);

        public static TimeSpan Hours(this uint number) =>
            TimeSpan.FromHours(number);

        public static TimeSpan Milliseconds(this uint number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Minutes(this uint number) =>
            TimeSpan.FromMinutes(number);

        public static TimeSpan Seconds(this uint number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Ticks(this uint number) =>
            TimeSpan.FromTicks(number);

        public static TimeSpan Days(this int number) =>
            TimeSpan.FromDays(number);

        public static TimeSpan Hours(this int number) =>
            TimeSpan.FromHours(number);

        public static TimeSpan Milliseconds(this int number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Minutes(this int number) =>
            TimeSpan.FromMinutes(number);

        public static TimeSpan Seconds(this int number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Ticks(this int number) =>
            TimeSpan.FromTicks(number);

        #endregion

        /// <summary>
        /// Clamps a value between a minimum and a maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Returns <paramref name="max"/> if <paramref name="value"/> is greater than it,
        /// <paramref name="min"/> if <paramref name="value"/> is less than it,
        /// or <paramref name="value"/> itself otherwise.</returns>
        public static int Clamp(this int value, int min, int max) =>
            Math.Min(Math.Max(value, min), max);

        /// <summary>
        /// Clamps a value between a minimum and a maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Returns <paramref name="max"/> if <paramref name="value"/> is greater than it,
        /// <paramref name="min"/> if <paramref name="value"/> is less than it,
        /// or <paramref name="value"/> itself otherwise.</returns>
        public static uint Clamp(this uint value, uint min, uint max) =>
            Math.Min(Math.Max(value, min), max);

        /// <summary>
        /// Converts the <see cref="Int32"/> to a <see cref="DateTime"/> treating it as a Unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isMillis">Optional. Whether or not the input value should be treated as milliseconds. Defaults
        /// to <see langword="false"/>..</param>
        /// <returns>Returns a <see cref="DateTime"/> representing <paramref name="timestamp"/> seconds since the Unix
        /// epoch.</returns>
        public static DateTime FromUnixTimestamp(this int timestamp, bool isMillis = false) =>
            ((long)timestamp).FromUnixTimestamp(isMillis);

        /// <summary>
        /// Converts the <see cref="UInt32"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this uint number) =>
            BitConverter.GetBytes(number);

        /// <summary>
        /// Converts the <see cref="Int32"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this int number) =>
            BitConverter.GetBytes(number);

        /// <summary>
        /// Determines if the <see cref="Int32"/> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is prime, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsPrime(this int number) =>
            ((long)number).IsPrime();

        /// <summary>
        /// Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> is 0,
        /// <see langword="true"/> otherwise.</returns>
        public static bool ToBoolean(this int value) =>
            value != 0;

        /// <summary>
        /// Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> is 0,
        /// <see langword="true"/> otherwise.</returns>
        public static bool ToBoolean(this uint value) =>
            value != 0;
    }
}
