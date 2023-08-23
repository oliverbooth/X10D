using System.Buffers.Binary;
using System.Diagnostics.Contracts;
#if !NET5_0_OR_GREATER
using System.Runtime.InteropServices;
#endif

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Converts the current single-precision floating-point number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this float value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current single-precision floating-point number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this float value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteLittleEndian(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current single-precision floating-point number into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndian(this float value, Span<byte> destination)
    {
#if NET5_0_OR_GREATER
        return BinaryPrimitives.TryWriteSingleBigEndian(destination, value);
#else
        if (BitConverter.IsLittleEndian)
        {
            return MemoryMarshal.TryWrite(destination, ref value);
        }

        int tmp = BinaryPrimitives.ReverseEndianness(BitConverter.SingleToInt32Bits(value));
        return MemoryMarshal.TryWrite(destination, ref tmp);
#endif
    }

    /// <summary>
    ///     Converts the current single-precision floating-point number into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndian(this float value, Span<byte> destination)
    {
#if NET5_0_OR_GREATER
        return BinaryPrimitives.TryWriteSingleLittleEndian(destination, value);
#else
        if (!BitConverter.IsLittleEndian)
        {
            return MemoryMarshal.TryWrite(destination, ref value);
        }

        int tmp = BinaryPrimitives.ReverseEndianness(BitConverter.SingleToInt32Bits(value));
        return MemoryMarshal.TryWrite(destination, ref tmp);
#endif
    }
}
