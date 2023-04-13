namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="DateTime.Parse(ReadOnlySpan{char},IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTime(this ReadOnlySpan<char> s,
                                      IFormatProvider? provider = null,
                                      DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.Parse(s, provider, styles);
    }

    /// <inheritdoc cref="DateTime.Parse(ReadOnlySpan{char},IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTime(this Span<char> s,
                                      IFormatProvider? provider = null,
                                      DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.Parse(s, provider, styles);
    }

    /// <inheritdoc cref="DateTime.ParseExact(ReadOnlySpan{char},ReadOnlySpan{char},IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTimeExact(this ReadOnlySpan<char> s,
                                           [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] ReadOnlySpan<char> format,
                                           IFormatProvider? provider,
                                           DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, format, provider, styles);
    }

    /// <inheritdoc cref="DateTime.ParseExact(ReadOnlySpan{char},ReadOnlySpan{char},IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTimeExact(this Span<char> s,
                                           [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] ReadOnlySpan<char> format,
                                           IFormatProvider? provider,
                                           DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, format, provider, styles);
    }

    /// <inheritdoc cref="DateTime.ParseExact(ReadOnlySpan{char},string[],IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTimeExact(this ReadOnlySpan<char> s,
                                           [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string[] formats,
                                           IFormatProvider? provider,
                                           DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, formats, provider, styles);
    }

    /// <inheritdoc cref="DateTime.ParseExact(ReadOnlySpan{char},string[],IFormatProvider,DateTimeStyles)"/>
    public static DateTime ToDateTimeExact(this Span<char> s,
                                           [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string[] formats,
                                           IFormatProvider? provider,
                                           DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, formats, provider, styles);
    }
}