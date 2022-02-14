using System.Web;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="Dictionary{TKey,TValue}" /> and similar types.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to an data connection
    ///     string.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="value">The source dictionary.</param>
    /// <returns>A <see cref="string" /> representing the dictionary as a <c>key=value;</c> set.</returns>
    public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        static string SanitizeValue(string? value)
        {
            if (value is null)
            {
                return string.Empty;
            }

            for (var index = 0; index < value.Length; index++)
            {
                if (char.IsWhiteSpace(value[index]))
                {
                    return $"\"{value}\"";
                }
            }

            return value;
        }

        var list = new List<string>();

        // ReSharper disable once UseDeconstruction
        // .NET Standard 2.0 does not support tuple deconstruct for KeyValuePair<K, V>
        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var pair in value)
        {
            list.Add($"{pair.Key}={SanitizeValue(pair.Value?.ToString())}");
        }

        return string.Join(";", list);
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a HTTP GET parameter
    ///     string.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="value">The source dictionary.</param>
    /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value&amp; set.</returns>
    public static string ToGetParameters<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        static string Sanitize(KeyValuePair<TKey, TValue> pair)
        {
            string? key = HttpUtility.UrlEncode(pair.Key?.ToString());
            string? value = HttpUtility.UrlEncode(pair.Value?.ToString());
            return $"{key}={value}";
        }

        var list = new List<string>();

        foreach (var pair in value)
        {
            list.Add(Sanitize(pair));
        }

        return string.Join(";", list);
    }
}
