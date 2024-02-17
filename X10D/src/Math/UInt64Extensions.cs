using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="ulong" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt64Extensions
{
#if !NET7_0_OR_GREATER
    /// <summary>
    ///     Returns the number of digits in the current 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose digit count to compute.</param>
    /// <returns>The number of digits in <paramref name="value" />.</returns>
    public static int CountDigits(this ulong value)
    {
        if (value == 0)
        {
            return 1;
        }

        return 1 + (int)System.Math.Floor(System.Math.Log10(System.Math.Abs((double)value)));
    }

    /// <summary>
    ///     Computes the digital root of the current 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose digital root to compute.</param>
    /// <returns>The digital root of <paramref name="value" />.</returns>
    /// <remarks>
    ///     <para>The digital root is defined as the recursive sum of digits until that result is a single digit.</para>
    ///     <para>For example, the digital root of 239 is 5: <c>2 + 3 + 9 = 14</c>, then <c>1 + 4 = 5</c>.</para>
    /// </remarks>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ulong DigitalRoot(this ulong value)
    {
        ulong root = value % 9;
        return root == 0 ? 9 : root;
    }

    /// <summary>
    ///     Returns the factorial of the current 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ulong Factorial(this ulong value)
    {
        if (value == 0)
        {
            return 1;
        }

        var result = 1UL;
        for (var i = 1UL; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
#endif

    /// <summary>
    ///     Calculates the greatest common factor between the current 64-bit unsigned integer, and another 64-bit unsigned
    ///     integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The greatest common factor between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ulong GreatestCommonFactor(this ulong value, ulong other)
    {
        while (other != 0)
        {
            (value, other) = (other, value % other);
        }

        return value;
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsEven(this ulong value)
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
    public static bool IsPrime(this ulong value)
    {
        switch (value)
        {
            case <= 1: return false;
            case <= 3: return true;
        }

        if ((value & 1) == 0 || value % 3 == 0)
        {
            return false;
        }

        for (var iterator = 5UL; iterator * iterator <= value; iterator += 6)
        {
            if (value % iterator == 0 || value % (iterator + 2) == 0)
            {
                return false;
            }
        }

        return true;
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
    public static bool IsOdd(this ulong value)
    {
        return !value.IsEven();
    }

    /// <summary>
    ///     Calculates the lowest common multiple between the current 64-bit unsigned integer, and another 64-bit unsigned
    ///     integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The lowest common multiple between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ulong LowestCommonMultiple(this ulong value, ulong other)
    {
        if (value == 0 || other == 0)
        {
            return 0;
        }

        if (value == 1)
        {
            return other;
        }

        if (other == 1)
        {
            return value;
        }

        return value * other / value.GreatestCommonFactor(other);
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
    public static int MultiplicativePersistence(this ulong value)
    {
        var persistence = 0;
        ulong product = value;

        while (product > 9)
        {
            if (value % 10 == 0)
            {
                return persistence + 1;
            }

            while (value > 9)
            {
                value /= 10;
                if (value % 10 == 0)
                {
                    return persistence + 1;
                }
            }

            ulong newProduct = 1;
            ulong currentProduct = product;
            while (currentProduct > 0)
            {
                newProduct *= currentProduct % 10;
                currentProduct /= 10;
            }

            product = newProduct;
            persistence++;
        }

        return persistence;
    }

    /// <summary>
    ///     Wraps the current 64-bit unsigned integer between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ulong Wrap(this ulong value, ulong low, ulong high)
    {
        ulong difference = high - low;
        return low + (((value - low) % difference) + difference) % difference;
    }

    /// <summary>
    ///     Wraps the current 64-bit unsigned integer between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static ulong Wrap(this ulong value, ulong length)
    {
        return ((value % length) + length) % length;
    }
}
