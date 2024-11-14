using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="ushort" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt16Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the current value is a prime number.
    /// </summary>
    /// <param name="value">The value whose primality to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsPrime(this ushort value)
    {
        return ((ulong)value).IsPrime();
    }

    /// <summary>
    ///     Returns the multiplicative persistence of a specified value.
    /// </summary>
    /// <param name="value">The value whose multiplicative persistence to calculate.</param>
    /// <returns>The multiplicative persistence.</returns>
    /// <remarks>
    ///     Multiplicative persistence is defined as the recursive digital product until that product is a single digit.
    /// </remarks>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int MultiplicativePersistence(this ushort value)
    {
        return ((ulong)value).MultiplicativePersistence();
    }

    /// <summary>
    ///     Wraps the current 16-bit unsigned integer between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ushort Wrap(this ushort value, ushort low, ushort high)
    {
        return (ushort)((ulong)value).Wrap(low, high);
    }

    /// <summary>
    ///     Wraps the current 16-bit unsigned integer between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ushort Wrap(this ushort value, ushort length)
    {
        return (ushort)((ulong)value).Wrap(length);
    }
}
