namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="short.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static short ToInt16(this ReadOnlySpan<char> chars,
                                NumberStyles style = NumberStyles.Integer,
                                IFormatProvider? formatProvider = null)
    {
        return short.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="short.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static short ToInt16(this Span<char> chars, NumberStyles style = NumberStyles.Integer, IFormatProvider? formatProvider = null)
    {
        return short.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="short.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out short)"/>
    public static bool TryToInt16(this ReadOnlySpan<char> chars,
                                  out short result,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? formatProvider = null)
    {
        return short.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="short.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out short)"/>
    public static bool TryToInt16(this Span<char> chars,
                                  out short result,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? formatProvider = null)
    {
        return short.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}