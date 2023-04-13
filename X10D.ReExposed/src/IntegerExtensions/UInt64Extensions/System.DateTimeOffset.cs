namespace X10D.ReExposed.IntegerExtensions.UInt64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt64Extensions
{
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public static DateTimeOffset FromUnixTimeMilliseconds(this ulong value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds((long)value);
    }

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds(long)"/>
    public static DateTimeOffset FromUnixTimeSeconds(this ulong value)
    {
        return DateTimeOffset.FromUnixTimeSeconds((long)value);
    }
}
