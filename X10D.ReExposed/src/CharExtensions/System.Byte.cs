﻿namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="byte.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static byte ToByte(this ReadOnlySpan<char> s,
                              NumberStyles style = NumberStyles.Integer,
                              IFormatProvider? provider = null)
    {
        return byte.Parse(s, style, provider);
    }

    /// <inheritdoc cref="byte.Parse(ReadOnlySpan{char},NumberStyles,IFormatProvider)"/>
    public static byte ToByte(this Span<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? formatProvider = null)
    {
        return byte.Parse(s, style, formatProvider);
    }

    /// <inheritdoc cref="byte.TryParse(ReadOnlySpan{char},out byte)"/>
    public static bool TryParse(this ReadOnlySpan<char> s, out byte result)
    {
        return byte.TryParse(s, out result);
    }

    /// <inheritdoc cref="byte.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out byte)"/>
    public static bool TryToByte(this ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out byte result)
    {
        return byte.TryParse(s, style, provider, out result);
    }

    /// <inheritdoc cref="byte.TryParse(ReadOnlySpan{char},out byte)"/>
    public static bool TryParse(this Span<char> s, out byte result)
    {
        return byte.TryParse(s, out result);
    }

    /// <inheritdoc cref="byte.TryParse(ReadOnlySpan{char},NumberStyles,IFormatProvider,out byte)"/>
    public static bool TryToByte(this Span<char> s, NumberStyles style, IFormatProvider? provider, out byte result)
    {
        return byte.TryParse(s, style, provider, out result);
    }
}