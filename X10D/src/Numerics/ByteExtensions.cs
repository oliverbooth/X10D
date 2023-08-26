using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;
using X10D.Math;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Returns the population count (number of bits set) of a mask.
    /// </summary>
    /// <param name="value">The mask.</param>
    /// <returns>The population count of <paramref name="value" />.</returns>
    /// <remarks>
    ///     This method is similar in behavior to the x86 instruction
    ///     <a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.x86.popcnt?view=net-6.0">POPCNT</a>
    /// </remarks>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static int PopCount(this byte value)
    {
        return ((uint)value).PopCount();
    }

    /// <summary>
    ///     Rotates the current value left by the specified number of bits.
    /// </summary>
    /// <param name="value">The value to rotate.</param>
    /// <param name="count">
    ///     The number of bits by which to rotate. Any value outside the range [0..7] is treated as congruent mod 8.
    /// </param>
    /// <returns>The rotated value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static byte RotateRight(this byte value, int count)
    {
        count = count.Mod(8);
        return (byte)((value >> count) | (value << (8 - count)));
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static byte RoundUpToPowerOf2(this byte value)
    {
        return (byte)((uint)value).RoundUpToPowerOf2();
    }
}
