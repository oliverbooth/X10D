using System.Diagnostics.CodeAnalysis;

namespace X10D.Time;

/// <summary>
///     Represents a class which contains a <see cref="string" /> parser which converts into <see cref="TimeSpan" />.
/// </summary>
public static class TimeSpanParser
{
    /// <summary>
    ///     Attempts to parses a shorthand time span string (e.g. 3w 2d 1h), converting it to an instance of
    ///     <see cref="TimeSpan" /> which represents that duration of time.
    /// </summary>
    /// <param name="value">
    ///     The input string. Floating point is not supported, but range the following units are supported:
    ///
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Suffix</term>
    ///             <description>Meaning</description>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term>ms</term>
    ///             <description>Milliseconds</description>
    ///         </item>
    ///         <item>
    ///             <term>s</term>
    ///             <description>Seconds</description>
    ///         </item>
    ///         <item>
    ///             <term>m</term>
    ///             <description>Minutes</description>
    ///         </item>
    ///         <item>
    ///             <term>h</term>
    ///             <description>Hours</description>
    ///         </item>
    ///         <item>
    ///             <term>d</term>
    ///             <description>Days</description>
    ///         </item>
    ///         <item>
    ///             <term>w</term>
    ///             <description>Weeks</description>
    ///         </item>
    ///         <item>
    ///             <term>mo</term>
    ///             <description>Months</description>
    ///         </item>
    ///         <item>
    ///             <term>y</term>
    ///             <description>Years</description>
    ///         </item>
    ///     </list>
    /// </param>
    /// <param name="result">When this method returns, contains the parsed result.</param>
    /// <returns><see langword="true" /> if the parse was successful, <see langword="false" /> otherwise.</returns>
    public static bool TryParse([NotNullWhen(true)] string? value, out TimeSpan result)
    {
        result = TimeSpan.Zero;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        var unitValue = 0;

        for (var index = 0; index < value.Length; index++)
        {
            char current = value[index];
            switch (current)
            {
                case var digitChar when char.IsDigit(digitChar):
                    var digit = (int)char.GetNumericValue(digitChar);
                    unitValue = unitValue * 10 + digit;
                    break;

                case 'y':
                    result += TimeSpan.FromDays(unitValue * 365);
                    unitValue = 0;
                    break;

                case 'm':
                    if (index < value.Length - 1 && value[index + 1] == 'o')
                    {
                        index++;
                        result += TimeSpan.FromDays(unitValue * 30);
                    }
                    else if (index < value.Length - 1 && value[index + 1] == 's')
                    {
                        index++;
                        result += TimeSpan.FromMilliseconds(unitValue);
                    }
                    else
                    {
                        result += TimeSpan.FromMinutes(unitValue);
                    }

                    unitValue = 0;
                    break;

                case 'w':
                    result += TimeSpan.FromDays(unitValue * 7);
                    unitValue = 0;
                    break;

                case 'd':
                    result += TimeSpan.FromDays(unitValue);
                    unitValue = 0;
                    break;

                case 'h':
                    result += TimeSpan.FromHours(unitValue);
                    unitValue = 0;
                    break;

                case 's':
                    result += TimeSpan.FromSeconds(unitValue);
                    unitValue = 0;
                    break;

                case var space when char.IsWhiteSpace(space):
                    break;

                default:
                    result = TimeSpan.Zero;
                    return false;
            }
        }

        return true;
    }
}
