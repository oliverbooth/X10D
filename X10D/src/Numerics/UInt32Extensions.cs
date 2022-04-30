using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="uint" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt32Extensions
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static uint RotateLeft(this uint value, int count)
    {
        return BitOperations.RotateLeft(value, count);
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static uint RotateRight(this uint value, int count)
    {
        return BitOperations.RotateRight(value, count);
    }
}
