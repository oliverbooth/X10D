namespace X10D.Math;

/// <summary>
///     Math-related extension methods for <see cref="byte" />.
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

    /// <summary>
    ///     Returns a value indicating whether the current value is evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    public static bool IsEven(this byte value)
    {
        return value % 2 == 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is not evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is not evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    public static bool IsOdd(this byte value)
    {
        return !value.IsEven();
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is a prime number.
    /// </summary>
    /// <param name="value">The value whose primality to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsPrime(this byte value)
    {
        return ((long)value).IsPrime();
    }
}
