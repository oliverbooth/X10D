namespace X10D.ReExposed.DateTimeExtensions;

/// <summary>
///     Extension methods for <see cref="DateTime"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class DateTimeExtensions
{
    /// <inheritdoc cref="DateTime.Compare(DateTime,DateTime)"/>
    public static int Compare(this DateTime value, DateTime comparison)
    {
        return DateTime.Compare(value, comparison);
    }

    /// <inheritdoc cref="DateTime.SpecifyKind(DateTime,DateTimeKind)"/>
    public static DateTime SpecifyKind(this DateTime value, DateTimeKind kind)
    {
        return DateTime.SpecifyKind(value, kind);
    }
}