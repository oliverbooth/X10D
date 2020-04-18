namespace X10D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extension methods for <see cref="byte"/>.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Gets a <see cref="string"/> literally representing the raw values in the <see cref="byte"/>[].
        /// </summary>
        /// <param name="bytes">The bytes to get.</param>
        /// <returns>Returns a <see cref="string"/>.</returns>
        public static string AsString(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToString(bytes.ToArray());
        }

        /// <summary>
        /// Converts the <see cref="byte"/>[] to an <see cref="short"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="short"/>.</returns>
        public static short GetInt16(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToInt16(bytes.ToArray(), 0);
        }

        /// <summary>
        /// Converts the <see cref="byte"/>[] to an <see cref="int"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="int"/>.</returns>
        public static int GetInt32(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToInt32(bytes.ToArray(), 0);
        }

        /// <summary>
        /// Converts the <see cref="byte"/>[] to an <see cref="long"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="long"/>.</returns>
        public static long GetInt64(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToInt64(bytes.ToArray(), 0);
        }

        /// <summary>
        /// Converts the <see cref="byte"/>[] to a <see cref="ushort"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="ushort"/>.</returns>
        public static ushort GetUInt16(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToUInt16(bytes.ToArray(), 0);
        }

        /// <summary>
        /// Converts the <see cref="byte"/>[] to an <see cref="uint"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="uint"/>.</returns>
        public static uint GetUInt32(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToUInt32(bytes.ToArray(), 0);
        }

        /// <summary>
        /// Converts the <see cref="byte"/>[] to an <see cref="ulong"/>.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns an <see cref="ulong"/>.</returns>
        public static ulong GetUInt64(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToUInt64(bytes.ToArray(), 0);
        }

        /// <summary>
        /// Gets a <see cref="string"/> representing the value the <see cref="byte"/>[] with
        /// <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>Returns a <see cref="string"/>.</returns>
        public static string GetString(this IEnumerable<byte> bytes)
        {
            return bytes.GetString(Encoding.UTF8);
        }

        /// <summary>
        /// Gets a <see cref="string"/> representing the value the <see cref="byte"/>[] with the provided encoding.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>Returns a <see cref="string"/>.</returns>
        public static string GetString(this IEnumerable<byte> bytes, Encoding encoding)
        {
            IEnumerable<byte> enumerable = bytes as byte[] ?? bytes.ToArray();
            return encoding.GetString(enumerable.ToArray(), 0, enumerable.Count());
        }
    }
}
