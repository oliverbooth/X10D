using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Extension methods for <see cref="string" />.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Parses a shorthand time span string (e.g. 3w 2d 1h) and converts it to an instance of <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="input">
    ///     The input string. Floating point is not supported, but range the following units are supported:
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Suffix</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>ms</term>
    ///             <description>Milliseconds</description>
    ///         </item>
    ///         <item>
    ///             <term>s</term>
    ///             <description>Seconds</description>
    ///         </item>
    ///         <item>
    ///             <term>m</term>
    ///             <description>Minutes</description>
    ///         </item>
    ///         <item>
    ///             <term>h</term>
    ///             <description>Hours</description>
    ///         </item>
    ///         <item>
    ///             <term>d</term>
    ///             <description>Days</description>
    ///         </item>
    ///         <item>
    ///             <term>w</term>
    ///             <description>Weeks</description>
    ///         </item>
    ///         <item>
    ///             <term>mo</term>
    ///             <description>Months</description>
    ///         </item>
    ///         <item>
    ///             <term>y</term>
    ///             <description>Years</description>
    ///         </item>
    ///     </list>
    /// </param>
    /// <returns>A new instance of <see cref="TimeSpan" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="input" /> is <see langword="null" />.</exception>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static TimeSpan ToTimeSpan(this string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        return TimeSpanParser.TryParse(input, out TimeSpan result)
            ? result
            : default;
    }
}
