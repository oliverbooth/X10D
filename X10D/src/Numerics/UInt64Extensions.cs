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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong RotateLeft(this ulong value, int count)
    {
        return BitOperations.RotateLeft(value, count);
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ulong RotateRight(this ulong value, int count)
    {
        return BitOperations.RotateRight(value, count);
    }
}
