using System;

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
        /// <param name="angle">The angle in degrees to convert.</param>
        /// <returns>
        ///     <paramref name="angle" /> converted from degrees to radians by calculating
        ///     <c><paramref name="angle" />π / 180</c>.
        /// </returns>
        public static double DegreesToRadians(this double angle)
        {
            return Math.PI * angle / 180.0;
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
        ///     Determines if the <see cref="double" /> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is even, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this double number)
        {
            return Math.Abs(number % 2.0) < double.Epsilon;
        }

        /// <summary>
        ///     Determines if the <see cref="double" /> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is odd, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsOdd(this double number)
        {
            return !number.IsEven();
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
        /// <param name="angle">The angle in radians to convert.</param>
        /// <returns>
        ///     <paramref name="angle" /> converted from radians to degrees by calculating
        ///     <c><paramref name="angle" />(180 / π)</c>.
        /// </returns>
        public static double RadiansToDegrees(this double angle)
        {
            return angle * (180.0 / Math.PI);
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

        private static double LerpInternal(double a, double b, double t)
        {
            // rookie mistake: a + t * (b - a)
            
            // "precise" method: (1 - t) * a + t * b
            return (1 - t) * a + t * b;
        }
    }
}
