using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using X10D.Collections;
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string Base64Decode(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        return Convert.FromBase64String(value).ToString(Encoding.ASCII);
    }

    /// <summary>
    ///     Converts the current string to its equivalent string representation that is encoded with base-64 digits.
    /// </summary>
    /// <param name="value">The plain text string to convert.</param>
    /// <returns>The string representation, in base 64, of <paramref name="value" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string Base64Encode(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ChangeEncoding(this string value, Encoding sourceEncoding, Encoding destinationEncoding)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(sourceEncoding);
        ArgumentNullException.ThrowIfNull(destinationEncoding);

        return value.GetBytes(sourceEncoding).ToString(destinationEncoding);
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T EnumParse<T>(this string value, bool ignoreCase)
        where T : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(value);

        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(Resource.EnumParseEmptyStringException, nameof(value));
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static byte[] GetBytes(this string value, Encoding encoding)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(encoding);

        return encoding.GetBytes(value);
    }

    /// <summary>
    ///     Determines if all alpha characters in this string are considered lowercase.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>
    ///     <see langword="true" /> if all alpha characters in this string are lowercase; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsLower(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsPalindrome(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUpper(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string Repeat(this string value, int count)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string Randomize(this string source, int length, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), ExceptionMessages.LengthGreaterThanOrEqualTo0);
        }

        if (length == 0)
        {
            return string.Empty;
        }

        random ??= Random.Shared;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string Reverse(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string Shuffled(this string value, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(value);

        random ??= Random.Shared;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static IEnumerable<string> Split(this string value, int chunkSize)
    {
        ArgumentNullException.ThrowIfNull(value);

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
    ///     Normalizes a string which may be either <see langword="null" /> or empty to a specified alternative.
    /// </summary>
    /// <param name="value">The value to normalize.</param>
    /// <param name="alternative">The alternative string.</param>
    /// <returns>
    ///     <paramref name="alternative" /> if <paramref name="value" /> is <see langword="null" /> or empty; otherwise,
    ///     <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    [return: NotNullIfNotNull("alternative")]
    public static string? WithWhiteSpaceAlternative(this string? value, string? alternative)
    {
        return string.IsNullOrWhiteSpace(value) ? alternative : value;
    }
}
