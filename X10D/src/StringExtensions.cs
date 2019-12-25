namespace X10D
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security;
    using System.Text;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="String"/>.
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
        /// Parses a <see cref="String"/> into an <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="value">The <see cref="String"/> value to parse</param>
        /// <returns>The <see cref="Enum"/> value corresponding to the <see cref="String"/>.</returns>
        public static T EnumParse<T>(this string value)
        {
            return value.EnumParse<T>(false);
        }

        /// <summary>
        /// Parses a <see cref="String"/> into an <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="value">The <see cref="String"/> value to parse</param>
        /// <param name="ignoreCase">Whether or not to ignore casing.</param>
        /// <returns>The <see cref="Enum"/> value corresponding to the <see cref="String"/></returns>
        public static T EnumParse<T>(this string value, bool ignoreCase)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = value.Trim();

            if (value.Length == 0)
            {
                throw new ArgumentException("Must specify valid information for parsing in the string.",
                    nameof(value));
            }

            Type t = typeof(T);

            if (!t.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", nameof(T));
            }

            return (T) Enum.Parse(t, value, ignoreCase);
        }

        /// <summary>
        /// Gets a <see cref="Byte"/>[] representing the value the <see cref="String"/> with
        /// <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this string str)
        {
            return str.GetBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Gets a <see cref="Byte"/>[] representing the value the <see cref="String"/> with the provided encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="str"/>.
        /// </summary>
        /// <param name="str">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a <see cref="String"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this string str, int length)
        {
            return str.Random(length, new Random());
        }

        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="str"/>.
        /// </summary>
        /// <param name="str">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns a <see cref="String"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this string str, int length, Random random)
        {
            return str.ToCharArray().Random(length, random);
        }

        /// <summary>
        /// Repeats a string a specified number of times.
        /// </summary>
        /// <param name="str">The string to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>Returns a <see cref="String"/> whose value is <paramref name="str"/> repeated
        /// <paramref name="count"/> times.</returns>
        public static string Repeat(this string str, int count)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                builder.Append(str);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Shuffles the characters in the string.
        /// </summary>
        /// <param name="str">The string to shuffle.</param>
        /// <returns>Returns a <see cref="String"/> containing the characters in <paramref name="str"/>, rearranged.</returns>
        public static string Shuffle(this string str)
        {
            return str.Shuffle(new Random());
        }

        /// <summary>
        /// Shuffles the characters in the string.
        /// </summary>
        /// <param name="str">The string to shuffle.</param>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns a <see cref="String"/> containing the characters in <paramref name="str"/>, rearranged.</returns>
        public static string Shuffle(this string str, Random random)
        {
            return new string(str.ToCharArray().Shuffle(random).ToArray());
        }

        /// <summary>
        /// Splits the <see cref="String"/> into chunks that are no greater than <paramref name="chunkSize"/> in length.
        /// </summary>
        /// <param name="str">The string to split.</param>
        /// <param name="chunkSize">The maximum length of each string in the returned result.</param>
        /// <returns>Returns an <see cref="IEnumerable{T}"/> containing <see cref="String"/> instances which are no
        /// greater than <paramref name="chunkSize"/> in length.</returns>
        public static IEnumerable<string> Split(this string str, int chunkSize)
        {
            for (int i = 0; i < str.Length; i += chunkSize)
            {
                yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
            }
        }

        /// <summary>
        /// Converts a <see cref="String"/> to a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>Returns a <see cref="SecureString"/>.</returns>
        public static SecureString ToSecureString(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
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
        /// Converts a <see cref="SecureString"/> to a <see cref="String"/>.
        /// </summary>
        /// <param name="str">The <see cref="SecureString"/> to convert.</param>
        /// <param name="extension">Whether or not to use this extension method.</param>
        /// <returns>Returns a <see cref="String"/>.</returns>
        public static string ToString(this SecureString str, bool extension)
        {
            return extension ? (new NetworkCredential(String.Empty, str).Password) : str.ToString();
        }
    }
}
