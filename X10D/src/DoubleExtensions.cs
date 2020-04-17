namespace X10D
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="double"/>.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Clamps a value between a minimum and a maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Returns <paramref name="max"/> if <paramref name="value"/> is greater than it,
        /// <paramref name="min"/> if <paramref name="value"/> is less than it,
        /// or <paramref name="value"/> itself otherwise.</returns>
        public static double Clamp(this double value, double min, double max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        /// Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <returns>Returns <paramref name="angle"/> in radians.</returns>
        public static double DegreesToRadians(this double angle)
        {
            return Math.PI * angle / 180.0;
        }

        /// <summary>
        /// Converts the <see cref="double"/> to a <see cref="byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="byte"/>[].</returns>
        public static byte[] GetBytes(this double number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        /// Determines if the <see cref="double"/> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is even, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsEven(this double number)
        {
            return Math.Abs(number % 2.0) < double.Epsilon;
        }

        /// <summary>
        /// Determines if the <see cref="double"/> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is odd, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsOdd(this double number)
        {
            return !number.IsEven();
        }

        /// <summary>
        /// Converts an angle from radians to degrees.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>Returns <paramref name="angle"/> in degrees.</returns>
        public static double RadiansToDegrees(this double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        /// <summary>
        /// Rounds to the nearest value.
        /// </summary>
        /// <param name="v">The value to round.</param>
        /// <param name="nearest">The nearest value.</param>
        /// <returns>Returns the rounded value.</returns>
        public static double Round(this double v, int nearest = 1)
        {
            return Math.Round(v / nearest) * nearest;
        }
    }
}
