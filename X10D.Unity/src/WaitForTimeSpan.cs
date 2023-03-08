using System.Collections;

namespace X10D.Unity;

/// <summary>
///     Represents a yield instruction which waits for a given amount of time, as provided by a <see cref="TimeSpan" />.
/// </summary>
public struct WaitForTimeSpan : IEnumerator
{
    private readonly TimeSpan _duration;
    private readonly DateTime _start;
    private DateTime _current;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitForTimeSpan" /> struct.
    /// </summary>
    /// <param name="duration">The duration of the pause.</param>
    public WaitForTimeSpan(TimeSpan duration)
    {
        _duration = duration;
        _start = DateTime.Now;
        _current = _start;
    }

    /// <inheritdoc />
    public object Current
    {
        get => _current;
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        _current += TimeSpan.FromSeconds(UnityEngine.Time.deltaTime);
        return _current < _start + _duration;
    }

    /// <inheritdoc />
    public void Reset()
    {
    }
}
