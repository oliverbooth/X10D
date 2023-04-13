using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;
using X10D.Math;

namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the current integer, representing a year, is a leap year.
    /// </summary>
    /// <param name="value">The value whose leap year status to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> refers to a leap year; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="value" /> is 0.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsLeapYear(this short value)
    {
        if (value == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), ExceptionMessages.YearCannotBeZero);
        }

        if (value < 0)
        {
            value++;
        }

        return value.Mod(4) == 0 && (value.Mod(100) != 0 || value.Mod(400) == 0);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of weeks.
    /// </summary>
    /// <param name="value">The duration, in weeks.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" /> × 7.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static TimeSpan Weeks(this short value)
    {
        return TimeSpan.FromDays(value * 7);
    }
}
