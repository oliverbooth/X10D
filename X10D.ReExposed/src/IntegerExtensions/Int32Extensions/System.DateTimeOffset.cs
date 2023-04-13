namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public static DateTimeOffset FromUnixTimeMilliseconds(this int value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds(long)"/>
    public static DateTimeOffset FromUnixTimeSeconds(this int value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}
