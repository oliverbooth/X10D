namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="ulong.Parse(string,NumberStyles,IFormatProvider)"/>
    public static ulong ToUInt64(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = null)
    {
        return ulong.Parse(s, style, provider);
    }

    /// <inheritdoc cref="ulong.TryParse(string,out ulong)"/>
    public static bool TryToUInt64([NotNullWhen(true)] this string? s,
                                   out ulong result)
    {
        return ulong.TryParse(s, out result);
    }

    /// <inheritdoc cref="ulong.TryParse(string,IFormatProvider,out ulong)"/>
    public static bool TryToUInt64([NotNullWhen(true)] this string? s,
                                   IFormatProvider? provider,
                                   out ulong result)
    {
        return ulong.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="ulong.TryParse(string,NumberStyles,IFormatProvider,out ulong)"/>
    public static bool TryToUInt64([NotNullWhen(true)] this string? s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out ulong result)
    {
        return ulong.TryParse(s, style, provider, out result);
    }
}