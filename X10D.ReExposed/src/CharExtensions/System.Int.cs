namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="int.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static int ToInt32(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return int.Parse(s, style, provider);
    }

    /// <inheritdoc cref="int.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static int ToInt32(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return int.Parse(s, style, provider);
    }

    /// <inheritdoc cref="int.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out int)"/>
    public static bool TryToInt32(this ReadOnlySpan<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out int result)
    {
        return int.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="int.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out int)"/>
    public static bool TryToInt32(this Span<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out int result)
    {
        return int.TryParse(s, style, provider, out result);
    }
}