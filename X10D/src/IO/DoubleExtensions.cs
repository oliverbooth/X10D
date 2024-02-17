using System.Buffers.Binary;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="double" />.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    ///     Converts the current double-precision floating-point number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this double value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteBigEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current double-precision floating-point number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this double value)
    {
        Span<byte> buffer = stackalloc byte[8];
        value.TryWriteLittleEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current double-precision floating-point number into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndianBytes(this double value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteDoubleBigEndian(destination, value);
    }

    /// <summary>
    ///     Converts the current double-precision floating-point number into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndianBytes(this double value, Span<byte> destination)
    {
        return BinaryPrimitives.TryWriteDoubleLittleEndian(destination, value);
    }
}
