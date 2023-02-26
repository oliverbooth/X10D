﻿using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Provides static helpers methods for mathematical functions not found in the .NET <see cref="System.Math" /> class.
/// </summary>
public static class MathUtility
{
    private const double DefaultGamma = 2.2;
    private const float DefaultGammaF = 2.2f;

    /// <summary>
    ///     Converts a gamma-encoded value to a linear value using a gamma value of <c>2.2</c>.
    /// </summary>
    /// <param name="value">The gamma-encoded value to convert. Expected range is [0, 1].</param>
    /// <returns>The linear value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static float GammaToLinear(float value)
    {
        return GammaToLinear(value, DefaultGammaF);
    }

    /// <summary>
    ///     Converts a gamma-encoded value to a linear value using the specified gamma value.
    /// </summary>
    /// <param name="value">The gamma-encoded value to convert. Expected range is [0, 1].</param>
    /// <param name="gamma">The gamma value to use for decoding.</param>
    /// <returns>The linear value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static float GammaToLinear(float value, float gamma)
    {
        return MathF.Pow(value, 1.0f / gamma);
    }

    /// <summary>
    ///     Converts a gamma-encoded value to a linear value using a gamma value of <c>2.2</c>.
    /// </summary>
    /// <param name="value">The gamma-encoded value to convert. Expected range is [0, 1].</param>
    /// <returns>The linear value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static double GammaToLinear(double value)
    {
        return GammaToLinear(value, DefaultGamma);
    }

    /// <summary>
    ///     Converts a gamma-encoded value to a linear value using the specified gamma value.
    /// </summary>
    /// <param name="value">The gamma-encoded value to convert. Expected range is [0, 1].</param>
    /// <param name="gamma">The gamma value to use for decoding.</param>
    /// <returns>The linear value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static double GammaToLinear(double value, double gamma)
    {
        return System.Math.Pow(value, 1.0 / gamma);
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

    /// <summary>
    ///     Converts a linear value to a gamma-encoded value using a gamma value of <c>2.2</c>.
    /// </summary>
    /// <param name="value">The linear value to convert. Expected range is [0, 1].</param>
    /// <returns>The gamma-encoded value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static float LinearToGamma(float value)
    {
        return LinearToGamma(value, DefaultGammaF);
    }

    /// <summary>
    ///     Converts a linear value to a gamma-encoded value using the specified gamma value.
    /// </summary>
    /// <param name="value">The linear value to convert. Expected range is [0, 1].</param>
    /// <param name="gamma">The gamma value to use for encoding.</param>
    /// <returns>The gamma-encoded value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static float LinearToGamma(float value, float gamma)
    {
        return MathF.Pow(value, 1.0f / gamma);
    }

    /// <summary>
    ///     Converts a linear value to a gamma-encoded value using a gamma value of <c>2.2</c>.
    /// </summary>
    /// <param name="value">The linear value to convert. Expected range is [0, 1].</param>
    /// <returns>The gamma-encoded value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static double LinearToGamma(double value)
    {
        return LinearToGamma(value, DefaultGamma);
    }

    /// <summary>
    ///     Converts a linear value to a gamma-encoded value using the specified gamma value.
    /// </summary>
    /// <param name="value">The linear value to convert. Expected range is [0, 1].</param>
    /// <param name="gamma">The gamma value to use for encoding.</param>
    /// <returns>The gamma-encoded value.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static double LinearToGamma(double value, double gamma)
    {
        return System.Math.Pow(value, 1.0 / gamma);
    }

    /// <summary>
    ///     Converts a value from being a percentage of one range, to being the same percentage in a new range.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="oldMin">The old minimum value.</param>
    /// <param name="oldMax">The old maximum value.</param>
    /// <param name="newMin">The new minimum value.</param>
    /// <param name="newMax">The new maximum value.</param>
    /// <returns>The scaled value.</returns>
    public static float ScaleRange(float value, float oldMin, float oldMax, float newMin, float newMax)
    {
        float oldRange = oldMax - oldMin;
        float newRange = newMax - newMin;
        float alpha = (value - oldMin) / oldRange;
        return (alpha * newRange) + newMin;
    }

    /// <summary>
    ///     Converts a value from being a percentage of one range, to being the same percentage in a new range.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="oldMin">The old minimum value.</param>
    /// <param name="oldMax">The old maximum value.</param>
    /// <param name="newMin">The new minimum value.</param>
    /// <param name="newMax">The new maximum value.</param>
    /// <returns>The scaled value.</returns>
    public static double ScaleRange(double value, double oldMin, double oldMax, double newMin, double newMax)
    {
        double oldRange = oldMax - oldMin;
        double newRange = newMax - newMin;
        double alpha = (value - oldMin) / oldRange;
        return (alpha * newRange) + newMin;
    }
}
