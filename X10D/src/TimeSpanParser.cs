namespace X10D
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    #endregion

    public static class TimeSpanParser
    {
        /// <summary>
        /// Parses a shorthand time span string (e.g. 3w 2d 1.5h) and converts it to an instance of
        /// <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Returns an instance of <see cref="TimeSpan"/>.</returns>
        public static TimeSpan Parse(string input)
        {
            const string realNumberPattern = @"([0-9]*\.[0-9]+|[0-9]+)";
            string pattern = $@"^(?:{realNumberPattern} *w)? *" +
                             $@"(?:{realNumberPattern} *d)? *" +
                             $@"(?:{realNumberPattern} *h)? *"  +
                             $@"(?:{realNumberPattern} *m)? *"  +
                             $@"(?:{realNumberPattern} *s)? *"  +
                             $@"(?:{realNumberPattern} *ms)?$";

            Match match = Regex.Match(input, pattern);
            double weeks = 0, days = 0, hours = 0, minutes = 0, seconds = 0, milliseconds = 0;

            if (match.Groups[1].Success)
            {
                weeks = Double.Parse(match.Groups[1].Value);
            }

            if (match.Groups[2].Success)
            {
                days = Double.Parse(match.Groups[2].Value);
            }

            if (match.Groups[3].Success)
            {
                hours = Double.Parse(match.Groups[3].Value);
            }

            if (match.Groups[4].Success)
            {
                minutes = Double.Parse(match.Groups[4].Value);
            }

            if (match.Groups[5].Success)
            {
                seconds = Double.Parse(match.Groups[5].Value);
            }

            if (match.Groups[6].Success)
            {
                milliseconds = Double.Parse(match.Groups[6].Value);
            }

            Trace.WriteLine($"Input: {input}");
            Trace.WriteLine($"Parsed: {weeks}w {days}d {hours}h {minutes}m {seconds}s {milliseconds}ms");

            TimeSpan span = TimeSpan.Zero;

            span += TimeSpan.FromDays(weeks * 7);
            span += TimeSpan.FromDays(days);
            span += TimeSpan.FromHours(hours);
            span += TimeSpan.FromMinutes(minutes);
            span += TimeSpan.FromSeconds(seconds);
            span += TimeSpan.FromMilliseconds(milliseconds);

            return span;
        }
    }
}
