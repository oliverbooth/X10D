namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public static DateTimeOffset FromUnixTimeMilliseconds(this long value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds(long)"/>
    public static DateTimeOffset FromUnixTimeSeconds(this long value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}
