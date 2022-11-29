using System.Diagnostics.Contracts;

namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    ///     Returns a number that represents how many elements in the specified sequence do not satisfy a condition.
    /// </summary>
    /// <param name="source">A sequence that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     A number that represents how many elements in the sequence do not satisfy the condition in the
    ///     <paramref name="predicate" /> function.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
    /// <exception cref="OverflowException">
    ///     The number of elements in <paramref name="source" /> is larger than <see cref="int.MaxValue" />.
    /// </exception>
    [Pure]
    public static int CountWhereNot<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
#if NET6_0
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        return source.Count(item => !predicate(item));
    }

    /// <summary>
    ///     Returns the first element in a sequence that does not satisfy a specified condition.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" /></typeparam>
    /// <returns>The first element in the sequence that fails the test in the specified predicate function.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
    /// <exception cref="InvalidOperationException">
    ///     <para>No element satisfies the condition in predicate.</para>
    ///      -or-
    ///     <para>The source sequence is empty.</para>
    /// </exception>
    [Pure]
    public static TSource FirstWhereNot<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
#if NET6_0
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        return source.First(item => !predicate(item));
    }

    /// <summary>
    ///     Returns the first element in a sequence that does not satisfy a specified condition.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" /></typeparam>
    /// <returns>
    ///     <see langword="default(TSource)" /> if <paramref name="source" /> is empty or if no element passes the test specified
    ///     by <paramref name="predicate"/>; otherwise, the first element in <paramref name="source" /> that fails the test
    ///     specified by <paramref name="predicate" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
    [Pure]
    public static TSource? FirstWhereNotOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
#if NET6_0
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        return source.FirstOrDefault(item => !predicate(item));
    }

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

            await item.DisposeAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    ///     Returns the last element in a sequence that does not satisfy a specified condition.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" /></typeparam>
    /// <returns>The last element in the sequence that fails the test in the specified predicate function.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
    /// <exception cref="InvalidOperationException">
    ///     <para>No element satisfies the condition in predicate.</para>
    ///      -or-
    ///     <para>The source sequence is empty.</para>
    /// </exception>
    [Pure]
    public static TSource LastWhereNot<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
#if NET6_0
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        return source.Last(item => !predicate(item));
    }

    /// <summary>
    ///     Returns the last element in a sequence that does not satisfy a specified condition.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" /></typeparam>
    /// <returns>
    ///     <see langword="default(TSource)" /> if <paramref name="source" /> is empty or if no element passes the test specified
    ///     by <paramref name="predicate"/>; otherwise, the last element in <paramref name="source" /> that fails the test
    ///     specified by <paramref name="predicate" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
    [Pure]
    public static TSource? LastWhereNotOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
#if NET6_0
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        return source.LastOrDefault(item => !predicate(item));
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

    /// <summary>
    ///     Filters a sequence of values based on a predicate, such that all elements in the result do not match the predicate.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}" /> to filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> that contains elements from the input sequence that do not satisfy the condition.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
    [Pure]
    public static IEnumerable<TSource> WhereNot<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
#if NET6_0
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        return source.Where(item => !predicate(item));
    }
}
