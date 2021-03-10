using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace X10D
{
    /// <summary>
    ///     Represents a class which contains a <see cref="string" /> parser which converts into <see cref="TimeSpan" />.
    /// </summary>
    public static class TimeSpanParser
    {
        /// <summary>
        ///     Parses a shorthand time span string (e.g. 3w 2d 1.5h) and converts it to an instance of
        ///     <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="provider">The format provider.</param>
        /// <returns>Returns an instance of <see cref="TimeSpan" />.</returns>
        public static TimeSpan Parse(string input, IFormatProvider? provider = null)
        {
            const string realNumberPattern = @"([0-9]*\.[0-9]+|[0-9]+)";
            var pattern = $"^(?:{realNumberPattern} *w)? *" +
                          $"(?:{realNumberPattern} *d)? *" +
                          $"(?:{realNumberPattern} *h)? *" +
                          $"(?:{realNumberPattern} *m)? *" +
                          $"(?:{realNumberPattern} *s)? *" +
                          $"(?:{realNumberPattern} *ms)?$";

            var match = Regex.Match(input, pattern);
            double weeks = 0, days = 0, hours = 0, minutes = 0, seconds = 0, milliseconds = 0;

            if (match.Groups[1].Success)
            {
                weeks = double.Parse(match.Groups[1].Value, provider);
            }

            if (match.Groups[2].Success)
            {
                days = double.Parse(match.Groups[2].Value, provider);
            }

            if (match.Groups[3].Success)
            {
                hours = double.Parse(match.Groups[3].Value, provider);
            }

            if (match.Groups[4].Success)
            {
                minutes = double.Parse(match.Groups[4].Value, provider);
            }

            if (match.Groups[5].Success)
            {
                seconds = double.Parse(match.Groups[5].Value, provider);
            }

            if (match.Groups[6].Success)
            {
                milliseconds = double.Parse(match.Groups[6].Value, provider);
            }

            Trace.WriteLine($"Input: {input}");
            Trace.WriteLine($"Parsed: {weeks}w {days}d {hours}h {minutes}m {seconds}s {milliseconds}ms");

            var span = TimeSpan.Zero;

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
