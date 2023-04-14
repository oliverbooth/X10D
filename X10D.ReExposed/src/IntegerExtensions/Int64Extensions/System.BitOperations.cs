namespace X10D.ReExposed.IntegerExtensions.Int64Extensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class Int64Extensions
{
    /// <inheritdoc cref="BitOperations.IsPow2(long)"/>
    public static bool IsPow2(this long value)
    {
        return BitOperations.IsPow2(value);
    }

    /// <inheritdoc cref="BitOperations.TrailingZeroCount(long)"/>
    public static long TrailingZeroCount(this long value)
    {
        return BitOperations.TrailingZeroCount(value);
    }
}