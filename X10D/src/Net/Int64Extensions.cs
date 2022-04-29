using System.Net;

namespace X10D.Net;

/// <summary>
///     IO-related extension methods for <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
    /// <summary>
    ///     Converts a 64-bit signed integer value from host byte order to network byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in host byte order.</param>
    /// <returns>An integer value, expressed in network byte order.</returns>
    public static long HostToNetworkOrder(this long value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }

    /// <summary>
    ///     Converts a 64-bit signed integer value from network byte order to host byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in network byte order.</param>
    /// <returns>An integer value, expressed in host byte order.</returns>
    public static long NetworkToHostOrder(this long value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }
}
