using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Extension methods for <see cref="RaycastHit" />.
/// </summary>
public static class RaycastHitExtensions
{
    /// <summary>
    ///     Gets the component of the specified type from the object that was hit by the raycast.
    /// </summary>
    /// <param name="hit">The raycast hit.</param>
    /// <typeparam name="T">The type of the component to retrieve.</typeparam>
    /// <returns>
    ///     The component of the specified type from the object that was hit by the raycast, or <see langword="null" /> if no
    ///     component of the specified type was found.
    /// </returns>
    public static T? GetComponent<T>(this RaycastHit hit)
    {
        if (hit.transform == null)
        {
            return default;
        }

        return hit.transform.GetComponent<T>();
    }

    /// <summary>
    ///     Gets the component of the specified type from the object that was hit by the raycast.
    /// </summary>
    /// <param name="hit">The raycast hit.</param>
    /// <param name="componentType">The type of the component to retrieve.</param>
    /// <returns>
    ///     The component of the specified type from the object that was hit by the raycast, or <see langword="null" /> if no
    ///     component of the specified type was found.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="componentType" /> is <see langword="null" />.</exception>
    public static Component? GetComponent(this RaycastHit hit, Type componentType)
    {
        if (componentType is null)
        {
            throw new ArgumentNullException(nameof(componentType));
        }

        if (hit.transform == null)
        {
            return default;
        }

        return hit.transform.GetComponent(componentType);
    }


    /// <summary>
    ///     Attempts to get the component of the specified type from the object that was hit by the raycast, and returns a value
    ///     that indicates whether the operation succeeded.
    /// </summary>
    /// <param name="hit">The raycast hit.</param>
    /// <param name="component">
    ///     When this method returns, contains the component of the specified type from the object that was hit by the raycast, or
    ///     <see langword="null" /> if no component of the specified type was found.
    /// </param>
    /// <typeparam name="T">The type of the component to retrieve.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the component of the specified type was found; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryGetComponent<T>(this RaycastHit hit, [NotNullWhen(true)] out T? component)
    {
        if (hit.transform == null)
        {
            component = default;
            return false;
        }

        return hit.transform.TryGetComponent(out component);
    }

    /// <summary>
    ///     Attempts to get the component of the specified type from the object that was hit by the raycast, and returns a value
    ///     that indicates whether the operation succeeded.
    /// </summary>
    /// <param name="hit">The raycast hit.</param>
    /// <param name="componentType">The type of the component to retrieve.</param>
    /// <param name="component">
    ///     When this method returns, contains the component of the specified type from the object that was hit by the raycast, or
    ///     <see langword="null" /> if no component of the specified type was found.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the component of the specified type was found; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="componentType" /> is <see langword="null" />.</exception>
    public static bool TryGetComponent(this RaycastHit hit, Type componentType, [NotNullWhen(true)] out Component? component)
    {
        if (componentType is null)
        {
            throw new ArgumentNullException(nameof(componentType));
        }

        if (hit.transform == null)
        {
            component = default;
            return false;
        }

        return hit.transform.TryGetComponent(componentType, out component);
    }
}
