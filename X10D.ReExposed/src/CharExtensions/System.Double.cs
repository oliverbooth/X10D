namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="double.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static double ToDouble(this ReadOnlySpan<char> s,
                                  NumberStyles style = NumberStyles.Number,
                                  IFormatProvider? provider = null)
    {
        return double.Parse(s, style, provider);
    }

    /// <inheritdoc cref="double.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static double ToDouble(this Span<char> s,
                                  NumberStyles style = NumberStyles.Number,
                                  IFormatProvider? provider = null)
    {
        return double.Parse(s, style, provider);
    }

    /// <inheritdoc cref="double.TryParse(ReadOnlySpan{char},out double)"/>
    public static bool TryToDouble(this ReadOnlySpan<char> s,
                                   out double result)
    {
        return double.TryParse(s, out result);
    }

    /// <inheritdoc cref="double.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out double)"/>
    public static bool TryToDouble(this ReadOnlySpan<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out double result)
    {
        return double.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="double.TryParse(ReadOnlySpan{char},out double)"/>
    public static bool TryToDouble(this Span<char> s,
                                   out double result)
    {
        return double.TryParse(s, out result);
    }

    /// <inheritdoc cref="double.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out double)"/>
    public static bool TryToDouble(this Span<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out double result)
    {
        return double.TryParse(s, style, provider, out result);
    }
}