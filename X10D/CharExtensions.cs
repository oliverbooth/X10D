namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Char"/>.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Repeats a character a specified number of times.
        /// </summary>
        /// <param name="c">The character to repeat.</param>
        /// <param name="count">The repeat count.</param>
        /// <returns>Returns a <see cref="String"/> whose value is <paramref name="c"/> repeated
        /// <paramref name="count"/> times.</returns>
        public static string Repeat(this char c, int count) =>
            new string(c, count);
    }
}
