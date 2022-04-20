using System.Globalization;
using System.Text.RegularExpressions;

namespace X10D;

/// <summary>
///     Represents a class which contains a <see cref="string" /> parser which converts into <see cref="TimeSpan" />.
/// </summary>
public static class TimeSpanParser
{
    private const string RealNumberPattern = @"(\d*\.\d+|\d+)";

    private static readonly string Pattern = $"^(?:{RealNumberPattern} *y)? *" +
                                             $"^(?:{RealNumberPattern} *mo)? *" +
                                             $"^(?:{RealNumberPattern} *w)? *" +
                                             $"(?:{RealNumberPattern} *d)? *" +
                                             $"(?:{RealNumberPattern} *h)? *" +
                                             $"(?:{RealNumberPattern} *m)? *" +
                                             $"(?:{RealNumberPattern} *s)? *" +
                                             $"(?:{RealNumberPattern} *ms)?$";

    private static readonly Regex Regex = new(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    ///     Attempts to parses a shorthand time span string (e.g. 3w 2d 1.5h), converting it to an instance of
    ///     <see cref="TimeSpan" /> which represents that duration of time.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="result">The parsed result.</param>
    /// <param name="provider">The format provider.</param>
    /// <returns><see langword="true" /> if the parse was successful, <see langword="false" /> otherwise.</returns>
    public static bool TryParse(string input, out TimeSpan result, IFormatProvider? provider = null)
    {
        result = default;

        Match? match = Regex.Match(input);

        if (!match.Success)
        {
            return false;
        }

        bool TryParseAt(int group, out double parsedResult)
        {
            parsedResult = 0;

            return match.Groups[group].Success
                   && double.TryParse(match.Groups[group].Value, NumberStyles.Number, provider, out parsedResult);
        }

        if (!TryParseAt(1, out double years))
        {
            return false;
        }

        if (!TryParseAt(2, out double months))
        {
            return false;
        }

        if (!TryParseAt(3, out double weeks))
        {
            return false;
        }

        if (!TryParseAt(4, out double days))
        {
            return false;
        }

        if (!TryParseAt(5, out double hours))
        {
            return false;
        }

        if (!TryParseAt(6, out double minutes))
        {
            return false;
        }

        if (!TryParseAt(7, out double seconds))
        {
            return false;
        }

        if (!TryParseAt(8, out double milliseconds))
        {
            return false;
        }

        result += TimeSpan.FromDays(years * 365);
        result += TimeSpan.FromDays(months * 30);
        result += TimeSpan.FromDays(weeks * 7);
        result += TimeSpan.FromDays(days);
        result += TimeSpan.FromHours(hours);
        result += TimeSpan.FromMinutes(minutes);
        result += TimeSpan.FromSeconds(seconds);
        result += TimeSpan.FromMilliseconds(milliseconds);

        return true;
    }
}