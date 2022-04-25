using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using X10D.Collections;

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
    [return: NotNullIfNotNull("value")]
    public static string? AsNullIfWhiteSpace(this string? value)
    {
        return value.WithWhiteSpaceAlternative(null);
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
    public static T? FromJson<T>(this string value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(value, options);
    }

    /// <summary>
    ///     Determines if all alpha characters in this string are considered lowercase.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>
    ///     <see langword="true" /> if all alpha characters in this string are lowercase; otherwise, <see langword="false" />.
    /// </returns>
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
    ///     Determines whether the current string is considered palindromic; that is, the letters within the string are the
    ///     same when reversed.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is considered a palindromic string; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
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
    ///     Repeats a string a specified number of times.
    /// </summary>
    /// <param name="value">The string to repeat.</param>
    /// <param name="count">The repeat count.</param>
    /// <returns>A string containing <paramref name="value" /> repeated <paramref name="count" /> times.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
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

        var builder = new StringBuilder(value.Length * count);

        for (var i = 0; i < count; i++)
        {
            builder.Append(value);
        }

        return builder.ToString();
    }

    /// <summary>
    ///     Reverses the current string.
    /// </summary>
    /// <param name="value">The string to reverse.</param>
    /// <returns>A <see cref="string" /> whose characters are that of <paramref name="value" /> in reverse order.</returns>
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
    ///     The <see cref="System.Random" /> instance to use for the shuffling. If <see langword="null" /> is specified,
    ///     <see cref="System.Random.Shared" /> is used.
    /// </param>
    /// <returns>A new <see cref="string" /> containing the characters in <paramref name="value" />, rearranged.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    public static string Shuffled(this string value, Random? random = null)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        random ??= Random.Shared;

        char[] array = value.ToCharArray();
        array.Shuffle(random);
        return new string(array);
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
    [return: NotNullIfNotNull("alternative")]
    public static string? WithWhiteSpaceAlternative(this string? value, string? alternative)
    {
        return string.IsNullOrWhiteSpace(value) ? alternative : value;
    }
}
