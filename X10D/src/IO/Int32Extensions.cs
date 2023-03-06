using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Returns the current 32-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetBytes(this int value)
    {
        byte[] buffer = new byte[4];
        value.TryWriteBytes(buffer);
        return buffer;
    }

    /// <summary>
    ///     Returns the current 32-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetBytes(this int value, Endianness endianness)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBytes(buffer, endianness);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 32-bit signed integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="int" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this int value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }

    /// <summary>
    ///     Converts the current 32-bit signed integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="int" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this int value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteInt32BigEndian(destination, value)
            : BinaryPrimitives.TryWriteInt32LittleEndian(destination, value);
    }
}
