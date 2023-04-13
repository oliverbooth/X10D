namespace X10D.ReExposed.IntegerExtensions.UInt64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class UInt64Extensions
{
    /// <inheritdoc cref="Math.BigMul(ulong,ulong,out ulong)"/>
    public static ulong BigMul(this ulong value, ulong value2, out ulong result)
    {
        return Math.BigMul(value, value2, out result);
    }

    /// <inheritdoc cref="Math.Clamp(ulong,ulong,ulong)"/>
    public static ulong Clamp(this ulong value, ulong min, ulong max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.Max(ulong,ulong)"/>
    public static ulong Max(this ulong value, ulong value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(ulong,ulong)"/>
    public static ulong Min(this ulong value, ulong value2)
    {
        return Math.Min(value, value2);
    }
}