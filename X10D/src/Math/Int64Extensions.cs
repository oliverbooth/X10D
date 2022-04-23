namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
    /// <summary>
    ///     Returns the factorial of the current 64-bit signed integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    /// <exception cref="ArithmeticException"><paramref name="value" /> is less than 0.</exception>
    public static long Factorial(this long value)
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
        for (var i = 1L; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
