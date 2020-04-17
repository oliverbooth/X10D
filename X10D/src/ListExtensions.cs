namespace X10D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for <see cref="IList{T}"/>.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns a random element from <paramref name="source"/> using a new <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IEnumerable<T> source)
        {
            return source.OneOf(new Random());
        }

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IEnumerable<T> source, Random random)
        {
            return source.ToList().OneOf(random);
        }

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using a new <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IList<T> source)
        {
            return source.OneOf(new Random());
        }

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IList<T> source, Random random)
        {
            return random.OneOf(source);
        }

        /// <summary>
        /// Shuffles an enumerable.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to shuffle.</param>
        /// <returns>Returns <paramref name="source"/> shuffled.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        /// <summary>
        /// Shuffles an enumerable.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to shuffle.</param>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>Returns <paramref name="source"/> shuffled.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
        {
            return source.OrderBy(_ => random.Next());
        }

        /// <summary>
        /// Shuffles a list.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to shuffle.</param>
        /// <returns>Returns <paramref name="source"/> shuffled.</returns>
        public static IEnumerable<T> Shuffle<T>(this IList<T> source)
        {
            return source.Shuffle(new Random());
        }

        /// <summary>
        /// Shuffles a list.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to shuffle.</param>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>Returns <paramref name="source"/> shuffled.</returns>
        public static IEnumerable<T> Shuffle<T>(this IList<T> source, Random random)
        {
            return source.OrderBy(_ => random.Next());
        }
    }
}
