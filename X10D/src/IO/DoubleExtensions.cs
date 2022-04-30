using System.Buffers.Binary;
using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="double" />.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    ///     Returns the current double-precision floating-point value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBytes(this double value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Returns the current double-precision floating-point value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 8.</returns>
    [Pure]
    public static byte[] GetBytes(this double value, Endianness endianness)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBytes(buffer, endianness);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current double-precision floating-point into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="double" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="double" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this double value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }

    /// <summary>
    ///     Converts the current double-precision floating-point into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="double" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="double" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this double value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteDoubleBigEndian(destination, value)
            : BinaryPrimitives.TryWriteDoubleLittleEndian(destination, value);
    }
}
