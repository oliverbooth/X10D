namespace X10D;

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
    public static IReadOnlyCollection<T> Shuffled<T>(this IEnumerable<T> source, Random? random = null)
    {
        var list = new List<T>(source);
        list.Shuffle(random);
        return list.AsReadOnly();
    }

    /// <summary>
    ///     Splits <paramref name="source" /> into chunks of size <paramref name="chunkSize" />.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <param name="source">The collection to split.</param>
    /// <param name="chunkSize">The maximum length of the nested collection.</param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> containing an <see cref="IEnumerable{T}" /> of <typeparamref name="T" />
    ///     whose lengths are no greater than <paramref name="chunkSize" />.
    /// </returns>
    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int chunkSize)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var buffer = new List<T>(chunkSize);
            
        foreach (var item in source)
        {
            buffer.Add(item);
                
            if (buffer.Count >= chunkSize)
            {
                yield return buffer;
                buffer.Clear();
            }
        }

        if (buffer.Count > 0)
        {
            yield return buffer;
        }
    }
}
