namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="bool" />.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="byte" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, or 0 otherwise.</returns>
        public static byte ToByte(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="short" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, or 0 otherwise.</returns>
        public static short ToInt16(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="int" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, or 0 otherwise.</returns>
        public static int ToInt32(this bool value)
        {
            return value.ToByte();
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="long" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, 0 otherwise.</returns>
        public static long ToInt64(this bool value)
        {
            return value.ToByte();
        }
    }
}
