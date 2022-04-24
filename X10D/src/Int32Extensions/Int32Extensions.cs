using System.Net;
using X10D.Math;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Performs a circular bitwise left-shift on an integer, such that the most-significant bits that are truncated occupy
    ///     the least-significant bits.
    /// </summary>
    /// <param name="value">The value to shift.</param>
    /// <param name="shift">The shift amount.</param>
    /// <returns>The result of the shift.</returns>
    public static int CircularLeftShift(this int value, int shift)
    {
        shift = shift.Mod(32);
        if (shift == 0)
        {
            return value;
        }

        var pattern = 0;
        for (var i = 0; i < shift; i++)
        {
            pattern |= 1 << (32 - i);
        }

        int cache = value & pattern;
        cache >>= 32 - shift;
        return (value << shift) | cache;
    }

    /// <summary>
    ///     Performs a circular bitwise right-shift on an integer, such that the least-significant bits that are truncated occupy
    ///     the most-significant bits.
    /// </summary>
    /// <param name="value">The value to shift.</param>
    /// <param name="shift">The shift amount.</param>
    /// <returns>The result of the shift.</returns>
    public static int CircularRightShift(this int value, int shift)
    {
        shift = shift.Mod(32);
        if (shift == 0)
        {
            return value;
        }

        var pattern = 0;
        for (var i = 0; i < shift; i++)
        {
            pattern |= 1 << i;
        }

        int cache = value & pattern;
        cache <<= 32 - shift;
        return (value >> shift) | cache;
    }

    /// <summary>
    ///     Converts the current angle in degrees to its equivalent represented in radians.
    /// </summary>
    /// <param name="value">The angle in degrees to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    public static float DegreesToRadians(this int value)
    {
        return ((float)value).DegreesToRadians();
    }

    /// <summary>
    ///     Returns the current 32-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 4.</returns>
    public static byte[] GetBytes(this int value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <summary>
    ///     Returns an enumerable collection of 32-bit signed integers that range from the current value to a specified value.
    /// </summary>
    /// <param name="start">The value of the first integer in the sequence.</param>
    /// <param name="end">The value of the last integer in the sequence.</param>
    /// <returns>
    ///     <para>
    ///         An enumerable collection of 32-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in ascending order if <paramref name="start" /> is less than than <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection of 32-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in descending order if <paramref name="start" /> is greater than than
    ///         <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection that contains a single value if <paramref name="start" /> is equal to
    ///         <paramref name="end" />.
    ///     </para>
    /// </returns>
    public static IEnumerable<int> To(this int start, int end)
    {
        return start.To(end, 1);
    }

    /// <summary>
    ///     Returns an enumerable collection of 32-bit signed integers that range from the current value to a specified value.
    /// </summary>
    /// <param name="start">The value of the first integer in the sequence.</param>
    /// <param name="end">The value of the last integer in the sequence.</param>
    /// <param name="step">The increment by which to step.</param>
    /// <returns>
    ///     <para>
    ///         An enumerable collection of 32-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in ascending order if <paramref name="start" /> is less than than <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection of 32-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in descending order if <paramref name="start" /> is greater than than
    ///         <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection that contains a single value if <paramref name="start" /> is equal to
    ///         <paramref name="end" />.
    ///     </para>
    /// </returns>
    public static IEnumerable<int> To(this int start, int end, int step)
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
            for (int i = start; i <= end; i += step)
            {
                yield return i;
            }
        }
        else
        {
            int absStep = System.Math.Abs(step);
            for (int i = start; i >= end; i -= absStep)
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
    public static int ToHostOrder(this int value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }

    /// <summary>
    ///     Converts an integer value from host byte order to network byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in host byte order.</param>
    /// <returns>An integer value, expressed in network byte order.</returns>
    public static int ToNetworkOrder(this int value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }
}
