using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.CompilerServices;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
    /// <summary>
    ///     Converts a Unix time expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z (January 1,
    ///     1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800,000.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799,999.</para>
    /// </exception>
    public static DateTimeOffset FromUnixTimeMilliseconds(this long value)
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
    public static DateTimeOffset FromUnixTimeSeconds(this long value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }

    /// <summary>
    ///     Returns the current 64-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 8.</returns>
    public static byte[] GetBytes(this long value)
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
    public static bool IsEven(this long value)
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
    public static bool IsOdd(this long value)
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
    public static bool IsPrime(this long value)
    {
        switch (value)
        {
            case < 2: return false;
            case 2:
            case 3: return true;
        }

        if (value % 2 == 0 || value % 3 == 0)
        {
            return false;
        }

        if ((value + 1) % 6 != 0 && (value - 1) % 6 != 0)
        {
            return false;
        }

        for (var iterator = 5L; iterator * iterator <= value; iterator += 6)
        {
            if (value % iterator == 0 || value % (iterator + 2) == 0)
            {
                return false;
            }
        }

        return true;
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
    public static double LerpFrom(this long target, double value, double alpha)
    {
        return MathUtils.Lerp(value, target, alpha);
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
    public static float LerpFrom(this long target, float value, float alpha)
    {
        return MathUtils.Lerp(value, target, alpha);
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
    public static double LerpTo(this long value, double target, double alpha)
    {
        return MathUtils.Lerp(value, target, alpha);
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
    public static float LerpTo(this long value, float target, float alpha)
    {
        return MathUtils.Lerp(value, target, alpha);
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
    public static double LerpWith(this long alpha, double value, double target)
    {
        return MathUtils.Lerp(value, target, alpha);
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
    public static float LerpWith(this long alpha, float value, float target)
    {
        return MathUtils.Lerp(value, target, alpha);
    }

    /// <summary>
    ///     Returns an integer that indicates the sign of this 64-bit signed integer.
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
    public static int Sign(this long value)
    {
        return Math.Sign(value);
    }

    /// <summary>
    ///     Converts an integer value from network byte order to host byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in network byte order.</param>
    /// <returns>An integer value, expressed in host byte order.</returns>
    public static long ToHostOrder(this long value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }

    /// <summary>
    ///     Converts an integer value from host byte order to network byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in host byte order.</param>
    /// <returns>An integer value, expressed in network byte order.</returns>
    public static long ToNetworkOrder(this long value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }
}
