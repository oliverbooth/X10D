namespace X10D
{
    using System;

    /// <summary>
    ///     Extension methods for <see langword="struct" /> types.
    /// </summary>
    public static class StructExtensions
    {
        /// <summary>
        ///     Returns the next value in an <see cref="Enum" /> using the specified value as a starting point.
        /// </summary>
        /// <typeparam name="T">An <see cref="Enum" />.</typeparam>
        /// <param name="src">An <see cref="Enum" /> value.</param>
        /// <param name="wrap">
        ///     Optional. Whether or not to wrap to the to the start of the enum. Defaults to
        ///     true.
        /// </param>
        /// <returns>Returns a <see cref="T" /> value.</returns>
        public static T Next<T>(this T src, bool wrap = true)
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");
            }

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf(arr, src) + 1;
            return arr.Length == j ? arr[wrap ? 0 : j - 1] : arr[j];
        }

        /// <summary>
        ///     Returns the previous value in an <see cref="Enum" /> using the specified value as a starting point.
        /// </summary>
        /// <typeparam name="T">An <see cref="Enum" />.</typeparam>
        /// <param name="src">An <see cref="Enum" /> value.</param>
        /// <param name="wrap">
        ///     Optional. Whether or not to wrap to the to the end of the enum. Defaults to
        ///     true.
        /// </param>
        /// <returns>Returns a <see cref="T" /> value.</returns>
        public static T Previous<T>(this T src, bool wrap = true)
            where T : struct
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
