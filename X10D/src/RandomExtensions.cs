namespace X10D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for <see cref="Random"/>.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Gets the <see cref="System.Random"/> instance to which other extension methods may refer, when one is
        /// needed but not provided.
        /// </summary>
        internal static Random Random { get; } = new Random();

        /// <summary>
        /// Returns either <see langword="true"/> or <see langword="false"/> based on <paramref name="random"/>'s next
        /// generation.
        /// </summary>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <returns>Returns <see langword="true"/> or <see langword="false"/> depending on the return value
        /// from <see cref="System.Random.Next(int)"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="random"/> is <see langword="null"/>.</exception>
        public static bool CoinToss(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return random.Next(2) == 0;
        }

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="System.Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <param name="source">The collection from which to draw.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this Random random, params T[] source)
        {
            return source.ToList().OneOf(random);
        }

        /// <summary>
        /// Returns a random element from <paramref name="source"/> using the <see cref="System.Random"/> instance.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="random">The <see cref="System.Random"/> instance.</param>
        /// <param name="source">The collection from which to draw.</param>
        /// <returns>Returns a random element of type <see cref="T"/> from <paramref name="source"/>.</returns>
        public static T OneOf<T>(this Random random, IList<T> source)
        {
            return source[random.Next(source.Count)];
        }
    }
}
