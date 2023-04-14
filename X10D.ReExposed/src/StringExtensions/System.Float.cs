namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="float.Parse(string,NumberStyles,IFormatProvider)"/>
    public static float ToSingle(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return float.Parse(s, style, formatProvider);
    }

    /// <inheritdoc cref="float.TryParse(string,out float)"/>
    public static bool TryToSingle([NotNullWhen(true)] this string? s,
                                   out float result)
    {
        return float.TryParse(s, out result);
    }

    /// <inheritdoc cref="float.TryParse(string,IFormatProvider,out float)"/>
    public static bool TryToSingle([NotNullWhen(true)] this string? s,
                                   IFormatProvider? provider,
                                   out float result)
    {
        return float.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="float.TryParse(string,NumberStyles,IFormatProvider,out float)"/>
    public static bool TryToSingle([NotNullWhen(true)] this string? s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out float result)
    {
        return float.TryParse(s, style, provider, out result);
    }
}