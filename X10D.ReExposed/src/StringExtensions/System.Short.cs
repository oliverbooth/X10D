namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="short.Parse(string,NumberStyles,IFormatProvider)"/>
    public static short ToInt16(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return short.Parse(s, style, formatProvider);
    }

    /// <inheritdoc cref="short.TryParse(string,out short)"/>
    public static bool TryToInt16([NotNullWhen(true)] this string? s,
                                  out short result)
    {
        return short.TryParse(s, out result);
    }

    /// <inheritdoc cref="short.TryParse(string,IFormatProvider,out short)"/>
    public static bool TryToInt16([NotNullWhen(true)] this string? s,
                                  IFormatProvider? provider,
                                  out short result)
    {
        return short.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="short.TryParse(string,NumberStyles,IFormatProvider,out short)"/>
    public static bool TryToInt16([NotNullWhen(true)] this string? s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out short result)
    {
        return short.TryParse(s, style, provider, out result);
    }
}