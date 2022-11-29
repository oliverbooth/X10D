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
        return source.AsReadOnly().Split(delimiter);
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
        return source.AsReadOnly().Split(delimiter);
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

    /// <summary>
    ///     Enumerates the elements of a <see cref="ReadOnlySpan{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of elements in the span.</typeparam>
    public ref struct SpanSplitEnumerator<T> where T : struct, IEquatable<T>
    {
        private ReadOnlySpan<T> _source;
        private readonly ReadOnlySpan<T> _delimiterSpan;
        private readonly T _delimiter;
        private readonly bool _usingSpanDelimiter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpanSplitEnumerator{T}" /> struct.
        /// </summary>
        /// <param name="source">The source span.</param>
        /// <param name="delimiter">The delimiting span of elements.</param>
        public SpanSplitEnumerator(in ReadOnlySpan<T> source, ReadOnlySpan<T> delimiter)
        {
            _usingSpanDelimiter = true;
            _source = source;
            _delimiter = default;
            _delimiterSpan = delimiter;
            Current = ReadOnlySpan<T>.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpanSplitEnumerator{T}" /> struct.
        /// </summary>
        /// <param name="source">The source span.</param>
        /// <param name="delimiter">The delimiting element.</param>
        public SpanSplitEnumerator(in ReadOnlySpan<T> source, T delimiter)
        {
            _usingSpanDelimiter = false;
            _source = source;
            _delimiter = delimiter;
            _delimiterSpan = ReadOnlySpan<T>.Empty;
            Current = ReadOnlySpan<T>.Empty;
        }

        /// <summary>
        ///     Gets the element at the current position of the enumerator.
        /// </summary>
        /// <value>The element in the <see cref="ReadOnlySpan{T}" /> at the current position of the enumerator.</value>
        public ReadOnlySpan<T> Current { get; private set; }

        /// <summary>
        ///     Returns the current enumerator.
        /// </summary>
        /// <returns>The current instance of <see cref="SpanSplitEnumerator{T}" />.</returns>
        /// <remarks>
        ///     This method exists to provide the ability to enumerate within a <c>foreach</c> loop. It should not be called
        ///     manually.
        /// </remarks>
        public readonly SpanSplitEnumerator<T> GetEnumerator()
        {
            return this;
        }

        /// <summary>
        ///     Advances the enumerator to the next element of the <see cref="ReadOnlySpan{T}" />.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" />
        ///     if the enumerator has passed the end of the span.
        /// </returns>
        public bool MoveNext()
        {
            if (_source.Length == 0)
            {
                return false;
            }

            int index = _usingSpanDelimiter ? _source.IndexOf(_delimiterSpan) : _source.IndexOf(_delimiter);
            if (index == -1)
            {
                Current = _source;
                _source = ReadOnlySpan<T>.Empty;
                return true;
            }

            Current = _source[..index];
            _source = _source[(index + 1)..];
            return true;
        }
    }
}
