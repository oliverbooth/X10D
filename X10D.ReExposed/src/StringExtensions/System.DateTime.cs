namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="DateTime.Parse(string,IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTime(this string s,
                                      IFormatProvider? provider = null,
                                      DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.Parse(s, provider, styles);
    }

    /// <inheritdoc cref="DateTime.ParseExact(string,string,IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTimeExact(this string s,
                                           [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format,
                                           IFormatProvider? provider = null,
                                           DateTimeStyles style = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, format, provider, style);
    }

    /// <inheritdoc cref="DateTime.ParseExact(string,string[],IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTimeExact(this string s,
                                           [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string[] formats,
                                           IFormatProvider? provider = null,
                                           DateTimeStyles style = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, formats, provider, style);
    }

    /// <inheritdoc cref="DateTime.TryParse(string,out DateTime)"/>
    public static bool TryToDateTime([NotNullWhen(true)] string? s,
                                     out DateTime result)
    {
        return DateTime.TryParse(s, out result);
    }

    /// <inheritdoc cref="DateTime.TryParse(string,IFormatProvider,out DateTime)"/>
    public static bool TryToDateTime([NotNullWhen(true)] string? s,
                                     IFormatProvider? provider,
                                     out DateTime result)
    {
        return DateTime.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="DateTime.TryParse(string,IFormatProvider,DateTimeStyles,out DateTime)"/>
    public static bool TryToDateTime([NotNullWhen(true)] string? s,
                                     IFormatProvider? provider,
                                     DateTimeStyles styles,
                                     out DateTime result)
    {
        return DateTime.TryParse(s, provider, styles, out result);
    }

    /// <inheritdoc cref="DateTime.TryParseExact(string,string,IFormatProvider,DateTimeStyles,out DateTime)"/>
    public static bool TryToDateTimeExact([NotNullWhen(true)] this string? s,
                                          [NotNullWhen(true)][StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string? format,
                                          IFormatProvider? provider,
                                          DateTimeStyles style,
                                          out DateTime result)
    {
        return DateTime.TryParseExact(s, format, provider, style, out result);
    }

    /// <inheritdoc cref="DateTime.TryParseExact(string,string[],IFormatProvider,DateTimeStyles,out DateTime)"/>
    public static bool TryToDateTimeExact([NotNullWhen(true)] this string? s,
                                          [NotNullWhen(true)][StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string?[]? formats,
                                          IFormatProvider? provider,
                                          DateTimeStyles style,
                                          out DateTime result)
    {
        return DateTime.TryParseExact(s, formats, provider, style, out result);
    }
}