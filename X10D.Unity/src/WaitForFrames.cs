using System.Collections;

namespace X10D.Unity;

/// <summary>
///     Represents a yield instruction that waits for a specific number of frames.
/// </summary>
public struct WaitForFrames : IEnumerator
{
    private readonly int _frameCount;
    private int _frameIndex;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitForFrames" /> struct.
    /// </summary>
    /// <param name="frameCount">The frame count.</param>
    public WaitForFrames(int frameCount)
    {
        _frameCount = frameCount;
        _frameIndex = 0;
    }

    /// <inheritdoc />
    public object Current
    {
        get => _frameCount;
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        return ++_frameIndex <= _frameCount;
    }

    /// <inheritdoc />
    public void Reset()
    {
        _frameIndex = 0;
    }
}
