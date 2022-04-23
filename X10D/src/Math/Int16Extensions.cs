namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Returns the factorial of the current 16-bit signed integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    /// <exception cref="ArithmeticException"><paramref name="value" /> is less than 0.</exception>
    public static long Factorial(this short value)
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
        for (short i = 1; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
