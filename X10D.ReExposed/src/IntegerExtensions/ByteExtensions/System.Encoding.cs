namespace X10D.ReExposed.IntegerExtensions.ByteExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class ByteExtensions
{
    /// <inheritdoc cref="Encoding.GetString(byte[])"/>
    public static string GetString(this byte[] bytes, Encoding? encoding = null)
    {
        return (encoding ?? Encoding.Default).GetString(bytes);
    }
}