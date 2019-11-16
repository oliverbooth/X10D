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
        /// <param name="span">The <see cref="TimeSpan"/>. Defaults to <see langword="false"/>.</param>
        /// <returns>Returns a human-readable <see cref="String"/> describing how long ago <paramref name="span"/>
        /// represents from now.</returns>
        public static string Ago(this TimeSpan span)
        {
            if (span < TimeSpan.FromSeconds(60))
            {
                return $"{span.Seconds} seconds ago";
            }

            if (span < TimeSpan.FromMinutes(60))
            {
                return span.Minutes > 1 ? $"about {span.Minutes} minutes ago" : "about a minute ago";
            }

            if (span < TimeSpan.FromHours(24))
            {
                return span.Hours > 1 ? $"about {span.Hours} hours ago" : "about an hour ago";
            }

            if (span <= TimeSpan.FromDays(7))
            {
                return span.Days > 1 ? $"about {span.Days} days ago" : "yesterday";
            }

            if (span < TimeSpan.FromDays(30))
            {
                return $"about {span.Days} days ago";
            }

            if (span < TimeSpan.FromDays(365))
            {
                return span.Days > 30 ? $"about {span.Days} months ago" : "about a month ago";
            }

            return span.Days > 365 ? $"about {span.Days / 365} years ago" : "about a year ago";
        }
    }
}
