using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Net;

/// <summary>
///     Extension methods for <see cref="IPAddress" />.
/// </summary>
public static class IPAddressExtensions
{
    /// <summary>
    ///     Returns a value indicating whether the specified IP address is a valid IPv4 address.
    /// </summary>
    /// <param name="address">The IP address to check.</param>
    /// <returns>
    ///     <see langword="true" /> if the specified IP address is a valid IPv4 address; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="address" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsIPv4(this IPAddress address)
    {
        if (address is null)
        {
            throw new ArgumentNullException(nameof(address));
        }

        return address.AddressFamily == AddressFamily.InterNetwork;
    }

    /// <summary>
    ///     Returns a value indicating whether the specified IP address is a valid IPv6 address.
    /// </summary>
    /// <param name="address">The IP address to check.</param>
    /// <returns>
    ///     <see langword="true" /> if the specified IP address is a valid IPv6 address; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="address" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsIPv6(this IPAddress address)
    {
        if (address is null)
        {
            throw new ArgumentNullException(nameof(address));
        }

        return address.AddressFamily == AddressFamily.InterNetworkV6;
    }
}
