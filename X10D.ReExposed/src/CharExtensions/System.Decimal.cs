namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="decimal.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static decimal ToDecimal(this ReadOnlySpan<char> s,
                                    NumberStyles style = NumberStyles.Number,
                                    IFormatProvider? provider = null)
    {
        return decimal.Parse(s, style, provider);
    }

    /// <inheritdoc cref="decimal.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static decimal ToDecimal(this Span<char> s,
                                    NumberStyles style = NumberStyles.Number,
                                    IFormatProvider? provider = null)
    {
        return decimal.Parse(s, style, provider);
    }

    /// <inheritdoc cref="decimal.TryParse(ReadOnlySpan{char},out decimal)"/>
    public static bool TryToDecimal(this ReadOnlySpan<char> s,
                                    out decimal result)
    {
        return decimal.TryParse(s, out result);
    }

    /// <inheritdoc cref="decimal.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out decimal)"/>
    public static bool TryToDecimal(this ReadOnlySpan<char> s,
                                    NumberStyles style,
                                    IFormatProvider? provider,
                                    out decimal result)
    {
        return decimal.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="decimal.TryParse(ReadOnlySpan{char},out decimal)"/>
    public static bool TryToDecimal(this Span<char> s,
                                    out decimal result)
    {
        return decimal.TryParse(s, out result);
    }

    /// <inheritdoc cref="decimal.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out decimal)"/>
    public static bool TryToDecimal(this Span<char> s,
                                    NumberStyles style,
                                    IFormatProvider? provider,
                                    out decimal result)
    {
        return decimal.TryParse(s, style, provider, out result);
    }
}