using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Converts the current 16-bit signed integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this short value)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBigEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 16-bit signed integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this short value)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteLittleEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Writes the current 16-bit signed integer into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndianBytes(this short value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteInt16BigEndian(destination, value);
    }

    /// <summary>
    ///     Writes the current 16-bit signed integer into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndianBytes(this short value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteInt16LittleEndian(destination, value);
    }
}
