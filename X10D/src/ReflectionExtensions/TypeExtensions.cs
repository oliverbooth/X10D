using System.Globalization;
using System.Reflection;

namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="Type" />.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     Returns a value indicating whether or not the current type has been decorated with a specified attribute.
        /// </summary>
        /// <param name="type">The type whose attributes to check.</param>
        /// <typeparam name="T">The attribute type.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if the current type has been decorated with a specified attribute, or
        ///     <see langword="false" /> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type" /> is <see langword="null" />.</exception>
        public static bool HasCustomAttribute<T>(this Type type)
            where T : Attribute
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.HasCustomAttribute(typeof(T));
        }

        /// <summary>
        ///     Returns a value indicating whether or not the current type has been decorated with a specified attribute.
        /// </summary>
        /// <param name="type">The type whose attributes to check.</param>
        /// <param name="attribute">The attribute type.</param>
        /// <returns>
        ///     <see langword="true" /> if the current type has been decorated with a specified attribute, or
        ///     <see langword="false" /> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type" /> is <see langword="null" />.</exception>
        public static bool HasCustomAttribute(this Type type, Type attribute)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (attribute is null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }

            if (!attribute.Inherits<Attribute>())
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, ExceptionMessages.TypeDoesNotInheritAttribute, attribute),
                    nameof(attribute));
            }

            return type.GetCustomAttribute(attribute) is not null;
        }

        /// <summary>
        ///     Returns a value indicating whether the current type implements a specified interface.
        /// </summary>
        /// <param name="value">The type whose interface list to check.</param>
        /// <typeparam name="T">The interface type.</typeparam>
        /// <returns><see langword="true" /> if the current exists on the type; otherwise, <see langword="false" />.</returns>
        public static bool Implements<T>(this Type value)
        {
            return value.Implements(typeof(T));
        }

        /// <summary>
        ///     Returns a value indicating whether the current type implements a specified interface.
        /// </summary>
        /// <param name="value">The type whose interface list to check.</param>
        /// <param name="interfaceType">The interface type.</param>
        /// <returns><see langword="true" /> if the current exists on the type; otherwise, <see langword="false" />.</returns>
        public static bool Implements(this Type value, Type interfaceType)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (interfaceType is null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }

            if (!interfaceType.IsInterface)
            {
                var exceptionMessage = ExceptionMessages.TypeIsNotInterface;
                var formattedMessage = string.Format(CultureInfo.CurrentCulture, exceptionMessage, interfaceType);

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
        public static bool Inherits<T>(this Type value)
            where T : class
        {
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
        public static bool Inherits(this Type value, Type type)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!value.IsClass)
            {
                var exceptionMessage = ExceptionMessages.TypeIsNotClass;
                var formattedMessage = string.Format(CultureInfo.CurrentCulture, exceptionMessage, value);

                throw new ArgumentException(formattedMessage, nameof(value));
            }

            if (!type.IsClass)
            {
                var exceptionMessage = ExceptionMessages.TypeIsNotClass;
                var formattedMessage = string.Format(CultureInfo.CurrentCulture, exceptionMessage, type);

                throw new ArgumentException(formattedMessage, nameof(type));
            }

            return value.IsSubclassOf(type);
        }

        /// <summary>
        ///     Retrieves a custom attribute that is decorated by the current type, and projects it into to a new form.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <typeparam name="TReturn">The return type of the <paramref name="selector" /> delegate.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="selector">A transform function to apply to the attribute.</param>
        /// <returns>
        ///     An instance of <typeparamref name="TReturn" /> as provided from <paramref name="selector" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="type" /> is <see langword="null" />
        ///     -or-
        ///     <paramref name="selector" /> is <see langword="null" />.
        /// </exception>
        public static TReturn? SelectFromCustomAttribute<TAttribute, TReturn>(this Type type, Func<TAttribute, TReturn> selector)
            where TAttribute : Attribute
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (selector is null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return type.GetCustomAttribute<TAttribute>() is { } attribute
                ? selector(attribute)
                : default;
        }
    }
}
