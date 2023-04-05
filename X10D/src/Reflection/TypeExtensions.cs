using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Reflection;

/// <summary>
///     Extension methods for <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    ///     Returns a value indicating whether the current type implements a specified interface.
    /// </summary>
    /// <param name="value">The type whose interface list to check.</param>
    /// <typeparam name="T">The interface type.</typeparam>
    /// <returns><see langword="true" /> if the current exists on the type; otherwise, <see langword="false" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool Implements<T>(this Type value)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value);
#else
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
#endif

        return value.Implements(typeof(T));
    }

    /// <summary>
    ///     Returns a value indicating whether the current type implements a specified interface.
    /// </summary>
    /// <param name="value">The type whose interface list to check.</param>
    /// <param name="interfaceType">The interface type.</param>
    /// <returns><see langword="true" /> if the current exists on the type; otherwise, <see langword="false" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="value" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="interfaceType" /> is <see langword="null" />.</para>
    /// </exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool Implements(this Type value, Type interfaceType)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(interfaceType);
#else
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (interfaceType is null)
        {
            throw new ArgumentNullException(nameof(interfaceType));
        }
#endif

        if (!interfaceType.IsInterface)
        {
            string? exceptionMessage = ExceptionMessages.TypeIsNotInterface;
            string formattedMessage = string.Format(CultureInfo.CurrentCulture, exceptionMessage, interfaceType);

            throw new ArgumentException(formattedMessage, nameof(interfaceType));
        }

        return Array.IndexOf(value.GetInterfaces(), interfaceType) >= 0;
    }

    /// <summary>
    ///     Returns a value indicating whether the current type inherits a specified type.
    /// </summary>
    /// <param name="value">The type whose interface list to check.</param>
    /// <typeparam name="T">The base type.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the current type inherits <typeparamref name="T" />, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="value" /> is not a class.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool Inherits<T>(this Type value)
        where T : class
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value);
#else
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
#endif

        return value.Inherits(typeof(T));
    }

    /// <summary>
    ///     Returns a value indicating whether the current type inherits a specified type.
    /// </summary>
    /// <param name="value">The type whose interface list to check.</param>
    /// <param name="type">The base type.</param>
    /// <returns>
    ///     <see langword="true" /> if the current type inherits <paramref name="type" />, or <see langword="false" />
    ///     otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="value" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="type" /> is <see langword="null" />.</para>
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <para><paramref name="value" /> is not a class.</para>
    ///     -or-
    ///     <para><paramref name="type" /> is not a class.</para>
    /// </exception>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool Inherits(this Type value, Type type)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(type);
#else
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }
#endif

        if (!value.IsClass)
        {
            string? exceptionMessage = ExceptionMessages.TypeIsNotClass;
            string formattedMessage = string.Format(CultureInfo.CurrentCulture, exceptionMessage, value);

            throw new ArgumentException(formattedMessage, nameof(value));
        }

        if (!type.IsClass)
        {
            string? exceptionMessage = ExceptionMessages.TypeIsNotClass;
            string formattedMessage = string.Format(CultureInfo.CurrentCulture, exceptionMessage, type);

            throw new ArgumentException(formattedMessage, nameof(type));
        }

        return value.IsSubclassOf(type);
    }
}
