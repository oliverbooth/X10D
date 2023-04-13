namespace X10D.ReExposed.IntegerExtensions.Int16Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int16Extensions
{
    /// <inheritdoc cref="TimeSpan.FromTicks(long)"/>
    public static TimeSpan GetTimeSpanTicks(this short value)
    {
        return TimeSpan.FromTicks(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMilliseconds(double)"/>
    public static TimeSpan GetTimeSpanMilliseconds(this short value)
    {
        return TimeSpan.FromMilliseconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromSeconds(double)"/>
    public static TimeSpan GetTimeSpanSeconds(this short value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <inheritdoc cref="TimeSpan.FromMinutes(double)"/>
    public static TimeSpan GetTimeSpanMinutes(this short value)
    {
        return TimeSpan.FromMinutes(value);
    }

    /// <inheritdoc cref="TimeSpan.FromHours(double)"/>
    public static TimeSpan GetTimeSpanHours(this short value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <inheritdoc cref="TimeSpan.FromDays(double)"/>
    public static TimeSpan GetTimeSpanDays(this short value)
    {
        return TimeSpan.FromDays(value);
    }
}
