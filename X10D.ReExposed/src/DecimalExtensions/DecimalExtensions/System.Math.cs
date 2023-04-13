namespace X10D.ReExposed.DecimalExtensions.DecimalExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DecimalExtensions
{
    /// <inheritdoc cref="Math.Abs(decimal)"/>
    public static decimal Abs(this decimal value)
    {
        return Math.Abs(value);
    }

    /// <inheritdoc cref="Math.Clamp(decimal,decimal,decimal)"/>
    public static decimal Clamp(this decimal value, decimal min, decimal max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.Max(decimal,decimal)"/>
    public static decimal Max(this decimal value, decimal value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(decimal,decimal)"/>
    public static decimal Min(this decimal value, decimal value2)
    {
        return Math.Min(value, value2);
    }

    /// <inheritdoc cref="Math.Sign(decimal)"/>
    public static int Sign(this decimal value)
    {
        return Math.Sign(value);
    }
}