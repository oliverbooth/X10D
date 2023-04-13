namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="long.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static long ToInt64(this ReadOnlySpan<char> chars,
                               NumberStyles style = NumberStyles.Integer,
                               IFormatProvider? formatProvider = null)
    {
        return long.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="long.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static long ToInt64(this Span<char> chars, NumberStyles style = NumberStyles.Integer, IFormatProvider? formatProvider = null)
    {
        return long.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="long.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out long)"/>
    public static bool TryToInt64(this ReadOnlySpan<char> chars,
                                  out long result,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? formatProvider = null)
    {
        return long.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="long.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out long)"/>
    public static bool TryToInt64(this Span<char> chars,
                                  out long result,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? formatProvider = null)
    {
        return long.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}