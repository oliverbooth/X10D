namespace X10D
{
    using System;

    /// <summary>
    ///     Extension methods for <see cref="float" />.
    /// </summary>
    public static class SingleExtensions
    {
        /// <summary>
        ///     Clamps a value between a minimum and a maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>
        ///     Returns <paramref name="max" /> if <paramref name="value" /> is greater than it,
        ///     <paramref name="min" /> if <paramref name="value" /> is less than it,
        ///     or <paramref name="value" /> itself otherwise.
        /// </returns>
        public static float Clamp(this float value, float min, float max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        ///     Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <returns>Returns <paramref name="angle" /> in radians.</returns>
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
        ///     Determines if the <see cref="float" /> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is even, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this float number)
        {
            return ((double)number).IsEven();
        }

        /// <summary>
        ///     Determines if the <see cref="float" /> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is odd, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsOdd(this float number)
        {
            return !number.IsEven();
        }

        /// <summary>
        ///     Converts an angle from radians to degrees.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>Returns <paramref name="angle" /> in degrees.</returns>
        public static float RadiansToDegrees(this float angle)
        {
            return (float)((double)angle).RadiansToDegrees();
        }

        /// <summary>
        ///     Rounds to the nearest value.
        /// </summary>
        /// <param name="v">The value to round.</param>
        /// <param name="nearest">The nearest value.</param>
        /// <returns>Returns the rounded value.</returns>
        public static float Round(this float v, float nearest = 1)
        {
            return (float)((double)v).Round(nearest);
        }
    }
}
