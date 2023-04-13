using X10D.ReExposed.DecimalExtensions.DoubleExtensions;

namespace X10D.ReExposed.BooleanExtensions;

/// <summary>
///     Extension methods for <see cref="bool"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class BooleanExtensions
{
    /// <inheritdoc cref="DoubleExtensions.GetBytes"/>
    public static byte[] GetBytes(this bool value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <inheritdoc cref="BitConverter.TryWriteBytes(Span{byte},bool)"/>
    public static bool TryWriteBytes(this bool value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }
}