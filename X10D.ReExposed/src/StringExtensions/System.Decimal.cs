namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="decimal.Parse(string,NumberStyles,IFormatProvider)"/>
    public static decimal ToDecimal(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = null)
    {
        return decimal.Parse(value, style, provider);
    }

    /// <inheritdoc cref="decimal.TryParse(string,out decimal)"/>
    public static bool TryToDecimal([NotNullWhen(true)] this string? s,
                                    out decimal result)
    {
        return decimal.TryParse(s, out result);
    }

    /// <inheritdoc cref="decimal.TryParse(string,IFormatProvider,out decimal)"/>
    public static bool TryToDecimal([NotNullWhen(true)] this string? s,
                                    IFormatProvider? provider,
                                    out decimal result)
    {
        return decimal.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="decimal.TryParse(string,NumberStyles,IFormatProvider,out decimal)"/>
    public static bool TryToDecimal([NotNullWhen(true)] this string? s,
                                    NumberStyles style,
                                    IFormatProvider? provider,
                                    out decimal result)
    {
        return decimal.TryParse(s, style, provider, out result);
    }
}