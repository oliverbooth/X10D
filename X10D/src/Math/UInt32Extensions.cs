using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="uint" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt32Extensions
{
#if !NET7_0_OR_GREATER
    /// <summary>
    ///     Returns the number of digits in the current 32-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose digit count to compute.</param>
    /// <returns>The number of digits in <paramref name="value" />.</returns>
    public static int CountDigits(this uint value)
    {
        if (value == 0)
        {
            return 1;
        }

        return ((ulong)value).CountDigits();
    }

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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static uint GreatestCommonFactor(this uint value, uint other)
    {
        return (uint)((long)value).GreatestCommonFactor(other);
    }
#endif

    /// <summary>
    ///     Returns a value indicating whether the current value is evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsOdd(this uint value)
    {
        return !value.IsEven();
    }

    /// <summary>
    ///     Calculates the lowest common multiple between the current 32-bit unsigned integer, and another 32-bit unsigned
    ///     integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The lowest common multiple between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static uint LowestCommonMultiple(this uint value, uint other)
    {
        return (uint)((ulong)value).LowestCommonMultiple(other);
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
    public static int MultiplicativePersistence(this uint value)
    {
        return ((ulong)value).MultiplicativePersistence();
    }

    /// <summary>
    ///     Wraps the current 32-bit unsigned integer between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static uint Wrap(this uint value, uint low, uint high)
    {
        return (uint)((ulong)value).Wrap(low, high);
    }

    /// <summary>
    ///     Wraps the current 32-bit unsigned integer between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static uint Wrap(this uint value, uint length)
    {
        return (uint)((ulong)value).Wrap(length);
    }
}
