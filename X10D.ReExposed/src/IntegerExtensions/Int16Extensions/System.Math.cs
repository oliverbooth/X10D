namespace X10D.ReExposed.IntegerExtensions.Int16Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int16Extensions
{
    /// <inheritdoc cref="Math.Abs(short)"/>
    public static short Abs(this short value)
    {
        return Math.Abs(value);
    }

    /// <inheritdoc cref="Math.Clamp(short,short,short)"/>
    public static short Clamp(this short value, short min, short max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.Max(short,short)"/>
    public static short Max(this short value, short value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(short,short)"/>
    public static short Min(this short value, short value2)
    {
        return Math.Min(value, value2);
    }

    /// <inheritdoc cref="Math.Sign(short)"/>
    public static int Sign(this short value)
    {
        return Math.Sign(value);
    }
}