using System.Collections.Generic;
using System.Linq;
using X10D.ComparableExtensions;
using X10D.ListExtensions;

namespace X10D.EnumerableExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Reorganizes the elements in an enumerable by implementing a Fisher-Yates shuffle, and returns th shuffled result.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}" /> to shuffle.</param>
        /// <param name="random">Optional. The <see cref="System.Random" /> instance to use for the shuffling.</param>
        public static IReadOnlyCollection<T> Shuffled<T>(this IEnumerable<T> source, System.Random? random = null)
        {
            var list = new List<T>(source);
            list.Shuffle(random);
            return list.AsReadOnly();
        }

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
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> value, int chunkSize)
        {
            var enumerable = value.ToArray();
            var count = enumerable.LongLength;
            chunkSize = chunkSize.Clamp(1, enumerable.Length);

            for (var i = 0; i < (int)(count / chunkSize); i++)
            {
                yield return enumerable.Skip(i * chunkSize).Take(chunkSize);
            }
        }
    }
}
