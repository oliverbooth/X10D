namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="ulong.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ulong ToUInt64(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return ulong.Parse(s, style, provider);
    }

    /// <inheritdoc cref="ulong.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ulong ToUInt64(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return ulong.Parse(s, style, provider);
    }

    /// <inheritdoc cref="ulong.TryParse(ReadOnlySpan{char},out ulong)"/>
    public static bool TryToUInt64(this ReadOnlySpan<char> s,
                                   out ulong result)
    {
        return ulong.TryParse(s, out result);
    }

    /// <inheritdoc cref="ulong.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ulong)"/>
    public static bool TryToUInt64(this ReadOnlySpan<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out ulong result)
    {
        return ulong.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="ulong.TryParse(ReadOnlySpan{char},out ulong)"/>
    public static bool TryToUInt64(this Span<char> s,
                                   out ulong result)
    {
        return ulong.TryParse(s, out result);
    }

    /// <inheritdoc cref="ulong.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ulong)"/>
    public static bool TryToUInt64(this Span<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out ulong result)
    {
        return ulong.TryParse(s, style, provider, out result);
    }
}