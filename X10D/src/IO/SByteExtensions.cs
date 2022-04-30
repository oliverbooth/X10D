using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="sbyte" />.
/// </summary>
[CLSCompliant(false)]
public static class SByteExtensions
{
    /// <summary>
    ///     Returns the current 16-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 1.</returns>
    [Pure]
    public static byte[] GetBytes(this sbyte value)
    {
        Span<byte> buffer = stackalloc byte[1];
        value.TryWriteBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 16-bit unsigned integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="sbyte" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="sbyte" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this sbyte value, Span<byte> destination)
    {
        if (destination.Length < 1)
        {
            return false;
        }

        destination[0] = (byte)value;
        return true;
    }
}
