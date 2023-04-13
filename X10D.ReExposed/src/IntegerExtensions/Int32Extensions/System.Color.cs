namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

/// <summary>
///     Extension methods for <see cref="Color"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="Color.FromArgb(int)"/>
    public static Color ToColor(this int value)
    {
        return Color.FromArgb(value);
    }
}