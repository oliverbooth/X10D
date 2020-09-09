namespace X10D
{
    using System;

    /// <summary>
    ///     Extension methods for <see cref="IConvertible" />.
    /// </summary>
    public static class ConvertibleExtensions
    {
        /// <summary>
        ///     Converts the object to another type.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>Returns the value converted to <typeparamref name="T" />.</returns>
        /// <exception cref="InvalidCastException">
        ///     This conversion is not supported.
        ///     -or-
        ///     <paramref name="value" /> is <see langword="null" /> and <typeparamref name="T" /> is a value type.
        /// </exception>
        [CLSCompliant(false)]
        public static T To<T>(this IConvertible value, IFormatProvider provider = null)
        {
            if (value is null)
            {
                return default;
            }

            return (T)Convert.ChangeType(value, typeof(T), provider);
        }

        /// <summary>
        ///     Converts the object to another type, returning the default value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="provider">The format provider.</param>
        /// <returns>Returns the value converted to <typeparamref name="T" />.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported.</exception>
        [CLSCompliant(false)]
        public static T ToOrDefault<T>(this IConvertible value, IFormatProvider provider = null)
        {
            return value is null ? default : To<T>(value, provider);
        }

        /// <summary>
        ///     Converts the object to another type, returning the default value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="newObj">The parameter where the result should be sent.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>Returns <see langword="true" /> on success, <see langword="true" /> on failure.</returns>
        [CLSCompliant(false)]
        public static bool ToOrDefault<T>(this IConvertible value, out T newObj, IFormatProvider provider = null)
        {
            if (value is null)
            {
                newObj = default;
                return false;
            }

            try
            {
                newObj = To<T>(value, provider);
                return true;
            }
            catch (InvalidCastException)
            {
                newObj = default;
                return false;
            }
        }

        /// <summary>
        ///     Converts the object to another type, returning <see langword="null" /> on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>Returns a <typeparamref name="T" /> or <see langword="null" />.</returns>
        [CLSCompliant(false)]
        public static T ToOrNull<T>(this IConvertible value, IFormatProvider provider = null)
            where T : class
        {
            return value.ToOrNull(out T v, provider) ? v : null;
        }

        /// <summary>
        ///     Converts the object to another type, returning <see langword="null" /> on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="newObj">The parameter where the result should be sent.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>Returns a <typeparamref name="T" /> or <see langword="null" />.</returns>
        [CLSCompliant(false)]
        public static bool ToOrNull<T>(this IConvertible value, out T newObj, IFormatProvider provider = null)
            where T : class
        {
            return ToOrOther(value, out newObj, null, provider);
        }

        /// <summary>
        ///     Converts the object to another type, returning a different value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="other">The backup value.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>Returns the value converted to <typeparamref name="T" />.</returns>
        [CLSCompliant(false)]
        public static T ToOrOther<T>(this IConvertible value, T other, IFormatProvider provider = null)
        {
            if (value is null)
            {
                return other;
            }

            try
            {
                return To<T>(value, provider);
            }
            catch (Exception ex) when (ex is InvalidCastException || ex is FormatException)
            {
                return other;
            }
        }

        /// <summary>
        ///     Converts the object to another type, returning a different value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <param name="newObj">The parameter where the result should be sent.</param>
        /// <param name="other">The backup value.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>Returns <see langword="true" /> on success, <see langword="true" /> on failure.</returns>
        [CLSCompliant(false)]
        public static bool ToOrOther<T>(this IConvertible value, out T newObj, T other, IFormatProvider provider = null)
        {
            if (value is null)
            {
                newObj = other;
                return false;
            }

            try
            {
                newObj = To<T>(value, provider);
                return true;
            }
            catch (Exception ex) when (ex is InvalidCastException || ex is FormatException)
            {
                newObj = other;
                return false;
            }
        }
    }
}
