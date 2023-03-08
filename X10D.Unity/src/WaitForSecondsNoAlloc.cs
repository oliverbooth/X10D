using System.Collections;

namespace X10D.Unity;

/// <summary>
///     Represents a yield instruction which waits for a specified amount of seconds.
/// </summary>
/// <remarks>This struct exists as an allocation-free alternative to <see cref="UnityEngine.WaitForSeconds" />.</remarks>
public struct WaitForSecondsNoAlloc : IEnumerator
{
    private readonly float _duration;
    private float _delta;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitForTimeSpan" /> struct.
    /// </summary>
    /// <param name="duration">The duration of the pause, in seconds.</param>
    public WaitForSecondsNoAlloc(float duration)
    {
        _duration = duration;
        _delta = 0f;
    }

    /// <inheritdoc />
    public object Current
    {
        get => _delta;
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        _delta += UnityEngine.Time.deltaTime;
        return _delta < _duration;
    }

    /// <inheritdoc />
    public void Reset()
    {
    }
}
