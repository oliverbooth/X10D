namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Returns the factorial of the current 8-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    public static long Factorial(this byte value)
    {
        if (value == 0)
        {
            return 1;
        }

        var result = 1L;
        for (byte i = 1; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
