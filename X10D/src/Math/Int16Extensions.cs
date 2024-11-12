using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the current value is a prime number.
    /// </summary>
    /// <param name="value">The value whose primality to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsPrime(this short value)
    {
        return ((long)value).IsPrime();
    }

    /// <summary>
    ///     Calculates the lowest common multiple between the current 16-bit signed integer, and another 16-bit signed integer.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="other">The second value.</param>
    /// <returns>The lowest common multiple between <paramref name="value" /> and <paramref name="other" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static short LowestCommonMultiple(this short value, short other)
    {
        return (short)((long)value).LowestCommonMultiple(other);
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int MultiplicativePersistence(this short value)
    {
        return ((long)value).MultiplicativePersistence();
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this 16-bit signed integer.
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
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int Sign(this short value)
    {
        return System.Math.Sign(value);
    }

    /// <summary>
    ///     Wraps the current 16-bit signed integer between a low and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="low">The inclusive lower bound.</param>
    /// <param name="high">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static short Wrap(this short value, short low, short high)
    {
        return (short)((long)value).Wrap(low, high);
    }

    /// <summary>
    ///     Wraps the current 16-bit signed integer between 0 and a high value.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <param name="length">The exclusive upper bound.</param>
    /// <returns>The wrapped value.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static short Wrap(this short value, short length)
    {
        return (short)((long)value).Wrap(length);
    }
}
