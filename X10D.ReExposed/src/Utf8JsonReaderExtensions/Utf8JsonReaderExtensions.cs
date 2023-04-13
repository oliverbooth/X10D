namespace X10D.ReExposed.Utf8JsonReaderExtensions;

/// <summary>
///     Extension methods for <see cref="Utf8JsonReader"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class Utf8JsonReaderExtensions
{
    /// <inheritdoc cref="JsonSerializer.Deserialize{T}(ref Utf8JsonReader,JsonSerializerOptions)"/>
    public static TValue? JsonTo<TValue>(this ref Utf8JsonReader reader, JsonSerializerOptions? serializerOptions = null)
    {
        return JsonSerializer.Deserialize<TValue>(ref reader, serializerOptions);
    }
}