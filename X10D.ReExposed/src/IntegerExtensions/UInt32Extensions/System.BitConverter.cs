namespace X10D.ReExposed.IntegerExtensions.UInt32Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt32Extensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(uint)"/>
    public static byte[] GetBytes(this uint value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},uint)"/>
    public static bool TryWriteBytes(this uint value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}