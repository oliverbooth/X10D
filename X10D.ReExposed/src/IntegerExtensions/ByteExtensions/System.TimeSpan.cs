namespace X10D.ReExposed.IntegerExtensions.ByteExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class ByteExtensions
{
    /// <inheritdoc cref="TimeSpan.FromTicks(long)"/>
    public static TimeSpan GetTimeSpanTicks(this byte value)
    {
        return TimeSpan.FromTicks(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMilliseconds(double)"/>
    public static TimeSpan GetTimeSpanMilliseconds(this byte value)
    {
        return TimeSpan.FromMilliseconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromSeconds(double)"/>
    public static TimeSpan GetTimeSpanSeconds(this byte value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMinutes(double)"/>
    public static TimeSpan GetTimeSpanMinutes(this byte value)
    {
        return TimeSpan.FromMinutes(value);
    }

    /// <inheritdoc cref="TimeSpan.FromHours(double)"/>
    public static TimeSpan GetTimeSpanHours(this byte value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <inheritdoc cref="TimeSpan.FromDays(double)"/>
    public static TimeSpan GetTimeSpanDays(this byte value)
    {
        return TimeSpan.FromDays(value);
    }
}
