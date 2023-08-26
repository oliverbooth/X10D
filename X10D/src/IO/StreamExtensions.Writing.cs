using System.Buffers.Binary;

namespace X10D.IO;

public static partial class StreamExtensions
{
    /// <summary>
    ///     Writes a <see cref="short" /> to the current stream as big endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="short" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteBigEndian(this Stream stream, short value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="int" /> to the current stream as big endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="int" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteBigEndian(this Stream stream, int value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="long" /> to the current stream as big endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="long" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteBigEndian(this Stream stream, long value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="ushort" /> to the current stream as big endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="ushort" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    [CLSCompliant(false)]
    public static int WriteBigEndian(this Stream stream, ushort value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="uint" /> to the current stream as big endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="uint" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    [CLSCompliant(false)]
    public static int WriteBigEndian(this Stream stream, uint value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="ulong" /> to the current stream as big endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="ulong" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    [CLSCompliant(false)]
    public static int WriteBigEndian(this Stream stream, ulong value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="float" /> to the current stream as little endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="float" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteBigEndian(this Stream stream, float value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="double" /> to the current stream as little endian, and advances the stream position by eight
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="double" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteBigEndian(this Stream stream, double value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="decimal" /> to the current stream as little endian, and advances the stream position by sixteen
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="decimal" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteBigEndian(this Stream stream, decimal value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[16];
        value.TryWriteBigEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="short" /> to the current stream as little endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="short" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteLittleEndian(this Stream stream, short value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteLittleEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes an <see cref="int" /> to the current stream as little endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="int" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteLittleEndian(this Stream stream, int value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteLittleEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="long" /> to the current stream as little endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="long" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteLittleEndian(this Stream stream, long value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteLittleEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="float" /> to the current stream as little endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="float" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteLittleEndian(this Stream stream, float value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteLittleEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="double" /> to the current stream as little endian, and advances the stream position by eight
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="double" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteLittleEndian(this Stream stream, double value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteLittleEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="decimal" /> to the current stream as little endian, and advances the stream position by sixteen
    ///     bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The <see cref="decimal" /> to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    public static int WriteLittleEndian(this Stream stream, decimal value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[16];
        value.TryWriteLittleEndian(buffer);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="ushort" /> to the current stream as little endian, and advances the stream position by two bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The two-byte signed integer to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    [CLSCompliant(false)]
    public static int WriteLittleEndian(this Stream stream, ushort value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[2];
        BinaryPrimitives.WriteUInt16LittleEndian(buffer, value);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="uint" /> to the current stream as little endian, and advances the stream position by four bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The two-byte signed integer to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    [CLSCompliant(false)]
    public static int WriteLittleEndian(this Stream stream, uint value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[4];
        BinaryPrimitives.WriteUInt32LittleEndian(buffer, value);
        return stream.WriteInternal(buffer);
    }

    /// <summary>
    ///     Writes a <see cref="ulong" /> to the current stream as little endian, and advances the stream position by eight bytes.
    /// </summary>
    /// <param name="stream">The stream to which the value should be written.</param>
    /// <param name="value">The two-byte signed integer to write.</param>
    /// <returns>The number of bytes written to the stream.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="stream" /> does not support writing.</exception>
    [CLSCompliant(false)]
    public static int WriteLittleEndian(this Stream stream, ulong value)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new ArgumentException(ExceptionMessages.StreamDoesNotSupportWriting);
        }

        Span<byte> buffer = stackalloc byte[8];
        BinaryPrimitives.WriteUInt64LittleEndian(buffer, value);
        return stream.WriteInternal(buffer);
    }

    private static int WriteInternal(this Stream stream, ReadOnlySpan<byte> value)
    {
        long preWritePosition = stream.Position;
        stream.Write(value);
        return (int)(stream.Position - preWritePosition);
    }
}
