using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Represents a class which implements the singleton pattern for a specific <see cref="MonoBehaviour" />. This class is not
///     thread-safe.
/// </summary>
/// <typeparam name="T">The type of the singleton.</typeparam>
public abstract class Singleton<T> : MonoBehaviour
    where T : Singleton<T>
{
    private static Lazy<T> s_instanceLazy = new(CreateLazyInstanceInternal, false);

    /// <summary>
    ///     Gets the instance of the singleton.
    /// </summary>
    /// <value>The singleton instance.</value>
    public static T Instance
    {
        get => s_instanceLazy.Value;
    }

    /// <summary>
    ///     Called when the object is destroyed.
    /// </summary>
    protected virtual void OnDestroy()
    {
        s_instanceLazy = new Lazy<T>(CreateLazyInstanceInternal, false);
    }

    private static T CreateLazyInstanceInternal()
    {
        if (FindObjectOfType<T>() is { } instance)
        {
            return instance;
        }

        var gameObject = new GameObject {name = typeof(T).Name};
        return gameObject.AddComponent<T>();
    }
}
