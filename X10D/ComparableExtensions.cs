namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="IComparable"/>.
    /// </summary>
    public static class ComparableExtensions
    {
        /// <summary>
        /// Determines if <paramref name="actual"/> is between <paramref name="lower"/> and <paramref name="upper"/>.
        /// </summary>
        /// <typeparam name="T">The comparable type.</typeparam>
        /// <param name="actual">The value to compare.</param>
        /// <param name="lower">The inclusive lower bound.</param>
        /// <param name="upper">The exclusive upper bound.</param>
        /// <returns>Returns <see langword="true"/> if the value is between the bounds, <see langword="false"/>
        /// otherwise.</returns>
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) > 0 && actual.CompareTo(upper) < 0;
        }
    }
}
