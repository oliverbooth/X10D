namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="ICollection{T}" /> and <see cref="IReadOnlyCollection{T}" />.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        ///     Splits <paramref name="value" /> into chunks of size <paramref name="chunkSize" />.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="value">The collection to split.</param>
        /// <param name="chunkSize">The maximum length of the nested collection.</param>
        /// <returns>
        ///     An <see cref="IEnumerable{T}" /> containing an <see cref="IEnumerable{T}" /> of <typeparamref name="T" />
        ///     whose lengths are no greater than <paramref name="chunkSize" />.
        /// </returns>
        public static IEnumerable<IReadOnlyCollection<T>> Split<T>(this IReadOnlyCollection<T> value, int chunkSize)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int count = value.Count;
            chunkSize = chunkSize.Clamp(1, count);

            for (var i = 0; i < count / chunkSize; i++)
            {
                yield return value.Skip(i * chunkSize).Take(chunkSize).ToArray();
            }
        }
    }
}
