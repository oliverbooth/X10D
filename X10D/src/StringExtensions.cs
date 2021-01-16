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
        /// <returns><see langword="null" /> or <paramref name="value" />.</returns>
        public static string? AsNullIfEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }

        /// <summary>
        ///     Returns the current string, or <see langword="null" /> if the current string is null, empty, or consists of only
        ///     whitespace.
        /// </summary>
        /// <param name="value">The value to sanitize.</param>
        /// <returns><see langword="null" /> or <paramref name="value" />.</returns>
        public static string? AsNullIfWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        /// <summary>
        ///     Decodes a base-64 encoded string.
        /// </summary>
        /// <param name="data">The base-64 string to decode.</param>
        /// <returns>Returns the string in plain text.</returns>
        public static string Base64Decode(this string data)
        {
            return Convert.FromBase64String(data).GetString();
        }

        /// <summary>
        ///     Encodes a base-64 encoded string.
        /// </summary>
        /// <param name="value">The plain text string to decode.</param>
        /// <returns>Returns the string in plain text.</returns>
        public static string Base64Encode(this string value)
        {
            return Convert.ToBase64String(value.GetBytes());
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

            return str.GetBytes(from).GetString(to);
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
        /// <param name="str">The string to convert.</param>
        /// <returns>Returns a <see cref="byte" />[].</returns>
        public static byte[] GetBytes(this string str)
        {
            return str.GetBytes(Encoding.UTF8);
        }

        /// <summary>
        ///     Gets a <see cref="byte" />[] representing the value the <see cref="string" /> with the provided encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>Returns a <see cref="byte" />[].</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="str" /> or <paramref name="encoding" /> or both are
        ///     <see langword="null" />.
        /// </exception>
        public static byte[] GetBytes(this string str, Encoding encoding)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            return encoding.GetBytes(str);
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
        ///     Generates a new random string by filling it with characters found in <see cref="str" />.
        /// </summary>
        /// <param name="str">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a <see cref="string" /> containing <paramref name="length" /> characters.</returns>
        public static string Random(this string str, int length)
        {
            return str.Random(length, RandomExtensions.Random);
        }

        /// <summary>
        ///     Generates a new random string by filling it with characters found in <see cref="str" />.
        /// </summary>
        /// <param name="str">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>Returns a <see cref="string" /> containing <paramref name="length" /> characters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str" /> is <see langword="null" />.</exception>
        public static string Random(this string str, int length, Random random)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return str.ToCharArray().Random(length, random);
        }

        /// <summary>
        ///     Repeats a string a specified number of times.
        /// </summary>
        /// <param name="str">The string to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> whose value is <paramref name="str" /> repeated
        ///     <paramref name="count" /> times.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="str" /> is <see langword="null" />.</exception>
        public static string Repeat(this string str, int count)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            var builder = new StringBuilder(str.Length * count);

            for (var i = 0; i < count; i++)
            {
                builder.Append(str);
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
        /// <param name="str">The string to shuffle.</param>
        /// <returns>Returns a <see cref="string" /> containing the characters in <paramref name="str" />, rearranged.</returns>
        public static string Shuffle(this string str)
        {
            return str.Shuffle(RandomExtensions.Random);
        }

        /// <summary>
        ///     Shuffles the characters in the string.
        /// </summary>
        /// <param name="str">The string to shuffle.</param>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>Returns a <see cref="string" /> containing the characters in <paramref name="str" />, rearranged.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str" /> is <see langword="null" />.</exception>
        public static string Shuffle(this string str, Random random)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return new string(str.Shuffled(random).ToArray());
        }

        /// <summary>
        ///     Splits the <see cref="string" /> into chunks that are no greater than <paramref name="chunkSize" /> in length.
        /// </summary>
        /// <param name="str">The string to split.</param>
        /// <param name="chunkSize">The maximum length of each string in the returned result.</param>
        /// <returns>
        ///     Returns an <see cref="IEnumerable{T}" /> containing <see cref="string" /> instances which are no
        ///     greater than <paramref name="chunkSize" /> in length.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="str" /> is <see langword="null" />.</exception>
        public static IEnumerable<string> Split(this string str, int chunkSize)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return SplitInternal();

            IEnumerable<string> SplitInternal()
            {
                for (var i = 0; i < str.Length; i += chunkSize)
                {
                    yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
                }
            }
        }
        
        /// <summary>
        ///     Parses a shorthand time span string (e.g. 3w 2d 1.5h) and converts it to an instance of
        ///     <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>Returns an instance of <see cref="TimeSpan" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str" /> is <see langword="null" />.</exception>
        public static TimeSpan ToTimeSpan(this string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return TimeSpanParser.Parse(str);
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
