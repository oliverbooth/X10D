using System.Diagnostics.Contracts;
using X10D.Core;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Returns the current 8-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 1.</returns>
    [Pure]
    public static byte[] GetBytes(this byte value)
    {
        return value.AsArrayValue();
    }

    /// <summary>
    ///     Converts a <see cref="byte" /> into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="byte" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="byte" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this byte value, Span<byte> destination)
    {
        if (destination.Length < 1)
        {
            return false;
        }

        destination[0] = value;
        return true;
    }
}
