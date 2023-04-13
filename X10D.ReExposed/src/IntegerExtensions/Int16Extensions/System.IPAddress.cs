namespace X10D.ReExposed.IntegerExtensions.Int16Extensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class Int16Extensions
{
    /// <inheritdoc cref="IPAddress.HostToNetworkOrder(short)"/>
    public static short HostToNetworkOrder(this short value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }

    /// <inheritdoc cref="IPAddress.NetworkToHostOrder(short)"/>
    public static short NetworkToHostOrder(this short value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }
}
