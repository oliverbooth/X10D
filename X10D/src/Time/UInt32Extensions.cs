namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="uint" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt32Extensions
{
    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of ticks.
    /// </summary>
    /// <param name="value">The duration, in ticks.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.Ticks" /> will equal <paramref name="value" />.</returns>
    public static TimeSpan Ticks(this uint value)
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
    public static TimeSpan Milliseconds(this uint value)
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
    public static TimeSpan Seconds(this uint value)
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
    public static TimeSpan Minutes(this uint value)
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
    public static TimeSpan Hours(this uint value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of days.
    /// </summary>
    /// <param name="value">The duration, in days.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" />.</returns>
    public static TimeSpan Days(this uint value)
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
    public static TimeSpan Weeks(this uint value)
    {
        return TimeSpan.FromDays(value * 7);
    }
}
