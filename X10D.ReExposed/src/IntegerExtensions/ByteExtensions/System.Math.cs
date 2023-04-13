namespace X10D.ReExposed.IntegerExtensions.ByteExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class ByteExtensions
{
    /// <inheritdoc cref="Math.Clamp(byte,byte,byte)"/>
    public static byte Clamp(this byte value, byte min, byte max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.Max(byte,byte)"/>
    public static byte Max(this byte value, byte value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(byte,byte)"/>
    public static byte Min(this byte value, byte value2)
    {
        return Math.Min(value, value2);
    }
}