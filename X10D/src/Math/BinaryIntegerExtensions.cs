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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static int CountDigits<TNumber>(this TNumber value)
        where TNumber : IBinaryInteger<TNumber>
    {
        if (TNumber.IsZero(value))
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static int DigitalRoot<TInteger>(this TInteger value)
        where TInteger : IBinaryInteger<TInteger>
    {
        var nine = TInteger.CreateChecked(9);
        TInteger root = TInteger.Abs(value).Mod(nine);
        return int.CreateChecked(root == TInteger.Zero ? nine : root);
    }
}
#endif
