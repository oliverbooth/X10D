namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(long)"/>
    public static byte[] GetBytes(this long value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},long)"/>
    public static bool TryWriteBytes(this long value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}