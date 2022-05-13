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
    ///     Calls <see cref="IDisposable.Dispose" /> on all elements of the <see cref="IEnumerable{T}" />.
    /// </summary>
    /// <param name="source">The enumerable collection whose elements to dispose.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <seealso cref="CollectionExtensions.ClearAndDisposeAll{T}" />
    public static void DisposeAll<T>(this IEnumerable<T> source) where T : IDisposable
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        foreach (T item in source)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (item is null)
            {
                continue;
            }

            item.Dispose();
        }
    }

    /// <summary>
    ///     Asynchronously calls <see cref="IAsyncDisposable.DisposeAsync" /> on all elements of the
    ///     <see cref="IEnumerable{T}" />.
    /// </summary>
    /// <param name="source">The enumerable collection whose elements to dispose.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <seealso cref="CollectionExtensions.ClearAndDisposeAllAsync{T}" />
    public static async Task DisposeAllAsync<T>(this IEnumerable<T> source) where T : IAsyncDisposable
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        foreach (T item in source)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (item is null)
            {
                continue;
            }

            await item.DisposeAsync();
        }
    }

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
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(source);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
#endif

        var list = new List<T>(source);
        list.Shuffle(random);
        return list.AsReadOnly();
    }
}
