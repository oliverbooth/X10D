namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="byte.Parse(string,NumberStyles,IFormatProvider)"/>
    public static byte ToByte(this string value, NumberStyles style = NumberStyles.Integer, IFormatProvider? formatProvider = null)
    {
        return byte.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="byte.TryParse(string,NumberStyles,IFormatProvider,out byte)"/>
    public static bool TryToByte(this string value,
                                 out byte result,
                                 NumberStyles style = NumberStyles.Integer,
                                 IFormatProvider? formatProvider = null)
    {
        return byte.TryParse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}