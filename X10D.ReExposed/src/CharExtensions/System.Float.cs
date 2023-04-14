namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="float.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static float ToSingle(this ReadOnlySpan<char> s,
                                 NumberStyles style = NumberStyles.Number,
                                 IFormatProvider? provider = null)
    {
        return float.Parse(s, style, provider);
    }

    /// <inheritdoc cref="float.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static float ToSingle(this Span<char> s,
                                 NumberStyles style = NumberStyles.Number,
                                 IFormatProvider? provider = null)
    {
        return float.Parse(s, style, provider);
    }

    /// <inheritdoc cref="float.TryParse(ReadOnlySpan{char},out float)"/>
    public static bool TryToSingle(this ReadOnlySpan<char> s,
                                   out float result)
    {
        return float.TryParse(s, out result);
    }

    /// <inheritdoc cref="float.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out float)"/>
    public static bool TryToSingle(this ReadOnlySpan<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out float result)
    {
        return float.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="float.TryParse(ReadOnlySpan{char},out float)"/>
    public static bool TryToSingle(this Span<char> s,
                                   out float result)
    {
        return float.TryParse(s, out result);
    }

    /// <inheritdoc cref="float.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out float)"/>
    public static bool TryToSingle(this Span<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out float result)
    {
        return float.TryParse(s, style, provider, out result);
    }
}