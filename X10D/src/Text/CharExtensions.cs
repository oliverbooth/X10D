using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="char" />.
/// </summary>
public static class CharExtensions
{
    /// <summary>
    ///     Returns a string composed of the current character repeated a specified number of times.
    /// </summary>
    /// <param name="value">The character to repeat.</param>
    /// <param name="count">The number of times to repeat.</param>
    /// <returns>
    ///     A <see cref="string" /> composed of <paramref name="value" /> repeated <paramref name="count" /> times.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static string Repeat(this char value, int count)
    {
        return count switch
        {
            < 0 => throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0),
            0 => string.Empty,
            1 => value.ToString(),
            _ => new string(value, count)
        };
    }
}
