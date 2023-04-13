using X10D.ReExposed.DecimalExtensions.DoubleExtensions;

namespace X10D.ReExposed.CharExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class CharExtensions
{
    /// <inheritdoc cref="DoubleExtensions.GetBytes"/>
    public static byte[] GetBytes(this char value)
    {
        return BitConverter.GetBytes(value);
    }
}