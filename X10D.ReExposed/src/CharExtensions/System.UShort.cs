namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="ushort.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ushort ToUInt16(this ReadOnlySpan<char> chars,
                                  NumberStyles style = NumberStyles.Integer,
                                  IFormatProvider? formatProvider = null)
    {
        return ushort.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="ushort.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static ushort ToUInt16(this Span<char> chars, NumberStyles style = NumberStyles.Integer, IFormatProvider? formatProvider = null)
    {
        return ushort.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="ushort.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16(this ReadOnlySpan<char> chars,
                                   out ushort result,
                                   NumberStyles style = NumberStyles.Integer,
                                   IFormatProvider? formatProvider = null)
    {
        return ushort.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="ushort.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16(this Span<char> chars,
                                   out ushort result,
                                   NumberStyles style = NumberStyles.Integer,
                                   IFormatProvider? formatProvider = null)
    {
        return ushort.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}