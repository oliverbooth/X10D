using System;
using X10D.Int64Extensions;

namespace X10D.Int16Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="short" />.
    /// </summary>
    public static class Int16Extensions
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
        public static DateTimeOffset FromUnixTimeMilliseconds(this short value)
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
        public static DateTimeOffset FromUnixTimeSeconds(this short value)
        {
            return DateTimeOffset.FromUnixTimeSeconds(value);
        }
        
        /// <summary>
        ///     Returns the current 16-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(this short value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        ///     Returns a value indicating whether the current 16-bit signed integer is even.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is even, or <see langword="false" /> otherwise.</returns>
        public static bool IsEven(this short value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        ///     Returns a value indicating whether the current 16-bit signed integer is odd.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is odd, or <see langword="false" /> otherwise.</returns>
        public static bool IsOdd(this short value)
        {
            return !value.IsEven();
        }

        /// <summary>
        ///     Returns a value indicating whether the current 16-bit signed integer is prime.
        /// </summary>
        /// <param name="value">The number to check.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is prime, or <see langword="false" /> otherwise.</returns>
        public static bool IsPrime(this short value)
        {
            return ((long)value).IsPrime();
        }

        /// <summary>
        ///     Converts the value of the current 16-bit signed integer to an equivalent <see cref="bool" /> value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns><see langword="true" /> if <paramref name="value" /> is not zero, or <see langword="false" /> otherwise.</returns>
        public static bool ToBoolean(this short value)
        {
            return value != 0;
        }
    }
}
