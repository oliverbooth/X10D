namespace X10D.ReExposed.IntegerExtensions.UInt16Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt16Extensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(ushort)"/>
    public static byte[] GetBytes(this ushort value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},ushort)"/>
    public static bool TryWriteBytes(this ushort value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}