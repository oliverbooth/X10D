using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Provides static helpers methods for mathematical functions not found in the .NET <see cref="System.Math" /> class.
/// </summary>
public static class MathUtility
{
    /// <summary>
    ///     Returns the linear interpolation inverse of a value, such that it determines where a value lies between two other
    ///     values.
    /// </summary>
    /// <param name="alpha">The value whose lerp inverse is to be found.</param>
    /// <param name="start">The start of the range.</param>
    /// <param name="end">The end of the range.</param>
    /// <returns>A value determined by <c>(alpha - start) / (end - start)</c>.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static float InverseLerp(float alpha, float start, float end)
    {
        if (MathF.Abs(start - end) < float.Epsilon)
        {
            return 0f;
        }

        return (alpha - start) / (end - start);
    }

    /// <summary>
    ///     Returns the linear interpolation inverse of a value, such that it determines where a value lies between two other
    ///     values.
    /// </summary>
    /// <param name="alpha">The value whose lerp inverse is to be found.</param>
    /// <param name="start">The start of the range.</param>
    /// <param name="end">The end of the range.</param>
    /// <returns>A value determined by <c>(alpha - start) / (end - start)</c>.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static double InverseLerp(double alpha, double start, double end)
    {
        if (System.Math.Abs(start - end) < double.Epsilon)
        {
            return 0.0;
        }

        return (alpha - start) / (end - start);
    }

    /// <summary>
    ///     Linearly interpolates from one value to a target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static float Lerp(float value, float target, float alpha)
    {
        // rookie mistake: a + t * (b - a)
        // "precise" method: (1 - t) * a + t * b
        return ((1.0f - alpha) * value) + (alpha * target);
    }

    /// <summary>
    ///     Linearly interpolates from one value to a target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static double Lerp(double value, double target, double alpha)
    {
        // rookie mistake: a + t * (b - a)
        // "precise" method: (1 - t) * a + t * b
        return ((1.0 - alpha) * value) + (alpha * target);
    }
}
