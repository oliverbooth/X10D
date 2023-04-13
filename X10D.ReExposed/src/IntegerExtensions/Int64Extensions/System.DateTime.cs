namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="DateTime.FromFileTime(long)"/>
    public static DateTime FromFileTime(this long fileTime)
    {
        return DateTime.FromFileTime(fileTime);
    }

    /// <inheritdoc cref="DateTime.FromFileTimeUtc(long)"/>
    public static DateTime FromFileTimeUtc(this long fileTime)
    {
        return DateTime.FromFileTimeUtc(fileTime);
    }
}