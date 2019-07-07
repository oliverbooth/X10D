namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Int32"/>.
    /// </summary>
    public static class Int32Extensions
    {
        #region TimeSpan Returns
        // TODO change

        public static TimeSpan Days(this uint number) =>
            TimeSpan.FromDays(number);

        public static TimeSpan Hours(this uint number) =>
            TimeSpan.FromHours(number);

        public static TimeSpan Milliseconds(this uint number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Minutes(this uint number) =>
            TimeSpan.FromMinutes(number);

        public static TimeSpan Seconds(this uint number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Ticks(this uint number) =>
            TimeSpan.FromTicks(number);

        public static TimeSpan Days(this int number) =>
            TimeSpan.FromDays(number);

        public static TimeSpan Hours(this int number) =>
            TimeSpan.FromHours(number);

        public static TimeSpan Milliseconds(this int number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Minutes(this int number) =>
            TimeSpan.FromMinutes(number);

        public static TimeSpan Seconds(this int number) =>
            TimeSpan.FromSeconds(number);

        public static TimeSpan Ticks(this int number) =>
            TimeSpan.FromTicks(number);

        #endregion

        /// <summary>
        /// Converts the <see cref="Int32"/> to a <see cref="DateTime"/> treating it as a Unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isMillis">Optional. Whether or not the input value should be treated as milliseconds. Defaults
        /// to <see langword="false"/>..</param>
        /// <returns>Returns a <see cref="DateTime"/> representing <paramref name="timestamp"/> seconds since the Unix
        /// epoch.</returns>
        public static DateTime FromUnixTimestamp(this int timestamp, bool isMillis = false) =>
            ((long)timestamp).FromUnixTimestamp(isMillis);

        /// <summary>
        /// Converts the <see cref="UInt32"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this uint number) =>
            BitConverter.GetBytes(number);

        /// <summary>
        /// Converts the <see cref="Int32"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this int number) =>
            BitConverter.GetBytes(number);

        /// <summary>
        /// Determines if the <see cref="Int32"/> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is prime, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsPrime(this int number) =>
            ((long)number).IsPrime();
    }
}
