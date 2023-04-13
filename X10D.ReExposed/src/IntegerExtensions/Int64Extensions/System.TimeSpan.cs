namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="TimeSpan.FromTicks(long)"/>
    public static TimeSpan GetTimeSpanTicks(this long value)
    {
        return TimeSpan.FromTicks(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMilliseconds(double)"/>
    public static TimeSpan GetTimeSpanMilliseconds(this long value)
    {
        return TimeSpan.FromMilliseconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromSeconds(double)"/>
    public static TimeSpan GetTimeSpanSeconds(this long value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMinutes(double)"/>
    public static TimeSpan GetTimeSpanMinutes(this long value)
    {
        return TimeSpan.FromMinutes(value);
    }

    /// <inheritdoc cref="TimeSpan.FromHours(double)"/>
    public static TimeSpan GetTimeSpanHours(this long value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <inheritdoc cref="TimeSpan.FromDays(double)"/>
    public static TimeSpan GetTimeSpanDays(this long value)
    {
        return TimeSpan.FromDays(value);
    }
}
