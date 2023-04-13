namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Encoding.GetBytes(string)"/>
    public static byte[] GetBytes(this string value, Encoding? encoding = null)
    {
        return (encoding ?? Encoding.Default).GetBytes(value);
    }
}