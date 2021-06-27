using System;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="sbyte" />.
    /// </summary>
    [CLSCompliant(false)]
    public static class SByteExtensions
    {
        /// <summary>
        ///     Returns a value indicating whether the current value is evenly divisible by 2.
        /// </summary>
        /// <param name="value">The value whose parity to check.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsEven(this sbyte value)
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
        public static bool IsOdd(this sbyte value)
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
        public static bool IsPrime(this sbyte value)
        {
            return value switch
            {
                2 => true,
                3 => true,
                5 => true,
                7 => true,
                11 => true,
                13 => true,
                17 => true,
                19 => true,
                23 => true,
                29 => true,
                31 => true,
                37 => true,
                41 => true,
                43 => true,
                47 => true,
                53 => true,
                59 => true,
                61 => true,
                67 => true,
                71 => true,
                73 => true,
                79 => true,
                83 => true,
                89 => true,
                97 => true,
                101 => true,
                103 => true,
                107 => true,
                109 => true,
                113 => true,
                127 => true,
                _ => false
            };
        }

        /// <summary>
        ///     Converts the value of the current 8-bit signed integer to an equivalent Boolean value.
        /// </summary>
        /// <param name="value">The 8-bit signed integer to convert.</param>
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
        public static bool ToBoolean(this sbyte value)
        {
            return value != 0;
        }
    }
}
