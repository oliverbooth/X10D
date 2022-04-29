﻿using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Extension methods for <see cref="DateTimeOffset" />.
/// </summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>
    ///     Returns the rounded-down integer number of years since a given date as of today.
    /// </summary>
    /// <param name="value">The date from which to calculate.</param>
    /// <returns>The rounded-down integer number of years since <paramref name="value" /> as of today.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Age(this DateTimeOffset value)
    {
        return value.Age(DateTime.Today);
    }

    /// <summary>
    ///     Returns the rounded-down integer number of years since a given date as of another specified date.
    /// </summary>
    /// <param name="value">The date from which to calculate.</param>
    /// <param name="asOf">The date at which to stop calculating.</param>
    /// <returns>
    ///     The rounded-down integer number of years since <paramref name="value" /> as of the date specified by
    ///     <paramref name="asOf" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Age(this DateTimeOffset value, DateTimeOffset asOf)
    {
        return (int)(((asOf.Date - TimeSpan.FromDays(1) - value.Date).TotalDays + 1) / 365.2425);
    }

    /// <summary>
    ///     Gets a date representing the first occurence of a specified day of the week in the current month.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <param name="dayOfWeek">The day of the week.</param>
    /// <returns>A <see cref="DateTimeOffset" /> representing the first occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static DateTimeOffset First(this DateTimeOffset value, DayOfWeek dayOfWeek)
    {
        var first = value.FirstDayOfMonth();

        if (first.DayOfWeek != dayOfWeek)
        {
            first = first.Next(dayOfWeek);
        }

        return first;
    }

    /// <summary>
    ///     Gets a date representing the first day of the current month.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <returns>A <see cref="DateTimeOffset" /> representing the first day of the current month.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset value)
    {
        return value.AddDays(1 - value.Day);
    }

    /// <summary>
    ///     Returns a value indicating whether the year represented by the current <see cref="DateTimeOffset" /> is a leap year.
    /// </summary>
    /// <param name="value">The date whose year to check.</param>
    /// <returns>
    ///     <see langword="true" /> if the year represented by <paramref name="value" /> is a leap year; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsLeapYear(this DateTimeOffset value)
    {
        return DateTime.IsLeapYear(value.Year);
    }

    /// <summary>
    ///     Gets a date representing the final occurence of a specified day of the week in the current month.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <param name="dayOfWeek">The day of the week.</param>
    /// <returns>A <see cref="DateTimeOffset" /> representing the final occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static DateTimeOffset Last(this DateTimeOffset value, DayOfWeek dayOfWeek)
    {
        var last = value.LastDayOfMonth();
        var lastDayOfWeek = last.DayOfWeek;

        int diff = dayOfWeek - lastDayOfWeek;
        int offset = diff > 0 ? diff - 7 : diff;

        return last.AddDays(offset);
    }

    /// <summary>
    ///     Gets a date representing the last day of the current month.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <returns>A <see cref="DateTimeOffset" /> representing the last day of the current month.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static DateTimeOffset LastDayOfMonth(this DateTimeOffset value)
    {
        int daysInMonth = DateTime.DaysInMonth(value.Year, value.Month);
        return new DateTime(value.Year, value.Month, daysInMonth);
    }

    /// <summary>
    ///     Gets a date representing the next occurence of a specified day of the week in the current month.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <param name="dayOfWeek">The day of the week.</param>
    /// <returns>A <see cref="DateTimeOffset" /> representing the next occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static DateTimeOffset Next(this DateTimeOffset value, DayOfWeek dayOfWeek)
    {
        int offsetDays = dayOfWeek - value.DayOfWeek;

        if (offsetDays <= 0)
        {
            offsetDays += 7;
        }

        return value.AddDays(offsetDays);
    }
}
