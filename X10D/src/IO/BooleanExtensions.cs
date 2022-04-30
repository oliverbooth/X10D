using System.Diagnostics.Contracts;

namespace X10D.IO;

/// <summary>
///     Extension methods for <see cref="bool" />.
/// </summary>
public static class BooleanExtensions
{
    /// <summary>
    ///     Returns the current boolean value as an array of bytes.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>An array of bytes with length 1.</returns>
    [Pure]
    public static byte[] GetBytes(this bool value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <summary>
    ///     Converts a <see cref="bool" /> into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="bool" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="bool" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this bool value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}
