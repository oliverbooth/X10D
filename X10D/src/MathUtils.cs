﻿namespace X10D
{
    /// <summary>
    ///     Provides static helpers methods for mathematical functions not found in the .NET <see cref="System.Math" /> class.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        ///     Linearly interpolates from one value to a target using a specified alpha.
        /// </summary>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static float Lerp(float value, float target, float alpha)
        {
            return (float)Lerp(value * 1.0, target, alpha);
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
        public static double Lerp(double value, double target, double alpha)
        {
            // rookie mistake: a + t * (b - a)
            // "precise" method: (1 - t) * a + t * b
            return ((1.0 - alpha) * value) + (alpha * target);
        }
    }
}