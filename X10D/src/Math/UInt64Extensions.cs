namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="ulong" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt64Extensions
{
    /// <summary>
    ///     Returns the factorial of the current 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    public static ulong Factorial(this ulong value)
    {
        if (value == 0)
        {
            return 1;
        }

        var result = 1UL;
        for (var i = 1UL; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
