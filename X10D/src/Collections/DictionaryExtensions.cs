using System.Diagnostics.Contracts;
#if NET6_0_OR_GREATER
using System.Runtime.InteropServices;
#endif
using System.Web;

namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Dictionary{TKey,TValue}" /> and similar types.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    ///     Adds a key/value pair to the <see cref="Dictionary{TKey,TValue}" /> if the key does not already exist, or updates a
    ///     key/value pair in the <see cref="Dictionary{TKey,TValue}" /> by using the specified function if the key already
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
    public static TValue AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue addValue,
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

#if NET6_0_OR_GREATER
        ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool exists);
        // DO NOT CHANGE. reassigning value is necessary to mutate the dictionary, due to ref return above.
        // mutation of the dictionary is INTENDED BEHAVIOUR. this is not a mistake.
        return value = exists ? updateValueFactory(key, value!) : addValue;
#else
        if (dictionary.TryGetValue(key, out TValue? old))
        {
            TValue updated = updateValueFactory(key, old);
            dictionary[key] = updated;

            return updated;
        }

        dictionary.Add(key, addValue);
        return addValue;
#endif
    }

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

        if (dictionary.TryGetValue(key, out TValue? old))
        {
            TValue updated = updateValueFactory(key, old);
            dictionary[key] = updated;

            return updated;
        }

        dictionary.Add(key, addValue);
        return addValue;
    }

    /// <summary>
    ///     Uses the specified functions to add a key/value pair to the <see cref="Dictionary{TKey,TValue}" /> if the key does
    ///     not already exist, or to update a key/value pair in the <see cref="Dictionary{TKey,TValue}" /> if the key already
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
    public static TValue AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key,
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

#if NET6_0_OR_GREATER
        ref TValue? value = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool exists);
        // DO NOT CHANGE. reassigning value is necessary to mutate the dictionary, due to ref return above.
        // mutation of the dictionary is INTENDED BEHAVIOUR. this is not a mistake.
        return value = exists ? updateValueFactory(key, value!) : addValueFactory(key);
#else
        if (dictionary.TryGetValue(key, out TValue? old))
        {
            TValue updated = updateValueFactory(key, old);
            dictionary[key] = updated;

            return updated;
        }

        TValue add = addValueFactory(key);
        dictionary.Add(key, add);

        return add;
#endif
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

        if (dictionary.TryGetValue(key, out TValue? old))
        {
            TValue updated = updateValueFactory(key, old);
            dictionary[key] = updated;

            return updated;
        }

        TValue add = addValueFactory(key);
        dictionary.Add(key, add);

        return add;
    }

    /// <summary>
    ///     Uses the specified functions and argument to add a key/value pair to the <see cref="Dictionary{TKey,TValue}" /> if
    ///     the key does not already exist, or to update a key/value pair in the <see cref="Dictionary{TKey,TValue}" /> if th
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
    public static TValue AddOrUpdate<TKey, TValue, TArg>(this Dictionary<TKey, TValue> dictionary, TKey key,
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

#if NET6_0_OR_GREATER
        ref TValue? value = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool exists);
        // DO NOT CHANGE. reassigning value is necessary to mutate the dictionary, due to ref return above.
        // mutation of the dictionary is INTENDED BEHAVIOUR. this is not a mistake.
        return value = exists ? updateValueFactory(key, value!, factoryArgument) : addValueFactory(key, factoryArgument);
#else
        if (dictionary.TryGetValue(key, out TValue? old))
        {
            TValue updated = updateValueFactory(key, old, factoryArgument);
            dictionary[key] = updated;

            return updated;
        }

        TValue add = addValueFactory(key, factoryArgument);
        dictionary.Add(key, add);

        return add;
#endif
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

        if (dictionary.TryGetValue(key, out TValue? old))
        {
            TValue updated = updateValueFactory(key, old, factoryArgument);
            dictionary[key] = updated;

            return updated;
        }

        TValue add = addValueFactory(key, factoryArgument);
        dictionary.Add(key, add);

        return add;
    }

    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> to a data connection
    ///     string.
    /// </summary>
    /// <typeparam name="TKey">The type of the key element of the key/value pair.</typeparam>
    /// <typeparam name="TValue">The type of the value element of the key/value pair.</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <returns>A <see cref="string" /> representing the dictionary as a key=value set, concatenated with <c>;</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
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

            return value.Contains(' ', StringComparison.Ordinal) ? $"\"{value}\"" : value;
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
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="selector" /> is <see langword="null" />.</para>
    /// </exception>
    [Pure]
    public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TValue, string?> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        static string SanitizeValue(string? value)
        {
            if (value is null)
            {
                return string.Empty;
            }

            return value.Contains(' ', StringComparison.Ordinal) ? $"\"{value}\"" : value;
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
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="keySelector" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="valueSelector" /> is <see langword="null" />.</para>
    /// </exception>
    [Pure]
    public static string ToConnectionString<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TKey, string> keySelector, Func<TValue, string?> valueSelector)
        where TKey : notnull
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (keySelector is null)
        {
            throw new ArgumentNullException(nameof(keySelector));
        }

        if (valueSelector is null)
        {
            throw new ArgumentNullException(nameof(valueSelector));
        }

        static string SanitizeValue(string? value)
        {
            if (value is null)
            {
                return string.Empty;
            }

            return value.Contains(' ', StringComparison.Ordinal) ? $"\"{value}\"" : value;
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
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
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
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="selector" /> is <see langword="null" />.</para>
    /// </exception>
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
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="keySelector" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="valueSelector" /> is <see langword="null" />.</para>
    /// </exception>
    [Pure]
    public static string ToGetParameters<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TKey, string> keySelector, Func<TValue, string?> valueSelector)
        where TKey : notnull
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (keySelector is null)
        {
            throw new ArgumentNullException(nameof(keySelector));
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
