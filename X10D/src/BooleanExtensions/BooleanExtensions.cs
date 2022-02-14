namespace X10D
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
        /// <example>
        ///     The following example converts the bit patterns of <see cref="bool" /> values to <see cref="byte" /> arrays.
        ///     <code lang="csharp">
        /// bool[] values = { true, false };
        /// 
        /// Console.WriteLine("{0,10}{1,16}\n", "Boolean", "Bytes");
        /// foreach (var value in values)
        /// {
        ///     byte[] bytes = value.GetBytes();
        ///     Console.WriteLine("{0,10}{1,16}", value, bytes.AsString());
        /// }
        /// 
        /// // The example displays the following output:
        /// //        Boolean           Bytes
        /// //
        /// //           True              01
        /// //          False              00
        /// </code>
        /// </example>
        public static byte[] GetBytes(this bool value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}
