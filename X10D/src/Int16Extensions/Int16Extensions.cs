using System.Net;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
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
