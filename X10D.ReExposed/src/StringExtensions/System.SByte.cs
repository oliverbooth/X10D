namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="sbyte.Parse(string,NumberStyles,IFormatProvider)"/>
    public static sbyte ToSByte(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return sbyte.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="sbyte.TryParse(string,out sbyte)"/>
    public static bool TryToSByte([NotNullWhen(true)] this string? s,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, out result);
    }

    /// <inheritdoc cref="sbyte.TryParse(string,IFormatProvider,out sbyte)"/>
    public static bool TryToSByte([NotNullWhen(true)] this string? s,
                                  IFormatProvider? provider,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="sbyte.TryParse(string,NumberStyles,IFormatProvider,out sbyte)"/>
    public static bool TryToSByte([NotNullWhen(true)] this string? s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, style, provider, out result);
    }
}