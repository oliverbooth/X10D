using System.Collections;

namespace X10D.Unity;

/// <summary>
///     Represents a yield instruction which waits for a given amount of time, as provided by a <see cref="TimeSpan" />.
/// </summary>
/// <remarks>This struct exists as an allocation-free alternative to <see cref="UnityEngine.WaitForSecondsRealtime" />.</remarks>
public readonly struct WaitForSecondsRealtimeNoAlloc : IEnumerator
{
    private readonly DateTime _expectedEnd;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitForTimeSpan" /> struct.
    /// </summary>
    /// <param name="duration">The duration of the pause, in seconds.</param>
    public WaitForSecondsRealtimeNoAlloc(float duration)
    {
        _expectedEnd = DateTime.Now + TimeSpan.FromSeconds(duration);
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
