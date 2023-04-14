namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="ushort.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ushort ToUInt16(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return ushort.Parse(s, style, provider);
    }

    /// <inheritdoc cref="ushort.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ushort ToUInt16(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return ushort.Parse(s, style, provider);
    }

    /// <inheritdoc cref="ushort.TryParse(ReadOnlySpan{char},out ushort)"/>
    public static bool TryToUInt16(this ReadOnlySpan<char> s,
                                   out ushort result)
    {
        return ushort.TryParse(s, out result);
    }

    /// <inheritdoc cref="ushort.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16(this ReadOnlySpan<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out ushort result)
    {
        return ushort.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="ushort.TryParse(ReadOnlySpan{char},out ushort)"/>
    public static bool TryToUInt16(this Span<char> s,
                                   out ushort result)
    {
        return ushort.TryParse(s, out result);
    }

    /// <inheritdoc cref="ushort.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16(this Span<char> s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out ushort result)
    {
        return ushort.TryParse(s, style, provider, out result);
    }
}