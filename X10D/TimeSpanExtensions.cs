namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="TimeSpan"/>.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Calculates how long ago a specified <see cref="TimeSpan"/> was.
        /// </summary>
        /// <param name="span">The <see cref="TimeSpan"/>.</param>
        /// <param name="utc">Optional. Whether or not to use <see cref="DateTime.UtcNow"/> instead of <see cref="DateTime.Now"/>.
        /// Defaults to <see langword="false"/>.</param>
        /// <returns>Returns a <see cref="DateTime"/>.</returns>
        public static DateTime Ago(this TimeSpan span, bool utc = false) =>
            (utc ? DateTime.UtcNow : DateTime.Now) - span;
    }
}
