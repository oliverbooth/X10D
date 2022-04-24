namespace X10D;

/// <summary>
///     Extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Returns the current 8-bit unsigned integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 1.</returns>
    public static byte[] GetBytes(this byte value)
    {
        return new[] { value };
    }
}
