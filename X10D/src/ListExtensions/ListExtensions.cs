namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="IList{T}" /> and <see cref="IReadOnlyList{T}" />.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///     Returns a random element from the current list using a specified <see cref="System.Random" /> instance.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source collection from which to draw.</param>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>A random element of type <see cref="T" /> from <paramref name="source" />.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="random" /> is is <see langword="null" />
        ///     -or-
        ///     <paramref name="source" /> is <see langword="null" />.
        /// </exception>
        /// <example>
        ///     <code lang="csharp">
        /// var list = new List&lt;int&gt; { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// var number = list.Random();
        ///     </code>
        /// </example>
        public static T Random<T>(this IReadOnlyList<T> source, Random? random = null)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            random ??= RandomExtensions.Random;
            return random.NextFrom(source);
        }

        /// <summary>
        ///     Reorganizes the elements in a list by implementing a Fisher-Yates shuffle.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The <see cref="IList{T}" /> to shuffle.</param>
        /// <param name="random">Optional. The <see cref="System.Random" /> instance to use for the shuffling.</param>
        public static void Shuffle<T>(this IList<T> source, Random? random = null)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            random ??= RandomExtensions.Random;

            int count = source.Count;
            while (count > 0)
            {
                int index = random.Next(count--);
                (source[count], source[index]) = (source[index], source[count]);
            }
        }
    }
}
