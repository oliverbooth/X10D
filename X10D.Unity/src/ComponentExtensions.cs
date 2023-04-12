using UnityEngine;

namespace X10D.Unity;

/// <summary>
///     Extension methods for <see cref="Component" />.
/// </summary>
public static class ComponentExtensions
{
    /// <summary>
    ///     Returns an array of components of the specified type, excluding components that live on the object to which this
    ///     component is attached.
    /// </summary>
    /// <param name="component">The component whose child components to retrieve.</param>
    /// <typeparam name="T">The type of the components to retrieve.</typeparam>
    /// <returns>An array <typeparamref name="T" /> representing the child components.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="component" /> is <see langword="null" />.</exception>
    public static T[] GetComponentsInChildrenOnly<T>(this Component component)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        return component.gameObject.GetComponentsInChildrenOnly<T>();
    }
}
