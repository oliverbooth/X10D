using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Returns the current 16-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 2.</returns>
    [Pure]
    public static byte[] GetBytes(this short value)
    {
        byte[] buffer = new byte[2];
        BitConverter.TryWriteBytes(buffer, value);
        return buffer;
    }

    /// <summary>
    ///     Returns the current 16-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 2.</returns>
    [Pure]
    public static byte[] GetBytes(this short value, Endianness endianness)
    {
        byte[] buffer = new byte[2];
        value.TryWriteBytes(buffer, endianness);
        return buffer;
    }

    /// <summary>
    ///     Converts the current 16-bit signed integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="short" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this short value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteInt16BigEndian(destination, value)
            : BinaryPrimitives.TryWriteInt16LittleEndian(destination, value);
    }
}
