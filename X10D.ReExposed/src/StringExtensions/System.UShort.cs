namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="ushort.Parse(string,NumberStyles,IFormatProvider)"/>
    public static ushort ToUInt16(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = null)
    {
        return ushort.Parse(s, style, provider);
    }

    /// <inheritdoc cref="ushort.TryParse(string,out ushort)"/>
    public static bool TryToUInt16([NotNullWhen(true)] this string? s,
                                   out ushort result)
    {
        return ushort.TryParse(s, out result);
    }

    /// <inheritdoc cref="ushort.TryParse(string,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16([NotNullWhen(true)] this string? s,
                                   IFormatProvider? provider,
                                   out ushort result)
    {
        return ushort.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="ushort.TryParse(string,NumberStyles,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16([NotNullWhen(true)] this string? s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out ushort result)
    {
        return ushort.TryParse(s, style, provider, out result);
    }
}