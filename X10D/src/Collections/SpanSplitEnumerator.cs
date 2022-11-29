namespace X10D.Collections;

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
    public SpanSplitEnumerator(ReadOnlySpan<T> source, ReadOnlySpan<T> delimiter)
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
    public SpanSplitEnumerator(ReadOnlySpan<T> source, T delimiter)
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
