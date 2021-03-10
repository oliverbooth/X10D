using System;
using X10D.DoubleExtensions;

namespace X10D.SingleExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="float" />.
    /// </summary>
    public static class SingleExtensions
    {
        /// <summary>
        ///     Converts the current angle in degrees to its equivalent represented in radians.
        /// </summary>
        /// <param name="angle">The angle in degrees to convert.</param>
        /// <returns>
        ///     <paramref name="angle" /> converted from degrees to radians by calculating
        ///     <c><paramref name="angle" />π / 180</c>.
        /// </returns>
        public static float DegreesToRadians(this float angle)
        {
            return (float)((double)angle).DegreesToRadians();
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
        ///     The interpolation result as determined by <c>(1 - <paramref name="alpha" />) * <paramref name="value" /> +
        ///     <paramref name="alpha" /> * <paramref name="target" /></c>.
        /// </returns>
        public static float LerpFrom(this float target, float value, float alpha)
        {
            return (float)((double)target).LerpFrom(value, alpha);
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
        public static float LerpTo(this float value, float target, float alpha)
        {
            return (float)((double)value).LerpTo(target, alpha);
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
        public static float LerpWith(this float alpha, float value, float target)
        {
            return (float)((double)alpha).LerpWith(value, target);
        }

        /// <summary>
        ///     Converts the current angle in radians to its equivalent represented in degrees.
        /// </summary>
        /// <param name="angle">The angle in radians to convert.</param>
        /// <returns>
        ///     <paramref name="angle" /> converted from radians to degrees by calculating
        ///     <c><paramref name="angle" />(180 / π)</c>.
        /// </returns>
        public static float RadiansToDegrees(this float angle)
        {
            return (float)((double)angle).RadiansToDegrees();
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
        /// <returns><paramref name="value" /> rounded to the nearest multiple of <paramref name="nearest"/>.</returns>
        public static float Round(this float value, float nearest)
        {
            return (float)((double)value).Round(nearest);
        }
    }
}
