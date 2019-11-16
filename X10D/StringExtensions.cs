namespace X10D
{
    #region Using Directives

    using System;
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
        public static string Base64Decode(this string data) =>
            Convert.FromBase64String(data).GetString();

        /// <summary>
        /// Encodes a base-64 encoded string.
        /// </summary>
        /// <param name="value">The plain text string to decode.</param>
        /// <returns>Returns the string in plain text.</returns>
        public static string Base64Encode(this string value) =>
            Convert.ToBase64String(value.GetBytes());

        /// <summary>
        /// Parses a <see cref="String"/> into an <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
        public static T EnumParse<T>(this string value) =>
            value.EnumParse<T>(false);

        /// <summary>
        /// Parses a <see cref="String"/> into an <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Enum</typeparam>
        /// <param name="value">String value to parse</param>
        /// <param name="ignoreCase">Whether or not to ignore casing.</param>
        /// <returns>The Enum corresponding to the stringExtensions</returns>
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
                throw new ArgumentException("Type provided must be an Enum.", "T");
            }

            return (T)Enum.Parse(t, value, ignoreCase);
        }

        /// <summary>
        /// Gets a <see cref="Byte"/>[] representing the value the <see cref="String"/> with
        /// <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this string str) =>
            str.GetBytes(Encoding.UTF8);

        /// <summary>
        /// Gets a <see cref="Byte"/>[] representing the value the <see cref="String"/> with the provided encoding.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>Returns a <see cref="Byte"/>[].</returns>
        public static byte[] GetBytes(this string str, Encoding encoding) =>
            encoding.GetBytes(str);

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
        public static string ToString(this SecureString str, bool extension) =>
            extension ? (new NetworkCredential(String.Empty, str).Password) : str.ToString();
    }
}
