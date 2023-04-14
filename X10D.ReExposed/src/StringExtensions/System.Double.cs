namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="double.Parse(string,NumberStyles,IFormatProvider)"/>
    public static double ToDouble(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = null)
    {
        return double.Parse(s, style, provider);
    }

    /// <inheritdoc cref="double.TryParse(string,out double)"/>
    public static bool TryToDouble([NotNullWhen(true)] this string? s,
                                   out double result)
    {
        return double.TryParse(s, out result);
    }

    /// <inheritdoc cref="double.TryParse(string,IFormatProvider,out double)"/>
    public static bool TryToDouble([NotNullWhen(true)] this string? s,
                                   IFormatProvider? provider,
                                   out double result)
    {
        return double.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="double.TryParse(string,NumberStyles,IFormatProvider,out double)"/>
    public static bool TryToDouble([NotNullWhen(true)] this string? s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out double result)
    {
        return double.TryParse(s, style, provider, out result);
    }
}