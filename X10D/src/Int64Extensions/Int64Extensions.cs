using System;

namespace X10D.Int64Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="long" />.
    /// </summary>
    public static class Int64Extensions
    {
        /// <summary>
        ///     Converts a Unix time expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z to a
        ///     <see cref="DateTimeOffset" /> value.
        /// </summary>
        /// <param name="value">
        ///     A Unix time, expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z (January 1,
        ///     1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
        /// </param>
        /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
        public static DateTimeOffset FromUnixTimeMilliseconds(this long value)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(value);
        }
        
        /// <summary>
        ///     Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a
        ///     <see cref="DateTimeOffset" /> value.
        /// </summary>
        /// <param name="value">
        ///     A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at
        ///     12:00 AM UTC). For Unix times before this date, its value is negative.
        /// </param>
        /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
        public static DateTimeOffset FromUnixTimeSeconds(this long value)
        {
            return DateTimeOffset.FromUnixTimeSeconds(value);
        }
        
        /// <summary>
        ///     Returns the current 64-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] GetBytes(this long value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Returns a value indicating whether the current 64-bit signed integer is even.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is even, or <see langword="false" /> otherwise.</returns>
        public static bool IsEven(this long value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        ///     Returns a value indicating whether the current 64-bit signed integer is odd.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is odd, or <see langword="false" /> otherwise.</returns>
        public static bool IsOdd(this long value)
        {
            return !value.IsEven();
        }

        /// <summary>
        ///     Returns a value indicating whether the current 64-bit signed integer is prime.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is prime, or <see langword="false" /> otherwise.</returns>
        public static bool IsPrime(this long value)
        {
            switch (value)
            {
                case < 2: return false;
                case 2:
                case 3: return true;
            }

            if (value % 2 == 0 || value % 3 == 0)
            {
                return false;
            }

            if ((value + 1) % 6 != 0 && (value - 1) % 6 != 0)
            {
                return false;
            }

            for (var iterator = 5L; iterator * iterator <= value; iterator += 6)
            {
                if (value % iterator == 0 || value % (iterator + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Converts the value of the current 64-bit signed integer to an equivalent <see cref="bool" /> value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is not zero, or <see langword="false" /> otherwise.</returns>
        public static bool ToBoolean(this long value)
        {
            return value != 0;
        }
    }
}
