using System.Text.Json;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for all types.
/// </summary>
public static class Extensions
{
    /// <summary>
    ///     Returns a JSON string representation of the specified value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="options">The JSON serialization options.</param>
    /// <typeparam name="T">The type of the value to convert.</typeparam>
    /// <returns>A JSON string representing the object.</returns>
    public static string ToJson<T>(this T value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(value, options);
    }
}
