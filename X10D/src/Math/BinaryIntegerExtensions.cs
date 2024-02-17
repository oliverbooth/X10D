#if NET7_0_OR_GREATER
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Math-related extension methods for <see cref="IBinaryInteger{TSelf}" />.
/// </summary>
public static class BinaryIntegerExtensions
{
    /// <summary>
    ///     Returns the number of digits in the current binary integer.
    /// </summary>
    /// <param name="value">The value whose digit count to compute.</param>
    /// <returns>The number of digits in <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int CountDigits<TInteger>(this TInteger value)
        where TInteger : IBinaryInteger<TInteger>
    {
        if (TInteger.IsZero(value))
        {
            return 1;
        }

        return 1 + (int)System.Math.Floor(System.Math.Log10(System.Math.Abs(double.CreateChecked(value))));
    }

    /// <summary>
    ///     Computes the digital root of this integer.
    /// </summary>
    /// <param name="value">The value whose digital root to compute.</param>
    /// <returns>The digital root of <paramref name="value" />.</returns>
    /// <remarks>The digital root is defined as the recursive sum of digits until that result is a single digit.</remarks>
    /// <remarks>
    ///     <para>The digital root is defined as the recursive sum of digits until that result is a single digit.</para>
    ///     <para>For example, the digital root of 239 is 5: <c>2 + 3 + 9 = 14</c>, then <c>1 + 4 = 5</c>.</para>
    /// </remarks>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int DigitalRoot<TInteger>(this TInteger value)
        where TInteger : IBinaryInteger<TInteger>
    {
        var nine = TInteger.CreateChecked(9);
        TInteger root = TInteger.Abs(value).Mod(nine);
        return int.CreateChecked(root == TInteger.Zero ? nine : root);
    }

    /// <summary>
    ///     Returns the factorial of the current binary integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    /// <exception cref="ArithmeticException"><paramref name="value" /> is less than 0.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static long Factorial<TInteger>(this TInteger value)
        where TInteger : IBinaryInteger<TInteger>
    {
        if (value < TInteger.Zero)
        {
            throw new ArithmeticException(nameof(value));
        }

        if (value == TInteger.Zero)
        {
            return 1;
        }

        var result = 1L;
        for (TInteger i = TInteger.One; i <= value; i++)
        {
            result *= long.CreateChecked(i);
        }

        return result;
    }

    /// <summary>
    ///     Calculates the greatest common factor between the current binary integer, and another binary integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The greatest common factor between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TInteger GreatestCommonFactor<TInteger>(this TInteger value, TInteger other)
        where TInteger : IBinaryInteger<TInteger>
    {
        while (other != TInteger.Zero)
        {
            (value, other) = (other, value % other);
        }

        return value;
    }
}
#endif