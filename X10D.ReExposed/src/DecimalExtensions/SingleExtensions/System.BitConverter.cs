namespace X10D.ReExposed.DecimalExtensions.SingleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class SingleExtensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(float)"/>
    public static byte[] GetBytes(this float value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},float)"/>
    public static bool TryWriteBytes(this float value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}