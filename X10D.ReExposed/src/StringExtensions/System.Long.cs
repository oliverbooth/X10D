namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="long.Parse(string,NumberStyles,IFormatProvider)"/>
    public static long ToInt64(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return long.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="long.TryParse(string,out long)"/>
    public static bool TryToInt64([NotNullWhen(true)] this string? s,
                                  out long result)
    {
        return long.TryParse(s, out result);
    }

    /// <inheritdoc cref="long.TryParse(string,IFormatProvider,out long)"/>
    public static bool TryToInt64([NotNullWhen(true)] this string? s,
                                  IFormatProvider? provider,
                                  out long result)
    {
        return long.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="long.TryParse(string,NumberStyles,IFormatProvider,out long)"/>
    public static bool TryToInt64([NotNullWhen(true)] this string? s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out long result)
    {
        return long.TryParse(s, style, provider, out result);
    }
}