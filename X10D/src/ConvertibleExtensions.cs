namespace X10D
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="IConvertible"/>.
    /// </summary>
    public static class ConvertibleExtensions
    {
        /// <summary>
        /// Converts the object to another type.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>Returns the value converted to <see cref="T"/>.</returns>
        public static T To<T>(this IConvertible obj)
        {
            return (T) Convert.ChangeType(obj, typeof(T));
        }

        /// <summary>
        /// Converts the object to another type, returning the default value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>Returns the value converted to <see cref="T"/>.</returns>
        public static T ToOrDefault<T>(this IConvertible obj)
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Converts the object to another type, returning the default value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <param name="newObj">The parameter where the result should be sent.</param>
        /// <returns>Returns <see langword="true"/> on success, <see langword="true"/> on failure.</returns>
        public static bool ToOrDefault<T>(this IConvertible obj, out T newObj)
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = default;
                return false;
            }
        }

        /// <summary>
        /// Converts the object to another type, returning a different value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <param name="other">The backup value.</param>
        /// <returns>Returns the value converted to <see cref="T"/>.</returns>
        public static T ToOrOther<T>(this IConvertible obj, T other)
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return other;
            }
        }

        /// <summary>
        /// Converts the object to another type, returning a different value on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <param name="newObj">The parameter where the result should be sent.</param>
        /// <param name="other">The backup value.</param>
        /// <returns>Returns <see langword="true"/> on success, <see langword="true"/> on failure.</returns>
        public static bool ToOrOther<T>(this IConvertible obj, out T newObj, T other)
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = other;
                return false;
            }
        }

        /// <summary>
        /// Converts the object to another type, returning <see langword="null"/> on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>Returns a <see cref="T"/> or <see langword="null"/>.</returns>
        public static T ToOrNull<T>(this IConvertible obj) where T : class
        {
            try
            {
                return To<T>(obj);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converts the object to another type, returning <see langword="null"/> on failure.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <param name="newObj">The parameter where the result should be sent.</param>
        /// <returns>Returns a <see cref="T"/> or <see langword="null"/>.</returns>
        public static bool ToOrNull<T>(this IConvertible obj, out T newObj) where T : class
        {
            try
            {
                newObj = To<T>(obj);
                return true;
            }
            catch
            {
                newObj = null;
                return false;
            }
        }
    }
}
