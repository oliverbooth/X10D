using System.Buffers.Binary;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Returns the current single-precision floating-point value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 4.</returns>
    public static byte[] GetBytes(this float value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Returns the current single-precision floating-point value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 4.</returns>
    public static byte[] GetBytes(this float value, Endianness endianness)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBytes(buffer, endianness);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current single-precision floating-point into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="float" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this float value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }

    /// <summary>
    ///     Converts the current single-precision floating-point into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="float" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this float value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteSingleBigEndian(destination, value)
            : BinaryPrimitives.TryWriteSingleLittleEndian(destination, value);
    }
}
