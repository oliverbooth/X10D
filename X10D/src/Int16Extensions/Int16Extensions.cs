using System;
using System.Net;

namespace X10D
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
        ///     Returns a value indicating whether the current value is not evenly divisible by 2.
        /// </summary>
        /// <param name="value">The value whose parity to check.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is not evenly divisible by 2, or <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this short value)
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
        ///     Linearly interpolates to the current value from a specified source using a specified alpha.
        /// </summary>
        /// <param name="target">The interpolation target.</param>
        /// <param name="value">The interpolation source.</param>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static double LerpFrom(this short target, double value, double alpha)
        {
            return MathUtils.Lerp(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates to the current value from a specified source using a specified alpha.
        /// </summary>
        /// <param name="target">The interpolation target.</param>
        /// <param name="value">The interpolation source.</param>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static float LerpFrom(this short target, float value, float alpha)
        {
            return MathUtils.Lerp(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates from the current value to a specified target using a specified alpha.
        /// </summary>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static double LerpTo(this short value, double target, double alpha)
        {
            return MathUtils.Lerp(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates from the current value to a specified target using a specified alpha.
        /// </summary>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static float LerpTo(this short value, float target, float alpha)
        {
            return MathUtils.Lerp(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates to a specified target from a specified source, using the current value as the alpha value.
        /// </summary>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static double LerpWith(this short alpha, double value, double target)
        {
            return MathUtils.Lerp(value, target, alpha);
        }

        /// <summary>
        ///     Linearly interpolates to a specified target from a specified source, using the current value as the alpha value.
        /// </summary>
        /// <param name="alpha">The interpolation alpha.</param>
        /// <param name="value">The interpolation source.</param>
        /// <param name="target">The interpolation target.</param>
        /// <returns>
        ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
        /// </returns>
        public static float LerpWith(this short alpha, float value, float target)
        {
            return MathUtils.Lerp(value, target, alpha);
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

        /// <summary>
        ///     Converts an integer value from network byte order to host byte order.
        /// </summary>
        /// <param name="value">The value to convert, expressed in network byte order.</param>
        /// <returns>An integer value, expressed in host byte order.</returns>
        public static short ToHostOrder(this short value)
        {
            return IPAddress.NetworkToHostOrder(value);
        }

        /// <summary>
        ///     Converts an integer value from host byte order to network byte order.
        /// </summary>
        /// <param name="value">The value to convert, expressed in host byte order.</param>
        /// <returns>An integer value, expressed in network byte order.</returns>
        public static short ToNetworkOrder(this short value)
        {
            return IPAddress.HostToNetworkOrder(value);
        }
    }
}
