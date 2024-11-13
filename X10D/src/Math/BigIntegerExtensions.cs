using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Math-related extension methods for <see cref="BigInteger" />.
/// </summary>
public static class BigIntegerExtensions
{
    /// <summary>
    ///     Returns the factorial of the current 64-bit signed integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    /// <exception cref="ArithmeticException"><paramref name="value" /> is less than 0.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static BigInteger Factorial(this BigInteger value)
    {
        if (value < 0)
        {
            throw new ArithmeticException(nameof(value));
        }

        if (value == 0)
        {
            return 1;
        }

        BigInteger result = 1;
        for (var i = 1L; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>
    ///     Calculates the greatest common factor between this, and another, <see cref="BigInteger" />.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The greatest common factor between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static BigInteger GreatestCommonFactor(this BigInteger value, BigInteger other)
    {
        while (other != 0)
        {
            (value, other) = (other, value % other);
        }

        return value;
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
    public static bool IsOdd(this BigInteger value)
    {
        return !value.IsEven;
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
    public static bool IsPrime(this BigInteger value)
    {
        if (value <= 1)
        {
            return false;
        }

        if (value <= 3)
        {
            return true;
        }

        if (value.IsEven || value % 3 == 0)
        {
            return false;
        }

        for (var iterator = 5L; iterator * iterator <= value; iterator += 6)
        {
            if (value % iterator == 0 || value % (iterator + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Calculates the lowest common multiple between the current 64-bit signed integer, and another 64-bit signed integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The lowest common multiple between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static BigInteger LowestCommonMultiple(this BigInteger value, BigInteger other)
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
    public static int MultiplicativePersistence(this BigInteger value)
    {
        var persistence = 0;
        BigInteger product = BigInteger.Abs(value);

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

            BigInteger newProduct = 1;
            BigInteger currentProduct = product;
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
    ///     Wraps the current integer between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static BigInteger Wrap(this BigInteger value, BigInteger low, BigInteger high)
    {
        BigInteger difference = high - low;
        return low + (((value - low) % difference) + difference) % difference;
    }

    /// <summary>
    ///     Wraps the current integer between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static BigInteger Wrap(this BigInteger value, BigInteger length)
    {
        return ((value % length) + length) % length;
    }
}
