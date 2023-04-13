namespace X10D.ReExposed.DecimalExtensions.DoubleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DoubleExtensions
{
    /// <inheritdoc cref="double.IsFinite(double)"/>
    public static bool IsFinite(this double value)
    {
        return double.IsFinite(value);
    }

    /// <inheritdoc cref="double.IsInfinity(double)"/>
    public static bool IsInfinity(this double value)
    {
        return double.IsInfinity(value);
    }

    /// <inheritdoc cref="double.IsNaN(double)"/>
    public static bool IsNaN(this double value)
    {
        return double.IsNaN(value);
    }

    /// <inheritdoc cref="double.IsNegative(double)"/>
    public static bool IsNegative(this double value)
    {
        return double.IsNegative(value);
    }

    /// <inheritdoc cref="double.IsNegativeInfinity(double)"/>
    public static bool IsNegativeInfinity(this double value)
    {
        return double.IsNegativeInfinity(value);
    }

    /// <inheritdoc cref="double.IsNormal(double)"/>
    public static bool IsNormal(this double value)
    {
        return double.IsNormal(value);
    }

    /// <inheritdoc cref="double.IsPositiveInfinity(double)"/>
    public static bool IsPositiveInfinity(this double value)
    {
        return double.IsPositiveInfinity(value);
    }

    /// <inheritdoc cref="double.IsSubnormal(double)"/>
    public static bool IsSubnormal(this double value)
    {
        return double.IsSubnormal(value);
    }
}