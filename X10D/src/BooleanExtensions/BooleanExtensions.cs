using System;

namespace X10D.BooleanExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="bool" />.
    /// </summary>
    public static partial class BooleanExtensions
    {
        /// <summary>
        ///     Returns the current Boolean value as a byte array.
        /// </summary>
        /// <param name="value">The Boolean value.</param>
        /// <returns>A byte array with length 1.</returns>
        public static byte[] GetBytes(this bool value)
        {
            return BitConverter.GetBytes(value);
        }
        
        /// <summary>
        ///     Converts the current Boolean value to the equivalent 8-bit unsigned integer. 
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="byte" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag, falseFlag.ToByte());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag, trueFlag.ToByte());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static byte ToByte(this bool value)
        {
            return value ? 1 : 0;
        }
        
        /// <summary>
        ///     Converts the current Boolean value to the equivalent decimal number.
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="decimal" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag, falseFlag.ToDecimal());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag, trueFlag.ToDecimal());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static decimal ToDecimal(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Converts the current Boolean value to the equivalent double-precision floating-point number.
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="double" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag, falseFlag.ToDouble());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag, trueFlag.ToDouble());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static long ToDouble(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Converts the current Boolean value to the equivalent 16-bit signed integer. 
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="short" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag,
        ///                   falseFlag.ToInt16());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag,
        ///                   trueFlag.ToInt16());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static short ToInt16(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Converts the current Boolean value to the equivalent 32-bit signed integer. 
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="int" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag,
        ///                   falseFlag.ToInt32());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag,
        ///                   trueFlag.ToInt32());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static int ToInt32(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Converts the current Boolean value to the equivalent 64-bit signed integer. 
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="long" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag,
        ///                   falseFlag.ToInt64());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag,
        ///                   trueFlag.ToInt64());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static long ToInt64(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Converts the current Boolean value to the equivalent single-precision floating-point number.
        /// </summary>
        /// <param name="value">The Boolean value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="false" />
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        /// <example>
        /// The following example illustrates the conversion of <see cref="bool" /> to <see cref="float" /> values.
        /// <code lang="csharp">
        /// bool falseFlag = false;
        /// bool trueFlag = true;
        ///
        /// Console.WriteLine("{0} converts to {1}.", falseFlag,
        ///                   falseFlag.ToSingle());
        /// Console.WriteLine("{0} converts to {1}.", trueFlag,
        ///                   trueFlag.ToSingle());
        /// // The example displays the following output:
        /// //       False converts to 0.
        /// //       True converts to 1.
        /// </code>
        /// </example>
        public static float ToSingle(this bool value)
        {
            return value.ToByte();
        }
    }
}
