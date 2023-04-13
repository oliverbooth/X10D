namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="sbyte.Parse(string,NumberStyles,IFormatProvider)"/>
    public static sbyte ToSByte(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return sbyte.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="sbyte.TryParse(string,NumberStyles,IFormatProvider,out sbyte)"/>
    public static bool TryToSByte(this string value,
                                  out sbyte result,
                                  NumberStyles style = NumberStyles.Number,
                                  IFormatProvider? formatProvider = null)
    {
        return sbyte.TryParse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}