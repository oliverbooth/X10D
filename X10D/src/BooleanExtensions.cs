namespace X10D
{
    /// <summary>
    /// Extension methods for <see cref="bool"/>.
    /// </summary>
    public static class BooleanExtensions
    {

        /// <summary>
        /// Gets the value of this boolean and another boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> when <paramref name="value"/> and <paramref name="comparison"/> are <see langword="true"/> Otherwise, the output is <see langword="false"/>.</returns>
        public static bool And(this bool value, bool comparison)
        {
            return value && comparison;
        }

        /// <summary>
        /// Gets the value of this boolean and another boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> and <paramref name="comparison"/> are <see langword="true"/>. Otherwise, <see langword="true"/>.</returns>
        public static bool NAnd(this bool value, bool comparison)
        {
            return !(value && comparison);
        }

        /// <summary>
        /// Gets the value of this boolean and another boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> and <paramref name="comparison"/> are <see langword="false"/>. Otherwise, <see langword="false"/>.</returns>
        public static bool NOr(this bool value, bool comparison)
        {
            return !(value || comparison);
        }

        /// <summary>
        /// Toggles this booleans current state.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns the opposite state of this boolean.</returns>
        public static bool Not(this ref bool value)
        {
            return value = !value;
        }

        /// <summary>
        /// Gets the value of this boolean or another boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> or <paramref name="comparison"/> is <see langword="true"/>.</returns>
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
            return value ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// Gets the value of this boolean and another boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="true"/> if <paramref name="value"/> and <paramref name="comparison"/> are the same, Otherwise <see langword="false"/>.</returns>
        public static bool XNOr(this bool value, bool comparison)
        {
            return !(value ^ comparison);
        }

        /// <summary>
        /// Gets the value of this boolean exclusively or another boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <param name="comparison">The boolean comparator.</param>
        /// <returns>Returns <see langword="false"/> if <paramref name="value"/> and <paramref name="comparison"/> are <see langword="false"/> or if <paramref name="value"/> and <paramref name="comparison"/> are <see langword="true"/>.</returns>
        public static bool XOr(this bool value, bool comparison)
        {
            return value ^ comparison;
        }
    }
}
