using System.Net;
using System.Net.Sockets;

namespace X10D.Net;

/// <summary>
///     Extension methods for <see cref="IPAddress" />.
/// </summary>
public static class IpAddressExtensions
{
    /// <summary>
    ///     Returns a value indicating whether the specified IP address is a valid IPv4 address.
    /// </summary>
    /// <param name="address">The IP address to check.</param>
    /// <returns>
    ///     <see langword="true" /> if the specified IP address is a valid IPv4 address; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsIpV4(this IPAddress address)
    {
        return address.AddressFamily == AddressFamily.InterNetwork;
    }

    /// <summary>
    ///     Returns a value indicating whether the specified IP address is a valid IPv6 address.
    /// </summary>
    /// <param name="address">The IP address to check.</param>
    /// <returns>
    ///     <see langword="true" /> if the specified IP address is a valid IPv6 address; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsIpV6(this IPAddress address)
    {
        return address.AddressFamily == AddressFamily.InterNetworkV6;
    }
}
