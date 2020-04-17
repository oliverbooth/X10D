namespace X10D
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="Int64"/>.
    /// </summary>
    public static class Int64Extensions
    {
        // TODO change

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Days(this ulong number)
        {
            return TimeSpan.FromDays(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Hours(this ulong number)
        {
            return TimeSpan.FromHours(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Milliseconds(this ulong number)
        {
            return TimeSpan.FromSeconds(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Minutes(this ulong number)
        {
            return TimeSpan.FromMinutes(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Seconds(this ulong number)
        {
            return TimeSpan.FromSeconds(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Days(this long number)
        {
            return TimeSpan.FromDays(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Hours(this long number)
        {
            return TimeSpan.FromHours(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Milliseconds(this long number)
        {
            return TimeSpan.FromSeconds(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Minutes(this long number)
        {
            return TimeSpan.FromMinutes(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Seconds(this long number)
        {
            return TimeSpan.FromSeconds(number);
        }

        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static TimeSpan Ticks(this long number)
        {
            return TimeSpan.FromTicks(number);
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
        public static long Clamp(this long value, long min, long max)
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
        public static ulong Clamp(this ulong value, ulong min, ulong max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        /// Converts the <see cref="Int64"/> to a <see cref="DateTime"/> treating it as a Unix timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isMillis">Optional. Whether or not the input value should be treated as milliseconds. Defaults
        /// to <see langword="false"/>.</param>
        /// <returns>Returns a <see cref="DateTime"/> representing <paramref name="timestamp"/> seconds since the Unix
        /// epoch.</returns>
        public static DateTime FromUnixTimestamp(this long timestamp, bool isMillis = false)
        {
            DateTimeOffset offset = isMillis
                ? DateTimeOffset.FromUnixTimeMilliseconds(timestamp)
                : DateTimeOffset.FromUnixTimeSeconds(timestamp);

            return offset.DateTime;
        }

        /// <summary>
        /// Converts the <see cref="UInt64"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this ulong number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        /// Converts the <see cref="Int64"/> to a <see cref="Byte"/>[].
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this long number)
        {
            return BitConverter.GetBytes(number);
        }

        /// <summary>
        /// Determines if the <see cref="Int64"/> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is even, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsEven(this long number)
        {
            return Math.Abs(number % 2.0) < Double.Epsilon;
        }

        /// <summary>
        /// Determines if the <see cref="UInt64"/> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is even, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsEven(this ulong number)
        {
            return Math.Abs(number % 2.0) < Double.Epsilon;
        }

        /// <summary>
        /// Determines if the <see cref="Int64"/> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is odd, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsOdd(this long number)
        {
            return !IsEven(number);
        }

        /// <summary>
        /// Determines if the <see cref="UInt64"/> is odd.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is odd, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsOdd(this ulong number)
        {
            return !IsEven(number);
        }

        /// <summary>
        /// Determines if the <see cref="Int64"/> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is prime, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsPrime(this long number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            long boundary = (long) Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if the <see cref="UInt64"/> is a prime number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="number"/> is prime, <see langword="false"/>
        /// otherwise.</returns>
        public static bool IsPrime(this ulong number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            ulong boundary = (ulong) Math.Floor(Math.Sqrt(number));
            for (uint i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> is 0,
        /// <see langword="true"/> otherwise.</returns>
        public static bool ToBoolean(this long value)
        {
            return value != 0;
        }

        /// <summary>
        /// Gets an boolean value that represents this integer.
        /// </summary>
        /// <param name="value">The integer.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> is 0,
        /// <see langword="true"/> otherwise.</returns>
        public static bool ToBoolean(this ulong value)
        {
            return value != 0;
        }
    }
}
