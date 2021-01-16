using System;
using System.ComponentModel;
using System.Reflection;

namespace X10D
{
    /// <summary>
    ///     Extension methods for various reflection types.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        ///     Gets the value set in this member's annotated <see cref="DefaultValueAttribute" />, or
        ///     <see langword="default" /> if none exists.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Returns an <see cref="object" /> representing the value stored in this member's
        ///     <see cref="DefaultValueAttribute" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="member" /> is <see langword="null" />.</exception>
        public static object GetDefaultValue(this MemberInfo member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (!(member.GetCustomAttribute<DefaultValueAttribute>() is { } attribute))
            {
                return default;
            }

            return attribute.Value;
        }

        /// <summary>
        ///     Gets the value set in this member's annotated <see cref="DefaultValueAttribute" />, or
        ///     <see langword="default" /> if none exists.
        /// </summary>
        /// <typeparam name="T">The type to which the value should cast.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Returns an instance of <typeparamref name="T" /> representing the value stored in this member's
        ///     <see cref="DefaultValueAttribute" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="member" /> is <see langword="null" />.</exception>
        public static T GetDefaultValue<T>(this MemberInfo member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            return (T)member.GetDefaultValue();
        }

        /// <summary>
        ///     Gets the value set in this member's annotated <see cref="DescriptionAttribute" />, or
        ///     <see langword="null" /> if none exists.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Returns a string representing the value stored in this member's
        ///     <see cref="DescriptionAttribute" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="member" /> is <see langword="null" />.</exception>
        public static string GetDescription(this MemberInfo member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (!(member.GetCustomAttribute<DescriptionAttribute>() is { } attribute))
            {
                return null;
            }

            return attribute.Description;
        }

        /// <summary>
        ///     Retrieves a custom attribute of a specified type that is applied to the specified member, and passes it
        ///     to a selector delegate in order to select one or more the members in the attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <typeparam name="TReturn">The return type of the <paramref name="selector" /> delegate.</typeparam>
        /// <param name="member">The member.</param>
        /// <param name="selector">The selector delegate.</param>
        /// <returns>
        ///     Returns an instance of <typeparamref name="TReturn" /> as provided from
        ///     <paramref name="selector" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="member" /> is <see langword="null" />
        ///     -or-
        ///     <paramref name="selector" /> is <see langword="null" />.
        /// </exception>
        public static TReturn SelectFromCustomAttribute<TAttribute, TReturn>(
            this MemberInfo member,
            Func<TAttribute, TReturn> selector)
            where TAttribute : Attribute
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (selector is null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            if (!(member.GetCustomAttribute<TAttribute>() is { } attribute))
            {
                return default;
            }

            return selector(attribute);
        }
    }
}
