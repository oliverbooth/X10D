namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

public static partial class Int32Extensions
{
    /// <inheritdoc cref="BitOperations.IsPow2(int)"/>
    public static bool IsPow2(this int value)
    {
        return BitOperations.IsPow2(value);
    }

    /// <inheritdoc cref="BitOperations.TrailingZeroCount(int)"/>
    public static int TrailingZeroCount(this int value)
    {
        return BitOperations.TrailingZeroCount(value);
    }
}