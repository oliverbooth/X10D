using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Net;

/// <summary>
///     IO-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Converts a 32-bit signed integer value from host byte order to network byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in host byte order.</param>
    /// <returns>An integer value, expressed in network byte order.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int HostToNetworkOrder(this int value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }

    /// <summary>
    ///     Converts a 32-bit signed integer value from network byte order to host byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in network byte order.</param>
    /// <returns>An integer value, expressed in host byte order.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static int NetworkToHostOrder(this int value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }
}
