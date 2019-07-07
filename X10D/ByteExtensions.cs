namespace X10D
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Byte"/>.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Gets a <see cref="String"/> literally representing the raw values in the <see cref="Byte"/>[].
        /// </summary>
        /// <param name="bytes">The bytes to get.</param>
        /// <returns>Returns a <see cref="String"/>.</returns>
        public static string AsString(this IEnumerable<byte> bytes) =>
            BitConverter.ToString(bytes.ToArray());

        /// <summary>
        /// Converts the <see cref="Byte"/>[] to an <see cref="Int16"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="Int16"/>.</returns>
        public static short GetInt16(this IEnumerable<byte> bytes) =>
            BitConverter.ToInt16(bytes.ToArray(), 0);

        /// <summary>
        /// Converts the <see cref="Byte"/>[] to an <see cref="Int32"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="Int32"/>.</returns>
        public static int GetInt32(this IEnumerable<byte> bytes) =>
            BitConverter.ToInt32(bytes.ToArray(), 0);

        /// <summary>
        /// Converts the <see cref="Byte"/>[] to an <see cref="Int64"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="Int64"/>.</returns>
        public static long GetInt64(this IEnumerable<byte> bytes) =>
            BitConverter.ToInt64(bytes.ToArray(), 0);

        /// <summary>
        /// Converts the <see cref="Byte"/>[] to a <see cref="UInt16"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="UInt16"/>.</returns>
        public static ushort GetUInt16(this IEnumerable<byte> bytes) =>
            BitConverter.ToUInt16(bytes.ToArray(), 0);

        /// <summary>
        /// Converts the <see cref="Byte"/>[] to an <see cref="UInt32"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="UInt32"/>.</returns>
        public static uint GetUInt32(this IEnumerable<byte> bytes) =>
            BitConverter.ToUInt32(bytes.ToArray(), 0);

        /// <summary>
        /// Converts the <see cref="Byte"/>[] to an <see cref="UInt64"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="UInt64"/>.</returns>
        public static ulong GetUInt64(this IEnumerable<byte> bytes) =>
            BitConverter.ToUInt64(bytes.ToArray(), 0);

        /// <summary>
        /// Gets a <see cref="String"/> representing the value the <see cref="Byte"/>[] with
        /// <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns a <see cref="String"/>.</returns>
        public static string GetString(this IEnumerable<byte> bytes) =>
            bytes.GetString(Encoding.UTF8);

        /// <summary>
        /// Gets a <see cref="String"/> representing the value the <see cref="Byte"/>[] with the provided encoding.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>Returns a <see cref="String"/>.</returns>
        public static string GetString(this IEnumerable<byte> bytes, Encoding encoding)
        {
            IEnumerable<byte> enumerable = bytes as byte[] ?? bytes.ToArray();
            return encoding.GetString(enumerable.ToArray(), 0, enumerable.Count());
        }
    }
}
