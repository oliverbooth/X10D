namespace X10D.ReExposed.DecimalExtensions.DoubleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DoubleExtensions
{
    /// <inheritdoc cref="BitConverter.GetBytes(double)"/>
    public static byte[] GetBytes(this double value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},double)"/>
    public static bool TryWriteBytes(this double value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}