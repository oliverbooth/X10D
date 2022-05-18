using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="ulong" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt64Extensions
{
    /// <summary>
    ///     Rotates the current value left by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..63] is treated as congruent mod 64.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static ulong RotateLeft(this ulong value, int count)
    {
        return (value << count) | (value >> (64 - count));
    }

    /// <summary>
    ///     Rotates the current value right by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..63] is treated as congruent mod 64.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static ulong RotateRight(this ulong value, int count)
    {
        return (value >> count) | (value << (64 - count));
    }

    /// <summary>
    ///     Rounds the current value up to a power of two.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <returns>
    ///     The smallest power of two that's greater than or equal to <paramref name="value" />, or 0 if <paramref name="value" />
    ///     is 0 or the result overflows.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static ulong RoundUpToPowerOf2(this ulong value)
    {
#if NET6_0_OR_GREATER
        return BitOperations.RoundUpToPowerOf2(value);
#else
        // Based on https://graphics.stanford.edu/~seander/bithacks.html#RoundUpPowerOf2
        --value;
        value |= value >> 1;
        value |= value >> 2;
        value |= value >> 4;
        value |= value >> 8;
        value |= value >> 16;
        value |= value >> 32;
        return value + 1;
#endif
    }
}
