namespace X10D.ReExposed.IntegerExtensions.SByteExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class SByteExtensions
{
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public static DateTimeOffset FromUnixTimeMilliseconds(this sbyte value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds(long)"/>
    public static DateTimeOffset FromUnixTimeSeconds(this sbyte value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}
