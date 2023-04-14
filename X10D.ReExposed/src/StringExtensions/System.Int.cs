namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="int.Parse(string,NumberStyles,IFormatProvider)"/>
    public static int ToInt32(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = null)
    {
        return int.Parse(s, style, provider);
    }

    /// <inheritdoc cref="int.TryParse(string,out int)"/>
    public static bool TryToInt32([NotNullWhen(true)] this string? s,
                                  out int result)
    {
        return int.TryParse(s, out result);
    }

    /// <inheritdoc cref="int.TryParse(string,IFormatProvider,out int)"/>
    public static bool TryToInt32([NotNullWhen(true)] this string? s,
                                  IFormatProvider? provider,
                                  out int result)
    {
        return int.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="int.TryParse(string,NumberStyles,IFormatProvider,out int)"/>
    public static bool TryToInt32([NotNullWhen(true)] this string? s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out int result)
    {
        return int.TryParse(s, style, provider, out result);
    }
}