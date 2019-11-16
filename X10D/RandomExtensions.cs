namespace X10D
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Random"/>.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns either <see langword="true"/> or <see langword="false"/> based on <paramref name="random"/>'s next
        /// generation.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        public static bool CoinToss(this Random random) =>
            random.Next(2) == 0;

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="random">The <see cref="Random"/> instance.</param>
        /// <param name="source">The collection to draw from.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this Random random, params T[] source) =>
            source.ToList().OneOf(random);

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
