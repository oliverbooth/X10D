using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.Math;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Rotates the current value left by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..7] is treated as congruent mod 8.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static byte RotateLeft(this byte value, int count)
    {
        count = count.Mod(8);
        return (byte)((value << count) | (value >> (8 - count)));
    }

    /// <summary>
    ///     Rotates the current value right by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..7] is treated as congruent mod 8.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static byte RotateRight(this byte value, int count)
    {
        count = count.Mod(8);
        return (byte)((value >> count) | (value << (8 - count)));
    }
}
