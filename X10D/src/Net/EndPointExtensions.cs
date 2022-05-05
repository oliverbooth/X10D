using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.CompilerServices;

namespace X10D.Net;

/// <summary>
///     Extension methods for <see cref="EndPoint" /> and derived types.
/// </summary>
public static class EndPointExtensions
{
    /// <summary>
    ///     Returns the hostname for the current <see cref="System.Net.EndPoint" />.
    /// </summary>
    /// <param name="endPoint">The endpoint whose hostname to get.</param>
    /// <returns>
    ///     <para><see cref="IPEndPoint.Address" /> if <paramref name="endPoint" /> is <see cref="IPEndPoint" />.</para>
    ///     -or-
    ///     <para><see cref="DnsEndPoint.Host" /> if <paramref name="endPoint" /> is <see cref="DnsEndPoint" />.</para>
    ///     -or-
    ///     <para><see cref="string.Empty" /> otherwise.</para>
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="endPoint" /> is <see langword="null" />.</exception>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static string GetHost(this EndPoint endPoint)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(endPoint);
#else
        if (endPoint is null)
        {
            throw new ArgumentNullException(nameof(endPoint));
        }
#endif

        return endPoint switch
        {
            IPEndPoint ip => ip.Address.ToString(),
            DnsEndPoint dns => dns.Host,
            _ => string.Empty
        };
    }

    /// <summary>
    ///     Returns the port number for the current <see cref="System.Net.EndPoint" />.
    /// </summary>
    /// <param name="endPoint">The endpoint whose port number to get.</param>
    /// <returns>
    ///     <para><see cref="IPEndPoint.Port" /> if <paramref name="endPoint" /> is <see cref="IPEndPoint" />.</para>
    ///     -or-
    ///     <para><see cref="DnsEndPoint.Port" /> if <paramref name="endPoint" /> is <see cref="DnsEndPoint" />.</para>
    ///     -or-
    ///     <para><c>0</c> otherwise.</para>
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="endPoint" /> is <see langword="null" />.</exception>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static int GetPort(this EndPoint endPoint)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(endPoint);
#else
        if (endPoint is null)
        {
            throw new ArgumentNullException(nameof(endPoint));
        }
#endif

        return endPoint switch
        {
            IPEndPoint ip => ip.Port,
            DnsEndPoint dns => dns.Port,
            _ => 0
        };
    }
}
