namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="byte" />.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        ///     Returns the current 8-bit unsigned integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 1.</returns>
        public static byte[] GetBytes(this byte value)
        {
            return new[] { value };
        }

        /// <summary>
        ///     Returns a value indicating whether the current value is evenly divisible by 2.
        /// </summary>
        /// <param name="value">The value whose parity to check.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this byte value)
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
        public static bool IsOdd(this byte value)
        {
            return !value.IsEven();
        }

        /// <summary>
        ///     Returns a value indicating whether the current value is a prime number.
        /// </summary>
        /// <param name="value">The value whose primality to check.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsPrime(this byte value)
        {
            return ((short)value).IsPrime();
        }
    }
}
