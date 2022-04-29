using System.Diagnostics.Contracts;
using System.Web;

namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Dictionary{TKey,TValue}" /> and similar types.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    ///     Adds a key/value pair to the <see cref="IDictionary{TKey,TValue}" /> if the key does not already exist, or updates a
    ///     key/value pair in the <see cref="IDictionary{TKey,TValue}" /> by using the specified function if the key already
    ///     exists.
    /// </summary>
    /// <param name="dictionary">The dictionary to update.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValue">The value to be added for an absent key.</param>
    /// <param name="updateValueFactory">
    ///     The function used to generate a new value for an existing key based on the key's existing value.
    /// </param>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <returns>
    ///     The new value for the key. This will be either be <paramref name="addValue" /> (if the key was absent) or the result
    ///     of <paramref name="updateValueFactory" /> (if the key was present).
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="dictionary" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="updateValueFactory" /> is <see langword="null" />.</para>
    /// </exception>
    public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue addValue,
        Func<TKey, TValue, TValue> updateValueFactory)
        where TKey : notnull
    {
        if (dictionary is null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }

        if (updateValueFactory is null)
        {
            throw new ArgumentNullException(nameof(updateValueFactory));
        }

        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = updateValueFactory(key, dictionary[key]);
        }
        else
        {
            dictionary.Add(key, addValue);
        }

        return dictionary[key];
    }

    /// <summary>
    ///     Uses the specified functions to add a key/value pair to the <see cref="IDictionary{TKey,TValue}" /> if the key does
    ///     not already exist, or to update a key/value pair in the <see cref="IDictionary{TKey,TValue}" /> if the key already
    ///     exists.
    /// </summary>
    /// <param name="dictionary">The dictionary to update.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValueFactory">The function used to generate a value for an absent key.</param>
    /// <param name="updateValueFactory">
    ///     The function used to generate a new value for an existing key based on the key's existing value.
    /// </param>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <returns>
    ///     The new value for the key. This will be either be the result of <paramref name="addValueFactory "/> (if the key was
    ///     absent) or the result of <paramref name="updateValueFactory" /> (if the key was present).
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="dictionary" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="addValueFactory" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="updateValueFactory" /> is <see langword="null" />.</para>
    /// </exception>
    public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
        Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        where TKey : notnull
    {
        if (dictionary is null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }

        if (addValueFactory is null)
        {
            throw new ArgumentNullException(nameof(addValueFactory));
        }

        if (updateValueFactory is null)
        {
            throw new ArgumentNullException(nameof(updateValueFactory));
        }

        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = updateValueFactory(key, dictionary[key]);
        }
        else
        {
            dictionary.Add(key, addValueFactory(key));
        }

        return dictionary[key];
    }

    /// <summary>
    ///     Uses the specified functions and argument to add a key/value pair to the <see cref="IDictionary{TKey,TValue}" /> if
    ///     the key does not already exist, or to update a key/value pair in the <see cref="IDictionary{TKey,TValue}" /> if th
    ///     key already exists.
    /// </summary>
    /// <param name="dictionary">The dictionary to update.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValueFactory">The function used to generate a value for an absent key.</param>
    /// <param name="updateValueFactory">
    ///     The function used to generate a new value for an existing key based on the key's existing value.
    /// </param>
    /// <param name="factoryArgument">
    ///     An argument to pass into <paramref name="addValueFactory" /> and <paramref name="updateValueFactory" />.
    /// </param>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <typeparam name="TArg">
    ///     The type of an argument to pass into <paramref name="addValueFactory" /> and <paramref name="updateValueFactory" />.
    /// </typeparam>
    /// <returns>
    ///     The new value for the key. This will be either be the result of <paramref name="addValueFactory "/> (if the key was
    ///     absent) or the result of <paramref name="updateValueFactory" /> (if the key was present).
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="dictionary" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="addValueFactory" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="updateValueFactory" /> is <see langword="null" />.</para>
    /// </exception>
    public static TValue AddOrUpdate<TKey, TValue, TArg>(this IDictionary<TKey, TValue> dictionary, TKey key,
        Func<TKey, TArg, TValue> addValueFactory, Func<TKey, TValue, TArg, TValue> updateValueFactory, TArg factoryArgument)
        where TKey : notnull
    {
        if (dictionary is null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }

        if (addValueFactory is null)
        {
            throw new ArgumentNullException(nameof(addValueFactory));
        }

        if (updateValueFactory is null)
        {
            throw new ArgumentNullException(nameof(updateValueFactory));
        }

        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = updateValueFactory(key, dictionary[key], factoryArgument);
        }
        else
        {
            dictionary.Add(key, addValueFactory(key, factoryArgument));
        }

        return dictionary[key];
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a data connection
    ///     string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>;</c>.</returns>
    [Pure]
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

            return value.Contains(' ') ? $"\"{value}\"" : value;
        }

        static string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            return $"{pair.Key}={SanitizeValue(pair.Value?.ToString())}";
        }

        return string.Join(';', source.Select(GetQueryParameter));
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a data connection
    ///     string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="selector">
    ///     A transform function to apply to the <see cref="KeyValuePair{TKey,TValue}.Value" /> of each element.
    /// </param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>;</c>.</returns>
    [Pure]
    public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TValue, string?> selector)
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

            return value.Contains(' ') ? $"\"{value}\"" : value;
        }

        string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            return $"{pair.Key}={SanitizeValue(selector(pair.Value))}";
        }

        return string.Join(';', source.Select(GetQueryParameter));
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to an data connection
    ///     string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="keySelector">
    ///     A transform function to apply to the <see cref="KeyValuePair{TKey,TValue}.Key" /> of each element.
    /// </param>
    /// <param name="valueSelector">
    ///     A transform function to apply to the <see cref="KeyValuePair{TKey,TValue}.Value" /> of each element.
    /// </param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>;</c>.</returns>
    [Pure]
    public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TKey, string> keySelector, Func<TValue, string?> valueSelector)
        where TKey : notnull
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

            return value.Contains(' ') ? $"\"{value}\"" : value;
        }

        string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            return $"{keySelector(pair.Key)}={SanitizeValue(valueSelector(pair.Value))}";
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
    [Pure]
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

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a HTTP GET query string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="selector">
    ///     A transform function to apply to the <see cref="KeyValuePair{TKey,TValue}.Value" /> of each element.
    /// </param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>&amp;</c>.</returns>
    [Pure]
    public static string ToGetParameters<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TValue, string?> selector)
        where TKey : notnull
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        // can't static here because of 'selector' parameter
        string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            string key = HttpUtility.UrlEncode(pair.Key.ToString())!;
            string? value = HttpUtility.UrlEncode(selector(pair.Value));
            return $"{key}={value}";
        }

        return string.Join('&', source.Select(GetQueryParameter));
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a HTTP GET query string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="keySelector">
    ///     A transform function to apply to the <see cref="KeyValuePair{TKey,TValue}.Key" /> of each element.
    /// </param>
    /// <param name="valueSelector">
    ///     A transform function to apply to the <see cref="KeyValuePair{TKey,TValue}.Value" /> of each element.
    /// </param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>&amp;</c>.</returns>
    [Pure]
    public static string ToGetParameters<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TKey, string> keySelector, Func<TValue, string?> valueSelector)
        where TKey : notnull
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (valueSelector is null)
        {
            throw new ArgumentNullException(nameof(valueSelector));
        }

        // can't static here because of selector parameters
        string GetQueryParameter(KeyValuePair<TKey, TValue> pair)
        {
            string key = HttpUtility.UrlEncode(keySelector(pair.Key));
            string? value = HttpUtility.UrlEncode(valueSelector(pair.Value));
            return $"{key}={value}";
        }

        return string.Join('&', source.Select(GetQueryParameter));
    }
}
