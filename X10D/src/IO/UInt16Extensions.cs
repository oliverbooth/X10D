using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="ushort" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt16Extensions
{
    /// <summary>
    ///     Converts the current 16-bit unsigned integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="ushort" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this ushort value)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBigEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 16-bit unsigned integer into an array of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="ushort" /> value.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this ushort value)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteLittleEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Writes the current 16-bit unsigned integer into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="ushort" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndianBytes(this ushort value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteUInt16BigEndian(destination, value);
    }

    /// <summary>
    ///     Writes the current 16-bit unsigned integer into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="ushort" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndianBytes(this ushort value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteUInt16LittleEndian(destination, value);
    }
}
