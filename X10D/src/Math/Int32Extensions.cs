using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Computes the digital root of this 32-bit integer.
    /// </summary>
    /// <param name="value">The value whose digital root to compute.</param>
    /// <returns>The digital root of <paramref name="value" />.</returns>
    /// <remarks>
    ///     <para>The digital root is defined as the recursive sum of digits until that result is a single digit.</para>
    ///     <para>For example, the digital root of 239 is 5: <c>2 + 3 + 9 = 14</c>, then <c>1 + 4 = 5</c>.</para>
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int DigitalRoot(this int value)
    {
        int root = System.Math.Abs(value).Mod(9);
        return root < 1 ? 9 - root : root;
    }

    /// <summary>
    ///     Returns the factorial of the current 32-bit signed integer.
    /// </summary>
    /// <param name="value">The value whose factorial to compute.</param>
    /// <returns>The factorial of <paramref name="value" />.</returns>
    /// <exception cref="ArithmeticException"><paramref name="value" /> is less than 0.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static long Factorial(this int value)
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
        for (var i = 1; i <= value; i++)
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
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsEven(this int value)
    {
        return (value & 1) == 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is not evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is not evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsOdd(this int value)
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
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsPrime(this int value)
    {
        return ((long)value).IsPrime();
    }

    /// <summary>
    ///     Performs a modulo operation which supports a negative dividend.
    /// </summary>
    /// <param name="dividend">The dividend.</param>
    /// <param name="divisor">The divisor.</param>
    /// <returns>The result of <c>dividend mod divisor</c>.</returns>
    /// <remarks>
    ///     The <c>%</c> operator (commonly called the modulo operator) in C# is not defined to be modulo, but is instead
    ///     remainder. This quirk inherently makes it difficult to use modulo in a negative context, as <c>x % y</c> where x is
    ///     negative will return a negative value, akin to <c>-(x % y)</c>, even if precedence is forced. This method provides a
    ///     modulo operation which supports negative dividends.
    /// </remarks>
    /// <author>ShreevatsaR, https://stackoverflow.com/a/1082938/1467293</author>
    /// <license>CC-BY-SA 2.5</license>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Mod(this int dividend, int divisor)
    {
        int r = dividend % divisor;
        return r < 0 ? r + divisor : r;
    }

    /// <summary>
    ///     Returns the multiplicative persistence of a specified value.
    /// </summary>
    /// <param name="value">The value whose multiplicative persistence to calculate.</param>
    /// <returns>The multiplicative persistence.</returns>
    /// <remarks>
    ///     Multiplicative persistence is defined as the recursive digital product until that product is a single digit.
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int MultiplicativePersistence(this int value)
    {
        return ((long)value).MultiplicativePersistence();
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this 32-bit signed integer.
    /// </summary>
    /// <param name="value">A signed number.</param>
    /// <returns>
    ///     A number that indicates the sign of <paramref name="value" />, as shown in the following table.
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Return value</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>-1</term>
    ///             <description><paramref name="value" /> is less than zero.</description>
    ///         </item>
    ///         <item>
    ///             <term>0</term>
    ///             <description><paramref name="value" /> is equal to zero.</description>
    ///         </item>
    ///         <item>
    ///             <term>1</term>
    ///             <description><paramref name="value" /> is greater than zero.</description>
    ///         </item>
    ///     </list>
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Sign(this int value)
    {
        return System.Math.Sign(value);
    }
}
