using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Returns the current string, or <see langword="null" /> if the current string is null or empty.
        /// </summary>
        /// <param name="value">The value to sanitize.</param>
        /// <returns>
        ///     <see langword="null" /> if <paramref name="value" /> is <see langword="null" /> or equal to
        ///     <see cref="string.Empty" />, or <paramref name="value" /> otherwise.
        /// </returns>
        public static string? AsNullIfEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }

        /// <summary>
        ///     Returns the current string, or <see langword="null" /> if the current string is null, empty, or consists of only
        ///     whitespace.
        /// </summary>
        /// <param name="value">The value to sanitize.</param>
        /// <returns>
        ///     <see langword="null" /> if <paramref name="value" /> is <see langword="null" /> or equal to
        ///     <see cref="string.Empty" /> or is composed of only whitespace characters, or <paramref name="value" /> otherwise.
        /// </returns>
        public static string? AsNullIfWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        /// <summary>
        ///     Converts the specified string, which encodes binary data as base-64 digits, to an equivalent plain text string.
        /// </summary>
        /// <param name="value">The base-64 string to convert.</param>
        /// <returns>The plain text string representation of <paramref name="value" />.</returns>
        public static string Base64Decode(this string value)
        {
            return Convert.FromBase64String(value).ToString(Encoding.ASCII);
        }

        /// <summary>
        ///     Converts the current string to its equivalent string representation that is encoded with base-64 digits.
        /// </summary>
        /// <param name="value">The plain text string to convert.</param>
        /// <returns>The string representation, in base 64, of <paramref name="value" />.</returns>
        public static string Base64Encode(this string value)
        {
            return Convert.ToBase64String(value.GetBytes(Encoding.ASCII));
        }

        /// <summary>
        ///     Converts this string from one encoding to another.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <param name="from">The input encoding.</param>
        /// <param name="to">The output encoding.</param>
        /// <returns>
        ///     Returns a new <see cref="string" /> with its data converted to
        ///     <paramref name="to" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="str" /> is <see langword="null" />
        ///     - or -
        ///     <paramref name="from" /> is <see langword="null" />
        ///     -or
        ///     <paramref name="to" /> is <see langword="null" />.
        /// </exception>
        public static string ChangeEncoding(this string str, Encoding from, Encoding to)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (from is null)
            {
                throw new ArgumentNullException(nameof(from));
            }

            if (to is null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            return str.GetBytes(from).ToString(to);
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
        public static T EnumParse<T>(this string value)
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
        public static T EnumParse<T>(this string value, bool ignoreCase)
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

            var t = typeof(T);

            if (!t.IsEnum)
            {
                throw new ArgumentException(Resource.EnumParseNotEnumException);
            }

            return (T)Enum.Parse(t, value, ignoreCase);
        }

        /// <summary>
        ///     Gets a <see cref="byte" />[] representing the value the <see cref="string" /> with
        ///     <see cref="Encoding.UTF8" /> encoding.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns a <see cref="byte" />[].</returns>
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
        ///     Determines if all alpha characters in this string are considered lowercase.
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if all alpha characters are lowercase, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsLower(this string value)
        {
            for (var index = 0; index < value.Length; index++)
            {
                if (!char.IsLetter(value[index]))
                {
                    continue;
                }

                if (!char.IsLower(value[index]))
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
        ///     Returns <see langword="true" /> if all alpha characters are uppercase, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public static bool IsUpper(this string value)
        {
            for (var index = 0; index < value.Length; index++)
            {
                if (!char.IsLetter(value[index]))
                {
                    continue;
                }

                if (!char.IsUpper(value[index]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Returns a new string of a specified length by randomly selecting characters from the current string.
        /// </summary>
        /// <param name="source">The pool of characters to use.</param>
        /// <param name="length">The length of the new string returned.</param>
        /// <returns>
        ///     A new string whose length is equal to <paramref name="length" /> which contains randomly selected characters from
        ///     <paramref name="source" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length" /> is less than 0.</exception>
        public static string Randomize(this string source, int length)
        {
            return source.Randomize(length, RandomExtensions.Random);
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
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source" /> is <see langword="null" />.
        ///     -or-
        ///     <paramref name="random" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length" /> is less than 0.</exception>
        public static string Randomize(this string source, int length, Random random)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), ExceptionMessages.LengthGreaterThanOrEqualTo0);
            }

            if (length == 0)
            {
                return string.Empty;
            }

            var array = source.ToCharArray();
            var builder = new StringBuilder(length);

            while (builder.Length < length)
            {
                var next = random.NextFrom(array);
                builder.Append(next);
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Repeats a string a specified number of times.
        /// </summary>
        /// <param name="value">The string to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> whose value is <paramref name="value" /> repeated
        ///     <paramref name="count" /> times.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
        public static string Repeat(this string value, int count)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
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

            if (value.Length == 1)
            {
                return value;
            }

            unsafe
            {
                var array = stackalloc char[value.Length];

                for (var index = 0; index < value.Length; index++)
                {
                    array[index] = value[value.Length - index - 1];
                }

                return new string(array);
            }
        }

        /// <summary>
        ///     Shuffles the characters in the string.
        /// </summary>
        /// <param name="value">The string to shuffle.</param>
        /// <returns>Returns a <see cref="string" /> containing the characters in <paramref name="value" />, rearranged.</returns>
        public static string Shuffled(this string value)
        {
            return value.Shuffled(RandomExtensions.Random);
        }

        /// <summary>
        ///     Shuffles the characters in the string.
        /// </summary>
        /// <param name="value">The string to shuffle.</param>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>Returns a <see cref="string" /> containing the characters in <paramref name="value" />, rearranged.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
        public static string Shuffled(this string value, Random random)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new string(value.ToCharArray().Shuffled(random).ToArray());
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
        public static IEnumerable<string> Split(this string value, int chunkSize)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return SplitInternal();

            IEnumerable<string> SplitInternal()
            {
                for (var i = 0; i < value.Length; i += chunkSize)
                {
                    yield return value.Substring(i, Math.Min(chunkSize, value.Length - i));
                }
            }
        }

        /// <summary>
        ///     Parses a shorthand time span string (e.g. 3w 2d 1.5h) and converts it to an instance of <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Returns an instance of <see cref="TimeSpan" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="input" /> is <see langword="null" />.</exception>
        public static TimeSpan ToTimeSpan(this string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return TimeSpanParser.TryParse(input, out var result)
                ? result
                : default;
        }

        /// <summary>
        ///     Returns the current string, or an alternative value if the current string is null or empty, or optionally if the
        ///     current string consists of only whitespace.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="alternative">The alternative value if <paramref name="value" /> does not meet the criteria.</param>
        /// <param name="includeWhiteSpace">
        ///     Optional. If set to <see langword="true" />, <paramref name="alternative" /> will be returned also if
        ///     <paramref name="value" /> only consists of whitespace.
        /// </param>
        /// <returns>Returns <paramref name="value" /> or <paramref name="alternative" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alternative" /> is <see langword="null" />.</exception>
        public static string WithAlternative(this string? value, string alternative, bool includeWhiteSpace = false)
        {
            if (alternative is null)
            {
                throw new ArgumentNullException(nameof(alternative));
            }

            return (includeWhiteSpace ? value?.AsNullIfWhiteSpace() : value?.AsNullIfEmpty()) ?? alternative;
        }
    }
}
