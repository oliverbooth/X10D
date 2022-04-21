namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="ulong" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt64Extensions
{
    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of ticks.
    /// </summary>
    /// <param name="value">The duration, in ticks.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.Ticks" /> will equal <paramref name="value" />.</returns>
    public static TimeSpan Ticks(this ulong value)
    {
        long remainder = 0;
        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromTicks((long)value).Add(TimeSpan.FromTicks(remainder));
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of milliseconds.
    /// </summary>
    /// <param name="value">The duration, in milliseconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMilliseconds" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Milliseconds(this ulong value)
    {
        long remainder = 0;

        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromMilliseconds((long)value).Add(TimeSpan.FromMilliseconds(remainder));
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of seconds.
    /// </summary>
    /// <param name="value">The duration, in seconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalSeconds" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Seconds(this ulong value)
    {
        long remainder = 0;

        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromSeconds((long)value).Add(TimeSpan.FromSeconds(remainder));
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of minutes.
    /// </summary>
    /// <param name="value">The duration, in minutes.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMinutes" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Minutes(this ulong value)
    {
        long remainder = 0;

        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromMinutes((long)value).Add(TimeSpan.FromMinutes(remainder));
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of hours.
    /// </summary>
    /// <param name="value">The duration, in hours.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalHours" /> will equal <paramref name="value" />.
    /// </returns>
    public static TimeSpan Hours(this ulong value)
    {
        long remainder = 0;

        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromHours((long)value).Add(TimeSpan.FromHours(remainder));
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of days.
    /// </summary>
    /// <param name="value">The duration, in days.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" />.</returns>
    public static TimeSpan Days(this ulong value)
    {
        long remainder = 0;

        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromDays((long)value).Add(TimeSpan.FromDays(remainder));
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of weeks.
    /// </summary>
    /// <param name="value">The duration, in weeks.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" /> × 7.
    /// </returns>
    public static TimeSpan Weeks(this ulong value)
    {
        long remainder = 0;

        if (value > long.MaxValue)
        {
            remainder = (long)(value - long.MaxValue);
            value -= long.MaxValue;
        }

        return TimeSpan.FromDays((long)value * 7).Add(TimeSpan.FromDays(remainder * 7));
    }
}
