namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="IPAddress.HostToNetworkOrder(long)"/>
    public static long HostToNetworkOrder(this long value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }

    /// <inheritdoc cref="IPAddress.NetworkToHostOrder(long)"/>
    public static long NetworkToHostOrder(this long value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }
}
