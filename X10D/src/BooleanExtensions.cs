namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="bool" />.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        ///     Performs logical AND on this <see cref="bool" /> and another <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> AND <paramref name="comparison" />
        ///     evaluate to <see langword="true" />, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool And(this bool value, bool comparison)
        {
            return value && comparison;
        }

        /// <summary>
        ///     Performs logical NAND on this <see cref="bool" /> and another <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> NAND <paramref name="comparison" />
        ///     evaluate to <see langword="true" />, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool NAnd(this bool value, bool comparison)
        {
            return !(value && comparison);
        }

        /// <summary>
        ///     Performs logical NOR on this <see cref="bool" /> and another <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> NOR <paramref name="comparison" />
        ///     evaluate to <see langword="true" />, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool NOr(this bool value, bool comparison)
        {
            return !(value || comparison);
        }

        /// <summary>
        ///     Performs logical NOT on this <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> is <see langword="false" />,
        ///     or <see langword="false" /> otherwise.
        /// </returns>
        public static bool Not(this bool value)
        {
            return !value;
        }

        /// <summary>
        ///     Performs logical OR on this <see cref="bool" /> and another <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> OR <paramref name="comparison" />
        ///     evaluate to <see langword="true" />, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool Or(this bool value, bool comparison)
        {
            return value || comparison;
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="byte" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, or 0 otherwise.</returns>
        public static byte ToByte(this bool value)
        {
            return (byte)value.ToInt32();
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="short" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, or 0 otherwise.</returns>
        public static short ToInt16(this bool value)
        {
            return (short)value.ToInt32();
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="int" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, or 0 otherwise.</returns>
        public static int ToInt32(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        ///     Gets the value of this boolean as represented by <see cref="long" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value" /> is <see langword="true" />, 0 otherwise.</returns>
        public static long ToInt64(this bool value)
        {
            return value.ToInt32();
        }

        /// <summary>
        ///     Performs logical XNOR on this <see cref="bool" /> and another <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> XNOR <paramref name="comparison" />
        ///     evaluate to <see langword="true" />, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool XNOr(this bool value, bool comparison)
        {
            return !(value ^ comparison);
        }

        /// <summary>
        ///     Performs logical XOR on this <see cref="bool" /> and another <see cref="bool" />.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>
        ///     Returns <see langword="true" /> if <paramref name="value" /> XOR <paramref name="comparison" />
        ///     evaluate to <see langword="true" />, or <see langword="false" /> otherwise.
        /// </returns>
        public static bool XOr(this bool value, bool comparison)
        {
            return value ^ comparison;
        }
    }
}
