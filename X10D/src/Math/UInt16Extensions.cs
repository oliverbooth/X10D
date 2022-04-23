namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="ushort" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt16Extensions
{
    /// <summary>
    ///     Returns the factorial of the current 16-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    public static ulong Factorial(this ushort value)
    {
        if (value == 0)
        {
            return 1;
        }

        var result = 1UL;
        for (ushort i = 1; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
