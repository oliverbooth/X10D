namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Span{T}" /> and <see cref="ReadOnlySpan{T}" />
/// </summary>
public static class SpanExtensions
{
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

#if !NET8_0_OR_GREATER
    /// <summary>
    ///     Replaces all occurrences of a specified element in a span of elements with another specified element.
    /// </summary>
    /// <param name="haystack">The source span.</param>
    /// <param name="needle">The element to replace.</param>
    /// <param name="replacement">The replacement element.</param>
    /// <typeparam name="T">The type of elements in <paramref name="haystack" />.</typeparam>
    public static void Replace<T>(this Span<T> haystack, T needle, T replacement) where T : struct
    {
        var comparer = EqualityComparer<T>.Default;

        for (var index = 0; index < haystack.Length; index++)
        {
            if (comparer.Equals(haystack[index], needle))
            {
                haystack[index] = replacement;
            }
        }
    }
#endif

#if !NET9_0_OR_GREATER
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
#endif
}
