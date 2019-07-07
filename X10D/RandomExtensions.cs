namespace X10D
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Random"/>.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this Random random, params T[] source) =>
            source[random.Next(source.Length)];

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this Random random, IList<T> source) =>
            source[random.Next(source.Count)];
    }
}
