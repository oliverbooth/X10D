namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Span{T}" /> and <see cref="ReadOnlySpan{T}" />
/// </summary>
public static class SpanExtensions
{
    /// <summary>
    ///     Returns the number of times that a specified element appears in a span of elements of the same type.
    /// </summary>
    /// <param name="source">The source to search.</param>
    /// <param name="element">The element to count.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>The number of times that <paramref name="element" /> appears in <paramref name="source" />.</returns>
    public static int Count<T>(this in Span<T> source, T element)
        where T : IEquatable<T>
    {
        return source.AsReadOnly().Count(element);
    }

    /// <summary>
    ///     Returns the number of times that a specified element appears in a read-only span of elements of the same type.
    /// </summary>
    /// <param name="source">The source to search.</param>
    /// <param name="element">The element to count.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>The number of times that <paramref name="element" /> appears in <paramref name="source" />.</returns>
    public static int Count<T>(this in ReadOnlySpan<T> source, T element)
        where T : IEquatable<T>
    {
        var count = 0;

        foreach (T item in source)
        {
            if (item.Equals(element))
            {
                count++;
            }
        }

        return count;
    }

    /// <summary>
    ///     Returns a read-only <see cref="ReadOnlySpan{T}" /> wrapper for the current span.
    /// </summary>
    /// <param name="source">The source span.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>A <see cref="ReadOnlySpan{T}" /> which wraps the elements in <paramref name="source" />.</returns>
    public static ReadOnlySpan<T> AsReadOnly<T>(this in Span<T> source)
    {
        return source;
    }

    /// <summary>
    ///     Splits a span of elements into sub-spans based on a delimiting element.
    /// </summary>
    /// <param name="source">The span to split.</param>
    /// <param name="delimiter">The delimiting element.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     An enumerator which wraps <paramref name="source"/> and delimits the elements based on <paramref name="delimiter" />.
    /// </returns>
    public static SpanSplitEnumerator<T> Split<T>(this in Span<T> source, T delimiter)
        where T : struct, IEquatable<T>
    {
        return new SpanSplitEnumerator<T>(source, delimiter);
    }

    /// <summary>
    ///     Splits a span of elements into sub-spans based on a delimiting element.
    /// </summary>
    /// <param name="source">The span to split.</param>
    /// <param name="delimiter">The delimiting element.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     An enumerator which wraps <paramref name="source"/> and delimits the elements based on <paramref name="delimiter" />.
    /// </returns>
    public static SpanSplitEnumerator<T> Split<T>(this in ReadOnlySpan<T> source, T delimiter)
        where T : struct, IEquatable<T>
    {
        return new SpanSplitEnumerator<T>(source, delimiter);
    }

    /// <summary>
    ///     Splits a span of elements into sub-spans based on a span of delimiting elements.
    /// </summary>
    /// <param name="source">The span to split.</param>
    /// <param name="delimiter">The span of delimiting elements.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     An enumerator which wraps <paramref name="source"/> and delimits the elements based on <paramref name="delimiter" />.
    /// </returns>
    public static SpanSplitEnumerator<T> Split<T>(this in Span<T> source, in ReadOnlySpan<T> delimiter)
        where T : struct, IEquatable<T>
    {
        return new SpanSplitEnumerator<T>(source, delimiter);
    }

    /// <summary>
    ///     Splits a span of elements into sub-spans based on a span of delimiting elements.
    /// </summary>
    /// <param name="source">The span to split.</param>
    /// <param name="delimiter">The span of delimiting elements.</param>
    /// <typeparam name="T">The type of elements in <paramref name="source" />.</typeparam>
    /// <returns>
    ///     An enumerator which wraps <paramref name="source"/> and delimits the elements based on <paramref name="delimiter" />.
    /// </returns>
    public static SpanSplitEnumerator<T> Split<T>(this in ReadOnlySpan<T> source, in ReadOnlySpan<T> delimiter)
        where T : struct, IEquatable<T>
    {
        return new SpanSplitEnumerator<T>(source, delimiter);
    }
}
