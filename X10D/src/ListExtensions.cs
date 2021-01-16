using System;
using System.Collections.Generic;
using System.Linq;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="IList{T}" />.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///     Returns a random element from <paramref name="source" /> using a new <see cref="Random" /> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T" /> from <paramref name="source" />.</returns>
        public static T OneOf<T>(this IEnumerable<T> source)
        {
            return source.OneOf(new Random());
        }

        /// <summary>
        ///     Returns a random element from <paramref name="source" /> using the <see cref="Random" /> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <param name="random">The <see cref="Random" /> instance.</param>
        /// <returns>Returns a random element of type <see cref="T" /> from <paramref name="source" />.</returns>
        public static T OneOf<T>(this IEnumerable<T> source, Random random)
        {
            return source.ToList().OneOf(random);
        }

        /// <summary>
        ///     Returns a random element from <paramref name="source" /> using a new <see cref="Random" /> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T" /> from <paramref name="source" />.</returns>
        public static T OneOf<T>(this IList<T> source)
        {
            return source.OneOf(new Random());
        }

        /// <summary>
        ///     Returns a random element from <paramref name="source" /> using the <see cref="Random" /> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <param name="random">The <see cref="Random" /> instance.</param>
        /// <returns>Returns a random element of type <see cref="T" /> from <paramref name="source" />.</returns>
        public static T OneOf<T>(this IList<T> source, Random random)
        {
            return random.OneOf(source);
        }

        /// <summary>
        ///     Reorganizes the elements in a list by implementing a Fisher-Yates shuffle.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The <see cref="IList{T}" /> to shuffle.</param>
        /// <param name="random">The <see cref="Random" /> instance.</param>
        public static void Shuffle<T>(this IList<T> source, System.Random? random = null)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            random ??= RandomExtensions.Random;

            var count = source.Count;
            while (count > 0)
            {
                var index = random.Next(count--);
                var temp = source[count];
                source[count] = source[index];
                source[index] = temp;
            }
        }
    }
}
