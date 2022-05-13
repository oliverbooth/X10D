using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Extension methods for <see cref="Transform" />.
/// </summary>
public static class TransformExtensions
{
    /// <summary>
    ///     Rotates this transform so the forward vector points at another game object.
    /// </summary>
    /// <param name="transform">The transform whose rotation will be changed.</param>
    /// <param name="target">The game object to look at.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="transform" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    public static void LookAt(this Transform transform, GameObject target)
    {
        if (transform == null)
        {
            throw new ArgumentNullException(nameof(transform));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        transform.LookAt(target.transform);
    }

    /// <summary>
    ///     Rotates this transform so the forward vector points at another game object.
    /// </summary>
    /// <param name="transform">The transform whose rotation will be changed.</param>
    /// <param name="target">The game object to look at.</param>
    /// <param name="worldUp">A vector specifying the upward direction.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="transform" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    public static void LookAt(this Transform transform, GameObject target, Vector3 worldUp)
    {
        if (transform == null)
        {
            throw new ArgumentNullException(nameof(transform));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        transform.LookAt(target.transform, worldUp);
    }

    /// <summary>
    ///     Sets the parent of this transform.
    /// </summary>
    /// <param name="transform">The transform whose parent to change.</param>
    /// <param name="parent">The new parent.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="transform" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="parent" /> is <see langword="null" />.</para>
    /// </exception>
    public static void SetParent(this Transform transform, GameObject parent)
    {
        if (transform == null)
        {
            throw new ArgumentNullException(nameof(transform));
        }

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        transform.transform.SetParent(parent.transform);
    }

    /// <summary>
    ///     Sets the parent of this transform.
    /// </summary>
    /// <param name="transform">The transform whose parent to change.</param>
    /// <param name="parent">The new parent.</param>
    /// <param name="worldPositionStays">
    ///     <see langword="true" /> to modify the parent-relative position, scale and rotation such that the object keeps the same
    ///     world space position, rotation and scale as before; otherwise, <see langword="false" />.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="transform" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="parent" /> is <see langword="null" />.</para>
    /// </exception>
    public static void SetParent(this Transform transform, GameObject parent, bool worldPositionStays)
    {
        if (transform == null)
        {
            throw new ArgumentNullException(nameof(transform));
        }

        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }

        transform.SetParent(parent.transform, worldPositionStays);
    }
}
