namespace X10D
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

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
        public static T OneOf<T>(this IEnumerable<T> source) =>
            source.OneOf(new Random());

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IEnumerable<T> source, Random random) =>
            source.ToList().OneOf(random);

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using a new <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IList<T> source) =>
            source.OneOf(new Random());

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="source">The collection to draw from.</param>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this IList<T> source, Random random) =>
            random.OneOf(source);
    }
}
