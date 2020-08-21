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
        /// <returns>Returns a <see cref="string" /> containing <paramref name="length" /> characters.</returns>
        public static char[] Random(this char[] chars, int length)
        {
            return chars.Random(length, RandomExtensions.Random);
        }

        /// <summary>
        ///     Generates a new random string by filling it with characters found in <see cref="chars" />.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>Returns a <see cref="string" /> containing <paramref name="length" /> characters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static char[] Random(this IEnumerable<char> chars, int length, Random random)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                buffer[i] = chars.ElementAt(random.Next(0, chars.Count()));
            }

            return buffer;
        }

        /// <summary>
        ///     Generates a new random string by filling it with characters found in <see cref="chars" />.
        /// </summary>
        /// <param name="chars">The character set.</param>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a <see cref="string" /> containing <paramref name="length" /> characters.</returns>
        public static char[] Random(this IEnumerable<char> chars, int length)
        {
            return chars.Random(length, RandomExtensions.Random);
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
        public static char[] Repeat(this char c, int count)
        {
            return Enumerable.Repeat(c, count).ToArray();
        }
    }
}
