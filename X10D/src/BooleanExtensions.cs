namespace X10D
{
    /// <summary>
    /// Extension methods for <see cref="bool"/>.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Performs logical AND on this <see cref="bool"/> and another <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> AND <paramref name="comparison"/>
        /// evaluate to <see langword="true"/>, or <see langword="false"/> otherwise.</returns>
        public static bool And(this bool value, bool comparison)
        {
            return value && comparison;
        }

        /// <summary>
        /// Performs logical NAND on this <see cref="bool"/> and another <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> NAND <paramref name="comparison"/>
        /// evaluate to <see langword="true"/>, or <see langword="false"/> otherwise.</returns>
        public static bool NAnd(this bool value, bool comparison)
        {
            return !(value && comparison);
        }

        /// <summary>
        /// Performs logical NOR on this <see cref="bool"/> and another <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> NOR <paramref name="comparison"/>
        /// evaluate to <see langword="true"/>, or <see langword="false"/> otherwise.</returns>
        public static bool NOr(this bool value, bool comparison)
        {
            return !(value || comparison);
        }

        /// <summary>
        /// Performs logical NOT on this <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> is <see langword="false"/>,
        /// or <see langword="false"/> otherwise.</returns>
        public static bool Not(this bool value)
        {
            return !value;
        }

        /// <summary>
        /// Performs logical OR on this <see cref="bool"/> and another <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> OR <paramref name="comparison"/>
        /// evaluate to <see langword="true"/>, or <see langword="false"/> otherwise.</returns>
        public static bool Or(this bool value, bool comparison)
        {
            return value || comparison;
        }

        /// <summary>
        /// Gets an integer value that represents this boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value"/> is <see langword="true"/>, 0 otherwise.</returns>
        public static int ToInt32(this bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Gets a byte value that represents this boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 00000001 if <paramref name="value"/> is <see langword="true"/>, otherwise 0000000.</returns>
        public static byte ToByte(this bool value)
        {
            return (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Performs logical XNOR on this <see cref="bool"/> and another <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> XNOR <paramref name="comparison"/>
        /// evaluate to <see langword="true"/>, or <see langword="false"/> otherwise.</returns>
        public static bool XNOr(this bool value, bool comparison)
        {
            return !(value ^ comparison);
        }

        /// <summary>
        /// Performs logical XOR on this <see cref="bool"/> and another <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> XOR <paramref name="comparison"/>
        /// evaluate to <see langword="true"/>, or <see langword="false"/> otherwise.</returns>
        public static bool XOr(this bool value, bool comparison)
        {
            return value ^ comparison;
        }
    }
}
