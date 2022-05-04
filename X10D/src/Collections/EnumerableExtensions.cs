using System.Diagnostics.Contracts;

namespace X10D.Collections;

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
    /// <returns>The shuffled collection.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [Pure]
    public static IReadOnlyCollection<T> Shuffled<T>(this IEnumerable<T> source, Random? random = null)
    {
        ArgumentNullException.ThrowIfNull(source);

        var list = new List<T>(source);
        list.Shuffle(random);
        return list.AsReadOnly();
    }
}
