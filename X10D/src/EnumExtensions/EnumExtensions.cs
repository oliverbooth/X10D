using System;

namespace X10D.EnumExtensions
{
    /// <summary>
    ///     Extension methods for <see langword="enum" /> types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Returns the next member defined in a specified enum.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="src">The enum value which should be used as the starting point.</param>
        /// <param name="wrap">
        ///     Optional. <see langword="true" /> if the final value of <typeparamref name="T" /> should wrap around to the first
        ///     value, or <see langword="false" /> otherwise. Defaults to <see langword="true" />.
        /// </param>
        /// <returns>
        ///     A value of <typeparamref name="T" /> that is considered to be the next value defined after
        ///     <paramref name="src" />.
        /// </returns>
        public static T Next<T>(this T src, bool wrap = true)
            where T : struct, Enum
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an enum");
            }

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf(arr, src) + 1;
            return arr.Length == j ? arr[wrap ? 0 : j - 1] : arr[j];
        }

        /// <summary>
        ///     Returns the previous member defined in a specified enum.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="src">The enum value which should be used as the starting point.</param>
        /// <param name="wrap">
        ///     Optional. <see langword="true" /> if the first value of <typeparamref name="T" /> should wrap around to the final
        ///     value, or <see langword="false" /> otherwise. Defaults to <see langword="true" />.
        /// </param>
        /// <returns>
        ///     A value of <typeparamref name="T" /> that is considered to be the previous value defined before
        ///     <paramref name="src" />.
        /// </returns>
        public static T Previous<T>(this T src, bool wrap = true)
            where T : struct, Enum
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");
            }

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf(arr, src) - 1;
            return j < 0 ? arr[wrap ? arr.Length - 1 : 0] : arr[j];
        }
    }
}
