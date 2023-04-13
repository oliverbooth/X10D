namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="IPAddress.HostToNetworkOrder(int)"/>
    public static int HostToNetworkOrder(this int value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }

    /// <inheritdoc cref="IPAddress.NetworkToHostOrder(int)"/>
    public static int NetworkToHostOrder(this int value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }
}
