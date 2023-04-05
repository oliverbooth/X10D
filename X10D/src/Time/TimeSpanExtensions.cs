using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Extension methods for <see cref="TimeSpan" />.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    ///     Returns a <see cref="DateTime" /> that is a specified duration in the past relative to the current time.
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan" /> whose duration to subtract.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> that is a duration of <paramref name="value" /> in the past relative to the current time.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static DateTime Ago(this TimeSpan value)
    {
        return DateTime.Now.Subtract(value);
    }

    /// <summary>
    ///     Returns a <see cref="DateTime" /> that is a specified duration in the future relative to the current time.
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan" /> whose duration to add.</param>
    /// <returns>
    ///     A <see cref="DateTime" /> that is a duration of <paramref name="value" /> in the future relative to the current time.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static DateTime FromNow(this TimeSpan value)
    {
        return DateTime.Now.Add(value);
    }
}
