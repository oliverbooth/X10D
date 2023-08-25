namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="ICollection{T}" />.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    ///     Calls <see cref="IDisposable.Dispose" /> on each item in the collection, then clears the collection by calling
    ///     <see cref="ICollection{T}.Clear" />.
    /// </summary>
    /// <param name="source">The collection to clear, and whose elements should be disposed.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> is read-only.</exception>
    /// <seealso cref="EnumerableExtensions.DisposeAll{T}" />
    public static void ClearAndDisposeAll<T>(this ICollection<T> source) where T : IDisposable
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.IsReadOnly)
        {
            throw new InvalidOperationException(ExceptionMessages.CollectionIsReadOnly_DisposeAll);
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

        source.Clear();
    }

    /// <summary>
    ///     Asynchronously calls <see cref="IAsyncDisposable.DisposeAsync" /> on each item in the collection, then clears the
    ///     collection by calling <see cref="ICollection{T}.Clear" />.
    /// </summary>
    /// <param name="source">The collection to clear, and whose elements should be disposed.</param>
    /// <typeparam name="T">The type of the elements in <paramref name="source" />.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> is read-only.</exception>
    /// <seealso cref="EnumerableExtensions.DisposeAllAsync{T}" />
    public static async Task ClearAndDisposeAllAsync<T>(this ICollection<T> source) where T : IAsyncDisposable
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source.IsReadOnly)
        {
            throw new InvalidOperationException(ExceptionMessages.CollectionIsReadOnly_DisposeAllAsync);
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

        source.Clear();
    }
}
