namespace X10D.ReExposed.IntegerExtensions.UInt64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt64Extensions
{
    /// <inheritdoc cref="TimeSpan.FromTicks(long)"/>
    public static TimeSpan GetTimeSpanTicks(this ushort value)
    {
        return TimeSpan.FromTicks(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMilliseconds(double)"/>
    public static TimeSpan GetTimeSpanMilliseconds(this ushort value)
    {
        return TimeSpan.FromMilliseconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromSeconds(double)"/>
    public static TimeSpan GetTimeSpanSeconds(this ushort value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMinutes(double)"/>
    public static TimeSpan GetTimeSpanMinutes(this ushort value)
    {
        return TimeSpan.FromMinutes(value);
    }

    /// <inheritdoc cref="TimeSpan.FromHours(double)"/>
    public static TimeSpan GetTimeSpanHours(this ushort value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <inheritdoc cref="TimeSpan.FromDays(double)"/>
    public static TimeSpan GetTimeSpanDays(this ushort value)
    {
        return TimeSpan.FromDays(value);
    }
}
