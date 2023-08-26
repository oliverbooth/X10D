using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Converts the current 32-bit signed integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this int value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 32-bit signed integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this int value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteLittleEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Writes the current 32-bit signed integer into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndian(this int value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteInt32BigEndian(destination, value);
    }

    /// <summary>
    ///     Writes the current 32-bit signed integer into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndian(this int value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteInt32LittleEndian(destination, value);
    }
}
