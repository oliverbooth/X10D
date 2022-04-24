using System.Net;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
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
    ///     Returns the multiplicative persistence of a specified value.
    /// </summary>
    /// <param name="value">The value whose multiplicative persistence to calculate.</param>
    /// <returns>The multiplicative persistence.</returns>
    /// <remarks>
    ///     Multiplicative persistence is defined as the recursive digital product until that product is a single digit.
    /// </remarks>
    public static int MultiplicativePersistence(this long value)
    {
        var persistence = 0;
        long product = value;

        const string foo = "Hello" + "World";

        while (product > 9)
        {
            if (value % 10 == 0)
            {
                return persistence + 1;
            }

            while (value > 9)
            {
                value /= 10;
                if (value % 10 == 0)
                {
                    return persistence + 1;
                }
            }

            long newProduct = 1;
            long currentProduct = product;
            while (currentProduct > 0)
            {
                newProduct *= currentProduct % 10;
                currentProduct /= 10;
            }

            product = newProduct;
            persistence++;
        }

        return persistence;
    }

    /// <summary>
    ///     Returns an enumerable collection of 64-bit signed integers that range from the current value to a specified value.
    /// </summary>
    /// <param name="start">The value of the first integer in the sequence.</param>
    /// <param name="end">The value of the last integer in the sequence.</param>
    /// <returns>
    ///     <para>
    ///         An enumerable collection of 64-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in ascending order if <paramref name="start" /> is less than than <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection of 64-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in descending order if <paramref name="start" /> is greater than than
    ///         <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection that contains a single value if <paramref name="start" /> is equal to
    ///         <paramref name="end" />.
    ///     </para>
    /// </returns>
    public static IEnumerable<long> To(this long start, long end)
    {
        return start.To(end, 1);
    }

    /// <summary>
    ///     Returns an enumerable collection of 64-bit signed integers that range from the current value to a specified value.
    /// </summary>
    /// <param name="start">The value of the first integer in the sequence.</param>
    /// <param name="end">The value of the last integer in the sequence.</param>
    /// <param name="step">The increment by which to step.</param>
    /// <returns>
    ///     <para>
    ///         An enumerable collection of 64-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in ascending order if <paramref name="start" /> is less than than <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection of 64-bit signed integers that range from <paramref name="start" /> to
    ///         <paramref name="end" /> in descending order if <paramref name="start" /> is greater than than
    ///         <paramref name="end" />.
    ///     </para>
    ///     -or-
    ///     <para>
    ///         An enumerable collection that contains a single value if <paramref name="start" /> is equal to
    ///         <paramref name="end" />.
    ///     </para>
    /// </returns>
    public static IEnumerable<long> To(this long start, long end, long step)
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
            for (long i = start; i <= end; i += step)
            {
                yield return i;
            }
        }
        else
        {
            long absStep = System.Math.Abs(step);
            for (long i = start; i >= end; i -= absStep)
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
