namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="double.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static double ToDouble(this ReadOnlySpan<char> chars,
                                  NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                  IFormatProvider? formatProvider = null)
    {
        return double.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="double.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static double ToDouble(this Span<char> chars,
                                  NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                  IFormatProvider? formatProvider = null)
    {
        return double.Parse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="double.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out double)"/>
    public static bool TryToSingle(this ReadOnlySpan<char> chars,
                                   out double result,
                                   NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                   IFormatProvider? formatProvider = null)
    {
        return double.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }

    /// <inheritdoc cref="double.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out double)"/>
    public static bool TryToSingle(this Span<char> chars,
                                   out double result,
                                   NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
                                   IFormatProvider? formatProvider = null)
    {
        return double.TryParse(chars, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}