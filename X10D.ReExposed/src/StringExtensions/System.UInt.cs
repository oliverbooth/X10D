namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="uint.Parse(string,NumberStyles,IFormatProvider)"/>
    public static uint ToUInt32(this string value, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null)
    {
        return uint.Parse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo);
    }

    /// <inheritdoc cref="uint.TryParse(string,NumberStyles,IFormatProvider,out uint)"/>
    public static bool TryToUInt32(this string value,
                                   out uint result,
                                   NumberStyles style = NumberStyles.Number,
                                   IFormatProvider? formatProvider = null)
    {
        return uint.TryParse(value, style, formatProvider ?? NumberFormatInfo.CurrentInfo, out result);
    }
}