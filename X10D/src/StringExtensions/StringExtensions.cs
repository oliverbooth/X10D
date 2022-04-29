using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using X10D.Core;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="string" />.
/// </summary>
public static class StringExtensions
{
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(Resource.EnumParseEmptyStringException, nameof(value));
        }

        return Enum.Parse<T>(value, ignoreCase);
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
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        for (var i = 0; i < value.Length; i += chunkSize)
        {
            yield return value[i..System.Math.Min(i + chunkSize, value.Length - 1)];
        }
    }

    /// <summary>
    ///     Parses a shorthand time span string (e.g. 3w 2d 1.5h) and converts it to an instance of <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>Returns an instance of <see cref="TimeSpan" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="input" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TimeSpan ToTimeSpan(this string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        return TimeSpanParser.TryParse(input, out TimeSpan result)
            ? result
            : default;
    }
}
