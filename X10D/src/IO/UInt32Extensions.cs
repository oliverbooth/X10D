using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="uint" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt32Extensions
{
    /// <summary>
    ///     Converts the current 32-bit unsigned integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="uint" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this uint value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 32-bit unsigned integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="uint" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this uint value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteLittleEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Writes the current 32-bit unsigned integer into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="uint" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndian(this uint value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteUInt32BigEndian(destination, value);
    }

    /// <summary>
    ///     Writes the current 32-bit unsigned integer into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="uint" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndian(this uint value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteUInt32LittleEndian(destination, value);
    }
}
