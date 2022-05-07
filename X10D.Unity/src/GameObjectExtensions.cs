using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Extension methods for <see cref="GameObject" />.
/// </summary>
public static class GameObjectExtensions
{
    /// <summary>
    ///     Returns an array of components of the specified type, excluding components that live on this game object.
    /// </summary>
    /// <param name="gameObject">The game object whose child components to retrieve.</param>
    /// <typeparam name="T">The type of the components to retrieve.</typeparam>
    /// <returns>An array <typeparamref name="T" /> representing the child components.</returns>
    public static T[] GetComponentsInChildrenOnly<T>(this GameObject gameObject)
    {
        var components = new List<T>(gameObject.GetComponentsInChildren<T>());

        for (var index = 0; index < components.Count; index++)
        {
            if (components[index] is not Component childComponent)
            {
                // this shouldn't happen, since you can't add a non-Component to a game object,
                // but GetComponentsInChildren<T> is not constrained, so this method shouldn't be either
                continue;
            }

            if (childComponent.transform.parent != gameObject.transform)
            {
                components.RemoveAt(index);
                index--;
            }
        }

        return components.ToArray();
    }

    /// <summary>
    ///     Rotates the transform component of this game object so the forward vector points at another game object.
    /// </summary>
    /// <param name="gameObject">The game object whose rotation will be changed.</param>
    /// <param name="target">The game object to look at.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    public static void LookAt(this GameObject gameObject, GameObject target)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        gameObject.transform.LookAt(target.transform);
    }

    /// <summary>
    ///     Rotates the transform component of this game object so the forward vector points at <paramref name="target" />.
    /// </summary>
    /// <param name="gameObject">The game object whose rotation will be changed.</param>
    /// <param name="target">The point to look at.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameObject" /> is <see langword="null" />.</exception>
    public static void LookAt(this GameObject gameObject, Vector3 target)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        gameObject.transform.LookAt(target);
    }

    /// <summary>
    ///     Rotates the transform component of this game object so the forward vector points at a specified transform.
    /// </summary>
    /// <param name="gameObject">The game object whose rotation will be changed.</param>
    /// <param name="target">The transform to look at.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    public static void LookAt(this GameObject gameObject, Transform target)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        gameObject.transform.LookAt(target);
    }

    /// <summary>
    ///     Rotates the transform component of this game object so the forward vector points at another game object.
    /// </summary>
    /// <param name="gameObject">The game object whose rotation will be changed.</param>
    /// <param name="target">The game object to look at.</param>
    /// <param name="worldUp">A vector specifying the upward direction.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    public static void LookAt(this GameObject gameObject, GameObject target, Vector3 worldUp)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        gameObject.transform.LookAt(target.transform, worldUp);
    }

    /// <summary>
    ///     Rotates the transform component of this game object so the forward vector points at <paramref name="target" />.
    /// </summary>
    /// <param name="gameObject">The game object whose rotation will be changed.</param>
    /// <param name="target">The point to look at.</param>
    /// <param name="worldUp">A vector specifying the upward direction.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameObject" /> is <see langword="null" />.</exception>
    public static void LookAt(this GameObject gameObject, Vector3 target, Vector3 worldUp)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        gameObject.transform.LookAt(target, worldUp);
    }

    /// <summary>
    ///     Rotates the transform component of this game object so the forward vector points at a specified transform.
    /// </summary>
    /// <param name="gameObject">The game object whose rotation will be changed.</param>
    /// <param name="target">The transform to look at.</param>
    /// <param name="worldUp">A vector specifying the upward direction.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    public static void LookAt(this GameObject gameObject, Transform target, Vector3 worldUp)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        gameObject.transform.LookAt(target, worldUp);
    }

    /// <summary>
    ///     Sets the parent of this game object.
    /// </summary>
    /// <param name="gameObject">The game object whose parent to change.</param>
    /// <param name="parent">The new parent.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="parent" /> is <see langword="null" />.</para>
    /// </exception>
    public static void SetParent(this GameObject gameObject, GameObject parent)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        gameObject.transform.SetParent(parent.transform);
    }

    /// <summary>
    ///     Sets the parent of this game object.
    /// </summary>
    /// <param name="gameObject">The game object whose parent to change.</param>
    /// <param name="parent">The new parent.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="parent" /> is <see langword="null" />.</para>
    /// </exception>
    public static void SetParent(this GameObject gameObject, Transform parent)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        gameObject.transform.SetParent(parent);
    }

    /// <summary>
    ///     Sets the parent of this game object.
    /// </summary>
    /// <param name="gameObject">The game object whose parent to change.</param>
    /// <param name="parent">The new parent.</param>
    /// <param name="worldPositionStays">
    ///     <see langword="true" /> to modify the parent-relative position, scale and rotation such that the object keeps the same
    ///     world space position, rotation and scale as before; otherwise, <see langword="false" />.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="parent" /> is <see langword="null" />.</para>
    /// </exception>
    public static void SetParent(this GameObject gameObject, GameObject parent, bool worldPositionStays)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        gameObject.transform.SetParent(parent.transform, worldPositionStays);
    }

    /// <summary>
    ///     Sets the parent of this game object.
    /// </summary>
    /// <param name="gameObject">The game object whose parent to change.</param>
    /// <param name="parent">The new parent.</param>
    /// <param name="worldPositionStays">
    ///     <see langword="true" /> to modify the parent-relative position, scale and rotation such that the object keeps the same
    ///     world space position, rotation and scale as before; otherwise, <see langword="false" />.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="gameObject" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="parent" /> is <see langword="null" />.</para>
    /// </exception>
    public static void SetParent(this GameObject gameObject, Transform parent, bool worldPositionStays)
    {
        if (gameObject == null)
        {
            throw new ArgumentNullException(nameof(gameObject));
        }

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        gameObject.transform.SetParent(parent, worldPositionStays);
    }
}
