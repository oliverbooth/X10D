namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="sbyte.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static sbyte ToSByte(this ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return sbyte.Parse(s, style, provider);
    }

    /// <inheritdoc cref="sbyte.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static sbyte ToSByte(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
    {
        return sbyte.Parse(s, style, provider);
    }

    /// <inheritdoc cref="sbyte.TryParse(ReadOnlySpan{char},out sbyte)"/>
    public static bool TryToSByte(this ReadOnlySpan<char> s,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, out result);
    }

    /// <inheritdoc cref="sbyte.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out sbyte)"/>
    public static bool TryToSByte(this ReadOnlySpan<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="sbyte.TryParse(ReadOnlySpan{char},out sbyte)"/>
    public static bool TryToSByte(this Span<char> s,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, out result);
    }

    /// <inheritdoc cref="sbyte.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out sbyte)"/>
    public static bool TryToSByte(this Span<char> s,
                                  NumberStyles style,
                                  IFormatProvider? provider,
                                  out sbyte result)
    {
        return sbyte.TryParse(s, style, provider, out result);
    }
}