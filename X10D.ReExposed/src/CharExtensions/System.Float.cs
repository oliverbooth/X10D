namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="float.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static float ToSingle(this ReadOnlySpan<char> chars,
                                 NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                 IFormatProvider? formatProvider = null)
    {
        return float.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="float.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static float ToSingle(this Span<char> chars,
                                 NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                 IFormatProvider? formatProvider = null)
    {
        return float.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="float.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out float)"/>
    public static bool TryToSingle(this ReadOnlySpan<char> chars,
                                   out float result,
                                   NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                   IFormatProvider? formatProvider = null)
    {
        return float.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="float.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out float)"/>
    public static bool TryToSingle(this Span<char> chars,
                                   out float result,
                                   NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                   IFormatProvider? formatProvider = null)
    {
        return float.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}