using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace X10D.IO;

public static partial class StreamExtensions
{
    /// <summary>
    ///     Reads an <see cref="decimal" /> from the current stream as big endian, and advances the stream position by sixteen
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static decimal ReadDecimalBigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        const int decimalSize = sizeof(decimal);
        const int int32Size = sizeof(int);
        const int partitionSize = decimalSize / int32Size;

        Span<int> buffer = stackalloc int[partitionSize];
        for (var index = 0; index < partitionSize; index++)
        {
            buffer[index] = stream.ReadInt32BigEndian();
        }

        if (BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }

#if NET5_0_OR_GREATER
        return new decimal(buffer);
#else
        return new decimal(buffer.ToArray());
#endif
    }

    /// <summary>
    ///     Reads an <see cref="decimal" /> from the current stream as big endian, and advances the stream position by sixteen
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static decimal ReadDecimalLittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        const int decimalSize = sizeof(decimal);
        const int int32Size = sizeof(int);
        const int partitionSize = decimalSize / int32Size;

        Span<int> buffer = stackalloc int[partitionSize];
        for (var index = 0; index < partitionSize; index++)
        {
            buffer[index] = stream.ReadInt32LittleEndian();
        }

        if (!BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }

#if NET5_0_OR_GREATER
        return new decimal(buffer);
#else
        return new decimal(buffer.ToArray());
#endif
    }

    /// <summary>
    ///     Reads an <see cref="double" /> from the current stream as big endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static double ReadDoubleBigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[8];
        _ = stream.Read(buffer);
#if NET5_0_OR_GREATER
        return BinaryPrimitives.ReadDoubleBigEndian(buffer);
#else
        if (BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }

        return MemoryMarshal.Read<double>(buffer);
#endif
    }

    /// <summary>
    ///     Reads an <see cref="double" /> from the current stream as little endian, and advances the stream position by eight
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static double ReadDoubleLittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[8];
        _ = stream.Read(buffer);
#if NET5_0_OR_GREATER
        return BinaryPrimitives.ReadDoubleLittleEndian(buffer);
#else
        if (!BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }

        return MemoryMarshal.Read<double>(buffer);
#endif
    }

    /// <summary>
    ///     Reads an <see cref="short" /> from the current stream as big endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static short ReadInt16BigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[2];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadInt16BigEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="short" /> from the current stream as little endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static short ReadInt16LittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[2];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadInt16LittleEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="int" /> from the current stream as big endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static int ReadInt32BigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[4];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadInt32BigEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="int" /> from the current stream as little endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static int ReadInt32LittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[4];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadInt32LittleEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="long" /> from the current stream as big endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static long ReadInt64BigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[8];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadInt64BigEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="long" /> from the current stream as little endian, and advances the stream position by eight
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    public static long ReadInt64LittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[8];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadInt64LittleEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="float" /> from the current stream as big endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static float ReadSingleBigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[4];
        _ = stream.Read(buffer);
#if NET5_0_OR_GREATER
        return BinaryPrimitives.ReadSingleBigEndian(buffer);
#else
        if (BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }

        return MemoryMarshal.Read<float>(buffer);
#endif
    }

    /// <summary>
    ///     Reads an <see cref="float" /> from the current stream as little endian, and advances the stream position by four
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static float ReadSingleLittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[4];
        _ = stream.Read(buffer);
#if NET5_0_OR_GREATER
        return BinaryPrimitives.ReadSingleLittleEndian(buffer);
#else
        if (!BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }

        return MemoryMarshal.Read<float>(buffer);
#endif
    }

    /// <summary>
    ///     Reads an <see cref="ushort" /> from the current stream as big endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static ushort ReadUInt16BigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[2];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadUInt16BigEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="ushort" /> from the current stream as little endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static ushort ReadUInt16LittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[2];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadUInt16LittleEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="uint" /> from the current stream as big endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static uint ReadUInt32BigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[4];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadUInt32BigEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="uint" /> from the current stream as little endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static uint ReadUInt32LittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[4];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadUInt32LittleEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="ulong" /> from the current stream as big endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The big endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static ulong ReadUInt64BigEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[8];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadUInt64BigEndian(buffer);
    }

    /// <summary>
    ///     Reads an <see cref="ulong" /> from the current stream as little endian, and advances the stream position by eight
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream from which the value should be read.</param>
    /// <returns>The little endian value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support reading.</exception>
    [CLSCompliant(false)]
    public static ulong ReadUInt64LittleEndian(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[8];
        _ = stream.Read(buffer);
        return BinaryPrimitives.ReadUInt64LittleEndian(buffer);
    }
}
