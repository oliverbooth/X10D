using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace X10D
{
    /// <summary>
    ///     A set of extension methods for <see cref="Dictionary{TKey,TValue}" />.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Converts a <see cref="IReadOnlyDictionary{T1,T2}" /> to an object-relational-safe connection string.
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value; set.</returns>
        public static string ToConnectionString<T1, T2>(this IReadOnlyDictionary<T1, T2> dictionary)
        {
            if (dictionary is null)
            {
                throw new ArgumentNullException(nameof(dictionary));
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
            
            foreach (var pair in dictionary)
            {
                list.Add($"{pair.Key}={SanitizeValue(pair.Value?.ToString())}");
            }

            return string.Join(";", list);
        }

        /// <summary>
        ///     Converts a <see cref="IDictionary{T1,T2}" /> to an object-relational-safe connection string.
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value; set.</returns>
        public static string ToConnectionString<T1, T2>(this IDictionary<T1, T2> dictionary)
        {
            return ((IReadOnlyDictionary<T1, T2>)dictionary).ToConnectionString();
        }

        /// <summary>
        ///     Converts a <see cref="Dictionary{T1,T2}" /> to an object-relational-safe connection string.
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value; set.</returns>
        public static string ToConnectionString<T1, T2>(this Dictionary<T1, T2> dictionary)
        {
            return ((IReadOnlyDictionary<T1, T2>)dictionary).ToConnectionString();
        }

        /// <summary>
        ///     Converts an <see cref="IReadOnlyDictionary{T1,T2}" /> to a HTTP GET parameter string.
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value& set.</returns>
        public static string ToGetParameters<T1, T2>(this IReadOnlyDictionary<T1, T2> dictionary)
        {
            static string Sanitize(KeyValuePair<T1, T2> kvp)
            {
                var key = HttpUtility.UrlEncode(kvp.Key.ToString());
                var value = HttpUtility.UrlEncode(kvp.Value.ToString());
                return $"{key}={value}";
            }

            return string.Join("&", dictionary.Select(Sanitize));
        }

        /// <summary>
        ///     Converts an <see cref="IDictionary{T1,T2}" /> to a HTTP GET parameter string.
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value& set.</returns>
        public static string ToGetParameters<T1, T2>(this IDictionary<T1, T2> dictionary)
        {
            return ((IReadOnlyDictionary<T1, T2>)dictionary).ToGetParameters();
        }

        /// <summary>
        ///     Converts a <see cref="Dictionary{T1,T2}" /> to a HTTP GET parameter string.
        /// </summary>
        /// <typeparam name="T1">The key type.</typeparam>
        /// <typeparam name="T2">The value type.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>Returns a <see cref="string" /> representing the dictionary as a key=value& set.</returns>
        public static string ToGetParameters<T1, T2>(this Dictionary<T1, T2> dictionary)
        {
            return ((IReadOnlyDictionary<T1, T2>)dictionary).ToGetParameters();
        }
    }
}
