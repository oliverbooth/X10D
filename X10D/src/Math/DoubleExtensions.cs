using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Mathematical extension methods.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    ///     Returns the arccosine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a cosine, which must be greater than or equal to -1, but less than or equal to 1.
    /// </param>
    /// <returns>
    ///     The arccosine of <paramref name="value" />, θ, measured in radians; such that 0 ≤ θ ≤ π. If <paramref name="value" />
    ///     is equal to <see cref="double.NaN" />, less than -1, or greater than 1, <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Acos(this double value)
    {
        return System.Math.Acos(value);
    }

    /// <summary>
    ///     Returns the hyperbolic arccosine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a hyperbolic cosine, which must be greater than or equal to 1, but less than or equal to
    ///     <see cref="double.PositiveInfinity" />.
    /// </param>
    /// <returns>
    ///     The hyperbolic arccosine of <paramref name="value" />, θ, measured in radians; such that 0 ≤ θ ≤ ∞. If
    ///     <paramref name="value" /> is less than 1 or equal to <see cref="double.NaN" />, <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Acosh(this double value)
    {
        return System.Math.Acosh(value);
    }

    /// <summary>
    ///     Returns the arcsine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a sine, which must be greater than or equal to -1, but less than or equal to 1.
    /// </param>
    /// <returns>
    ///     The arccosine of <paramref name="value" />, θ, measured in radians; such that π/2 ≤ θ ≤ π/2. If
    ///     <paramref name="value" /> is equal to <see cref="double.NaN" />, less than -1, or greater than 1,
    ///     <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Asin(this double value)
    {
        return System.Math.Asin(value);
    }

    /// <summary>
    ///     Returns the hyperbolic arcsine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a hyperbolic sine, which must be greater than or equal to 1, but less than or equal to
    ///     <see cref="double.PositiveInfinity" />.
    /// </param>
    /// <returns>
    ///     The hyperbolic arccosine of <paramref name="value" />, measured in radians. If <paramref name="value" /> is equal to
    ///     <see cref="double.NaN" />, <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Asinh(this double value)
    {
        return System.Math.Asinh(value);
    }

    /// <summary>
    ///     Returns the arctangent of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a tangent, which must be greater than or equal to -1, but less than or equal to 1.
    /// </param>
    /// <returns>
    ///     The arctangent of <paramref name="value" />, θ, measured in radians; such that π/2 ≤ θ ≤ π/2. If
    ///     <paramref name="value" /> is equal to <see cref="double.NaN" />, <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Atan(this double value)
    {
        return System.Math.Atan(value);
    }

    /// <summary>
    ///     Returns the hyperbolic arctangent of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a hyperbolic tangent, which must be greater than or equal to 1, but less than or equal to
    ///     <see cref="double.PositiveInfinity" />.
    /// </param>
    /// <returns>
    ///     The hyperbolic arctangent of <paramref name="value" />, θ, measured in radians; such that -∞ &lt; θ &lt; -1, or 1 &lt;
    ///     θ &lt; ∞. If <paramref name="value" /> is equal to <see cref="double.NaN" />, less than -1, or greater than 1,
    ///     <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Atanh(this double value)
    {
        return System.Math.Atanh(value);
    }

    /// <summary>
    ///     Returns the complex square root of this double-precision floating-point number.
    /// </summary>
    /// <param name="value">The number whose square root is to be found.</param>
    /// <returns>The square root of <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Complex ComplexSqrt(this double value)
    {
        switch (value)
        {
            case double.PositiveInfinity:
            case double.NegativeInfinity:
                return Complex.Infinity;
            case double.NaN:
                return Complex.NaN;

            case 0:
                return Complex.Zero;
            case > 0:
                return new Complex(System.Math.Sqrt(value), 0);
            case < 0:
                return new Complex(0, System.Math.Sqrt(-value));
        }
    }

    /// <summary>
    ///     Returns the cosine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The cosine of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="double.NaN" />,
    ///     <see cref="double.NegativeInfinity" />, or <see cref="double.PositiveInfinity" />, this method returns
    ///     <see cref="double.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Cos(this double value)
    {
        return System.Math.Cos(value);
    }

    /// <summary>
    ///     Returns the hyperbolic cosine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The hyperbolic cosine of <paramref name="value" />. If <paramref name="value" /> is equal to
    ///     <see cref="double.NegativeInfinity" /> or <see cref="double.PositiveInfinity" />,
    ///     <see cref="double.PositiveInfinity" /> is returned. If <paramref name="value" /> is equal to
    ///     <see cref="double.NaN" />, <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Cosh(this double value)
    {
        return System.Math.Cosh(value);
    }

    /// <summary>
    ///     Converts the current angle in degrees to its equivalent represented in radians.
    /// </summary>
    /// <param name="value">The angle in degrees to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Round(this double value, double nearest)
    {
        return System.Math.Round(value / nearest) * nearest;
    }

    /// <summary>
    ///     Returns the sine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, in radians.</param>
    /// <returns>
    ///     The sine of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="double.NaN" />,
    ///     <see cref="double.NegativeInfinity" />, or <see cref="double.PositiveInfinity" />, this method returns
    ///     <see cref="double.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Sin(this double value)
    {
        return System.Math.Sin(value);
    }

    /// <summary>
    ///     Returns the hyperbolic sine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, in radians.</param>
    /// <returns>
    ///     The hyperbolic sine of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="double.NaN" />,
    ///     <see cref="double.NegativeInfinity" />, or <see cref="double.PositiveInfinity" />, this method returns
    ///     <see cref="double.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Sinh(this double value)
    {
        return System.Math.Sinh(value);
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this double-precision floating-point number.
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
    /// <exception cref="ArithmeticException"><paramref name="value" /> is equal to <see cref="double.NaN" />.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Sign(this double value)
    {
        return System.Math.Sign(value);
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
    /// <remarks>
    ///     For negative input, this method returns <see cref="double.NaN" />. To receive a complex number, see
    ///     <see cref="Numerics.DoubleExtensions.ComplexSqrt" />.
    /// </remarks>
    /// <seealso cref="Numerics.DoubleExtensions.ComplexSqrt" />
    /// <author>SLenik https://stackoverflow.com/a/6755197/1467293</author>
    /// <license>CC BY-SA 3.0</license>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
            if (previous == 0.0)
            {
                return 0;
            }

            current = (previous + value / previous) / 2;
        } while (System.Math.Abs(previous - current) > double.Epsilon);

        return current;
    }

    /// <summary>
    ///     Returns the tangent of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The tangent of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="double.NaN" />,
    ///     <see cref="double.NegativeInfinity" />, or <see cref="double.PositiveInfinity" />, this method returns
    ///     <see cref="double.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Tan(this double value)
    {
        return System.Math.Tan(value);
    }

    /// <summary>
    ///     Returns the hyperbolic tangent of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The hyperbolic tangent of <paramref name="value" />. If <paramref name="value" /> is equal to
    ///     <see cref="double.NegativeInfinity" />, this method returns -1. If <paramref name="value" /> is equal to
    ///     <see cref="double.PositiveInfinity" />, this method returns 1. If <paramref name="value" /> is equal to
    ///     <see cref="double.NaN" />, this method returns <see cref="double.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double Tanh(this double value)
    {
        return System.Math.Tanh(value);
    }
}
