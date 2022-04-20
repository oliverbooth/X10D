namespace X10D;

/// <summary>
///     Extension methods for <see cref="ReadOnlySpan{T}" />.
/// </summary>
public static class ReadOnlySpanExtensions
{
    /// <summary>
    ///     Determines whether all elements of a read-only span satisfy a condition.
    /// </summary>
    /// <param name="source">A <see cref="ReadOnlySpan{T}" /> that contains the elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if every element of the source sequence passes the test in the specified predicate, or if the
    ///     span is empty; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is <see langword="null" />.</exception>
    public static bool All<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
    {
        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        if (source.IsEmpty)
        {
            return true;
        }

        for (var index = 0; index < source.Length; index++)
        {
            if (!predicate(source[index]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether any element of a read-only span satisfies a condition.
    /// </summary>
    /// <param name="source">A <see cref="ReadOnlySpan{T}" /> that contains the elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the source span is not empty and at least one of its elements passes the test in the
    ///     specified predicate; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is <see langword="null" />.</exception>
    public static bool Any<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
    {
        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        if (source.IsEmpty)
        {
            return false;
        }

        for (var index = 0; index < source.Length; index++)
        {
            if (predicate(source[index]))
            {
                return true;
            }
        }

        return false;
    }
}
