namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="long.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static long ToInt64(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return long.Parse(s, style, provider);
    }

    /// <inheritdoc cref="long.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static long ToInt64(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return long.Parse(s, style, provider);
    }

    /// <inheritdoc cref="long.TryParse(ReadOnlySpan{char},out long)"/>
    public static bool TryToInt64(this ReadOnlySpan<char> s,
                                  out long result)
    {
        return long.TryParse(s, out result);
    }

    /// <inheritdoc cref="long.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out long)"/>
    public static bool TryToInt64(this ReadOnlySpan<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out long result)
    {
        return long.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="long.TryParse(ReadOnlySpan{char},out long)"/>
    public static bool TryToInt64(this Span<char> s,
                                  out long result)
    {
        return long.TryParse(s, out result);
    }

    /// <inheritdoc cref="long.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out long)"/>
    public static bool TryToInt64(this Span<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out long result)
    {
        return long.TryParse(s, style, provider, out result);
    }
}