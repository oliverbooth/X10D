namespace X10D.ReExposed.DecimalExtensions.SingleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class SingleExtensions
{
    /// <inheritdoc cref="float.IsFinite(float)"/>
    public static bool IsFinite(this float d)
    {
        return float.IsFinite(d);
    }

    /// <inheritdoc cref="float.IsInfinity(float)"/>
    public static bool IsInfinity(this float d)
    {
        return float.IsInfinity(d);
    }

    /// <inheritdoc cref="float.IsNaN(float)"/>
    public static bool IsNaN(this float d)
    {
        return float.IsNaN(d);
    }

    /// <inheritdoc cref="float.IsNegative(float)"/>
    public static bool IsNegative(this float d)
    {
        return float.IsNegative(d);
    }

    /// <inheritdoc cref="float.IsNegativeInfinity(float)"/>
    public static bool IsNegativeInfinity(this float d)
    {
        return float.IsNegativeInfinity(d);
    }

    /// <inheritdoc cref="float.IsNormal(float)"/>
    public static bool IsNormal(this float d)
    {
        return float.IsNormal(d);
    }

    /// <inheritdoc cref="float.IsPositiveInfinity(float)"/>
    public static bool IsPositiveInfinity(this float d)
    {
        return float.IsPositiveInfinity(d);
    }

    /// <inheritdoc cref="float.IsSubnormal(float)"/>
    public static bool IsSubnormal(this float d)
    {
        return float.IsSubnormal(d);
    }
}