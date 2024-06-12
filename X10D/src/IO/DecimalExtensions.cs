using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="decimal" />.
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    ///     Converts the current decimal number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 16.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this decimal value)
    {
        Span<byte> buffer = stackalloc byte[16];
        value.TryWriteBigEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current decimal number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 16.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this decimal value)
    {
        Span<byte> buffer = stackalloc byte[16];
        value.TryWriteLittleEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current decimal number into a span of bytes, as big endian.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as big endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBigEndianBytes(this decimal value, Span<byte> destination)
    {
        Span<int> buffer = stackalloc int[4];
        decimal.GetBits(value, buffer);

        Span<byte> result = stackalloc byte[16];
        MemoryMarshal.Cast<int, byte>(buffer).CopyTo(result);

        if (BitConverter.IsLittleEndian)
        {
            result.Reverse();
        }

        return result.TryCopyTo(destination);
    }

    /// <summary>
    ///     Converts the current decimal number into a span of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="float" /> value.</param>
    /// <param name="destination">The span of bytes where the value is to be written, as little endian.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteLittleEndianBytes(this decimal value, Span<byte> destination)
    {
        Span<int> buffer = stackalloc int[4];
        decimal.GetBits(value, buffer);

        Span<byte> result = stackalloc byte[16];
        MemoryMarshal.Cast<int, byte>(buffer).CopyTo(result);

        if (!BitConverter.IsLittleEndian)
        {
            result.Reverse();
        }

        return result.TryCopyTo(destination);
    }
}
