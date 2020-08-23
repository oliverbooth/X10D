namespace X10D
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///     Extension methods for <see langword="struct" /> types.
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        ///      Checks if all properties of two types are equal.
        /// </summary>
        /// <param name="instance"> The first value being checked. </param>
        /// <param name="comparator"> The second value being checked. </param>
        /// <param name="bindingFlags"> The flags that specify what fields are being checked. </param>
        /// <typeparam name="T"> Any type. </typeparam>
        /// <returns> True if all properties of <param name="instance"/> equals all properties of <param name="comparator"/>. </returns>
        public static bool PropertiesEquals<T>(this T instance, T comparator, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public)
            where T : class
        {
            return typeof(T).GetProperties(bindingFlags).Any(e => e.GetValue(instance).Equals(e.GetValue(comparator)));
        }

        /// <summary>
        ///      Checks if all fields of two types are equal.
        /// </summary>
        /// <param name="instance"> The first value being checked. </param>
        /// <param name="comparator"> The second value being checked. </param>
        /// <param name="bindingFlags"> The flags that specify what fields are being checked. </param>
        /// <typeparam name="T"> Any type. </typeparam>
        /// <returns> True if all fields of <param name="instance"/> equals all fields of <param name="comparator"/>. </returns>
        public static bool FieldsEquals<T>(this T instance, T comparator, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public)
            where T : class
        {
            return typeof(T).GetFields(bindingFlags).Any(e => e.GetValue(instance).Equals(e.GetValue(comparator)));
        }
    }
}
