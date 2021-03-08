using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X10D.RandomExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="Random" />.
    /// </summary>
    public static class RandomExtensions
    {
        internal static readonly Random Random = new();

        /// <summary>
        ///     Returns a random value that defined in a specified enum.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <typeparam name="T">An enum type.</typeparam>
        /// <returns>
        ///     A <typeparamref name="T" /> value at index <c>n</c> where <c>n = </c><see cref="System.Random.Next(int)" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static T Next<T>(this Random random)
            where T : struct, Enum
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length))!;
        }

        /// <summary>
        ///     Returns either <see langword="true" /> or <see langword="false" /> based on the next generation of the current
        ///     <see cref="System.Random" />.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>
        ///     <see langword="true" /> if the return value from <see cref="System.Random.NextDouble()" /> is greater than or
        ///     equal to 0.5
        ///     -or-
        ///     <see langword="false" /> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static bool NextBoolean(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return random.NextDouble() >= 0.5;
        }
        
        /// <summary>
        ///     Returns a random double-precision floating point number that is within a specified range.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">
        ///     The exclusive upper bound of the random number returned. This value must be greater than or equal to
        ///     <paramref name="minValue" />.
        /// </param>
        /// <returns>
        ///     A random double-precision floating point number between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="maxValue" /> is less than <paramref name="minValue" />.
        /// </exception>
        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (maxValue < minValue)
            {
                throw new ArgumentException("maximum must be greater than or equal to minimum.");
            }

            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        ///     Returns a random element from <paramref name="source" /> using the <see cref="System.Random" /> instance.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <param name="source">The source collection from which to draw.</param>
        /// <returns>A random element of type <see cref="T" /> from <paramref name="source" />.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="random" /> is is <see langword="null" />
        ///     -or-
        ///     <paramref name="source" /> is <see langword="null" />.
        /// </exception>
        /// <example>
        /// <code lang="csharp">
        /// var list = new List&lt;int&gt; { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// var random = new Random();
        /// var number = random.NextFrom(list);
        /// </code>
        /// </example>
        public static T NextFrom<T>(this System.Random random, IEnumerable<T> source)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is T[] array)
            {
                return array[random.Next(array.Length)];
            }

            if (source is not IReadOnlyList<T> list)
            {
                list = source.ToList();
            }

            return list[random.Next(list.Count)];
        }

        /// <summary>
        ///     Returns a random single-precision floating point number between 0 and 1.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>A random single-precision floating point number between 0 and 1.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static float NextSingle(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return random.NextSingle(0, 1);
        }

        /// <summary>
        ///     Returns a random single-precision floating point number that is within a specified range.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">
        ///     The exclusive upper bound of the random number returned. This value must be greater than or equal to
        ///     <paramref name="minValue" />.
        /// </param>
        /// <returns>
        ///     A random single-precision floating point number between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="maxValue" /> is less than <paramref name="minValue" />.
        /// </exception>
        public static float NextSingle(this Random random, float minValue, float maxValue)
        {
            return (float)random.NextDouble(minValue, maxValue);
        }

        /// <summary>
        ///     Returns a new string of a specified length which is composed of specified characters.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <param name="source">The source collection of characters to poll.</param>
        /// <param name="length">The length of the new string to generate.</param>
        /// <returns>
        ///     A <see cref="string" /> whose length is equal to that of <paramref name="length" />, composed of characters
        ///     specified by the characters in <paramref name="source" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="random" /> is <see langword="null" />.
        ///     -or-
        ///     <paramref name="source" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length" /> is less than 0.</exception>
        public static string NextString(this Random random, IReadOnlyList<char> source, int length)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), ExceptionMessages.LengthMustBePositiveValue);
            }

            if (length == 0)
            {
                return string.Empty;
            }

            if (length == 1)
            {
                return source[random.Next(0, source.Count)].ToString();
            }

            var builder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                builder.Append(source[random.Next(0, source.Count)]);
            }

            return builder.ToString();
        }
    }
}
