#if NET7_0_OR_GREATER
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Math-related extension methods for <see cref="INumber{TSelf}" />.
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    ///     Returns the number of digits in the current binary integer.
    /// </summary>
    /// <param name="value">The value whose digit count to compute.</param>
    /// <returns>The number of digits in <paramref name="value" />.</returns>
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
    ///     Returns a value indicating whether the current value is evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsEven<TNumber>(this TNumber value)
        where TNumber : INumber<TNumber>
    {
        return value % TNumber.CreateChecked(2) == TNumber.Zero;
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsOdd<TNumber>(this TNumber value)
        where TNumber : INumber<TNumber>
    {
        return !value.IsEven();
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
    public static TNumber Mod<TNumber>(this TNumber dividend, TNumber divisor)
        where TNumber : INumber<TNumber>
    {
        TNumber r = dividend % divisor;
        return r < TNumber.Zero ? r + divisor : r;
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this number.
    /// </summary>
    /// <param name="value">A signed number.</param>
    /// <returns>
    ///     A number that indicates the sign of <paramref name="value" />, as shown in the following table.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>-1</term>
    ///             <description><paramref name="value" /> is less than zero.</description>
    ///         </item>
    ///         <item>
    ///             <term>0</term>
    ///             <description><paramref name="value" /> is equal to zero.</description>
    ///         </item>
    ///         <item>
    ///             <term>1</term>
    ///             <description><paramref name="value" /> is greater than zero.</description>
    ///         </item>
    ///     </list>
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static int Sign<TNumber>(this TNumber value)
        where TNumber : INumber<TNumber>
    {
        return TNumber.Sign(value);
    }
}
#endif
