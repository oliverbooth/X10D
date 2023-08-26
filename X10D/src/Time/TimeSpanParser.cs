using System.Diagnostics.CodeAnalysis;

namespace X10D.Time;

/// <summary>
///     Represents a class which contains a <see cref="string" /> parser which converts into <see cref="TimeSpan" />.
/// </summary>
public static class TimeSpanParser
{
    /// <summary>
    ///     Attempts to parses a shorthand time span (e.g. 3w 2d 1h) as a span of characters, converting it to an instance of
    ///     <see cref="TimeSpan" /> which represents that duration of time.
    /// </summary>
    /// <param name="value">
    ///     The input span of characters. Floating point is not supported, but range the following units are supported:
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
    public static bool TryParse(ReadOnlySpan<char> value, out TimeSpan result)
    {
        result = TimeSpan.Zero;

        if (value.Length == 0 || value.IsWhiteSpace())
        {
            return false;
        }

        var unitValue = 0;

        for (var index = 0; index < value.Length; index++)
        {
            char current = value[index];
            if (!HandleCharacter(value, ref result, current, ref unitValue, ref index))
            {
                return false;
            }
        }

        return true;
    }

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
        return !string.IsNullOrWhiteSpace(value) && TryParse(value.AsSpan(), out result);
    }

    private static bool HandleCharacter(
        ReadOnlySpan<char> value,
        ref TimeSpan result,
        char current,
        ref int unitValue,
        ref int index
    )
    {
        char next = index < value.Length - 1 ? value[index + 1] : '\0';
        if (HandleSpecial(ref unitValue, current))
        {
            return true;
        }

        if (HandleSuffix(ref index, ref result, ref unitValue, current, next))
        {
            return true;
        }

        result = TimeSpan.Zero;
        return false;
    }

    private static bool HandleSuffix(ref int index, ref TimeSpan result, ref int unitValue, char current, char next)
    {
        switch (current)
        {
            case 'm' when next == 'o':
                index++;
                result += TimeSpan.FromDays(unitValue * 30);
                unitValue = 0;
                return true;

            case 'm' when next == 's':
                index++;
                result += TimeSpan.FromMilliseconds(unitValue);
                unitValue = 0;
                return true;

            case 'm':
                result += TimeSpan.FromMinutes(unitValue);
                unitValue = 0;
                return true;

            case 'y':
                result += TimeSpan.FromDays(unitValue * 365);
                unitValue = 0;
                return true;

            case 'w':
                result += TimeSpan.FromDays(unitValue * 7);
                unitValue = 0;
                return true;

            case 'd':
                result += TimeSpan.FromDays(unitValue);
                unitValue = 0;
                return true;

            case 'h':
                result += TimeSpan.FromHours(unitValue);
                unitValue = 0;
                return true;

            case 's':
                result += TimeSpan.FromSeconds(unitValue);
                unitValue = 0;
                return true;
        }

        return false;
    }

    private static bool HandleSpecial(ref int unitValue, char current)
    {
        switch (current)
        {
            case var _ when char.IsDigit(current):
                var digit = (int)char.GetNumericValue(current);
                unitValue = unitValue * 10 + digit;
                return true;

            case var _ when char.IsWhiteSpace(current):
                return true;
        }

        return false;
    }
}
