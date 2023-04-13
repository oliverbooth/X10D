namespace X10D.ReExposed.IntegerExtensions.UInt16Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt16Extensions
{
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public static DateTimeOffset FromUnixTimeMilliseconds(this ushort value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds(long)"/>
    public static DateTimeOffset FromUnixTimeSeconds(this ushort value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}
