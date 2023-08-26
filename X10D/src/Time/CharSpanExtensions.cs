using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="ReadOnlySpan{T}" /> of <see cref="char" />.
/// </summary>
public static class CharSpanExtensions
{
    /// <summary>
    ///     Parses this span of characters as a shorthand time span (e.g. 3w 2d 1h) and converts it to an instance of
    ///     <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="input">
    ///     The input span of characters. Floating point is not supported, but integers with the following units are supported:
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
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static TimeSpan ToTimeSpan(this ReadOnlySpan<char> input)
    {
        return TimeSpanParser.TryParse(input, out TimeSpan result) ? result : default;
    }
}
