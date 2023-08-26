using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
    /// <summary>
    ///     Converts the current 64-bit signed integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="long" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this long value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBigEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 64-bit signed integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="long" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this long value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteLittleEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Writes the current 64-bit signed integer into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="long" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndian(this long value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteInt64BigEndian(destination, value);
    }

    /// <summary>
    ///     Writes the current 64-bit signed integer into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="long" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndian(this long value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteInt64LittleEndian(destination, value);
    }
}
