using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Mathematical extension methods.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    ///     Returns the complex square root of this double-precision floating-point number.
    /// </summary>
    /// <param name="value">The number whose square root is to be found.</param>
    /// <returns>The square root of <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Complex ComplexSqrt(this double value)
    {
        switch (value)
        {
            case double.PositiveInfinity:
            case double.NegativeInfinity:
                return new Complex(double.PositiveInfinity, double.PositiveInfinity);
            case double.NaN:
                return new Complex(double.NaN, double.NaN);

            case 0:
                return Complex.Zero;
            case > 0:
                return new Complex(System.Math.Sqrt(value), 0);
            case < 0:
                return new Complex(0, System.Math.Sqrt(-value));
        }
    }

    /// <summary>
    ///     Converts the current angle in degrees to its equivalent represented in radians.
    /// </summary>
    /// <param name="value">The angle in degrees to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double DegreesToRadians(this double value)
    {
        return value * (System.Math.PI / 180.0);
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
    public static bool IsEven(this double value)
    {
        return System.Math.Abs(value % 2.0) < double.Epsilon;
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
    public static bool IsOdd(this double value)
    {
        return !value.IsEven();
    }

    /// <summary>
    ///     Converts the current angle in radians to its equivalent represented in degrees.
    /// </summary>
    /// <param name="value">The angle in radians to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double RadiansToDegrees(this double value)
    {
        return value * (180.0 / System.Math.PI);
    }

    /// <summary>
    ///     Rounds the current value to the nearest whole number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <returns><paramref name="value" /> rounded to the nearest whole number.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double Round(this double value)
    {
        return value.Round(1.0);
    }

    /// <summary>
    ///     Rounds the current value to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <param name="nearest">The nearest multiple to which <paramref name="value" /> should be rounded.</param>
    /// <returns><paramref name="value" /> rounded to the nearest multiple of <paramref name="nearest" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double Round(this double value, double nearest)
    {
        return System.Math.Round(value / nearest) * nearest;
    }

    /// <summary>
    ///     Saturates this double-precision floating-point number.
    /// </summary>
    /// <param name="value">The value to saturate.</param>
    /// <returns>The saturated value.</returns>
    /// <remarks>This method clamps <paramref name="value" /> between 0 and 1.</remarks>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double Saturate(this double value)
    {
        return System.Math.Clamp(value, 0.0, 1.0);
    }

    /// <summary>
    ///     Returns the square root of this double-precision floating-point number.
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
    /// <author>SLenik https://stackoverflow.com/a/6755197/1467293</author>
    /// <license>CC BY-SA 3.0</license>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double Sqrt(this double value)
    {
        switch (value)
        {
            case 0:
                return 0;
            case < 0 or double.NaN:
                return double.NaN;
            case double.PositiveInfinity:
                return double.PositiveInfinity;
        }

        double previous;
        double current = System.Math.Sqrt(value);
        do
        {
            previous = current;
            current = (previous + value / previous) / 2;
        } while (System.Math.Abs(previous - current) > double.Epsilon);

        return current;
    }

    /// <summary>
    ///     Wraps the current double-precision floating-point number between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double Wrap(this double value, double low, double high)
    {
        double difference = high - low;
        return low + (((value - low) % difference) + difference) % difference;
    }

    /// <summary>
    ///     Wraps the current double-precision floating-point number between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static double Wrap(this double value, double length)
    {
        return ((value % length) + length) % length;
    }
}
