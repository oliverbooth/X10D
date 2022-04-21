using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.Math;

namespace X10D.Numerics;

/// <summary>
///     Extension methods which accept or return types within <see cref="System.Numerics" />.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    ///     Returns the complex square root of this double-precision floating-point number.
    /// </summary>
    /// <param name="value">The number whose square root is to be found.</param>
    /// <returns>The square root of <paramref name="value" />.</returns>
    /// <seealso cref="X10D.Math.DoubleExtensions.Sqrt" />
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
        }

        double absoluteSqrt = System.Math.Abs(value).Sqrt();
        return new Complex(absoluteSqrt, value >= 0 ? 0 : 1);
    }
}
