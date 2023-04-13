namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="short.Parse(string,NumberStyles,IFormatProvider)"/>
    public static short ToInt16(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return short.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="short.TryParse(string,NumberStyles,IFormatProvider,out short)"/>
    public static bool TryToInt16(this string value,
                                  out short result,
                                  NumberStyles style = NumberStyles.Number,
                                  IFormatProvider? formatProvider = null)
    {
        return short.TryParse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}