using System.Collections;
using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Represents a yield instruction that waits for a key to be released.
/// </summary>
public readonly struct WaitForKeyUp : IEnumerator
{
    private readonly KeyCode _keyCode;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitForKeyUp" /> struct.
    /// </summary>
    /// <param name="keyCode">The key to wait for.</param>
    public WaitForKeyUp(KeyCode keyCode)
    {
        _keyCode = keyCode;
    }

    /// <inheritdoc />
    public object Current
    {
        get => _keyCode == KeyCode.None || Input.GetKeyUp(_keyCode);
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        return !(_keyCode == KeyCode.None || Input.GetKeyUp(_keyCode));
    }

    /// <inheritdoc />
    public void Reset()
    {
    }
}
