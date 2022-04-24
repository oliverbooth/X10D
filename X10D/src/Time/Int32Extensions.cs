namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Converts a Unix time expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z (January 1,
    ///     1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800,000.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799,999.</para>
    /// </exception>
    public static DateTimeOffset FromUnixTimeMilliseconds(this int value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <summary>
    ///     Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at
    ///     12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799.</para>
    /// </exception>
    public static DateTimeOffset FromUnixTimeSeconds(this int value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of ticks.
    /// </summary>
    /// <param name="value">The duration, in ticks.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.Ticks" /> will equal <paramref name="value" />.</returns>
    public static TimeSpan Ticks(this int value)
    {
        return TimeSpan.FromTicks(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of milliseconds.
    /// </summary>
    /// <param name="value">The duration, in milliseconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMilliseconds" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Milliseconds(this int value)
    {
        return TimeSpan.FromMilliseconds(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of seconds.
    /// </summary>
    /// <param name="value">The duration, in seconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalSeconds" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Seconds(this int value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of minutes.
    /// </summary>
    /// <param name="value">The duration, in minutes.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMinutes" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Minutes(this int value)
    {
        return TimeSpan.FromMinutes(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of hours.
    /// </summary>
    /// <param name="value">The duration, in hours.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalHours" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Hours(this int value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of days.
    /// </summary>
    /// <param name="value">The duration, in days.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" />.</returns>
    public static TimeSpan Days(this int value)
    {
        return TimeSpan.FromDays(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of weeks.
    /// </summary>
    /// <param name="value">The duration, in weeks.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" /> × 7.
    /// </returns>
    public static TimeSpan Weeks(this int value)
    {
        return TimeSpan.FromDays(value * 7);
    }
}
