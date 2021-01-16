using System.Collections.Generic;
using System.Linq;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Splits <paramref name="value" /> into chunks of size <paramref name="chunkSize" />.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="value">The collection to split.</param>
        /// <param name="chunkSize">The maximum length of the nested <see cref="byte" /> collection.</param>
        /// <returns>
        ///     Returns an <see cref="IEnumerable{T}" /> of <see cref="IEnumerable{T}" /> of <see cref="byte" />
        ///     values.
        /// </returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> value, int chunkSize)
        {
            var enumerable = value.ToArray();
            var count = enumerable.LongCount();
            chunkSize = chunkSize.Clamp(1, enumerable.Length);

            for (var i = 0; i < (int)(count / chunkSize); i++)
            {
                yield return enumerable.Skip(i * chunkSize).Take(chunkSize);
            }
        }
    }
}
