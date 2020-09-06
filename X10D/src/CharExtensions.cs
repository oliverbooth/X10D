namespace X10D
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///     Extension methods for <see cref="char" />.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        ///     Generates a new random string by filling it with characters found in <see cref="chars" />.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <typeparam name="T"> A generic char collection, allows for implicit vars. </typeparam>
        /// <returns>Returns a <see cref="string" /> containing <paramref name="length" /> characters.</returns>
        public static T Random<T>(this T chars, int length)
            where T : IEnumerable<char>
        {
            return chars.Random(length, RandomExtensions.Random);
        }

        /// <summary>
        ///     Generates a new random string by filling it with characters found in <see cref="chars" />.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="count">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// /// <typeparam name="T"> A generic char collection, allows for implicit vars. </typeparam>
        /// <returns>Returns a <see cref="string" /> containing <paramref name="count" /> characters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static T Random<T>(this T chars, int count, Random random)
            where T : IEnumerable<char>
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var buffer = new char[count];
            for (var i = 0; i < count; i++)
            {
                buffer[i] = chars.ElementAt(random.Next(0, chars.Count()));
            }

            return (T)(chars is string
                ? (IEnumerable)new string(buffer)
                : buffer);
        }

        /// <summary>
        ///     Repeats a character a specified number of times.
        /// </summary>
        /// <param name="c">The character to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> whose value is <paramref name="c" /> repeated
        ///     <paramref name="count" /> times.
        /// </returns>
        public static string Repeat(this char c, int count)
        {
            return new string(c, count);
        }
    }
}
