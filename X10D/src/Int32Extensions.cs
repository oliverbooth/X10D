namespace X10D
{
    using System;

    /// <summary>
    ///     Extension methods for <see cref="int" />.
    /// </summary>
    public static class Int32Extensions
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
        public static int Clamp(this int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

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
        [CLSCompliant(false)]
        public static uint Clamp(this uint value, uint min, uint max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        ///     Converts the <see cref="int" /> to a <see cref="DateTime" /> treating it as a Unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isMillis">
        ///     Optional. Whether or not the input value should be treated as milliseconds. Defaults
        ///     to <see langword="false" />..
        /// </param>
        /// <returns>
        ///     Returns a <see cref="DateTime" /> representing <paramref name="timestamp" /> seconds since the Unix
        ///     epoch.
        /// </returns>
        public static DateTime FromUnixTimestamp(this int timestamp, bool isMillis = false)
        {
            return ((long)timestamp).FromUnixTimestamp(isMillis);
        }

        /// <summary>
        ///     Converts the <see cref="uint" /> to a <see cref="byte" />[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="byte" />[].</returns>
        [CLSCompliant(false)]
        public static byte[] GetBytes(this uint number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        ///     Converts the <see cref="int" /> to a <see cref="byte" />[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="byte" />[].</returns>
        public static byte[] GetBytes(this int number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        ///     Determines if the <see cref="int" /> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is even, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this int number)
        {
            return ((long)number).IsEven();
        }

        /// <summary>
        ///     Determines if the <see cref="uint" /> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is even, <see langword="false" />
        ///     otherwise.
        /// </returns>
        [CLSCompliant(false)]
        public static bool IsEven(this uint number)
        {
            return ((ulong)number).IsEven();
        }

        /// <summary>
        ///     Determines if the <see cref="int" /> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is odd, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsOdd(this int number)
        {
            return !number.IsEven();
        }

        /// <summary>
        ///     Determines if the <see cref="uint" /> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is odd, <see langword="false" />
        ///     otherwise.
        /// </returns>
        [CLSCompliant(false)]
        public static bool IsOdd(this uint number)
        {
            return !number.IsEven();
        }

        /// <summary>
        ///     Determines if the <see cref="int" /> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="number" /> is prime, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsPrime(this int number)
        {
            return ((long)number).IsPrime();
        }

        /// <summary>
        ///     Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>
        ///     Returns <see langword="false" /> if <paramref name="value" /> is 0,
        ///     <see langword="true" /> otherwise.
        /// </returns>
        public static bool ToBoolean(this int value)
        {
            return ((long)value).ToBoolean();
        }

        /// <summary>
        ///     Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>
        ///     Returns <see langword="false" /> if <paramref name="value" /> is 0,
        ///     <see langword="true" /> otherwise.
        /// </returns>
        [CLSCompliant(false)]
        public static bool ToBoolean(this uint value)
        {
            return ((ulong)value).ToBoolean();
        }
    }
}
