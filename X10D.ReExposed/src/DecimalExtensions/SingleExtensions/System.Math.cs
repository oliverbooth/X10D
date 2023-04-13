namespace X10D.ReExposed.DecimalExtensions.SingleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class SingleExtensions
{
    /// <inheritdoc cref="Math.Abs(float)"/>
    public static float Abs(this float value)
    {
        return Math.Abs(value);
    }

    /// <inheritdoc cref="Math.Clamp(float,float,float)"/>
    public static float Clamp(this float value, float min, float max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.Max(float,float)"/>
    public static float Max(this float value, float value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(float,float)"/>
    public static float Min(this float value, float value2)
    {
        return Math.Min(value, value2);
    }

    /// <inheritdoc cref="Math.Sign(float)"/>
    public static int Sign(this float value)
    {
        return Math.Sign(value);
    }
}