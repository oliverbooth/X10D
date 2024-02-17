using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="ulong" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt64Extensions
{
    /// <summary>
    ///     Converts the current 64-bit unsigned integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="ulong" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this ulong value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBigEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 64-bit unsigned integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="ulong" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this ulong value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteLittleEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Writes the current 64-bit unsigned integer into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="ulong" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndianBytes(this ulong value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteUInt64BigEndian(destination, value);
    }

    /// <summary>
    ///     Writes the current 64-bit unsigned integer into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="ulong" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndianBytes(this ulong value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteUInt64LittleEndian(destination, value);
    }
}
