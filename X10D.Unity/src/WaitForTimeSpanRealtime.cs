using System.Collections;

namespace X10D.Unity;

/// <summary>
///     Represents a yield instruction which waits for a given amount of time, as provided by a <see cref="TimeSpan" />.
/// </summary>
public readonly struct WaitForTimeSpanRealtime : IEnumerator
{
    private readonly DateTime _expectedEnd;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitForTimeSpanRealtime" /> struct.
    /// </summary>
    /// <param name="duration">The duration of the pause.</param>
    public WaitForTimeSpanRealtime(TimeSpan duration)
    {
        _expectedEnd = DateTime.Now + duration;
    }

    /// <inheritdoc />
    public object Current
    {
        get => DateTime.Now;
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        return DateTime.Now < _expectedEnd;
    }

    /// <inheritdoc />
    public void Reset()
    {
    }
}
