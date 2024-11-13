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
