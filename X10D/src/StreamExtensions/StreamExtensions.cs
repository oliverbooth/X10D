using System;
using System.IO;
using System.Security.Cryptography;

namespace X10D.StreamExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="Stream" />.
    /// </summary>
    public static class StreamExtensions
    {
        private static readonly Endianness DefaultEndianness =
            BitConverter.IsLittleEndian ? Endianness.LittleEndian : Endianness.BigEndian;

        /// <summary>
        ///     Returns the hash of a stream using the specified hash algorithm.
        /// </summary>
        /// <typeparam name="T">A <see cref="HashAlgorithm" /> derived type.</typeparam>
        /// <param name="stream">The stream whose hash is to be computed.</param>
        /// <returns>A <see cref="byte" /> array representing the hash of the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">
        ///     <typeparamref name="T" /> does not offer a static <c>Create</c> method.
        ///     -or-
        ///     An invocation to the static <c>Create</c> method defined in <typeparamref name="T" /> returned
        ///     <see langword="null" />.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
        /// <remarks>This method consumes the stream from its current position!.</remarks>
        public static byte[] GetHash<T>(this Stream stream)
            where T : HashAlgorithm
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var type = typeof(T);
            var create = type.GetMethod("Create", Array.Empty<Type>());
            if (create is null)
            {
                throw new TypeInitializationException(type.FullName,
                    new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod));
            }

            using var crypt = create.Invoke(null, null) as T;
            if (crypt is null)
            {
                throw new TypeInitializationException(type.FullName,
                    new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull));
            }

            return crypt.ComputeHash(stream);
        }

        /// <summary>
        ///     Reads a two-byte signed integer from the current stream using the system's default endian encoding, and advances
        ///     the stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>An two-byte signed integer read from the stream.</returns>
        public static short ReadInt16(this Stream stream)
        {
            return stream.ReadInt16(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a two-byte signed integer from the current stream using the specified endian encoding, and advances the
        ///     stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>An two-byte unsigned integer read from the stream.</returns>
        public static short ReadInt16(this Stream stream, Endianness endianness)
        {
            var value = ReadInternal<short>(stream, endianness);
            return BitConverter.ToInt16(value, 0);
        }

        /// <summary>
        ///     Reads a four-byte signed integer from the current stream using the system's default endian encoding, and advances
        ///     the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>An four-byte signed integer read from the stream.</returns>
        public static int ReadInt32(this Stream stream)
        {
            return stream.ReadInt32(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a four-byte signed integer from the current stream using the specified endian encoding, and advances the
        ///     stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>An four-byte unsigned integer read from the stream.</returns>
        public static int ReadInt32(this Stream stream, Endianness endianness)
        {
            var value = ReadInternal<int>(stream, endianness);
            return BitConverter.ToInt32(value, 0);
        }

        /// <summary>
        ///     Reads an eight-byte signed integer from the current stream using the system's default endian encoding, and
        ///     advances the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>An eight-byte signed integer read from the stream.</returns>
        public static long ReadInt64(this Stream stream)
        {
            return stream.ReadInt64(DefaultEndianness);
        }

        /// <summary>
        ///     Reads an eight-byte signed integer from the current stream using the specified endian encoding, and advances the
        ///     stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>An eight-byte unsigned integer read from the stream.</returns>
        public static long ReadInt64(this Stream stream, Endianness endianness)
        {
            var value = ReadInternal<long>(stream, endianness);
            return BitConverter.ToInt64(value, 0);
        }

        /// <summary>
        ///     Reads a two-byte unsigned integer from the current stream using the system's default endian encoding, and advances
        ///     the stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>An two-byte unsigned integer read from the stream.</returns>
        [CLSCompliant(false)]
        public static ushort ReadUInt16(this Stream stream)
        {
            return stream.ReadUInt16(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a two-byte unsigned integer from the current stream using the specified endian encoding, and advances the
        ///     stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>An two-byte unsigned integer read from the stream.</returns>
        [CLSCompliant(false)]
        public static ushort ReadUInt16(this Stream stream, Endianness endianness)
        {
            var value = ReadInternal<ushort>(stream, endianness);
            return BitConverter.ToUInt16(value, 0);
        }

        /// <summary>
        ///     Reads a four-byte unsigned integer from the current stream using the system's default endian encoding, and
        ///     advances the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>An four-byte unsigned integer read from the stream.</returns>
        [CLSCompliant(false)]
        public static uint ReadUInt32(this Stream stream)
        {
            return stream.ReadUInt32(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a four-byte unsigned integer from the current stream using the specified endian encoding, and advances the
        ///     stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>An four-byte unsigned integer read from the stream.</returns>
        [CLSCompliant(false)]
        public static uint ReadUInt32(this Stream stream, Endianness endianness)
        {
            var value = ReadInternal<uint>(stream, endianness);
            return BitConverter.ToUInt32(value, 0);
        }

        /// <summary>
        ///     Reads an eight-byte unsigned integer from the current stream using the system's default endian encoding, and
        ///     advances the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>An eight-byte unsigned integer read from the stream.</returns>
        [CLSCompliant(false)]
        public static ulong ReadUInt64(this Stream stream)
        {
            return stream.ReadUInt64(DefaultEndianness);
        }

        /// <summary>
        ///     Reads an eight-byte unsigned integer from the current stream using the specified endian encoding, and advances the
        ///     stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>An eight-byte unsigned integer read from the stream.</returns>
        [CLSCompliant(false)]
        public static ulong ReadUInt64(this Stream stream, Endianness endianness)
        {
            var value = ReadInternal<ulong>(stream, endianness);
            return BitConverter.ToUInt64(value, 0);
        }

        /// <summary>
        ///     Writes a two-byte signed integer to the current stream using the system's default endian encoding, and advances
        ///     the stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The two-byte signed integer to write.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, short value)
        {
            return stream.Write(value, DefaultEndianness);
        }

        /// <summary>
        ///     Writes a two-byte signed integer to the current stream using the specified endian encoding, and advances the
        ///     stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The two-byte signed integer to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, short value, Endianness endianness)
        {
            var buffer = BitConverter.GetBytes(value);
            return stream.WriteInternal(buffer, endianness);
        }

        /// <summary>
        ///     Writes a four-byte signed integer to the current stream using the system's default endian encoding, and advances
        ///     the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The four-byte signed integer to write.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, int value)
        {
            return stream.Write(value, DefaultEndianness);
        }

        /// <summary>
        ///     Writes a four-byte signed integer to the current stream using the specified endian encoding, and advances the
        ///     stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The four-byte signed integer to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, int value, Endianness endianness)
        {
            var buffer = BitConverter.GetBytes(value);
            return stream.WriteInternal(buffer, endianness);
        }

        /// <summary>
        ///     Writes an eight-byte signed integer to the current stream using the system's default endian encoding, and advances
        ///     the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The eight-byte signed integer to write.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, long value)
        {
            return stream.Write(value, DefaultEndianness);
        }

        /// <summary>
        ///     Writes an eight-byte signed integer to the current stream using the specified endian encoding, and advances the
        ///     stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The eight-byte signed integer to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, long value, Endianness endianness)
        {
            var buffer = BitConverter.GetBytes(value);
            return stream.WriteInternal(buffer, endianness);
        }

        /// <summary>
        ///     Writes a two-byte unsigned integer to the current stream using the system's default endian encoding, and advances
        ///     the stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The two-byte unsigned integer to write.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        [CLSCompliant(false)]
        public static int Write(this Stream stream, ushort value)
        {
            return stream.Write(value, DefaultEndianness);
        }

        /// <summary>
        ///     Writes a two-byte unsigned integer to the current stream using the specified endian encoding, and advances the
        ///     stream position by two bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The two-byte unsigned integer to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        [CLSCompliant(false)]
        public static int Write(this Stream stream, ushort value, Endianness endianness)
        {
            var buffer = BitConverter.GetBytes(value);
            return stream.WriteInternal(buffer, endianness);
        }

        /// <summary>
        ///     Writes a four-byte unsigned integer to the current stream using the system's default endian encoding, and advances
        ///     the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The four-byte unsigned integer to write.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        [CLSCompliant(false)]
        public static int Write(this Stream stream, uint value)
        {
            return stream.Write(value, DefaultEndianness);
        }

        /// <summary>
        ///     Writes a four-byte unsigned integer to the current stream using the specified endian encoding, and advances the
        ///     stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The four-byte unsigned integer to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        [CLSCompliant(false)]
        public static int Write(this Stream stream, uint value, Endianness endianness)
        {
            var buffer = BitConverter.GetBytes(value);
            return stream.WriteInternal(buffer, endianness);
        }

        /// <summary>
        ///     Writes an eight-byte unsigned integer to the current stream using the system's default endian encoding, and
        ///     advances the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The eight-byte unsigned integer to write.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        [CLSCompliant(false)]
        public static int Write(this Stream stream, ulong value)
        {
            return stream.Write(value, DefaultEndianness);
        }

        /// <summary>
        ///     Writes an eight-byte signed integer to the current stream using the specified endian encoding, and advances the
        ///     stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The eight-byte signed integer to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        [CLSCompliant(false)]
        public static int Write(this Stream stream, ulong value, Endianness endianness)
        {
            var buffer = BitConverter.GetBytes(value);
            return stream.WriteInternal(buffer, endianness);
        }

        private static unsafe byte[] ReadInternal<T>(this Stream stream, Endianness endianness)
            where T : unmanaged
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading, nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }

            var buffer = new byte[sizeof(T)];
            stream.Read(buffer, 0, buffer.Length);
            Util.SwapIfNeeded(ref buffer, endianness);
            return buffer;
        }

        private static int WriteInternal(this Stream stream, byte[] value, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!stream.CanWrite)
            {
                throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting, nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }

            byte[] clone = (byte[])value.Clone();
            Util.SwapIfNeeded(ref clone, endianness);
            var preWritePosition = stream.Position;
            stream.Write(clone, 0, clone.Length);
            return (int)(stream.Position - preWritePosition);
        }
    }
}
