namespace X10D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extension methods for <see cref="Char"/>.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="chars"/>.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a <see cref="String"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this char[] chars, int length)
        {
            return chars.Random(length, new Random());
        }

        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="chars"/>.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns a <see cref="String"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this char[] chars, int length, Random random)
        {
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(chars.ElementAt(random.Next(0, chars.Length)));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="chars"/>.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a <see cref="String"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this IEnumerable<char> chars, int length)
        {
            return chars.Random(length, new Random());
        }

        /// <summary>
        /// Generates a new random string by filling it with characters found in <see cref="chars"/>.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns a <see cref="String"/> containing <paramref name="length"/> characters.</returns>
        public static string Random(this IEnumerable<char> chars, int length, Random random)
        {
            return chars.ToArray().Random(length, random);
        }

        /// <summary>
        /// Repeats a character a specified number of times.
        /// </summary>
        /// <param name="c">The character to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>Returns a <see cref="String"/> whose value is <paramref name="c"/> repeated
        /// <paramref name="count"/> times.</returns>
        public static string Repeat(this char c, int count)
        {
            return new string(c, count);
        }
    }
}
