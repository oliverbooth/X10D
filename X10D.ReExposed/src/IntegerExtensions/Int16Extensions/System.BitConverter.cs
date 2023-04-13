namespace X10D.ReExposed.IntegerExtensions.Int16Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int16Extensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(short)"/>
    public static byte[] GetBytes(this short value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},short)"/>
    public static bool TryWriteBytes(this short value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}