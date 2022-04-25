using System.Buffers.Binary;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="ushort" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt16Extensions
{
    /// <summary>
    ///     Returns the current 16-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 2.</returns>
    public static byte[] GetBytes(this ushort value)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBytes(buffer);
        return buffer.ToArray();
    }
    
    /// <summary>
    ///     Returns the current 16-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 2.</returns>
    public static byte[] GetBytes(this ushort value, Endianness endianness)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBytes(buffer, endianness);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 16-bit unsigned integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="ushort" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="ushort" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this ushort value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }

    /// <summary>
    ///     Converts the current 16-bit unsigned integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="ushort" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="ushort" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this ushort value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteUInt16BigEndian(destination, value)
            : BinaryPrimitives.TryWriteUInt16LittleEndian(destination, value);
    }
}
