namespace X10D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security;
    using System.Text;

    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Decodes a base-64 encoded string.
        /// </summary>
        /// <param name="data">The base-64 string to decode.</param>
        /// <returns>Returns the string in plain text.</returns>
        public static string Base64Decode(this string data)
        {
            return Convert.FromBase64String(data).GetString();
        }

        /// <summary>
        /// Encodes a base-64 encoded string.
        /// </summary>
        /// <param name="value">The plain text string to decode.</param>
        /// <returns>Returns the string in plain text.</returns>
        public static string Base64Encode(this string value)
        {
            return Convert.ToBase64String(value.GetBytes());
        }

        /// <summary>
        /// Parses a <see cref="string"/> into an <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="value">The <see cref="string"/> value to parse</param>
        /// <returns>The <see cref="Enum"/> value corresponding to the <see cref="string"/>.</returns>
        public static T EnumParse<T>(this string value)
        {
            return value.EnumParse<T>(false);
        }

        /// <summary>
        /// Parses a <see cref="string"/> into an <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="value">The <see cref="string"/> value to parse</param>
        /// <param name="ignoreCase">Whether or not to ignore casing.</param>
        /// <returns>The <see cref="Enum"/> value corresponding to the <see cref="string"/></returns>
        public static T EnumParse<T>(this string value, bool ignoreCase)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = value.Trim();

            if (value.Length == 0)
            {
                throw new ArgumentException("Must specify valid information for parsing in the string.", nameof(value));
            }

            Type t = typeof(T);

            if (!t.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.");
            }

            return (T)Enum.Parse(t, value, ignoreCase);
        }

        /// <summary>
        /// Gets a <see cref="byte"/>[] representing the value the <see cref="string"/> with
        /// <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>Returns a <see cref="byte"/>[].</returns>
        public static byte[] GetBytes(this string str)
        {
            return str.GetBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Gets a <see cref="byte"/>[] representing the value the <see cref="string"/> with the provided encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>Returns a <see cref="byte"/>[].</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> or <paramref name="encoding"/> or both are
        /// <see langword="null"/>.</exception>
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
        /// Generates a new random string by filling it with characters found in <see cref="str"/>.
        /// </summary>
        /// <param name="str">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a <see cref="string"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this string str, int length)
        {
            return str.Random(length, RandomExtensions.Random);
        }

        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="str"/>.
        /// </summary>
        /// <param name="str">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns a <see cref="string"/> containing <paramref name="length"/> characters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static string Random(this string str, int length, Random random)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return str.ToCharArray().Random(length, random);
        }

        /// <summary>
        /// Repeats a string a specified number of times.
        /// </summary>
        /// <param name="str">The string to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>Returns a <see cref="string"/> whose value is <paramref name="str"/> repeated
        /// <paramref name="count"/> times.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
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
        /// Shuffles the characters in the string.
        /// </summary>
        /// <param name="str">The string to shuffle.</param>
        /// <returns>Returns a <see cref="string"/> containing the characters in <paramref name="str"/>, rearranged.</returns>
        public static string Shuffle(this string str)
        {
            return str.Shuffle(RandomExtensions.Random);
        }

        /// <summary>
        /// Shuffles the characters in the string.
        /// </summary>
        /// <param name="str">The string to shuffle.</param>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns a <see cref="string"/> containing the characters in <paramref name="str"/>, rearranged.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static string Shuffle(this string str, Random random)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return new string(str.ToCharArray().Shuffle(random).ToArray());
        }

        /// <summary>
        /// Splits the <see cref="string"/> into chunks that are no greater than <paramref name="chunkSize"/> in length.
        /// </summary>
        /// <param name="str">The string to split.</param>
        /// <param name="chunkSize">The maximum length of each string in the returned result.</param>
        /// <returns>Returns an <see cref="IEnumerable{T}"/> containing <see cref="string"/> instances which are no
        /// greater than <paramref name="chunkSize"/> in length.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static IEnumerable<string> Split(this string str, int chunkSize)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            for (var i = 0; i < str.Length; i += chunkSize)
            {
                yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
            }
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>Returns a <see cref="SecureString"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static SecureString ToSecureString(this string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            SecureString result = new SecureString();
            foreach (char c in str)
            {
                result.AppendChar(c);
            }

            return result;
        }

        /// <summary>
        /// Converts a <see cref="SecureString"/> to a <see cref="string"/>.
        /// </summary>
        /// <param name="str">The <see cref="SecureString"/> to convert.</param>
        /// <param name="extension">Whether or not to use this extension method.</param>
        /// <returns>Returns a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static string ToString(this SecureString str, bool extension)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return extension ? new NetworkCredential(string.Empty, str).Password : str.ToString();
        }

        /// <summary>
        /// Parses a shorthand time span string (e.g. 3w 2d 1.5h) and converts it to an instance of
        /// <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>Returns an instance of <see cref="TimeSpan"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static TimeSpan ToTimeSpan(this string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return TimeSpanParser.Parse(str);
        }
    }
}
