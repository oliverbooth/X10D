using System.Reflection;
using System.Security.Cryptography;
using System.Buffers.Binary;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="Stream" />.
    /// </summary>
    public static partial class StreamExtensions
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

            if (!stream.CanRead)
            {
                throw new IOException(ExceptionMessages.StreamDoesNotSupportReading);
            }

            Type type = typeof(T);
            MethodInfo? createMethod = type.GetMethod("Create", BindingFlags.Public | BindingFlags.Static);
            if (createMethod is null)
            {
                throw new TypeInitializationException(type.FullName,
                    new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod));
            }

            using var crypt = createMethod.Invoke(null, null) as T;
            if (crypt is null)
            {
                throw new TypeInitializationException(type.FullName,
                    new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull));
            }

            return crypt.ComputeHash(stream);
        }

        /// <summary>
        ///     Reads a decimal value from the current stream using the system's default endian encoding, and advances the stream
        ///     position by sixteen bytes.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <returns>A sixteen-byte decimal value read from the stream.</returns>
        public static decimal ReadDecimal(this Stream stream)
        {
            return stream.ReadDecimal(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a decimal value from the current stream using a specified endian encoding, and advances the stream position
        ///     by sixteen bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>A decimal value read from the stream.</returns>
        public static decimal ReadDecimal(this Stream stream, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }

            const int decimalSize = sizeof(decimal);
            const int int32Size = sizeof(int);
            const int partitionSize = decimalSize / int32Size;

            var bits = new int[partitionSize];
            for (var index = 0; index < partitionSize; index++)
            {
                bits[index] = stream.ReadInt32(endianness);
            }

            return new decimal(bits);
        }

        /// <summary>
        ///     Reads a double-precision floating point value from the current stream using the system's default endian encoding,
        ///     and advances the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>A double-precision floating point value read from the stream.</returns>
        public static double ReadDouble(this Stream stream)
        {
            return stream.ReadDouble(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a double-precision floating point value from the current stream using a specified endian encoding, and
        ///     advances the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>A double-precision floating point value read from the stream.</returns>
        public static double ReadDouble(this Stream stream, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadDoubleLittleEndian(buffer)
                : BinaryPrimitives.ReadDoubleBigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadInt16LittleEndian(buffer)
                : BinaryPrimitives.ReadInt16BigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadInt32LittleEndian(buffer)
                : BinaryPrimitives.ReadInt32BigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadInt64LittleEndian(buffer)
                : BinaryPrimitives.ReadInt64BigEndian(buffer);
        }

        /// <summary>
        ///     Reads a single-precision floating point value from the current stream using the system's default endian encoding,
        ///     and advances the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <returns>A single-precision floating point value read from the stream.</returns>
        public static double ReadSingle(this Stream stream)
        {
            return stream.ReadSingle(DefaultEndianness);
        }

        /// <summary>
        ///     Reads a double-precision floating point value from the current stream using a specified endian encoding, and
        ///     advances the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream from which the value should be read.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>A single-precision floating point value read from the stream.</returns>
        public static double ReadSingle(this Stream stream, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadSingleLittleEndian(buffer)
                : BinaryPrimitives.ReadSingleBigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadUInt16LittleEndian(buffer)
                : BinaryPrimitives.ReadUInt16BigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadUInt32LittleEndian(buffer)
                : BinaryPrimitives.ReadUInt32BigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];
            stream.Read(buffer);

            return endianness == Endianness.LittleEndian
                ? BinaryPrimitives.ReadUInt64LittleEndian(buffer)
                : BinaryPrimitives.ReadUInt64BigEndian(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(short)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteInt16LittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(int)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteInt32LittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(long)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteInt64LittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(ushort)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteUInt16LittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(uint)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(ulong)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
        }

        /// <summary>
        ///     Writes a single-precision floating point value to the current stream using the specified endian encoding, and
        ///     advances the stream position by four bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The single-precision floating point value to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, float value, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(float)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteSingleLittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteSingleBigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
        }

        /// <summary>
        ///     Writes a double-precision floating point value to the current stream using the specified endian encoding, and
        ///     advances the stream position by eight bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The double-precision floating point value to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, double value, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }


            Span<byte> buffer = stackalloc byte[sizeof(double)];

            if (endianness == Endianness.LittleEndian)
            {
                BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
            }
            else
            {
                BinaryPrimitives.WriteDoubleBigEndian(buffer, value);
            }

            return stream.WriteInternal(buffer);
        }

        /// <summary>
        ///     Writes a decimal value to the current stream using the specified endian encoding, and advances the stream position
        ///     by sixteen bytes.
        /// </summary>
        /// <param name="stream">The stream to which the value should be written.</param>
        /// <param name="value">The decimal value to write.</param>
        /// <param name="endianness">The endian encoding to use.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public static int Write(this Stream stream, decimal value, Endianness endianness)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!Enum.IsDefined(typeof(Endianness), endianness))
            {
                throw new ArgumentOutOfRangeException(nameof(endianness));
            }

            var bits = decimal.GetBits(value);
            var preWritePosition = stream.Position;

            foreach (var section in bits)
            {
                stream.Write(section, endianness);
            }

            return (int)(stream.Position - preWritePosition);
        }
    }
}
