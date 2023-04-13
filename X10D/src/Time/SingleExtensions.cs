using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of weeks.
    /// </summary>
    /// <param name="value">The duration, in weeks.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" /> × 7.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static TimeSpan Weeks(this float value)
    {
        return TimeSpan.FromDays(value * 7);
    }
}
