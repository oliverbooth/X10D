namespace X10D.ReExposed.IntegerExtensions.SByteExtensions;

/// <summary>
///     Extension methods for <see cref="sbyte"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class SByteExtensions
{
    /// <inheritdoc cref="Math.Abs(sbyte)"/>
    public static sbyte Abs(this sbyte value)
    {
        return Math.Abs(value);
    }

    /// <inheritdoc cref="Math.Clamp(sbyte,sbyte,sbyte)"/>
    public static sbyte Clamp(this sbyte value, sbyte min, sbyte max)
    {
        return Math.Clamp(value, min, max);
    }

    /// <inheritdoc cref="Math.Max(sbyte,sbyte)"/>
    public static sbyte Max(this sbyte value, sbyte value2)
    {
        return Math.Max(value, value2);
    }

    /// <inheritdoc cref="Math.Min(sbyte,sbyte)"/>
    public static sbyte Min(this sbyte value, sbyte value2)
    {
        return Math.Min(value, value2);
    }

    /// <inheritdoc cref="Math.Sign(sbyte)"/>
    public static int Sign(this sbyte value)
    {
        return Math.Sign(value);
    }
}