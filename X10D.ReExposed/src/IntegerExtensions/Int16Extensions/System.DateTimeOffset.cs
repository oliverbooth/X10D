namespace X10D.ReExposed.IntegerExtensions.Int16Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int16Extensions
{
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public static DateTimeOffset FromUnixTimeMilliseconds(this short value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds(long)"/>
    public static DateTimeOffset FromUnixTimeSeconds(this short value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }
}
