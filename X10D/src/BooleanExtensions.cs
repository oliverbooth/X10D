namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="bool" />.
    /// </summary>
    public static class BooleanExtensions
    {
        private delegate bool SimpleOperator(bool a, bool b);

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
        ///     Checks if this element is equal to any of the params.
        /// </summary>
        /// <param name="value"> The value being checked into. </param>
        /// <param name="comparisons"> All values being checked against. </param>
        /// <typeparam name="T"> The type being tested against. </typeparam>
        /// <returns>
        ///     <see langword="true" /> if value is or equaled to all of the parameters.
        ///     EX: a == b && a == c && a == d.
        /// </returns>
        public static bool AndEquals<T>(this T value, params T[] comparisons)
        {
            return AdvancedComparison(value, And, comparisons);
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
        ///     Checks if this element is equal to any of the params.
        /// </summary>
        /// <param name="value"> The value being checked into. </param>
        /// <param name="comparisons"> All values being checked against. </param>
        /// <typeparam name="T"> The type being tested against. </typeparam>
        /// <returns>
        ///     <see langword="true" /> if value is nand to all of the parameters.
        ///     EX: !(!(a == b && a == c) && a == d).
        /// </returns>
        public static bool NAndEquals<T>(this T value, params T[] comparisons)
        {
            return AdvancedComparison(value, NAnd, comparisons);
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
        ///     Checks if this element is equal to any of the params.
        /// </summary>
        /// <param name="value"> The value being checked into. </param>
        /// <param name="comparisons"> All values being checked against. </param>
        /// <typeparam name="T"> The type being tested against. </typeparam>
        /// <returns>
        ///     <see langword="true" /> if value is nor to all of the parameters.
        ///     EX: !(!(a == b || a == c) || a == d).
        /// </returns>
        public static bool NOrEquals<T>(this T value, params T[] comparisons)
        {
            return AdvancedComparison(value, NOr, comparisons);
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
        ///     Checks if this element is equal to any of the params.
        /// </summary>
        /// <param name="value"> The value being checked into. </param>
        /// <param name="comparisons"> All values being checked against. </param>
        /// <typeparam name="T"> The type being tested against. </typeparam>
        /// <returns>
        ///     <see langword="true" /> if value is or equaled to any of the parameters.
        ///     EX: a == b || a == c || a == d.
        /// </returns>
        public static bool OrEquals<T>(this T value, params T[] comparisons)
        {
            return AdvancedComparison(value, Or, comparisons);
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
        ///     Checks if this element is equal to any of the params.
        /// </summary>
        /// <param name="value"> The value being checked into. </param>
        /// <param name="comparisons"> All values being checked against. </param>
        /// <typeparam name="T"> The type being tested against. </typeparam>
        /// <returns>
        ///     <see langword="true" /> if value is xnor equaled to any of the parameters.
        ///     EX: !(!(a == b ^ a == c) ^ a == d).
        /// </returns>
        public static bool XNOrEquals<T>(this T value, params T[] comparisons)
        {
            return AdvancedComparison(value, XNOr, comparisons);
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

        /// <summary>
        ///     Checks if this element is equal to any of the params.
        /// </summary>
        /// <param name="value"> The value being checked into. </param>
        /// <param name="comparisons"> All values being checked against. </param>
        /// <typeparam name="T"> The type being tested against. </typeparam>
        /// <returns>
        ///     <see langword="true" /> if value is xor to all of the parameters.
        ///     EX: a == b ^ a == c ^ a == d.
        /// </returns>
        public static bool XOrEquals<T>(this T value, params T[] comparisons)
        {
            return AdvancedComparison(value, XOr, comparisons);
        }

        private static bool AdvancedComparison<T>(T value, SimpleOperator simpleOperator, params T[] comparisons)
        {
            var temp = value.Equals(comparisons[0]);

            for (var index = 1; index < comparisons.Length; index++)
            {
                var currentComparison = comparisons[index];
                temp = simpleOperator.Invoke(temp, value.Equals(currentComparison));
            }

            return temp;
        }
    }
}
