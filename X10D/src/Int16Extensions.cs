namespace X10D
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="short"/>.
    /// </summary>
    public static class Int16Extensions
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
        public static short Clamp(this short value, short min, short max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        /// Clamps a value between a minimum and a maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Returns <paramref name="max"/> if <paramref name="value"/> is greater than it,
        /// <paramref name="min"/> if <paramref name="value"/> is less than it,
        /// or <paramref name="value"/> itself otherwise.</returns>
        [CLSCompliant(false)]
        public static ushort Clamp(this ushort value, ushort min, ushort max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        /// Converts the <see cref="short"/> to a <see cref="DateTime"/> treating it as a Unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isMillis">Optional. Whether or not the input value should be treated as milliseconds. Defaults
        /// to <see langword="false"/>..</param>
        /// <returns>Returns a <see cref="DateTime"/> representing <paramref name="timestamp"/> seconds since the Unix
        /// epoch.</returns>
        public static DateTime FromUnixTimestamp(this short timestamp, bool isMillis = false)
        {
            return ((long)timestamp).FromUnixTimestamp(isMillis);
        }

        /// <summary>
        /// Converts the <see cref="ushort"/> to a <see cref="byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="byte"/>[].</returns>
        [CLSCompliant(false)]
        public static byte[] GetBytes(this ushort number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        /// Converts the <see cref="short"/> to a <see cref="byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="byte"/>[].</returns>
        public static byte[] GetBytes(this short number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        /// Determines if the <see cref="short"/> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is even, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsEven(this short number)
        {
            return ((long)number).IsEven();
        }

        /// <summary>
        /// Determines if the <see cref="ushort"/> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is even, <see langword="false"/>
        /// otherwise.</returns>
        [CLSCompliant(false)]
        public static bool IsEven(this ushort number)
        {
            return ((ulong)number).IsEven();
        }

        /// <summary>
        /// Determines if the <see cref="short"/> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is odd, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsOdd(this short number)
        {
            return !number.IsEven();
        }

        /// <summary>
        /// Determines if the <see cref="ushort"/> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is odd, <see langword="false"/>
        /// otherwise.</returns>
        [CLSCompliant(false)]
        public static bool IsOdd(this ushort number)
        {
            return !number.IsEven();
        }

        /// <summary>
        /// Determines if the <see cref="short"/> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is prime, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsPrime(this short number)
        {
            return ((long)number).IsPrime();
        }

        /// <summary>
        /// Determines if the <see cref="short"/> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is prime, <see langword="false"/>
        /// otherwise.</returns>
        [CLSCompliant(false)]
        public static bool IsPrime(this ushort number)
        {
            return ((ulong)number).IsPrime();
        }

        /// <summary>
        /// Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> is 0,
        /// <see langword="true"/> otherwise.</returns>
        public static bool ToBoolean(this short value)
        {
            return ((long)value).ToBoolean();
        }

        /// <summary>
        /// Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> is 0,
        /// <see langword="true"/> otherwise.</returns>
        [CLSCompliant(false)]
        public static bool ToBoolean(this ushort value)
        {
            return ((ulong)value).ToBoolean();
        }
    }
}
