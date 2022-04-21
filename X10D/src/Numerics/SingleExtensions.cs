using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.Math;

namespace X10D.Numerics;

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
    /// <seealso cref="X10D.Math.SingleExtensions.Sqrt" />
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
}
