using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Rotates the current value left by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..31] is treated as congruent mod 32.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static int RotateLeft(this int value, int count)
    {
        var unsigned = unchecked((uint)value);
        return unchecked((int)unsigned.RotateLeft(count));
    }

    /// <summary>
    ///     Rotates the current value right by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..31] is treated as congruent mod 32.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static int RotateRight(this int value, int count)
    {
        var unsigned = unchecked((uint)value);
        return unchecked((int)unsigned.RotateRight(count));
    }
}
