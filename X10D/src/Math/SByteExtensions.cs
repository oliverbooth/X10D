namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="sbyte" />.
/// </summary>
[CLSCompliant(false)]
public static class SByteExtensions
{
    /// <summary>
    ///     Returns the factorial of the current 8-bit signed integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    /// <exception cref="ArithmeticException"><paramref name="value" /> is less than 0.</exception>
    public static long Factorial(this sbyte value)
    {
        if (value < 0)
        {
            throw new ArithmeticException(nameof(value));
        }

        if (value == 0)
        {
            return 1;
        }

        var result = 1L;
        for (ushort i = 1; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
