namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="long.Parse(string,NumberStyles,IFormatProvider)"/>
    public static long ToInt64(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return long.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="long.TryParse(string,NumberStyles,IFormatProvider,out long)"/>
    public static bool TryToInt64(this string value,
                                  out long result,
                                  NumberStyles style = NumberStyles.Number,
                                  IFormatProvider? formatProvider = null)
    {
        return long.TryParse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}