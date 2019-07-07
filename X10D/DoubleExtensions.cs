namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Double"/>.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <returns>Returns <paramref name="angle"/> in radians.</returns>
        public static double DegreesToRadians(this double angle) =>
            Math.PI * angle / 180.0;

        /// <summary>
        /// Converts the <see cref="Double"/> to a <see cref="DateTime"/> treating it as a Unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isMillis">Optional. Whether or not the input value should be treated as milliseconds. Defaults
        /// to <see langword="false"/>.</param>
        /// <returns>Returns a <see cref="DateTime"/> representing <paramref name="timestamp"/> seconds since the Unix
        /// epoch.</returns>
        public static DateTime FromUnixTimestamp(this double timestamp, bool isMillis = false) =>
            isMillis
                ? DateTimeExtensions.UnixEpoch.AddMilliseconds(timestamp)
                : DateTimeExtensions.UnixEpoch.AddSeconds(timestamp);

        /// <summary>
        /// Converts the <see cref="Double"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this double number) =>
            BitConverter.GetBytes(number);

        /// <summary>
        /// Converts an angle from radians to degrees.
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>Returns <paramref name="angle"/> in degrees.</returns>
        public static double RadiansToDegrees(this double angle) =>
            angle * (180.0 / Math.PI);

        /// <summary>
        /// Rounds to the nearest value.
        /// </summary>
        /// <param name="v">The value to round.</param>
        /// <param name="nearest">The nearest value.</param>
        /// <returns>Returns the rounded value.</returns>
        public static double Round(this double v, int nearest = 1) =>
            Math.Round(v / nearest) * nearest;
    }
}
