#if NET7_0_OR_GREATER
using System.Diagnostics.Contracts;
using System.Globalization;
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

    /// <summary>
    ///     Performs a modulo operation which supports a negative dividend.
    /// </summary>
    /// <param name="dividend">The dividend.</param>
    /// <param name="divisor">The divisor.</param>
    /// <returns>The result of <c>dividend mod divisor</c>.</returns>
    /// <remarks>
    ///     The <c>%</c> operator (commonly called the modulo operator) in C# is not defined to be modulo, but is instead
    ///     remainder. This quirk inherently makes it difficult to use modulo in a negative context, as <c>x % y</c> where x is
    ///     negative will return a negative value, akin to <c>-(x % y)</c>, even if precedence is forced. This method provides a
    ///     modulo operation which supports negative dividends.
    /// </remarks>
    /// <author>ShreevatsaR, https://stackoverflow.com/a/1082938/1467293</author>
    /// <license>CC-BY-SA 2.5</license>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static TInteger Mod<TInteger>(this TInteger dividend, TInteger divisor)
        where TInteger : IBinaryInteger<TInteger>
    {
        TInteger r = dividend % divisor;
        return r < TInteger.Zero ? r + divisor : r;
    }
}
#endif
