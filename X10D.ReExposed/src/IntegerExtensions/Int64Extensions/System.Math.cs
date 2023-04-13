namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="Math.Abs(long)"/>
    public static long Abs(this long value)
    {
        return Math.Abs(value);
    }

    /// <inheritdoc cref="Math.BigMul(long,long,out long)"/>
    public static long BigMul(this long value, long value2, out long result)
    {
        return Math.BigMul(value, value2, out result);
    }

    /// <inheritdoc cref="Math.Clamp(long,long,long)"/>
    public static long Clamp(this long value, long min, long max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.DivRem(long,long,out long)"/>
    public static long DivRem(this long value, long value2, out long result)
    {
        return Math.DivRem(value, value2, out result);
    }

    /// <inheritdoc cref="Math.Max(long,long)"/>
    public static long Max(this long value, long value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(long,long)"/>
    public static long Min(this long value, long value2)
    {
        return Math.Min(value, value2);
    }

    /// <inheritdoc cref="Math.Sign(long)"/>
    public static int Sign(this long value)
    {
        return Math.Sign(value);
    }
}