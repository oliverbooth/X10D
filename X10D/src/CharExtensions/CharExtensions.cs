namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="char" />.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        ///     Returns a string composed of the current character repeated a specified number of times.
        /// </summary>
        /// <param name="value">The character to repeat.</param>
        /// <param name="count">The number of times to repeat.</param>
        /// <returns>
        ///     A <see cref="string" /> composed of <paramref name="value" /> repeated <paramref name="count" /> times.
        /// </returns>
        public static string Repeat(this char value, int count)
        {
            return new(value, count);
        }
    }
}
