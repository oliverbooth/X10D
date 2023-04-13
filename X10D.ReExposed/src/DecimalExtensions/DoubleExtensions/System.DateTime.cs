namespace X10D.ReExposed.DecimalExtensions.DoubleExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DoubleExtensions
{
    /// <inheritdoc cref="DateTime.FromOADate(double)"/>
    public static DateTime FromOADate(this double value)
    {
        return DateTime.FromOADate(value);
    }
}