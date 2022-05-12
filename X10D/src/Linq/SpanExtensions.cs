using System.Diagnostics.Contracts;

namespace X10D.Linq;

/// <summary>
///     Extension methods for <see cref="Span{T}" />.
/// </summary>
public static class SpanExtensions
{
    /// <summary>
    ///     Determines whether all elements of a span satisfy a condition.
    /// </summary>
    /// <param name="source">A <see cref="Span{T}" /> that contains the elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if every element of the source sequence passes the test in the specified predicate, or if the
    ///     span is empty; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is <see langword="null" />.</exception>
    [Pure]
    public static bool All<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

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
    ///     Determines whether any element of a span satisfies a condition.
    /// </summary>
    /// <param name="source">A <see cref="Span{T}" /> that contains the elements to apply the predicate to.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the source span is not empty and at least one of its elements passes the test in the
    ///     specified predicate; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is <see langword="null" />.</exception>
    [Pure]
    public static bool Any<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

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

    /// <summary>
    ///     Returns a number that represents how many elements in the specified sequence satisfy a condition.
    /// </summary>
    /// <param name="source">A <see cref="Span{T}" /> that contains elements to be tested and counted.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <typeparam name="TSource">The type of the elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     A number that represents how many elements in the sequence satisfy the condition in the predicate function.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is <see langword="null" />.</exception>
    public static int Count<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(predicate);
#else
        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
#endif

        if (source.IsEmpty)
        {
            return 0;
        }

        var count = 0;

        foreach (TSource item in source)
        {
            if (predicate(item))
            {
                count++;
            }
        }

        return count;
    }
}
