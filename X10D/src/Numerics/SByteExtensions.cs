using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="sbyte" />.
/// </summary>
[CLSCompliant(false)]
public static class SByteExtensions
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
    public static sbyte RotateLeft(this sbyte value, int count)
    {
        var signed = unchecked((byte)value);
        return unchecked((sbyte)signed.RotateLeft(count));
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
    public static sbyte RotateRight(this sbyte value, int count)
    {
        var signed = unchecked((byte)value);
        return unchecked((sbyte)signed.RotateRight(count));
    }
}
