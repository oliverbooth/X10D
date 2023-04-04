using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="decimal" />.
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    ///     Returns the complex square root of this decimal number.
    /// </summary>
    /// <param name="value">The number whose square root is to be found.</param>
    /// <returns>The square root of <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Complex ComplexSqrt(this decimal value)
    {
        return Complex.Sqrt((double)value);
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
    public static bool IsEven(this decimal value)
    {
        return value % 2.0m == 0.0m;
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
    public static bool IsOdd(this decimal value)
    {
        return !value.IsEven();
    }

    /// <summary>
    ///     Rounds the current value to the nearest whole number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <returns><paramref name="value" /> rounded to the nearest whole number.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static decimal Round(this decimal value)
    {
        return value.Round(1.0m);
    }

    /// <summary>
    ///     Rounds the current value to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <param name="nearest">The nearest multiple to which <paramref name="value" /> should be rounded.</param>
    /// <returns><paramref name="value" /> rounded to the nearest multiple of <paramref name="nearest" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static decimal Round(this decimal value, decimal nearest)
    {
        return System.Math.Round(value / nearest) * nearest;
    }

    /// <summary>
    ///     Saturates this decimal number.
    /// </summary>
    /// <param name="value">The value to saturate.</param>
    /// <returns>The saturated value.</returns>
    /// <remarks>This method clamps <paramref name="value" /> between 0 and 1.</remarks>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static decimal Saturate(this decimal value)
    {
        return System.Math.Clamp(value, 0.0m, 1.0m);
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this decimal number.
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
    public static int Sign(this decimal value)
    {
        return System.Math.Sign(value);
    }

    /// <summary>
    ///     Returns the square root of this decimal number.
    /// </summary>
    /// <param name="value">The number whose square root is to be found.</param>
    /// <returns>
    ///     One of the values in the following table.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///            <term>The positive square root of <paramref name="value" />.</term>
    ///            <description><paramref name="value" /> is greater than or equal to 0.</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="double.NaN" /></term>
    ///             <description><paramref name="value" /> is equal to <see cref="double.NaN" /> or is negative.</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="double.PositiveInfinity" /></term>
    ///             <description><paramref name="value" /> is equal to <see cref="double.PositiveInfinity" />.</description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="value" /> is negative.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static decimal Sqrt(this decimal value)
    {
        switch (value)
        {
            case 0:
                return 0;
            case < 0:
                throw new ArgumentException(ExceptionMessages.ValueCannotBeNegative, nameof(value));
        }

        decimal previous;
        var current = (decimal)System.Math.Sqrt((double)value);
        do
        {
            previous = current;
            current = (previous + value / previous) / 2;
        } while (System.Math.Abs(previous - current) > 0.0m);

        return current;
    }

    /// <summary>
    ///     Wraps the current decimal number between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static decimal Wrap(this decimal value, decimal low, decimal high)
    {
        decimal difference = high - low;
        return low + (((value - low) % difference) + difference) % difference;
    }

    /// <summary>
    ///     Wraps the current decimal number between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static decimal Wrap(this decimal value, decimal length)
    {
        return ((value % length) + length) % length;
    }
}
