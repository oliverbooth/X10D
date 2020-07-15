namespace X10D
{
    using System.Net;

    /// <summary>
    ///     Extension methods for <see cref="EndPoint" /> and derived types.
    /// </summary>
    public static class EndPointExtensions
    {
        /// <summary>
        ///     Gets the endpoint hostname.
        /// </summary>
        /// <param name="endPoint">The endpoint whose hostname to get.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> representing the hostname, which may be an IP or a DNS, or empty
        ///     string on failure.
        /// </returns>
        public static string GetHost(this EndPoint endPoint)
        {
            return endPoint switch
            {
                IPEndPoint ip => ip.Address.ToString(),
                DnsEndPoint dns => dns.Host,
                var _ => string.Empty,
            };
        }

        /// <summary>
        ///     Gets the endpoint port.
        /// </summary>
        /// <param name="endPoint">The endpoint whose port to get.</param>
        /// <returns>Returns an <see cref="int" /> representing the port, or 0 on failure.</returns>
        public static int GetPort(this EndPoint endPoint)
        {
            return endPoint switch
            {
                IPEndPoint ip => ip.Port,
                DnsEndPoint dns => dns.Port,
                var _ => 0,
            };
        }
    }
}
