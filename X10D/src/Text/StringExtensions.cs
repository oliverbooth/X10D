using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using X10D.Collections;
using X10D.CompilerServices;
using X10D.Core;
using X10D.IO;

namespace X10D.Text;

/// <summary>
///     Text-related extension methods for <see cref="string" />.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Normalizes a string which may be either <see langword="null" /> or empty to <see langword="null" />.
    /// </summary>
    /// <param name="value">The value to normalize.</param>
    /// <returns>
    ///     <see langword="null" /> if <paramref name="value" /> is <see langword="null" /> or empty; otherwise,
    ///     <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    [return: NotNullIfNotNull("value")]
    public static string? AsNullIfEmpty(this string? value)
    {
        return value.WithEmptyAlternative(null);
    }

    /// <summary>
    ///     Normalizes a string which may be either <see langword="null" />, empty, or consisting of only whitespace, to
    ///     <see langword="null" />.
    /// </summary>
    /// <param name="value">The value to normalize.</param>
    /// <returns>
    ///     <see langword="null" /> if <paramref name="value" /> is <see langword="null" />, empty, or consists of only
    ///     whitespace; otherwise, <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    [return: NotNullIfNotNull("value")]
    public static string? AsNullIfWhiteSpace(this string? value)
    {
        return value.WithWhiteSpaceAlternative(null);
    }

    /// <summary>
    ///     Converts the specified string, which encodes binary data as base-64 digits, to an equivalent plain text string.
    /// </summary>
    /// <param name="value">The base-64 string to convert.</param>
    /// <returns>The plain text string representation of <paramref name="value" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string Base64Decode(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return Convert.FromBase64String(value).ToString(Encoding.ASCII);
    }

    /// <summary>
    ///     Converts the current string to its equivalent string representation that is encoded with base-64 digits.
    /// </summary>
    /// <param name="value">The plain text string to convert.</param>
    /// <returns>The string representation, in base 64, of <paramref name="value" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string Base64Encode(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return Convert.ToBase64String(value.GetBytes(Encoding.ASCII));
    }

    /// <summary>
    ///     Converts this string from one encoding to another.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <param name="sourceEncoding">The input encoding.</param>
    /// <param name="destinationEncoding">The output encoding.</param>
    /// <returns>
    ///     Returns a new <see cref="string" /> with its data converted to
    ///     <paramref name="destinationEncoding" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value" /> is <see langword="null" />
    ///     - or -
    ///     <paramref name="sourceEncoding" /> is <see langword="null" />
    ///     -or
    ///     <paramref name="destinationEncoding" /> is <see langword="null" />.
    /// </exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string ChangeEncoding(this string value, Encoding sourceEncoding, Encoding destinationEncoding)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (sourceEncoding is null)
        {
            throw new ArgumentNullException(nameof(sourceEncoding));
        }

        if (destinationEncoding is null)
        {
            throw new ArgumentNullException(nameof(destinationEncoding));
        }

        return value.GetBytes(sourceEncoding).ToString(destinationEncoding);
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="appendValue">The string to append if the condition is true.</param>
    /// <returns>The concatenated string.</returns>
    [Pure]
    public static string? ConcatIf(this string? value, bool condition, string? appendValue)
    {
        return condition ? value + appendValue : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="conditionFactory">The function that returns the condition to evaluate.</param>
    /// <param name="appendValue">The string to append if the condition is true.</param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="conditionFactory" /> is <see langword="null" />.</exception>
    [Pure]
    public static string? ConcatIf(this string? value, Func<bool> conditionFactory, string? appendValue)
    {
        if (conditionFactory is null)
        {
            throw new ArgumentNullException(nameof(conditionFactory));
        }

        return conditionFactory() ? value + appendValue : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="conditionFactory">
    ///     The function that returns the condition to evaluate, with <paramref name="value" /> given as an argument.
    /// </param>
    /// <param name="appendValue">The string to append if the condition is true.</param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="conditionFactory" /> is <see langword="null" />.</exception>
    [Pure]
    public static string? ConcatIf(this string? value, Func<string?, bool> conditionFactory, string? appendValue)
    {
        if (conditionFactory is null)
        {
            throw new ArgumentNullException(nameof(conditionFactory));
        }

        return conditionFactory(value) ? value + appendValue : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="valueFactory">The function that returns the string to append if the condition is true.</param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="valueFactory" /> is <see langword="null" />.</exception>
    [Pure]
    public static string? ConcatIf(this string? value, bool condition, Func<string?> valueFactory)
    {
        if (valueFactory is null)
        {
            throw new ArgumentNullException(nameof(valueFactory));
        }

        return condition ? value + valueFactory() : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="condition">The condition to evaluate.</param>
    /// <param name="valueFactory">
    ///     The function that returns the string to append if the condition is true, with <paramref name="value" /> given as an
    ///     argument.
    /// </param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="valueFactory" /> is <see langword="null" />.</exception>
    [Pure]
    public static string? ConcatIf(this string? value, bool condition, Func<string?, string?> valueFactory)
    {
        if (valueFactory is null)
        {
            throw new ArgumentNullException(nameof(valueFactory));
        }

        return condition ? value + valueFactory(value) : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="conditionFactory">The function that returns the condition to evaluate.</param>
    /// <param name="valueFactory">The function that returns the string to append if the condition is true.</param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="conditionFactory" /> or <paramref name="valueFactory" /> is <see langword="null" />.
    /// </exception>
    [Pure]
    public static string? ConcatIf(this string? value, Func<bool> conditionFactory, Func<string?> valueFactory)
    {
        if (conditionFactory is null)
        {
            throw new ArgumentNullException(nameof(conditionFactory));
        }

        if (valueFactory is null)
        {
            throw new ArgumentNullException(nameof(valueFactory));
        }

        return conditionFactory() ? value + valueFactory() : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="conditionFactory">The function that returns the condition to evaluate.</param>
    /// <param name="valueFactory">
    ///     The function that returns the string to append if the condition is true, with <paramref name="value" /> given as an
    ///     argument.
    /// </param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="conditionFactory" /> or <paramref name="valueFactory" /> is <see langword="null" />.
    /// </exception>
    [Pure]
    public static string? ConcatIf(this string? value, Func<bool> conditionFactory, Func<string?, string?> valueFactory)
    {
        if (conditionFactory is null)
        {
            throw new ArgumentNullException(nameof(conditionFactory));
        }

        if (valueFactory is null)
        {
            throw new ArgumentNullException(nameof(valueFactory));
        }

        return conditionFactory() ? value + valueFactory(value) : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="conditionFactory">
    ///     The function that returns the condition to evaluate, with <paramref name="value" /> given as an argument.
    /// </param>
    /// <param name="valueFactory">The function that returns the string to append if the condition is true.</param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="conditionFactory" /> or <paramref name="valueFactory" /> is <see langword="null" />.
    /// </exception>
    [Pure]
    public static string? ConcatIf(this string? value, Func<string?, bool> conditionFactory, Func<string?> valueFactory)
    {
        if (conditionFactory is null)
        {
            throw new ArgumentNullException(nameof(conditionFactory));
        }

        if (valueFactory is null)
        {
            throw new ArgumentNullException(nameof(valueFactory));
        }

        return conditionFactory(value) ? value + valueFactory() : value;
    }

    /// <summary>
    ///     Appends a string to the current string if the specified condition evaluates to <see langword="true" />.
    /// </summary>
    /// <param name="value">The current string.</param>
    /// <param name="conditionFactory">
    ///     The function that returns the condition to evaluate, with <paramref name="value" /> given as an argument.
    /// </param>
    /// <param name="valueFactory">
    ///     The function that returns the string to append if the condition is true, with <paramref name="value" /> given as an
    ///     argument.
    /// </param>
    /// <returns>The concatenated string.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="conditionFactory" /> or <paramref name="valueFactory" /> is <see langword="null" />.
    /// </exception>
    [Pure]
    public static string? ConcatIf(this string? value, Func<string?, bool> conditionFactory, Func<string?, string?> valueFactory)
    {
        if (conditionFactory is null)
        {
            throw new ArgumentNullException(nameof(conditionFactory));
        }

        if (valueFactory is null)
        {
            throw new ArgumentNullException(nameof(valueFactory));
        }

        return conditionFactory(value) ? value + valueFactory(value) : value;
    }

    /// <summary>
    ///     Counts the occurrences of a character within the current character span.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character to count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this Span<char> haystack, char needle)
    {
        return CountSubstring((ReadOnlySpan<char>)haystack, needle);
    }

    /// <summary>
    ///     Counts the occurrences of a character within the current character span.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character to count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this ReadOnlySpan<char> haystack, char needle)
    {
        var count = 0;

        for (var index = 0; index < haystack.Length; index++)
        {
            if (haystack[index] == needle)
            {
                count++;
            }
        }

        return count;
    }

    /// <summary>
    ///     Counts the occurrences of a character within the current string.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The character to count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this string haystack, char needle)
    {
        if (haystack is null)
        {
            throw new ArgumentNullException(nameof(haystack));
        }

        return haystack.AsSpan().CountSubstring(needle);
    }

    /// <summary>
    ///     Counts the occurrences of a substring within the current string.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The substring to count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this string haystack, string? needle)
    {
        return CountSubstring(haystack, needle, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Counts the occurrences of a substring within the current string, using a specified string comparison method.
    /// </summary>
    /// <param name="haystack">The haystack search space.</param>
    /// <param name="needle">The substring to count.</param>
    /// <param name="comparison">The string comparison method used for determining substring count.</param>
    /// <returns>An integer representing the count of <paramref name="needle" /> inside <paramref name="haystack" />.</returns>
    public static int CountSubstring(this string haystack, string? needle, StringComparison comparison)
    {
        if (haystack is null)
        {
            throw new ArgumentNullException(nameof(haystack));
        }

        if (string.IsNullOrWhiteSpace(needle))
        {
            return 0;
        }

        return haystack.AsSpan().CountSubstring(needle, comparison);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureEndsWith(this string? value, char substring)
    {
        return EnsureEndsWith(value, substring, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the substring is compared.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureEndsWith(this string? value, char substring, StringComparison comparisonType)
    {
        return EnsureEndsWith(value, substring.ToString(), comparisonType);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureEndsWith(this string? value, string substring)
    {
        return EnsureEndsWith(value, substring, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the substring is compared.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureEndsWith(this string? value, string substring, StringComparison comparisonType)
    {
        if (string.IsNullOrEmpty(value))
        {
            return substring;
        }

        if (value.EndsWith(substring, comparisonType))
        {
            return value;
        }

        return value + substring;
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureStartsWith(this string? value, char substring)
    {
        return EnsureStartsWith(value, substring, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the substring is compared.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureStartsWith(this string? value, char substring, StringComparison comparisonType)
    {
        return EnsureStartsWith(value, substring.ToString(), comparisonType);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureStartsWith(this string? value, string substring)
    {
        return EnsureStartsWith(value, substring, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Ensures that the current string starts with a specified substring.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="substring">The substring to prepend, if the current string does not already start with it.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the substring is compared.</param>
    /// <returns>The combined string.</returns>
    public static string EnsureStartsWith(this string? value, string substring, StringComparison comparisonType)
    {
        if (string.IsNullOrEmpty(value))
        {
            return substring;
        }

        if (value.StartsWith(substring, comparisonType))
        {
            return value;
        }

        return substring + value;
    }

    /// <summary>
    ///     Parses a <see cref="string" /> into an <see cref="Enum" />.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Enum" />.</typeparam>
    /// <param name="value">The <see cref="string" /> value to parse.</param>
    /// <returns>The <see cref="Enum" /> value corresponding to the <see cref="string" />.</returns>
    /// <remarks>
    ///     Credit for this method goes to Scott Dorman:
    ///     (http://geekswithblogs.net/sdorman/Default.aspx).
    /// </remarks>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static T EnumParse<T>(this string value)
        where T : struct, Enum
    {
        return value.EnumParse<T>(false);
    }

    /// <summary>
    ///     Parses a <see cref="string" /> into an <see cref="Enum" />.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Enum" />.</typeparam>
    /// <param name="value">The <see cref="string" /> value to parse.</param>
    /// <param name="ignoreCase">Whether or not to ignore casing.</param>
    /// <returns>The <see cref="Enum" /> value corresponding to the <see cref="string" />.</returns>
    /// <remarks>
    ///     Credit for this method goes to Scott Dorman:
    ///     (http://geekswithblogs.net/sdorman/Default.aspx).
    /// </remarks>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static T EnumParse<T>(this string value, bool ignoreCase)
        where T : struct, Enum
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(ExceptionMessages.EnumParseEmptyStringException, nameof(value));
        }

        return Enum.Parse<T>(value, ignoreCase);
    }

    /// <summary>
    ///     Returns an object from the specified JSON string.
    /// </summary>
    /// <param name="value">The JSON to convert.</param>
    /// <param name="options">The JSON serialization options.</param>
    /// <typeparam name="T">The type of the value to deserialize.</typeparam>
    /// <returns>
    ///     An object constructed from the JSON string, or <see langword="null" /> if deserialization could not be performed.
    /// </returns>
    [Pure]
    public static T? FromJson<T>(this string value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(value, options);
    }

    /// <summary>
    ///     Gets a <see cref="byte" />[] representing the value the <see cref="string" /> with
    ///     <see cref="Encoding.UTF8" /> encoding.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>Returns a <see cref="byte" />[].</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static byte[] GetBytes(this string value)
    {
        return value.GetBytes(Encoding.UTF8);
    }

    /// <summary>
    ///     Gets a <see cref="byte" />[] representing the value the <see cref="string" /> with the provided encoding.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <returns>Returns a <see cref="byte" />[].</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="value" /> or <paramref name="encoding" /> or both are
    ///     <see langword="null" />.
    /// </exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static byte[] GetBytes(this string value, Encoding encoding)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (encoding is null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }

        return encoding.GetBytes(value);
    }

    /// <summary>
    ///     Returns a value indicating whether this string constitutes an emoji.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns><see langword="true" /> if this string is an emoji; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsEmoji(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return EmojiRegex.Value.IsMatch(value);
    }

    /// <summary>
    ///     Returns a value indicating whether the current string represents an empty string.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is empty; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsEmpty(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return value.Length == 0;
    }

    /// <summary>
    ///     Determines if all alpha characters in this string are considered lowercase.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>
    ///     <see langword="true" /> if all alpha characters in this string are lowercase; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsLower(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        for (var index = 0; index < value.Length; index++)
        {
            var rune = new Rune(value[index]);

            if (!Rune.IsLetter(rune))
            {
                continue;
            }

            if (!Rune.IsLower(rune))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Returns a value indicating whether the current string is <see langword="null" /> (<see langword="Nothing" /> in Visual
    ///     Basic), or represents an empty string.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is <see langword="null" /> or empty; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    ///     Returns a value indicating whether the current string is <see langword="null" /> (<see langword="Nothing" /> in Visual
    ///     Basic), represents an empty string, or consists of only whitespace characters.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is <see langword="null" />, empty, or consists of only
    ///     whitespace; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Determines whether the current string is considered palindromic; that is, the letters within the string are the
    ///     same when reversed.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is considered a palindromic string; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsPalindrome(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            // empty string is not palindromic
            return false;
        }

        for (int index = 0, endIndex = value.Length - 1; index < value.Length; index++, endIndex--)
        {
            Rune startRune = new Rune(value[index]);
            Rune endRune = new Rune(value[endIndex]);

            if (!Rune.IsLetter(startRune) && !Rune.IsNumber(startRune))
            {
                endIndex++;
                continue;
            }

            if (!Rune.IsLetter(endRune) && !Rune.IsNumber(endRune))
            {
                index--;
                continue;
            }

            if (Rune.ToUpperInvariant(startRune) != Rune.ToUpperInvariant(endRune))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines if all alpha characters in this string are considered uppercase.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>
    ///     <see langword="true" /> if all alpha characters in this string are uppercase; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsUpper(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        for (var index = 0; index < value.Length; index++)
        {
            var rune = new Rune(value[index]);

            if (!Rune.IsLetter(rune))
            {
                continue;
            }

            if (!Rune.IsUpper(rune))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Returns a value indicating whether the current string represents an empty string, or consists of only whitespace
    ///     characters.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is empty or consists of only whitespace; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsWhiteSpace(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length == 0)
        {
            return true;
        }

        for (var index = 0; index < value.Length; index++)
        {
            if (!char.IsWhiteSpace(value[index]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Repeats a string a specified number of times.
    /// </summary>
    /// <param name="value">The string to repeat.</param>
    /// <param name="count">The repeat count.</param>
    /// <returns>A string containing <paramref name="value" /> repeated <paramref name="count" /> times.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string Repeat(this string value, int count)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        switch (count)
        {
            case < 0:
                throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0);
            case 0:
                return string.Empty;
            case 1:
                return value;
        }

        Span<char> destination = stackalloc char[value.Length * count];
        value.Repeat(count, destination);
        return new string(destination);
    }

    /// <summary>
    ///     Repeats a string a specified number of times, writing the result to a span of characters.
    /// </summary>
    /// <param name="value">The string to repeat.</param>
    /// <param name="count">The repeat count.</param>
    /// <param name="destination">The destination span to write to.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count" /> is less than 0.</exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="destination" /> is too short to contain the repeated string.
    /// </exception>
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static void Repeat(this string value, int count, Span<char> destination)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0);
        }

        if (count == 0)
        {
            return;
        }

        if (destination.Length < value.Length * count)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

        for (var iteration = 0; iteration < count; iteration++)
        {
            Span<char> slice = destination.Slice(iteration * value.Length, value.Length);
            value.AsSpan().CopyTo(slice);
        }
    }

    /// <summary>
    ///     Returns a new string of a specified length by randomly selecting characters from the current string.
    /// </summary>
    /// <param name="source">The pool of characters to use.</param>
    /// <param name="length">The length of the new string returned.</param>
    /// <param name="random">The <see cref="System.Random" /> supplier.</param>
    /// <returns>
    ///     A new string whose length is equal to <paramref name="length" /> which contains randomly selected characters from
    ///     <paramref name="source" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length" /> is less than 0.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string Randomize(this string source, int length, Random? random = null)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), ExceptionMessages.LengthGreaterThanOrEqualTo0);
        }

        if (length == 0)
        {
            return string.Empty;
        }

        random ??= RandomExtensions.GetShared();

        char[] array = source.ToCharArray();
        var builder = new StringBuilder(length);

        while (builder.Length < length)
        {
            char next = random.NextFrom(array);
            builder.Append(next);
        }

        return builder.ToString();
    }

    /// <summary>
    ///     Reverses the current string.
    /// </summary>
    /// <param name="value">The string to reverse.</param>
    /// <returns>A <see cref="string" /> whose characters are that of <paramref name="value" /> in reverse order.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string Reverse(this string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < 2)
        {
            return value;
        }

        Span<char> span = stackalloc char[value.Length];

        for (var index = 0; index < value.Length; index++)
        {
            span[index] = value[value.Length - index - 1];
        }

        return new string(span);
    }

    /// <summary>
    ///     Shuffles the characters in the string.
    /// </summary>
    /// <param name="value">The string to shuffle.</param>
    /// <param name="random">
    ///     The <see cref="System.Random" /> instance to use for the shuffling. If <see langword="null" /> is specified, a shared
    ///     instance is used.
    /// </param>
    /// <returns>A new <see cref="string" /> containing the characters in <paramref name="value" />, rearranged.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static string Shuffled(this string value, Random? random = null)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        random ??= RandomExtensions.GetShared();

        char[] array = value.ToCharArray();
        array.Shuffle(random);
        return new string(array);
    }

    /// <summary>
    ///     Splits the <see cref="string" /> into chunks that are no greater than <paramref name="chunkSize" /> in length.
    /// </summary>
    /// <param name="value">The string to split.</param>
    /// <param name="chunkSize">The maximum length of each string in the returned result.</param>
    /// <returns>
    ///     Returns an <see cref="IEnumerable{T}" /> containing <see cref="string" /> instances which are no
    ///     greater than <paramref name="chunkSize" /> in length.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static IEnumerable<string> Split(this string value, int chunkSize)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (chunkSize == 0)
        {
            yield return string.Empty;
            yield break;
        }

        for (var i = 0; i < value.Length; i += chunkSize)
        {
            yield return value[i..System.Math.Min(i + chunkSize, value.Length)];
        }
    }

    /// <summary>
    ///     Determines whether the beginning of this string instance matches any of the specified strings using the current
    ///     culture for comparison.
    /// </summary>
    /// <param name="value">The value to compare.</param>
    /// <param name="startValues">An array of string to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> starts with any of the <paramref name="startValues" />;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="startValues" />, or at least one of its elements, is <see langword="null" />.
    /// </exception>
    public static bool StartsWithAny(this string? value, params string[] startValues)
    {
        if (startValues is null)
        {
            throw new ArgumentNullException(nameof(startValues));
        }

        if (startValues.Length == 0 || string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return value.StartsWithAny(StringComparison.CurrentCulture, startValues);
    }

    /// <summary>
    ///     Determines whether the beginning of this string instance matches any of the specified strings when compared using the
    ///     specified comparison option.
    /// </summary>
    /// <param name="value">The value to compare.</param>
    /// <param name="comparison">One of the enumeration values that determines how this string and value are compared.</param>
    /// <param name="startValues">An array of string to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> starts with any of the <paramref name="startValues" />;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="startValues" />, or at least one of its elements, is <see langword="null" />.
    /// </exception>
    public static bool StartsWithAny(this string? value, StringComparison comparison, params string[] startValues)
    {
        if (startValues is null)
        {
            throw new ArgumentNullException(nameof(startValues));
        }

        if (startValues.Length == 0 || string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        for (var index = 0; index < startValues.Length; index++)
        {
            if (startValues[index] is null)
            {
                throw new ArgumentNullException(nameof(startValues));
            }

            if (value.StartsWith(startValues[index], comparison))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Normalizes a string which may be either <see langword="null" /> or empty to a specified alternative.
    /// </summary>
    /// <param name="value">The value to normalize.</param>
    /// <param name="alternative">The alternative string.</param>
    /// <returns>
    ///     <paramref name="alternative" /> if <paramref name="value" /> is <see langword="null" /> or empty; otherwise,
    ///     <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    [return: NotNullIfNotNull("alternative")]
    public static string? WithEmptyAlternative(this string? value, string? alternative)
    {
        return string.IsNullOrEmpty(value) ? alternative : value;
    }

    /// <summary>
    ///     Normalizes a string which may be either <see langword="null" />, empty, or consisting of only whitespace, to a
    ///     specified alternative.
    /// </summary>
    /// <param name="value">The value to normalize.</param>
    /// <param name="alternative">The alternative string.</param>
    /// <returns>
    ///     <paramref name="alternative" /> if <paramref name="value" /> is <see langword="null" />, empty, or consists of only
    ///     whitespace; otherwise, <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    [return: NotNullIfNotNull("alternative")]
    public static string? WithWhiteSpaceAlternative(this string? value, string? alternative)
    {
        return string.IsNullOrWhiteSpace(value) ? alternative : value;
    }
}
