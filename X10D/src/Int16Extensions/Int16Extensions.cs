using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.CompilerServices;
using X10D.Math;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Computes the digital root of an integer.
    /// </summary>
    /// <param name="value">The value whose digital root to compute.</param>
    /// <returns>The digital root of <paramref name="value" />.</returns>
    /// <remarks>The digital root is defined as the recursive sum of digits until that result is a single digit.</remarks>
    public static short DigitalRoot(this short value)
    {
        short root = value.Mod(9);
        return root < 1 ? (short)(9 - root) : root;
    }

    /// <summary>
    ///     Converts a Unix time expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at
    ///     12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800,000.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799,999.</para>
    /// </exception>
    public static DateTimeOffset FromUnixTimeMilliseconds(this short value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <summary>
    ///     Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at
    ///     12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799.</para>
    /// </exception>
    public static DateTimeOffset FromUnixTimeSeconds(this short value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }

    /// <summary>
    ///     Returns the current 16-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 2.</returns>
    public static byte[] GetBytes(this short value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <summary>
    ///     Returns a value indicating whether the current value is evenly divisible by 2.
    /// </summary>
    /// <param name="value">The value whose parity to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is evenly divisible by 2, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    public static bool IsEven(this short value)
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
    public static bool IsOdd(this short value)
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
    public static bool IsPrime(this short value)
    {
        return ((long)value).IsPrime();
    }

    /// <summary>
    ///     Linearly interpolates to the current value from a specified source using a specified alpha.
    /// </summary>
    /// <param name="target">The interpolation target.</param>
    /// <param name="value">The interpolation source.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static double LerpFrom(this short target, double value, double alpha)
    {
        return MathUtility.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates to the current value from a specified source using a specified alpha.
    /// </summary>
    /// <param name="target">The interpolation target.</param>
    /// <param name="value">The interpolation source.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static float LerpFrom(this short target, float value, float alpha)
    {
        return MathUtility.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates from the current value to a specified target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static double LerpTo(this short value, double target, double alpha)
    {
        return MathUtility.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates from the current value to a specified target using a specified alpha.
    /// </summary>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static float LerpTo(this short value, float target, float alpha)
    {
        return MathUtility.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates to a specified target from a specified source, using the current value as the alpha value.
    /// </summary>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static double LerpWith(this short alpha, double value, double target)
    {
        return MathUtility.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Linearly interpolates to a specified target from a specified source, using the current value as the alpha value.
    /// </summary>
    /// <param name="alpha">The interpolation alpha.</param>
    /// <param name="value">The interpolation source.</param>
    /// <param name="target">The interpolation target.</param>
    /// <returns>
    ///     The interpolation result as determined by <c>(1 - alpha) * value + alpha * target</c>.
    /// </returns>
    public static float LerpWith(this short alpha, float value, float target)
    {
        return MathUtility.Lerp(value, target, alpha);
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
    public static short Mod(this short dividend, short divisor)
    {
        var r = (short)(dividend % divisor);
        return (short)(r < 0 ? r + divisor : r);
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int Sign(this short value)
    {
        return System.Math.Sign(value);
    }

    /// <summary>
    ///     Returns an enumerable collection of 16-bit signed integers that range from the current value to a specified value.
    /// </summary>
    /// <param name="start">The value of the first integer in the sequence.</param>
    /// <param name="end">The value of the last integer in the sequence.</param>
    /// <returns>
    ///     <para>
    ///         An enumerable collection of 16-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in ascending order if <paramref name="start" /> is less than than <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection of 16-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in descending order if <paramref name="start" /> is greater than than
    ///         <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection that contains a single value if <paramref name="start" /> is equal to
    ///         <paramref name="end" />.
    ///     </para>
    /// </returns>
    public static IEnumerable<short> To(this short start, short end)
    {
        return start.To(end, 1);
    }

    /// <summary>
    ///     Returns an enumerable collection of 16-bit signed integers that range from the current value to a specified value.
    /// </summary>
    /// <param name="start">The value of the first integer in the sequence.</param>
    /// <param name="end">The value of the last integer in the sequence.</param>
    /// <param name="step">The increment by which to step.</param>
    /// <returns>
    ///     <para>
    ///         An enumerable collection of 16-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in ascending order if <paramref name="start" /> is less than than <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection of 16-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in descending order if <paramref name="start" /> is greater than than
    ///         <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection that contains a single value if <paramref name="start" /> is equal to
    ///         <paramref name="end" />.
    ///     </para>
    /// </returns>
    public static IEnumerable<short> To(this short start, short end, short step)
    {
        if (step == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(step), "Step cannot be zero.");
        }

        if (end == start)
        {
            yield return start;
            yield break;
        }

        if (step > 0 || start < end)
        {
            for (short i = start; i <= end; i += step)
            {
                yield return i;
            }
        }
        else
        {
            short absStep = System.Math.Abs(step);
            for (short i = start; i >= end; i -= absStep)
            {
                yield return i;
            }
        }
    }

    /// <summary>
    ///     Converts an integer value from network byte order to host byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in network byte order.</param>
    /// <returns>An integer value, expressed in host byte order.</returns>
    public static short ToHostOrder(this short value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }

    /// <summary>
    ///     Converts an integer value from host byte order to network byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in host byte order.</param>
    /// <returns>An integer value, expressed in network byte order.</returns>
    public static short ToNetworkOrder(this short value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }
}
