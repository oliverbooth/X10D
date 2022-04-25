using System.Net;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
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
