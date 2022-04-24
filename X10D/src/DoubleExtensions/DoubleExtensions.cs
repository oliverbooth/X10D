namespace X10D;

/// <summary>
///     Extension methods for <see cref="double" />.
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    ///     Converts the <see cref="double" /> to a <see cref="byte" />[].
    /// </summary>
    /// <param name="number">The number to convert.</param>
    /// <returns>Returns a <see cref="byte" />[].</returns>
    public static byte[] GetBytes(this double number)
    {
        return BitConverter.GetBytes(number);
    }
}
