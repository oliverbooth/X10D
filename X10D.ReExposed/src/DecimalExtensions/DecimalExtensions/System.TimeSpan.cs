namespace X10D.ReExposed.DecimalExtensions.DecimalExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class DecimalExtensions
{
    /// <inheritdoc cref="TimeSpan.FromTicks(long)"/>
    public static TimeSpan GetTimeSpanTicks(this decimal value)
    {
        return TimeSpan.FromTicks((long)value);
    }

    /// <inheritdoc cref="TimeSpan.FromMilliseconds(double)"/>
    public static TimeSpan GetTimeSpanMilliseconds(this decimal value)
    {
        return TimeSpan.FromMilliseconds((double)value);
    }

    /// <inheritdoc cref="TimeSpan.FromSeconds(double)"/>
    public static TimeSpan GetTimeSpanSeconds(this decimal value)
    {
        return TimeSpan.FromSeconds((double)value);
    }

    /// <inheritdoc cref="TimeSpan.FromMinutes(double)"/>
    public static TimeSpan GetTimeSpanMinutes(this decimal value)
    {
        return TimeSpan.FromMinutes((double)value);
    }

    /// <inheritdoc cref="TimeSpan.FromHours(double)"/>
    public static TimeSpan GetTimeSpanHours(this decimal value)
    {
        return TimeSpan.FromHours((double)value);
    }

    /// <inheritdoc cref="TimeSpan.FromDays(double)"/>
    public static TimeSpan GetTimeSpanDays(this decimal value)
    {
        return TimeSpan.FromDays((double)value);
    }
}
