namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="short.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static short ToInt16(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return short.Parse(s, style, provider);
    }

    /// <inheritdoc cref="short.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static short ToInt16(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return short.Parse(s, style, provider);
    }

    /// <inheritdoc cref="short.TryParse(ReadOnlySpan{char},out short)"/>
    public static bool TryToInt16(this ReadOnlySpan<char> s,
                                  out short result)
    {
        return short.TryParse(s, out result);
    }

    /// <inheritdoc cref="short.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out short)"/>
    public static bool TryToInt16(this ReadOnlySpan<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out short result)
    {
        return short.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="short.TryParse(ReadOnlySpan{char},out short)"/>
    public static bool TryToInt16(this Span<char> s,
                                  out short result)
    {
        return short.TryParse(s, out result);
    }

    /// <inheritdoc cref="short.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out short)"/>
    public static bool TryToInt16(this Span<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out short result)
    {
        return short.TryParse(s, style, provider, out result);
    }
}