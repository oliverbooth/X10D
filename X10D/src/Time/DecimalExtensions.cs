﻿using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="decimal" />.
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of milliseconds.
    /// </summary>
    /// <param name="value">The duration, in milliseconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMilliseconds" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Milliseconds(this decimal value)
    {
        return TimeSpan.FromMilliseconds((double)value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of seconds.
    /// </summary>
    /// <param name="value">The duration, in seconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalSeconds" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Seconds(this decimal value)
    {
        return TimeSpan.FromSeconds((double)value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of minutes.
    /// </summary>
    /// <param name="value">The duration, in minutes.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMinutes" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Minutes(this decimal value)
    {
        return TimeSpan.FromMinutes((double)value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of hours.
    /// </summary>
    /// <param name="value">The duration, in hours.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalHours" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Hours(this decimal value)
    {
        return TimeSpan.FromHours((double)value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of days.
    /// </summary>
    /// <param name="value">The duration, in days.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Days(this decimal value)
    {
        return TimeSpan.FromDays((double)value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of weeks.
    /// </summary>
    /// <param name="value">The duration, in weeks.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" /> × 7.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Weeks(this decimal value)
    {
        return TimeSpan.FromDays((double)value * 7);
    }
}
