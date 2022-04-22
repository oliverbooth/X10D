using System.Text.Json;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="string" />.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Returns an object from the specified JSON string.
    /// </summary>
    /// <param name="value">The JSON to convert.</param>
    /// <param name="options">The JSON serialization options.</param>
    /// <typeparam name="T">The type of the value to deserialize.</typeparam>
    /// <returns>
    ///     An object constructed from the JSON string, or <see langword="null" /> if deserialization could not be performed.
    /// </returns>
    public static T? FromJson<T>(this string value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(value, options);
    }
}
