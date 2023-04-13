namespace X10D.ReExposed.StreamExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StreamExtensions
{
    /// <inheritdoc cref="System.Text.Json.JsonSerializer.Deserialize{T}(string,JsonSerializerOptions)"/>
    public static async ValueTask<TValue?> AsyncJsonTo<TValue>(this Stream value, JsonSerializerOptions? serializerOptions = null)
    {
        return await JsonSerializer.DeserializeAsync<TValue>(value, serializerOptions);
    }

    /// <inheritdoc cref="System.Text.Json.JsonSerializer.SerializeAsync{T}(Stream,T,JsonSerializerOptions,CancellationToken)"/>
    public static async Task ToJsonAsync<TValue>(this Stream stream,
                                                 TValue value,
                                                 JsonSerializerOptions? serializerOptions = null,
                                                 CancellationToken cancellationToken = default)
    {
        await JsonSerializer.SerializeAsync(stream, value, serializerOptions, cancellationToken);
    }
}