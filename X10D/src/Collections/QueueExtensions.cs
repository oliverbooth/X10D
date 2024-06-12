namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Queue{T}" />.
/// </summary>
public static class QueueExtensions
{
    /// <summary>
    ///     Adds an enumerable collection of objects to the end of the <see cref="Queue{T}" />, in the order that they were
    ///     enumerated.
    /// </summary>
    /// <param name="queue">The queue to which the elements will be added.</param>
    /// <param name="values">An enumerable collection of elements to enqueue.</param>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="queue" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="values" /> is <see langword="null" />.</para>
    /// </exception>
    public static void EnqueueAll<TElement>(this Queue<TElement> queue, IEnumerable<TElement> values)
    {
        if (queue is null)
        {
            throw new ArgumentNullException(nameof(queue));
        }

        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        foreach (TElement element in values)
        {
            queue.Enqueue(element);
        }
    }

    /// <summary>
    ///     Removes and returns each element from the queue starting at the beginning, until the queue is empty.
    /// </summary>
    /// <param name="queue">The queue from which the elements will be removed.</param>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="queue" /> is <see langword="null" />.</exception>
    public static IEnumerable<TElement> DequeueAll<TElement>(this Queue<TElement> queue)
    {
        if (queue is null)
        {
            throw new ArgumentNullException(nameof(queue));
        }

        while (queue.Count > 0)
        {
            yield return queue.Dequeue();
        }
    }
}
