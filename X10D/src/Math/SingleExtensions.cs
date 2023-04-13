using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Returns the complex square root of this single-precision floating-point number.
    /// </summary>
    /// <param name="value">The number whose square root is to be found.</param>
    /// <returns>The square root of <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Complex ComplexSqrt(this float value)
    {
        switch (value)
        {
            case float.PositiveInfinity:
            case float.NegativeInfinity:
                return new Complex(double.PositiveInfinity, double.PositiveInfinity);
            case float.NaN:
                return new Complex(double.NaN, double.NaN);

            case 0:
                return Complex.Zero;
            case > 0:
                return new Complex(MathF.Sqrt(value), 0);
            case < 0:
                return new Complex(0, MathF.Sqrt(-value));
        }
    }

    /// <summary>
    ///     Converts the current angle in degrees to its equivalent represented in radians.
    /// </summary>
    /// <param name="value">The angle in degrees to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float DegreesToRadians(this float value)
    {
        return value * (MathF.PI / 180.0f);
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
    public static bool IsEven(this float value)
    {
        return value % 2 == 0;
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
    public static bool IsOdd(this float value)
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
    public static float RadiansToDegrees(this float value)
    {
        return value * (180.0f / MathF.PI);
    }

    /// <summary>
    ///     Rounds the current value to the nearest whole number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <returns><paramref name="value" /> rounded to the nearest whole number.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float Round(this float value)
    {
        return value.Round(1.0f);
    }

    /// <summary>
    ///     Rounds the current value to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <param name="nearest">The nearest multiple to which <paramref name="value" /> should be rounded.</param>
    /// <returns><paramref name="value" /> rounded to the nearest multiple of <paramref name="nearest" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float Round(this float value, float nearest)
    {
        return MathF.Round(value / nearest) * nearest;
    }

    /// <summary>
    ///     Saturates this single-precision floating-point number.
    /// </summary>
    /// <param name="value">The value to saturate.</param>
    /// <returns>The saturated value.</returns>
    /// <remarks>This method clamps <paramref name="value" /> between 0 and 1.</remarks>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float Saturate(this float value)
    {
        return System.Math.Clamp(value, 0.0f, 1.0f);
    }

    /// <summary>
    ///     Returns the square root of this single-precision floating-point number.
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
    ///             <term><see cref="float.NaN" /></term>
    ///             <description><paramref name="value" /> is equal to <see cref="float.NaN" /> or is negative.</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="float.PositiveInfinity" /></term>
    ///             <description><paramref name="value" /> is equal to <see cref="float.PositiveInfinity" />.</description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <author>SLenik https://stackoverflow.com/a/6755197/1467293</author>
    /// <license>CC BY-SA 3.0</license>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float Sqrt(this float value)
    {
        switch (value)
        {
            case 0:
                return 0;
            case < 0 or float.NaN:
                return float.NaN;
            case float.PositiveInfinity:
                return float.PositiveInfinity;
        }

        float previous;
        float current = MathF.Sqrt(value);
        do
        {
            previous = current;
            current = (previous + value / previous) / 2;
        } while (MathF.Abs(previous - current) > float.Epsilon);

        return current;
    }

    /// <summary>
    ///     Wraps the current single-precision floating-point number between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float Wrap(this float value, float low, float high)
    {
        return (float)((double)value).Wrap(low, high);
    }

    /// <summary>
    ///     Wraps the current single-precision floating-point number between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static float Wrap(this float value, float length)
    {
        return (float)((double)value).Wrap(length);
    }
}
