namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="int.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static int ToInt32(this ReadOnlySpan<char> chars, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return int.Parse(chars, style, provider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="int.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static int ToInt32(this Span<char> chars, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return int.Parse(chars, style, provider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="int.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out int)"/>
    public static bool TryToInt32(this ReadOnlySpan<char> chars,
                                  out int result,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? provider = null)
    {
        return int.TryParse(chars, style, provider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="int.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out int)"/>
    public static bool TryToInt32(this Span<char> chars,
                                  out int result,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? provider = null)
    {
        return int.TryParse(chars, style, provider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}