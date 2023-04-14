namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="byte.Parse(string,NumberStyles,IFormatProvider)"/>
    public static byte ToByte(this string value,
                              NumberStyles style = NumberStyles.Integer,
                              IFormatProvider? formatProvider = null)
    {
        return byte.Parse(value, style, formatProvider);
    }

    /// <inheritdoc cref="byte.TryParse(string,out byte)"/>
    public static bool TryToByte([NotNullWhen(true)] this string? s,
                                 out byte result)
    {
        return byte.TryParse(s, out result);
    }

    /// <inheritdoc cref="byte.TryParse(string,IFormatProvider,out byte)"/>
    public static bool TryToByte([NotNullWhen(true)] this string? s,
                                 IFormatProvider? provider,
                                 out byte result)
    {
        return byte.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="byte.TryParse(string,NumberStyles,IFormatProvider,out byte)"/>
    public static bool TryToByte([NotNullWhen(true)] this string? s,
                                 NumberStyles style,
                                 IFormatProvider? provider,
                                 out byte result)
    {
        return byte.TryParse(s, style, provider, out result);
    }
}