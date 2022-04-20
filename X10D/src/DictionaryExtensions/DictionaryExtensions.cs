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
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>;</c>.</returns>
    public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        static string SanitizeValue(string? value)
        {
            if (value is null)
            {
                return string.Empty;
            }

            foreach (char character in value)
            {
                if (char.IsWhiteSpace(character))
                {
                    return $"\"{value}\"";
                }
            }

            return value;
        }

        static string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            return $"{pair.Key}={SanitizeValue(pair.Value?.ToString())}");
        }

        return string.Join(';', source.Select(GetQueryParameter));
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a HTTP GET query string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>&amp;</c>.</returns>
    public static string ToGetParameters<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        static string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            string key = HttpUtility.UrlEncode(pair.Key.ToString())!;
            string? value = HttpUtility.UrlEncode(pair.Value?.ToString());
            return $"{key}={value}";
        }

        return string.Join('&', source.Select(GetQueryParameter));
    }
}
