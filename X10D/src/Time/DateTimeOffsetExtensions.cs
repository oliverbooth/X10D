using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    [ExcludeFromCodeCoverage]
    public static int Age(this DateTimeOffset value)
    {
        return value.Age(DateTime.Today);
    }

    /// <summary>
    ///     Returns the rounded-down integer number of years since a given date as of another specified date.
    /// </summary>
    /// <param name="value">The date from which to calculate.</param>
    /// <param name="referenceDate">The date to use as the calculation reference.</param>
    /// <returns>
    ///     The rounded-down integer number of years since <paramref name="value" /> as of the date specified by
    ///     <paramref name="referenceDate" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static int Age(this DateTimeOffset value, DateTimeOffset referenceDate)
    {
        return (int)(((referenceDate.Date - TimeSpan.FromDays(1) - value.Date).TotalDays + 1) / 365.2425);
    }

    /// <summary>
    ///     Gets a date representing the first occurence of a specified day of the week in the current month.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <param name="dayOfWeek">The day of the week.</param>
    /// <returns>A <see cref="DateTimeOffset" /> representing the first occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset value)
    {
        return value.AddDays(1 - value.Day);
    }

    /// <summary>
    ///     Gets the ISO-8601 week number of the year for the current date.
    /// </summary>
    /// <param name="value">The date whose week number to return.</param>
    /// <returns>The ISO-8601 week number of the year.</returns>
    /// <author>Shawn Steele, Microsoft</author>
    /// <remarks>
    ///     This implementation is directly inspired from a
    ///     <a href="https://docs.microsoft.com/en-gb/archive/blogs/shawnste/iso-8601-week-of-year-format-in-microsoft-net">
    ///         blog post
    ///     </a>.
    ///     about this subject.
    /// </remarks>
    [Pure]
    public static int GetIso8601WeekOfYear(this DateTimeOffset value)
    {
        return value.DateTime.GetIso8601WeekOfYear();
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
