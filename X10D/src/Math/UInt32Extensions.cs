using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="uint" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt32Extensions
{
    /// <summary>
    ///     Computes the digital root of the current 32-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose digital root to compute.</param>
    /// <returns>The digital root of <paramref name="value" />.</returns>
    /// <remarks>
    ///     <para>The digital root is defined as the recursive sum of digits until that result is a single digit.</para>
    ///     <para>For example, the digital root of 239 is 5: <c>2 + 3 + 9 = 14</c>, then <c>1 + 4 = 5</c>.</para>
    /// </remarks>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static uint DigitalRoot(this uint value)
    {
        uint root = value % 9;
        return root == 0 ? 9 : root;
    }

    /// <summary>
    ///     Returns the factorial of the current 32-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static ulong Factorial(this uint value)
    {
        if (value == 0)
        {
            return 1;
        }

        var result = 1UL;
        for (var i = 1U; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>
    ///     Calculates the greatest common factor between the current 32-bit unsigned integer, and another 32-bit unsigned
    ///     integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The greatest common factor between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static uint GreatestCommonFactor(this uint value, uint other)
    {
        return (uint)((long)value).GreatestCommonFactor(other);
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool IsEven(this uint value)
    {
        return (value & 1) == 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is a prime number.
    /// </summary>
    /// <param name="value">The value whose primality to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool IsPrime(this uint value)
    {
        return ((ulong)value).IsPrime();
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is not evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is not evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool IsOdd(this uint value)
    {
        return !value.IsEven();
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
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static int MultiplicativePersistence(this uint value)
    {
        return ((ulong)value).MultiplicativePersistence();
    }
}
