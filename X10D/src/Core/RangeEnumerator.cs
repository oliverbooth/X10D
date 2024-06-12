namespace X10D.Core;

/// <summary>
///     Enumerates the indices of a <see cref="Range" />.
/// </summary>
public struct RangeEnumerator
{
    private readonly bool _decrement;
    private readonly int _endValue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RangeEnumerator" /> structure.
    /// </summary>
    /// <param name="range">The range over which to enumerate.</param>
    public RangeEnumerator(Range range)
    {
        Index start = range.Start;
        Index end = range.End;

        int startValue = start.IsFromEnd ? -start.Value : start.Value;
        _endValue = end.IsFromEnd ? -end.Value : end.Value;

        _decrement = _endValue < startValue;
        Current = _decrement ? startValue + 1 : startValue - 1;
    }

    /// <summary>
    ///     Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    /// <value>The element in the collection at the current position of the enumerator.</value>
    public int Current { get; private set; }

    /// <summary>
    ///     Advances the enumerator to the next element of the collection.
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if
    ///     the enumerator has passed the end of the collection.
    /// </returns>
    public bool MoveNext()
    {
        int value = Current;

        if (_decrement)
        {
            Current--;
            return value > _endValue;
        }

        Current++;
        return value < _endValue;
    }
}
