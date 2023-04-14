namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Encoding.GetBytes(string)"/>
    public static byte[] GetBytes(this string value)
    {
        return Encoding.Default.GetBytes(value);
    }

    /// <inheritdoc cref="Encoding.GetBytes(string)"/>
    public static byte[] GetBytes(this string value, Encoding encoding)
    {
        return encoding.GetBytes(value);
    }
}