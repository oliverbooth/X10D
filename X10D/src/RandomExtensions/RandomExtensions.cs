using System;
using System.Collections.Generic;
using System.Linq;

namespace X10D.RandomExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="Random" />.
    /// </summary>
    public static class RandomExtensions
    {
        internal static readonly Random Random = new();

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
    }
}
