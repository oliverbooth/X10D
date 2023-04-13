namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="System.Text.Json.JsonSerializer.Deserialize{T}(string,JsonSerializerOptions)"/>
    public static T? JsonTo<T>(this string value, JsonSerializerOptions? serializerOptions = null)
    {
        return JsonSerializer.Deserialize<T>(value, serializerOptions);
    }
}