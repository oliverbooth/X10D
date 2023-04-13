namespace X10D.ReExposed.IntegerExtensions.ByteExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class ByteExtensions
{
    /// <inheritdoc cref="System.Text.Json.JsonSerializer.Deserialize{T}(ReadOnlySpan{byte},JsonSerializerOptions)"/>
    public static TValue? JsonTo<TValue>(this ReadOnlySpan<byte> value, JsonSerializerOptions? serializerOptions = null)
    {
        return JsonSerializer.Deserialize<TValue>(value, serializerOptions);
    }

    /// <inheritdoc cref="System.Text.Json.JsonSerializer.Deserialize{T}(ReadOnlySpan{byte},JsonSerializerOptions)"/>
    public static TValue? JsonTo<TValue>(this Span<byte> value, JsonSerializerOptions? serializerOptions = null)
    {
        return JsonSerializer.Deserialize<TValue>(value, serializerOptions);
    }
}