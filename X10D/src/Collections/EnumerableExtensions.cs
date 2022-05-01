using System.Diagnostics.Contracts;

namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    ///     Performs the specified action on each element of the <see cref="IEnumerable{T}" />.
    /// </summary>
    /// <param name="source">
    ///     The <see cref="IEnumerable{T}" /> whose elements on which to perform <paramref name="action" />.
    /// </param>
    /// <param name="action">
    ///     The <see cref="Action{T, T}" /> delegate to perform on each element of the <see cref="IEnumerable{T}" />. The
    ///     <see cref="int" /> argument passed to this delegate represents the index.
    /// </param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="action" /> is <see langword="null" />.</para>
    /// </exception>
    public static void For<T>(this IEnumerable<T> source, Action<int, T> action)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        var index = 0;
        foreach (T item in source)
        {
            action(index++, item);
        }
    }

    /// <summary>
    ///     Performs the specified action on each element of the <see cref="IEnumerable{T}" />.
    /// </summary>
    /// <param name="source">
    ///     The <see cref="IEnumerable{T}" /> whose elements on which to perform <paramref name="action" />.
    /// </param>
    /// <param name="action">
    ///     The <see cref="Action{T}" /> delegate to perform on each element of the <see cref="IEnumerable{T}" />.
    /// </param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="action" /> is <see langword="null" />.</para>
    /// </exception>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        foreach (T item in source)
        {
            action(item);
        }
    }

    /// <summary>
    ///     Reorganizes the elements in an enumerable by implementing a Fisher-Yates shuffle, and returns th shuffled result.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}" /> to shuffle.</param>
    /// <param name="random">Optional. The <see cref="System.Random" /> instance to use for the shuffling.</param>
    [Pure]
    public static IReadOnlyCollection<T> Shuffled<T>(this IEnumerable<T> source, Random? random = null)
    {
        var list = new List<T>(source);
        list.Shuffle(random);
        return list.AsReadOnly();
    }
}
