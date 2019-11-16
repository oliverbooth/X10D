namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Single"/>.
    /// </summary>
    public static class SingleExtensions
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
        public static float Clamp(this float value, float min, float max) =>
            Math.Min(Math.Max(value, min), max);

        /// <summary>
        /// Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <returns>Returns <paramref name="angle"/> in radians.</returns>
        public static float DegreesToRadians(this float angle) =>
            (float)((double)angle).DegreesToRadians();

        /// <summary>
        /// Converts the <see cref="Single"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this float number) =>
            BitConverter.GetBytes(number);

        /// <summary>
        /// Converts an angle from radians to degrees.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>Returns <paramref name="angle"/> in degrees.</returns>
        public static float RadiansToDegrees(this float angle) =>
            (float)((double)angle).RadiansToDegrees();

        /// <summary>
        /// Rounds to the nearest value.
        /// </summary>
        /// <param name="v">The value to round.</param>
        /// <param name="nearest">The nearest value.</param>
        /// <returns>Returns the rounded value.</returns>
        public static float Round(this float v, int nearest = 1) =>
            (float)((double)v).Round(nearest);
    }
}
