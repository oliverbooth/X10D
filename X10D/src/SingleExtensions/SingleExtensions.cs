namespace X10D;

/// <summary>
///     Extension methods for <see cref="float" />.
/// </summary>
public static class SingleExtensions
{
    /// <summary>
    ///     Converts the <see cref="float" /> to a <see cref="byte" />[].
    /// </summary>
    /// <param name="number">The number to convert.</param>
    /// <returns>Returns a <see cref="byte" />[].</returns>
    public static byte[] GetBytes(this float number)
    {
        return BitConverter.GetBytes(number);
    }
}
