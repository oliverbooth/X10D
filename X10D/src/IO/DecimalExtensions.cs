using System.Diagnostics;
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
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetBigEndianBytes(this decimal value)
    {
        Span<byte> buffer = stackalloc byte[4];
        value.TryWriteBigEndianBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current decimal number into an array of bytes, as little endian.
    /// </summary>
    /// <param name="value">The <see cref="int" /> value.</param>
    /// <returns>An array of bytes with length 4.</returns>
    [Pure]
    public static byte[] GetLittleEndianBytes(this decimal value)
    {
        Span<byte> buffer = stackalloc byte[4];
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
        GetBits(value, buffer);

        if (buffer[0].TryWriteBigEndianBytes(destination[..4]) &&
            buffer[1].TryWriteBigEndianBytes(destination[4..8]) &&
            buffer[2].TryWriteBigEndianBytes(destination[8..12]) &&
            buffer[3].TryWriteBigEndianBytes(destination[12..]))
        {
            if (BitConverter.IsLittleEndian)
            {
                destination.Reverse();
            }

            return true;
        }

        destination.Clear();
        return false;
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
        GetBits(value, buffer);

        if (buffer[0].TryWriteLittleEndianBytes(destination[..4]) &&
            buffer[1].TryWriteLittleEndianBytes(destination[4..8]) &&
            buffer[2].TryWriteLittleEndianBytes(destination[8..12]) &&
            buffer[3].TryWriteLittleEndianBytes(destination[12..]))
        {
            if (!BitConverter.IsLittleEndian)
            {
                destination.Reverse();
            }

            return true;
        }

        destination.Clear();
        return false;
    }

    private static void GetBits(decimal value, Span<int> destination)
    {
        _ = decimal.GetBits(value, destination);
    }

#if !NET5_0_OR_GREATER
    private static void WriteBits(Span<int> destination, Span<byte> buffer)
    {
        var flags = MemoryMarshal.Read<int>(buffer[..4]);
        var hi = MemoryMarshal.Read<int>(buffer[4..8]);
        var lo = MemoryMarshal.Read<long>(buffer[8..]);

        var low = (uint)lo;
        var mid = (uint)(lo >> 32);

        destination[0] = (int)low;
        destination[1] = (int)mid;
        destination[2] = hi;
        destination[3] = flags;
    }
#endif
}
