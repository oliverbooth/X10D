using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Returns the arccosine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a cosine, which must be greater than or equal to -1, but less than or equal to 1.
    /// </param>
    /// <returns>
    ///     The arccosine of <paramref name="value" />, θ, measured in radians; such that 0 ≤ θ ≤ π. If <paramref name="value" />
    ///     is equal to <see cref="float.NaN" />, less than -1, or greater than 1, <see cref="float.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Acos(this float value)
    {
        return MathF.Acos(value);
    }

    /// <summary>
    ///     Returns the hyperbolic arccosine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a hyperbolic cosine, which must be greater than or equal to 1, but less than or equal to
    ///     <see cref="float.PositiveInfinity" />.
    /// </param>
    /// <returns>
    ///     The hyperbolic arccosine of <paramref name="value" />, θ, measured in radians; such that 0 ≤ θ ≤ ∞. If
    ///     <paramref name="value" /> is less than 1 or equal to <see cref="float.NaN" />, <see cref="float.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Acosh(this float value)
    {
        return MathF.Acosh(value);
    }

    /// <summary>
    ///     Returns the arcsine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a sine, which must be greater than or equal to -1, but less than or equal to 1.
    /// </param>
    /// <returns>
    ///     The arccosine of <paramref name="value" />, θ, measured in radians; such that π/2 ≤ θ ≤ π/2. If
    ///     <paramref name="value" /> is equal to <see cref="float.NaN" />, less than -1, or greater than 1,
    ///     <see cref="float.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Asin(this float value)
    {
        return MathF.Asin(value);
    }

    /// <summary>
    ///     Returns the hyperbolic arcsine of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a hyperbolic sine, which must be greater than or equal to 1, but less than or equal to
    ///     <see cref="float.PositiveInfinity" />.
    /// </param>
    /// <returns>
    ///     The hyperbolic arccosine of <paramref name="value" />, measured in radians. If <paramref name="value" /> is equal to
    ///     <see cref="float.NaN" />, <see cref="float.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Asinh(this float value)
    {
        return MathF.Asinh(value);
    }

    /// <summary>
    ///     Returns the arctangent of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a tangent, which must be greater than or equal to -1, but less than or equal to 1.
    /// </param>
    /// <returns>
    ///     The arctangent of <paramref name="value" />, θ, measured in radians; such that π/2 ≤ θ ≤ π/2. If
    ///     <paramref name="value" /> is equal to <see cref="float.NaN" />, <see cref="float.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Atan(this float value)
    {
        return MathF.Atan(value);
    }

    /// <summary>
    ///     Returns the hyperbolic arctangent of the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value representing a hyperbolic tangent, which must be greater than or equal to 1, but less than or equal to
    ///     <see cref="float.PositiveInfinity" />.
    /// </param>
    /// <returns>
    ///     The hyperbolic arctangent of <paramref name="value" />, θ, measured in radians; such that -∞ &lt; θ &lt; -1, or 1 &lt;
    ///     θ &lt; ∞. If <paramref name="value" /> is equal to <see cref="float.NaN" />, less than -1, or greater than 1,
    ///     <see cref="float.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Atanh(this float value)
    {
        return MathF.Atanh(value);
    }

    /// <summary>
    ///     Returns the cosine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The cosine of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="float.NaN" />,
    ///     <see cref="float.NegativeInfinity" />, or <see cref="float.PositiveInfinity" />, this method returns
    ///     <see cref="float.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Cos(this float value)
    {
        return MathF.Cos(value);
    }

    /// <summary>
    ///     Returns the hyperbolic cosine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The hyperbolic cosine of <paramref name="value" />. If <paramref name="value" /> is equal to
    ///     <see cref="float.NegativeInfinity" /> or <see cref="float.PositiveInfinity" />,
    ///     <see cref="float.PositiveInfinity" /> is returned. If <paramref name="value" /> is equal to
    ///     <see cref="float.NaN" />, <see cref="double.NaN" /> is returned.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Cosh(this float value)
    {
        return MathF.Cosh(value);
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
    ///     <see cref="Numerics.SingleExtensions.ComplexSqrt" />.
    /// </remarks>
    /// <seealso cref="Numerics.SingleExtensions.ComplexSqrt" />
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

    /// <summary>
    ///     Returns the sine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The sine of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="double.NaN" />,
    ///     <see cref="double.NegativeInfinity" />, or <see cref="double.PositiveInfinity" />, this method returns
    ///     <see cref="double.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Sin(this float value)
    {
        return MathF.Sin(value);
    }

    /// <summary>
    ///     Returns the hyperbolic sine of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The hyperbolic sine of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="float.NaN" />,
    ///     <see cref="float.NegativeInfinity" />, or <see cref="float.PositiveInfinity" />, this method returns
    ///     <see cref="float.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Sinh(this float value)
    {
        return MathF.Sinh(value);
    }

    /// <summary>
    ///     Returns the tangent of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The tangent of <paramref name="value" />. If <paramref name="value" /> is equal to <see cref="float.NaN" />,
    ///     <see cref="float.NegativeInfinity" />, or <see cref="float.PositiveInfinity" />, this method returns
    ///     <see cref="float.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Tan(this float value)
    {
        return MathF.Sin(value);
    }

    /// <summary>
    ///     Returns the hyperbolic tangent of the specified angle.
    /// </summary>
    /// <param name="value">The angle, measured in radians.</param>
    /// <returns>
    ///     The hyperbolic tangent of <paramref name="value" />. If <paramref name="value" /> is equal to
    ///     <see cref="float.NegativeInfinity" />, this method returns -1. If <paramref name="value" /> is equal to
    ///     <see cref="float.PositiveInfinity" />, this method returns 1. If <paramref name="value" /> is equal to
    ///     <see cref="float.NaN" />, this method returns <see cref="float.NaN" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float Tanh(this float value)
    {
        return MathF.Tanh(value);
    }
}
