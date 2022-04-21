using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D;

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
    /// <seealso cref="Sqrt" />
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Complex ComplexSqrt(this float value)
    {
        switch (value)
        {
            case float.PositiveInfinity:
            case float.NegativeInfinity:
                return Complex.Infinity;
            case float.NaN:
                return Complex.NaN;
        }

        float absoluteSqrt = MathF.Abs(value).Sqrt();
        return new Complex(absoluteSqrt, value >= 0 ? 0 : 1);
    }

    /// <summary>
    ///     Converts the current angle in degrees to its equivalent represented in radians.
    /// </summary>
    /// <param name="value">The angle in degrees to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    public static float DegreesToRadians(this float value)
    {
        return value * (MathF.PI / 180.0f);
    }

    /// <summary>
    ///     Converts the <see cref="float" /> to a <see cref="byte" />[].
    /// </summary>
    /// <param name="number">The number to convert.</param>
    /// <returns>Returns a <see cref="byte" />[].</returns>
    public static byte[] GetBytes(this float number)
    {
        return BitConverter.GetBytes(number);
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
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
    public static bool IsOdd(this float value)
    {
        return !value.IsEven();
    }

    /// <summary>
    ///     Linearly interpolates to the current value from a specified source using a specified alpha.
    /// </summary>
    /// <param name="target">The interpolation target.</param>
    /// <param name="value">The interpolation source.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static float LerpFrom(this float target, float value, float alpha)
    {
        return MathUtils.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates from the current value to a specified target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static float LerpTo(this float value, float target, float alpha)
    {
        return MathUtils.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates to a specified target from a specified source, using the current value as the alpha value.
    /// </summary>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static float LerpWith(this float alpha, float value, float target)
    {
        return MathUtils.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Converts the current angle in radians to its equivalent represented in degrees.
    /// </summary>
    /// <param name="value">The angle in radians to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    public static float RadiansToDegrees(this float value)
    {
        return value * (180.0f / MathF.PI);
    }

    /// <summary>
    ///     Rounds the current value to the nearest whole number.
    /// </summary>
    /// <param name="value">The value to round.</param>
    /// <returns><paramref name="value" /> rounded to the nearest whole number.</returns>
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
    public static float Round(this float value, float nearest)
    {
        return MathF.Round(value / nearest) * nearest;
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this single-precision floating-point number.
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Sign(this float value)
    {
        return MathF.Sign(value);
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
    /// <remarks>
    ///     For negative input, this method returns <see cref="float.NaN" />. To receive a complex number, see
    ///     <see cref="ComplexSqrt" />.
    /// </remarks>
    /// <seealso cref="ComplexSqrt" />
    /// <author>SLenik https://stackoverflow.com/a/6755197/1467293</author>
    /// <license>CC BY-SA 3.0</license>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
            if (previous == 0.0f)
            {
                return 0;
            }

            current = (previous + value / previous) / 2;
        } while (MathF.Abs(previous - current) > float.Epsilon);

        return current;
    }
}
