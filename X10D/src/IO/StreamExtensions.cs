using System.Buffers.Binary;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="Stream" />.
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    ///     Returns the hash of the current stream as an array of bytes using the specified hash algorithm.
    /// </summary>
    /// <param name="stream">The stream whose hash is to be computed.</param>
    /// <typeparam name="T">
    ///     The type of the <see cref="HashAlgorithm" /> whose <see cref="HashAlgorithm.ComputeHash(Stream)" /> is to be used for
    ///     computing the hash.
    /// </typeparam>
    /// <returns>The hash of <paramref name="stream" /> represented as an array of bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="IOException"><paramref name="stream" /> does not support reading.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
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

        MethodInfo? createMethod = type.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .FirstOrDefault(c => c.Name == "Create" && c.GetParameters().Length == 0);
        if (createMethod is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod);
        }

        using var crypt = createMethod.Invoke(null, null) as T;
        if (crypt is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull);
        }

        return crypt.ComputeHash(stream);
    }

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

    /// <summary>
    ///     Returns the hash of the current stream as an array of bytes using the specified hash algorithm.
    /// </summary>
    /// <param name="stream">The stream whose hash is to be computed.</param>
    /// <param name="destination">When this method returns, contains the computed hash of <paramref name="stream" />.</param>
    /// <param name="bytesWritten">
    ///     When this method returns, the total number of bytes written into destination. This parameter is treated as
    ///     uninitialized.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the <see cref="HashAlgorithm" /> whose <see cref="HashAlgorithm.ComputeHash(Stream)" /> is to be used for
    ///     computing the hash.
    /// </typeparam>
    /// <returns>
    ///     <see langword="true" /> if the destination is long enough to receive the hash; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="IOException"><paramref name="stream" /> does not support reading.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
    public static bool TryWriteHash<T>(this Stream stream, Span<byte> destination, out int bytesWritten)
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

        MethodInfo? createMethod = type.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .FirstOrDefault(c => c.Name == "Create" && c.GetParameters().Length == 0);
        if (createMethod is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod);
        }

        using var crypt = createMethod.Invoke(null, null) as T;
        if (crypt is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull);
        }

        if (stream.Length > int.MaxValue)
        {
            throw new ArgumentException(ExceptionMessages.StreamTooLarge);
        }

        Span<byte> buffer = stackalloc byte[(int)stream.Length];
        _ = stream.Read(buffer); // we don't care about the number of bytes read. we can ignore MustUseReturnValue
        return crypt.TryComputeHash(buffer, destination, out bytesWritten);
    }

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
