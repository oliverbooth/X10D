namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="ulong.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ulong ToUInt64(this ReadOnlySpan<char> chars,
                                 NumberStyles style = NumberStyles.Integer,
                                 IFormatProvider? formatProvider = null)
    {
        return ulong.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="ulong.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ulong ToUInt64(this Span<char> chars, NumberStyles style = NumberStyles.Integer, IFormatProvider? formatProvider = null)
    {
        return ulong.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="ulong.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ulong)"/>
    public static bool TryToUInt64(this ReadOnlySpan<char> chars,
                                   out ulong result,
                                   NumberStyles style = NumberStyles.Integer,
                                   IFormatProvider? formatProvider = null)
    {
        return ulong.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="ulong.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ulong)"/>
    public static bool TryToUInt64(this Span<char> chars,
                                   out ulong result,
                                   NumberStyles style = NumberStyles.Integer,
                                   IFormatProvider? formatProvider = null)
    {
        return ulong.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}