namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="uint.Parse(string,NumberStyles,IFormatProvider)"/>
    public static uint ToUInt32(this string s, NumberStyles style = NumberStyles.Number, IFormatProvider? provider = null)
    {
        return uint.Parse(s, style, provider);
    }

    /// <inheritdoc cref="uint.TryParse(string,out uint)"/>
    public static bool TryToUInt32([NotNullWhen(true)] this string? s,
                                   out uint result)
    {
        return uint.TryParse(s, out result);
    }

    /// <inheritdoc cref="uint.TryParse(string,IFormatProvider,out uint)"/>
    public static bool TryToUInt32([NotNullWhen(true)] this string? s,
                                   IFormatProvider? provider,
                                   out uint result)
    {
        return uint.TryParse(s, provider, out result);
    }

    /// <inheritdoc cref="uint.TryParse(string,NumberStyles,IFormatProvider,out uint)"/>
    public static bool TryToUInt32([NotNullWhen(true)] this string? s,
                                   NumberStyles style,
                                   IFormatProvider? provider,
                                   out uint result)
    {
        return uint.TryParse(s, style, provider, out result);
    }
}