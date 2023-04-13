namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="ushort.Parse(string,NumberStyles,IFormatProvider)"/>
    public static ushort ToUInt16(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return ushort.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="ushort.TryParse(string,NumberStyles,IFormatProvider,out ushort)"/>
    public static bool TryToUInt16(this string value,
                                   out ushort result,
                                   NumberStyles style = NumberStyles.Number,
                                   IFormatProvider? formatProvider = null)
    {
        return ushort.TryParse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}