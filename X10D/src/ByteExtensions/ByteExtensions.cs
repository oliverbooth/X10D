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
        ///     <see langword="true" /> if <paramref name="value" /> is prime, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsPrime(this byte value)
        {
            return ((int)value).IsPrime();
        }

        /// <summary>
        ///     Converts the value of the current 8-bit unsigned integer to an equivalent Boolean value.
        /// </summary>
        /// <param name="value">The 8-bit unsigned integer to convert.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is not zero, or <see langword="false" /> otherwise.
        /// </returns>
        /// <seealso cref="BooleanExtensions.BooleanExtensions.ToByte(bool)" />
        /// <example>
        /// The following example converts an array of <see cref="byte" /> values to <see cref="bool" /> values.
        /// 
        /// <code lang="csharp">
        /// byte[] bytes = { byte.MinValue, 100, 200, byte.MaxValue };
        /// bool result;
        ///
        /// foreach (byte value in bytes)
        /// {
        ///     result = value.ToBoolean();
        ///     Console.WriteLine("{0, -5}  -->  {1}", value, result);
        /// }
        ///
        /// // The example displays the following output:
        /// //       0      -->  False
        /// //       100    -->  True
        /// //       200    -->  True
        /// //       255    -->  True
        /// </code>
        /// </example>
        public static bool ToBoolean(this byte value)
        {
            return value != 0;
        }
    }
}
