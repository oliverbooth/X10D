namespace X10D.ReExposed.DecimalExtensions.DoubleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DoubleExtensions
{
    /// <inheritdoc cref="double.IsFinite(double)"/>
    public static bool IsFinite(this double d)
    {
        return double.IsFinite(d);
    }

    /// <inheritdoc cref="double.IsInfinity(double)"/>
    public static bool IsInfinity(this double d)
    {
        return double.IsInfinity(d);
    }

    /// <inheritdoc cref="double.IsNaN(double)"/>
    public static bool IsNaN(this double d)
    {
        return double.IsNaN(d);
    }

    /// <inheritdoc cref="double.IsNegative(double)"/>
    public static bool IsNegative(this double d)
    {
        return double.IsNegative(d);
    }

    /// <inheritdoc cref="double.IsNegativeInfinity(double)"/>
    public static bool IsNegativeInfinity(this double d)
    {
        return double.IsNegativeInfinity(d);
    }

    /// <inheritdoc cref="double.IsNormal(double)"/>
    public static bool IsNormal(this double d)
    {
        return double.IsNormal(d);
    }

    /// <inheritdoc cref="double.IsPositiveInfinity(double)"/>
    public static bool IsPositiveInfinity(this double d)
    {
        return double.IsPositiveInfinity(d);
    }

    /// <inheritdoc cref="double.IsSubnormal(double)"/>
    public static bool IsSubnormal(this double d)
    {
        return double.IsSubnormal(d);
    }
}