using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Provides static helpers methods for mathematical functions not found in the .NET <see cref="System.Math" /> class.
/// </summary>
public static class MathUtility
{
    private const double DefaultGamma = 2.2;
    private const float DefaultGammaF = 2.2f;

    /// <summary>
    ///     Calculates exponential decay for a value.
    /// </summary>
    /// <param name="value">The value to decay.</param>
    /// <param name="alpha">A factor by which to scale the decay.</param>
    /// <param name="decay">The decay amount.</param>
    /// <returns>The exponentially decayed value.</returns>
    public static float ExponentialDecay(float value, float alpha, float decay)
    {
        return value * MathF.Exp(-decay * alpha);
    }

    /// <summary>
    ///     Calculates exponential decay for a value.
    /// </summary>
    /// <param name="value">The value to decay.</param>
    /// <param name="alpha">A factor by which to scale the decay.</param>
    /// <param name="decay">The decay amount.</param>
    /// <returns>The exponentially decayed value.</returns>
    public static double ExponentialDecay(double value, double alpha, double decay)
    {
        return value * System.Math.Exp(-decay * alpha);
    }

    /// <summary>
    ///     Converts a gamma-encoded value to a linear value using a gamma value of <c>2.2</c>.
    /// </summary>
    /// <param name="value">The gamma-encoded value to convert. Expected range is [0, 1].</param>
    /// <returns>The linear value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static double InverseLerp(double alpha, double start, double end)
    {
        if (System.Math.Abs(start - end) < double.Epsilon)
        {
            return 0.0;
        }

        return (alpha - start) / (end - start);
    }


#if !NET7_0_OR_GREATER
    /// <summary>
    ///     Applies a simple bias function to value.
    /// </summary>
    /// <param name="value">The value to which the bias function will be applied.</param>
    /// <param name="bias">The bias value. Valid values range from 0-1.</param>
    /// <returns>The biased result.</returns>
    /// <remarks>
    ///     If <paramref name="bias" /> is less than 0.5, <paramref name="value" /> will be shifted downward; otherwise, upward.
    /// </remarks>
    public static float Bias(float value, float bias)
    {
        return value / ((1.0f / bias - 2.0f) * (1.0f - value) + 1.0f);
    }

    /// <summary>
    ///     Applies a simple bias function to value.
    /// </summary>
    /// <param name="value">The value to which the bias function will be applied.</param>
    /// <param name="bias">The bias value. Valid values range from 0-1.</param>
    /// <returns>The biased result.</returns>
    /// <remarks>
    ///     If <paramref name="bias" /> is less than 0.5, <paramref name="value" /> will be shifted downward; otherwise, upward.
    /// </remarks>
    public static double Bias(double value, double bias)
    {
        return value / ((1.0 / bias - 2.0) * (1.0 - value) + 1.0);
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static double Lerp(double value, double target, double alpha)
    {
        // rookie mistake: a + t * (b - a)
        // "precise" method: (1 - t) * a + t * b
        return ((1.0 - alpha) * value) + (alpha * target);
    }

    /// <summary>
    ///     Performs smooth Hermite interpolation from one value to a target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>The interpolation result.</returns>
    public static float SmoothStep(float value, float target, float alpha)
    {
        alpha = System.Math.Clamp(alpha, 0.0f, 1.0f);
        alpha = -2.0f * alpha * alpha * alpha + 3.0f * alpha * alpha;
        return target * alpha + value * (1.0f - alpha);
    }

    /// <summary>
    ///     Performs smooth Hermite interpolation from one value to a target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>The interpolation result.</returns>
    public static double SmoothStep(double value, double target, double alpha)
    {
        alpha = System.Math.Clamp(alpha, 0.0, 1.0);
        alpha = -2.0 * alpha * alpha * alpha + 3.0 * alpha * alpha;
        return target * alpha + value * (1.0 - alpha);
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
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static double ScaleRange(double value, double oldMin, double oldMax, double newMin, double newMax)
    {
        double oldRange = oldMax - oldMin;
        double newRange = newMax - newMin;
        double alpha = (value - oldMin) / oldRange;
        return (alpha * newRange) + newMin;
    }

    /// <summary>
    ///     Returns the incremental sawtooth wave of a given value.
    /// </summary>
    /// <param name="value">The value to calculate.</param>
    /// <returns>The sawtooth wave of the given value.</returns>
    public static float Sawtooth(float value)
    {
        return (value - MathF.Floor(value));
    }

    /// <summary>
    ///     Returns the incremental sawtooth wave of a given value.
    /// </summary>
    /// <param name="value">The value to calculate.</param>
    /// <returns>The sawtooth wave of the given value.</returns>
    public static double Sawtooth(double value)
    {
        return (value - System.Math.Floor(value));
    }
#endif

    /// <summary>
    ///     Converts a linear value to a gamma-encoded value using a gamma value of <c>2.2</c>.
    /// </summary>
    /// <param name="value">The linear value to convert. Expected range is [0, 1].</param>
    /// <returns>The gamma-encoded value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static double LinearToGamma(double value, double gamma)
    {
        return System.Math.Pow(value, 1.0 / gamma);
    }

    /// <summary>
    ///     Returns the pulse wave for a given value.
    /// </summary>
    /// <param name="value">The value to calculate.</param>
    /// <param name="lowerBound">The inclusive lower bound of the pulse.</param>
    /// <param name="upperBound">The inclusive upper bound of the pulse.</param>
    /// <returns>
    ///     1 if <paramref name="value" /> lies between <paramref name="lowerBound" /> and <paramref name="upperBound" />;
    ///     otherwise, 0.
    /// </returns>
    public static float Pulse(float value, float lowerBound, float upperBound)
    {
        bool result = lowerBound <= value && value <= upperBound;
        return Unsafe.As<bool, int>(ref result);
    }

    /// <summary>
    ///     Returns the pulse wave for a given value.
    /// </summary>
    /// <param name="value">The value to calculate.</param>
    /// <param name="lowerBound">The inclusive lower bound of the pulse.</param>
    /// <param name="upperBound">The inclusive upper bound of the pulse.</param>
    /// <returns>
    ///     1 if <paramref name="value" /> lies between <paramref name="lowerBound" /> and <paramref name="upperBound" />;
    ///     otherwise, 0.
    /// </returns>
    public static double Pulse(double value, double lowerBound, double upperBound)
    {
        bool result = lowerBound <= value && value <= upperBound;
        return Unsafe.As<bool, int>(ref result);
    }

    /// <summary>
    ///     Calculates the sigmoid function for the given input value.
    /// </summary>
    /// <param name="value">The input value for which to calculate the sigmoid function.</param>
    /// <returns>The result of applying the sigmoid function to the input value.</returns>
    /// <remarks>
    ///     The sigmoid function is a commonly used activation function in artificial neural networks and logistic regression. It
    ///     maps any real-valued number to a value between 0 and 1.
    /// </remarks>
    public static float Sigmoid(float value)
    {
        return 1.0f / (1.0f + MathF.Exp(-value));
    }

    /// <summary>
    ///     Calculates the sigmoid function for the given input value.
    /// </summary>
    /// <param name="value">The input value for which to calculate the sigmoid function.</param>
    /// <returns>The result of applying the sigmoid function to the input value.</returns>
    /// <remarks>
    ///     The sigmoid function is a commonly used activation function in artificial neural networks and logistic regression. It
    ///     maps any real-valued number to a value between 0 and 1.
    /// </remarks>
    public static double Sigmoid(double value)
    {
        return 1.0f / (1.0f + System.Math.Exp(-value));
    }

#if NET7_0_OR_GREATER
    /// <summary>
    ///     Applies a simple bias function to value.
    /// </summary>
    /// <param name="value">The value to which the bias function will be applied.</param>
    /// <param name="bias">The bias value. Valid values range from 0-1.</param>
    /// <returns>The biased result.</returns>
    /// <remarks>
    ///     If <paramref name="bias" /> is less than 0.5, <paramref name="value" /> will be shifted downward; otherwise, upward.
    /// </remarks>
    public static TNumber Bias<TNumber>(TNumber value, TNumber bias)
        where TNumber : INumber<TNumber>
    {
        TNumber identity = TNumber.MultiplicativeIdentity;
        return value / ((identity / bias - TNumber.CreateChecked(2)) * (identity - value) + identity);
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TNumber Lerp<TNumber>(TNumber value, TNumber target, TNumber alpha)
        where TNumber : INumber<TNumber>
    {
        // rookie mistake: a + t * (b - a)
        // "precise" method: (1 - t) * a + t * b
        return ((TNumber.MultiplicativeIdentity - alpha) * value) + (alpha * target);
    }

    /// <summary>
    ///     Returns the incremental sawtooth wave of a given value.
    /// </summary>
    /// <param name="value">The value to calculate.</param>
    /// <returns>The sawtooth wave of the given value.</returns>
    public static TNumber Sawtooth<TNumber>(TNumber value)
        where TNumber : IFloatingPoint<TNumber>
    {
        return (value - TNumber.Floor(value));
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
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TNumber ScaleRange<TNumber>(TNumber value, TNumber oldMin, TNumber oldMax, TNumber newMin, TNumber newMax)
        where TNumber : INumber<TNumber>
    {
        TNumber oldRange = oldMax - oldMin;
        TNumber newRange = newMax - newMin;
        TNumber alpha = (value - oldMin) / oldRange;
        return (alpha * newRange) + newMin;
    }

    /// <summary>
    ///     Performs smooth Hermite interpolation from one value to a target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>The interpolation result.</returns>
    public static TNumber SmoothStep<TNumber>(TNumber value, TNumber target, TNumber alpha)
        where TNumber : INumber<TNumber>
    {
        TNumber one = TNumber.One;
        TNumber two = one + one;
        TNumber three = two + one;

        alpha = TNumber.Clamp(alpha, TNumber.Zero, TNumber.One);
        alpha = -two * alpha * alpha * alpha + three * alpha * alpha;
        return target * alpha + value * (one - alpha);
    }
#endif
}
