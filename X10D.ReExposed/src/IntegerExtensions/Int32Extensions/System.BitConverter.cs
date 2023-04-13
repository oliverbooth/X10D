namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(int)"/>
    public static byte[] GetBytes(this int value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},int)"/>
    public static bool TryWriteBytes(this int value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}