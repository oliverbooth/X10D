namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="string.Create{T}(int,T,SpanAction{char,T})"/>
    public static string CreateString<TState>(this int length, TState state, SpanAction<char, TState> action)
    {
        return string.Create(length, state, action);
    }
}