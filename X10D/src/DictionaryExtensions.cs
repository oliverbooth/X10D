namespace X10D
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    ///     A set of extension methods for <see cref="Dictionary{TKey,TValue}" />.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Converts a <see cref="IReadOnlyDictionary{T1,T2}" /> to an object-relational-safe connection string.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value; set.</returns>
        public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
        {
            static string SanitizeValue<T>(T value)
            {
                return value is string str &&
                       Regex.IsMatch(str, "\\s")
                    ? $"\"{str}\""
                    : value.ToString();
            }

            var strings = dictionary.Select(o => $"{o.Key}={SanitizeValue(o.Value)}");
            return string.Join(";", strings);
        }

        /// <summary>
        ///     Converts an <see cref="IReadOnlyDictionary{T1,T2}" /> to a HTTP GET parameter string.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value& set.</returns>
        public static string ToGetParameters<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
        {
            static string Sanitize(KeyValuePair<TKey, TValue> kvp)
            {
                var key = HttpUtility.UrlEncode(kvp.Key.ToString());
                var value = HttpUtility.UrlEncode(kvp.Value.ToString());
                return $"{key}={value}";
            }

            return string.Join("&", dictionary.Select(Sanitize));
        }
    }
}
