using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="ushort" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt16Extensions
{
    /// <summary>
    ///     Computes the digital root of the current 16-bit unsigned integer.
    /// </summary>
    /// <param name="value">The value whose digital root to compute.</param>
    /// <returns>The digital root of <paramref name="value" />.</returns>
    /// <remarks>
    ///     <para>The digital root is defined as the recursive sum of digits until that result is a single digit.</para>
    ///     <para>For example, the digital root of 239 is 5: <c>2 + 3 + 9 = 14</c>, then <c>1 + 4 = 5</c>.</para>
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ushort DigitalRoot(this ushort value)
    {
        var root = (ushort)(value % 9);
        return (ushort)(root == 0 ? 9 : root);
    }

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
