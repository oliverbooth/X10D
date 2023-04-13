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
    ///     Returns the current 64-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBytes(this ulong value)
    {
        Span<byte> buffer = stackalloc byte[8];
        BitConverter.TryWriteBytes(buffer, value);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Returns the current 64-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBytes(this ulong value, Endianness endianness)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBytes(buffer, endianness);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 64-bit unsigned integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="ulong" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="ulong" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this ulong value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteUInt64BigEndian(destination, value)
            : BinaryPrimitives.TryWriteUInt64LittleEndian(destination, value);
    }
}
