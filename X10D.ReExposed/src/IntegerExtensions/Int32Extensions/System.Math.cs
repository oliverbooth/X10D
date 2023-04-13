namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="Math.Abs(int)"/>
    public static int Abs(this int value)
    {
        return Math.Abs(value);
    }

    /// <inheritdoc cref="Math.BigMul(int,int)"/>
    public static long BigMul(this int value, int value2)
    {
        return Math.BigMul(value, value2);
    }

    /// <inheritdoc cref="Math.Clamp(int,int,int)"/>
    public static int Clamp(this int value, int min, int max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.DivRem(int,int,out int)"/>
    public static int DivRem(this int value, int value2, out int result)
    {
        return Math.DivRem(value, value2, out result);
    }

    /// <inheritdoc cref="Math.Max(int,int)"/>
    public static int Mac(this int value, int value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(int,int)"/>
    public static int Min(this int value, int value2)
    {
        return Math.Min(value, value2);
    }

    /// <inheritdoc cref="Math.Sign(int)"/>
    public static int Sign(this int value)
    {
        return Math.Sign(value);
    }
}