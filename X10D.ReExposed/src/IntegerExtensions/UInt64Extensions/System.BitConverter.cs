namespace X10D.ReExposed.IntegerExtensions.UInt64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt64Extensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(ulong)"/>
    public static byte[] GetBytes(this ulong value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},ulong)"/>
    public static bool TryWriteBytes(this ulong value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}