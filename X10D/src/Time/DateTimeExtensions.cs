using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Extension methods for <see cref="DateTime" />.
/// </summary>
public static class DateTimeExtensions
{
    /// <inheritdoc cref="DateTimeOffsetExtensions.Age(DateTimeOffset)" />
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static int Age(this DateTime value)
    {
        return value.Age(DateTime.Today);
    }

    /// <inheritdoc cref="DateTimeOffsetExtensions.Age(DateTimeOffset, DateTimeOffset)" />
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static int Age(this DateTime value, DateTime asOf)
    {
        return ((DateTimeOffset)value).Age(asOf);
    }

    /// <inheritdoc cref="DateTimeOffsetExtensions.First(DateTimeOffset, DayOfWeek)" />
    /// <returns>A <see cref="DateTime" /> representing the first occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static DateTime First(this DateTime value, DayOfWeek dayOfWeek)
    {
        return ((DateTimeOffset)value).First(dayOfWeek).DateTime;
    }

    /// <inheritdoc cref="DateTimeOffsetExtensions.FirstDayOfMonth(DateTimeOffset)" />
    /// <returns>A <see cref="DateTime" /> representing the first day of the current month.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static DateTime FirstDayOfMonth(this DateTime value)
    {
        return ((DateTimeOffset)value).FirstDayOfMonth().DateTime;
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
    public static int GetIso8601WeekOfYear(this DateTime value)
    {
        var calendar = CultureInfo.InvariantCulture.Calendar;
        DayOfWeek day = calendar.GetDayOfWeek(value);
        if (day is >= DayOfWeek.Monday and <= DayOfWeek.Wednesday)
        {
            value = value.AddDays(3);
        }

        return calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    /// <summary>
    ///     Returns a value indicating whether the year represented by the current <see cref="DateTime" /> is a leap year.
    /// </summary>
    /// <param name="value">The date whose year to check.</param>
    /// <returns>
    ///     <see langword="true" /> if the year represented by <paramref name="value" /> is a leap year; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool IsLeapYear(this DateTime value)
    {
        return DateTime.IsLeapYear(value.Year);
    }

    /// <inheritdoc cref="DateTimeOffsetExtensions.Last(DateTimeOffset, DayOfWeek)" />
    /// <returns>A <see cref="DateTimeOffset" /> representing the final occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static DateTime Last(this DateTime value, DayOfWeek dayOfWeek)
    {
        return ((DateTimeOffset)value).Last(dayOfWeek).DateTime;
    }

    /// <inheritdoc cref="DateTimeOffsetExtensions.LastDayOfMonth(DateTimeOffset)" />
    /// <returns>A <see cref="DateTimeOffset" /> representing the last day of the current month.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static DateTime LastDayOfMonth(this DateTime value)
    {
        return ((DateTimeOffset)value).LastDayOfMonth().DateTime;
    }

    /// <inheritdoc cref="DateTimeOffsetExtensions.Next(DateTimeOffset, DayOfWeek)" />
    /// <returns>A <see cref="DateTimeOffset" /> representing the next occurence of <paramref name="dayOfWeek" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static DateTime Next(this DateTime value, DayOfWeek dayOfWeek)
    {
        return ((DateTimeOffset)value).Next(dayOfWeek).DateTime;
    }

    /// <summary>
    ///     Returns the number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <returns>The number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static long ToUnixTimeMilliseconds(this DateTime value)
    {
        return ((DateTimeOffset)value).ToUnixTimeMilliseconds();
    }

    /// <summary>
    ///     Returns the number of seconds that have elapsed since 1970-01-01T00:00:00.000Z.
    /// </summary>
    /// <param name="value">The current date.</param>
    /// <returns>The number of seconds that have elapsed since 1970-01-01T00:00:00.000Z.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static long ToUnixTimeSeconds(this DateTime value)
    {
        return ((DateTimeOffset)value).ToUnixTimeSeconds();
    }
}
