using System;
using X10D.Int64Extensions;

namespace X10D.Int32Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="int" />.
    /// </summary>
    public static class Int32Extensions
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
        public static DateTimeOffset FromUnixTimeMilliseconds(this int value)
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
        public static DateTimeOffset FromUnixTimeSeconds(this int value)
        {
            return DateTimeOffset.FromUnixTimeSeconds(value);
        }

        /// <summary>
        ///     Returns the current 32-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] GetBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Returns a value indicating whether the current value is evenly divisible by 2.
        /// </summary>
        /// <param name="value">The value whose parity to check.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this int value)
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
        public static bool IsOdd(this int value)
        {
            return !value.IsEven();
        }

        /// <summary>
        ///     Returns a value indicating whether the current 32-bit signed integer is prime.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is prime, or <see langword="false" /> otherwise.</returns>
        public static bool IsPrime(this int value)
        {
            return ((long)value).IsPrime();
        }

        /// <summary>
        ///     Converts the value of the current 32-bit signed integer to an equivalent <see cref="bool" /> value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is not zero, or <see langword="false" /> otherwise.</returns>
        public static bool ToBoolean(this int value)
        {
            return value != 0;
        }
    }
}
