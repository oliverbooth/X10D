namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="uint.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static uint ToUInt132(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return uint.Parse(s, style, provider);
    }

    /// <inheritdoc cref="uint.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static uint ToUInt132(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return uint.Parse(s, style, provider);
    }

    /// <inheritdoc cref="uint.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out uint)"/>
    public static bool TryToUInt132(this ReadOnlySpan<char> s,
                                    NumberStyles style,
                                    IFormatProvider? provider,
                                    out uint result)
    {
        return uint.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="uint.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out uint)"/>
    public static bool TryToUInt132(this Span<char> s,
                                    NumberStyles style,
                                    IFormatProvider? provider,
                                    out uint result)
    {
        return uint.TryParse(s, style, provider, out result);
    }
}