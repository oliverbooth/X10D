using System;
using System.Runtime.CompilerServices;

namespace X10D.DoubleExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="double" />.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        ///     Converts the current angle in degrees to its equivalent represented in radians.
        /// </summary>
        /// <param name="value">The angle in degrees to convert.</param>
        /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
        public static double DegreesToRadians(this double value)
        {
            return Math.PI * value / 180.0;
        }

        /// <summary>
        ///     Converts the <see cref="double" /> to a <see cref="byte" />[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="byte" />[].</returns>
        public static byte[] GetBytes(this double number)
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
        public static bool IsEven(this double value)
        {
            return Math.Abs(value % 2.0) < double.Epsilon;
        }

        /// <summary>
        ///     Returns a value indicating whether the current value is not evenly divisible by 2.
        /// </summary>
        /// <param name="value">The value whose parity to check.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is not evenly divisible by 2, or <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsOdd(this double value)
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
        ///     The interpolation result as determined by <c>(1 - <paramref name="alpha" />) * <paramref name="value" /> +
        ///     <paramref name="alpha" /> * <paramref name="target" /></c>.
        /// </returns>
        public static double LerpFrom(this double target, double value, double alpha)
        {
            return LerpInternal(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates from the current value to a specified target using a specified alpha.
        /// </summary>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - <paramref name="alpha" />) * <paramref name="value" /> +
        ///     <paramref name="alpha" /> * <paramref name="target" /></c>.
        /// </returns>
        public static double LerpTo(this double value, double target, double alpha)
        {
            return LerpInternal(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates to a specified target from a specified source, using the current value as the alpha value.
        /// </summary>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - <paramref name="alpha" />) * <paramref name="value" /> +
        ///     <paramref name="alpha" /> * <paramref name="target" /></c>.
        /// </returns>
        public static double LerpWith(this double alpha, double value, double target)
        {
            return LerpInternal(value, target, alpha);
        }

        /// <summary>
        ///     Converts the current angle in radians to its equivalent represented in degrees.
        /// </summary>
        /// <param name="value">The angle in radians to convert.</param>
        /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
        public static double RadiansToDegrees(this double value)
        {
            return value * (180.0 / Math.PI);
        }

        /// <summary>
        ///     Rounds the current value to the nearest whole number.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns><paramref name="value" /> rounded to the nearest whole number.</returns>
        public static double Round(this double value)
        {
            return value.Round(1.0);
        }

        /// <summary>
        ///     Rounds the current value to the nearest multiple of a specified number.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="nearest">The nearest multiple to which <paramref name="value" /> should be rounded.</param>
        /// <returns><paramref name="value" /> rounded to the nearest multiple of <paramref name="nearest"/>.</returns>
        public static double Round(this double value, double nearest)
        {
            return Math.Round(value / nearest) * nearest;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double LerpInternal(double a, double b, double t)
        {
            // rookie mistake: a + t * (b - a)
            // "precise" method: (1 - t) * a + t * b
            return (1.0 - t) * a + t * b;
        }
    }
}
