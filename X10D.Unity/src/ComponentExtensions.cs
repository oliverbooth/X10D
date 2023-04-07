using System.Globalization;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace X10D.Unity;

/// <summary>
///     Extension methods for <see cref="Component" />.
/// </summary>
public static class ComponentExtensions
{
    /// <summary>
    ///     Copies the component to another game object.
    /// </summary>
    /// <param name="component">The component to copy.</param>
    /// <param name="target">The game object to which the component will be copied.</param>
    /// <typeparam name="T">The type of the component to copy.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="component" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     <paramref name="target" /> already has a component of type <typeparamref name="T" />.
    /// </exception>
    /// <remarks>
    ///     This method will destroy the component on the source game object, creating a new instance on the target. Use with
    ///     caution.
    /// </remarks>
    public static void CopyTo<T>(this T component, GameObject target)
        where T : Component
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        if (target.TryGetComponent(out T targetComponent))
        {
            string message = ExceptionMessages.ComponentAlreadyExists;
            message = string.Format(CultureInfo.CurrentCulture, message, target.name, typeof(T).Name);
            throw new InvalidOperationException(message);
        }

        targetComponent = target.AddComponent<T>();

        var typeInfo = typeof(T).GetTypeInfo();
        CopyFields(typeInfo, component, targetComponent);
        CopyProperties(typeInfo, component, targetComponent);
    }

    /// <summary>
    ///     Copies the component to another game object.
    /// </summary>
    /// <param name="component">The component to copy.</param>
    /// <param name="target">The game object to which the component will be copied.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="component" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     <paramref name="target" /> already has a component of the same type.
    /// </exception>
    /// <remarks>
    ///     This method will destroy the component on the source game object, creating a new instance on the target. Use with
    ///     caution.
    /// </remarks>
    public static void CopyTo(this Component component, GameObject target)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        var componentType = component.GetType();
        if (target.TryGetComponent(componentType, out Component targetComponent))
        {
            string message = ExceptionMessages.ComponentAlreadyExists;
            message = string.Format(CultureInfo.CurrentCulture, message, target.name, componentType.Name);
            throw new InvalidOperationException(message);
        }

        targetComponent = target.AddComponent(componentType);

        var typeInfo = componentType.GetTypeInfo();
        CopyFields(typeInfo, component, targetComponent);
        CopyProperties(typeInfo, component, targetComponent);
    }

    /// <summary>
    ///     Returns an array of components of the specified type, excluding components that live on the object to which this
    ///     component is attached.
    /// </summary>
    /// <param name="component">The component whose child components to retrieve.</param>
    /// <typeparam name="T">The type of the components to retrieve.</typeparam>
    /// <returns>An array <typeparamref name="T" /> representing the child components.</returns>
    public static T[] GetComponentsInChildrenOnly<T>(this Component component)
    {
        return component.gameObject.GetComponentsInChildrenOnly<T>();
    }

    /// <summary>
    ///     Moves the component to another game object.
    /// </summary>
    /// <param name="component">The component to move.</param>
    /// <param name="target">The game object to which the component will be moved.</param>
    /// <typeparam name="T">The type of the component to move.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="component" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     <paramref name="target" /> already has a component of type <typeparamref name="T" />.
    /// </exception>
    /// <remarks>
    ///     This method will destroy the component on the source game object, creating a new instance on the target. Use with
    ///     caution.
    /// </remarks>
    public static void MoveTo<T>(this T component, GameObject target)
        where T : Component
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        component.CopyTo(target);
        Object.Destroy(component);
    }

    /// <summary>
    ///     Moves the component to another game object.
    /// </summary>
    /// <param name="component">The component to move.</param>
    /// <param name="target">The game object to which the component will be moved.</param>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="component" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="target" /> is <see langword="null" />.</para>
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     <paramref name="target" /> already has a component of the same type.
    /// </exception>
    /// <remarks>
    ///     This method will destroy the component on the source game object, creating a new instance on the target. Use with
    ///     caution.
    /// </remarks>
    public static void MoveTo(this Component component, GameObject target)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        component.CopyTo(target);
        Object.Destroy(component);
    }

    private static void CopyFields<T>(TypeInfo typeInfo, T component, T targetComponent)
        where T : Component
    {
        foreach (FieldInfo field in typeInfo.DeclaredFields)
        {
            if (field.IsStatic)
            {
                continue;
            }

            object fieldValue = GetNewReferences(component, targetComponent, field.GetValue(component));
            field.SetValue(targetComponent, fieldValue);
        }
    }

    private static void CopyProperties<T>(TypeInfo typeInfo, T component, T targetComponent)
        where T : Component
    {
        foreach (PropertyInfo property in typeInfo.DeclaredProperties)
        {
            if (!property.CanRead || !property.CanWrite)
            {
                continue;
            }

            MethodInfo getMethod = property.GetMethod;
            MethodInfo setMethod = property.SetMethod;
            if (getMethod.IsStatic || setMethod.IsStatic)
            {
                continue;
            }

            object propertyValue = GetNewReferences(component, targetComponent, property.GetValue(component));
            property.SetValue(targetComponent, propertyValue);
        }
    }

    private static object GetNewReferences<T>(T component, T targetComponent, object value)
        where T : Component
    {
        if (ReferenceEquals(value, component))
        {
            value = targetComponent;
        }
        else if (ReferenceEquals(value, component.gameObject))
        {
            value = targetComponent.gameObject;
        }

        return value;
    }
}
