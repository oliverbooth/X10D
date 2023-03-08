using System.Globalization;

namespace X10D.DSharpPlus;

/// <summary>
///     Provides methods for encoding and decoding Discord mention strings.
/// </summary>
/// <remarks>
///     The implementations in this class are designed to resemble <c>MentionUtils</c> as provided by Discord.NET. The source is
///     available
///     <a href="https://github.com/discord-net/Discord.Net/blob/dev/src/Discord.Net.Core/Utils/MentionUtils.cs">
///         here
///     </a>.
/// </remarks>
public static class MentionUtility
{
    /// <summary>
    ///     Returns a channel mention string built from the specified channel ID.
    /// </summary>
    /// <param name="id">The ID of the channel to mention.</param>
    /// <returns>A channel mention string in the format <c>&lt;#123&gt;</c>.</returns>
    public static string MentionChannel(decimal id)
    {
        return $"<#{id:N0}>";
    }

    /// <summary>
    ///     Returns a channel mention string built from the specified channel ID.
    /// </summary>
    /// <param name="id">The ID of the channel to mention.</param>
    /// <returns>A channel mention string in the format <c>&lt;#123&gt;</c>.</returns>
    [CLSCompliant(false)]
    public static string MentionChannel(ulong id)
    {
        return $"<#{id}>";
    }

    /// <summary>
    ///     Returns a role mention string built from the specified channel ID.
    /// </summary>
    /// <param name="id">The ID of the role to mention.</param>
    /// <returns>A role mention string in the format <c>&lt;@&amp;123&gt;</c>.</returns>
    public static string MentionRole(decimal id)
    {
        return $"<@&{id:N0}>";
    }

    /// <summary>
    ///     Returns a role mention string built from the specified role ID.
    /// </summary>
    /// <param name="id">The ID of the role to mention.</param>
    /// <returns>A role mention string in the format <c>&lt;@&amp;123&gt;</c>.</returns>
    [CLSCompliant(false)]
    public static string MentionRole(ulong id)
    {
        return $"<@&{id}>";
    }

    /// <summary>
    ///     Returns a user mention string built from the specified user ID.
    /// </summary>
    /// <param name="id">The ID of the user to mention.</param>
    /// <returns>A user mention string in the format <c>&lt;@123&gt;</c>.</returns>
    [CLSCompliant(false)]
    public static string MentionUser(decimal id)
    {
        return MentionUser(id, false);
    }

    /// <summary>
    ///     Returns a user mention string built from the specified user ID.
    /// </summary>
    /// <param name="id">The ID of the user to mention.</param>
    /// <param name="nickname">
    ///     <see langword="true" /> if the mention string should account for nicknames; otherwise, <see langword="false" />.
    /// </param>
    /// <returns>
    ///     A user mention string in the format <c>&lt;@!123&gt;</c> if <paramref name="nickname" /> is <see langword="true" />,
    ///     or in the format <c>&lt;@123&gt;</c> if <paramref name="nickname" /> is <see langword="false" />.
    /// </returns>
    [CLSCompliant(false)]
    public static string MentionUser(decimal id, bool nickname)
    {
        return nickname ? $"<@!{id:N0}>" : $"<@{id:N0}>";
    }

    /// <summary>
    ///     Returns a user mention string built from the specified user ID.
    /// </summary>
    /// <param name="id">The ID of the user to mention.</param>
    /// <returns>A user mention string in the format <c>&lt;@123&gt;</c>.</returns>
    [CLSCompliant(false)]
    public static string MentionUser(ulong id)
    {
        return MentionUser(id, false);
    }

    /// <summary>
    ///     Returns a user mention string built from the specified user ID.
    /// </summary>
    /// <param name="id">The ID of the user to mention.</param>
    /// <param name="nickname">
    ///     <see langword="true" /> if the mention string should account for nicknames; otherwise, <see langword="false" />.
    /// </param>
    /// <returns>
    ///     A user mention string in the format <c>&lt;@!123&gt;</c> if <paramref name="nickname" /> is <see langword="true" />,
    ///     or in the format <c>&lt;@123&gt;</c> if <paramref name="nickname" /> is <see langword="false" />.
    /// </returns>
    [CLSCompliant(false)]
    public static string MentionUser(ulong id, bool nickname)
    {
        return nickname ? $"<@!{id}>" : $"<@{id}>";
    }

    /// <summary>
    ///     Parses a provided channel mention string to a decimal value representing the channel ID. A return value indicates
    ///     whether the parse succeeded.
    /// </summary>
    /// <param name="value">A string containing a mention string to parse, in the format <c>&lt;#123&gt;</c>.</param>
    /// <param name="result">
    ///     When this method returns, contains the decimal value representing the channel ID contained within
    ///     <paramref name="value" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the
    ///     <paramref name="value" /> parameter is <see langword="null" /> or <see cref="string.Empty" />, is not of the correct
    ///     format, or represents a number less than <see cref="ulong.MinValue" /> or greater than <see cref="ulong.MaxValue" />.
    /// </param>
    /// <returns><see langword="true" /> if the parse was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryParseChannel(string? value, out decimal result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < 3 || value[0] != '<' || value[1] != '#' || value[^1] != '>')
        {
            return false;
        }

        value = value.Substring(2, value.Length - 3); // <#123>
        if (!ulong.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out ulong actual))
        {
            return false;
        }

        result = actual;
        return true;
    }

    /// <summary>
    ///     Parses a provided channel mention string to a 64-bit unsigned integer representing the channel ID. A return value
    ///     indicates whether the parse succeeded.
    /// </summary>
    /// <param name="value">A string containing a mention string to parse, in the format <c>&lt;#123&gt;</c>.</param>
    /// <param name="result">
    ///     When this method returns, contains the 64-bit unsigned integer value representing the channel ID contained within
    ///     <paramref name="value" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the
    ///     <paramref name="value" /> parameter is <see langword="null" /> or <see cref="string.Empty" />, is not of the correct
    ///     format, or represents a number less than <see cref="ulong.MinValue" /> or greater than <see cref="ulong.MaxValue" />.
    /// </param>
    /// <returns><see langword="true" /> if the parse was successful; otherwise, <see langword="false" />.</returns>
    [CLSCompliant(false)]
    public static bool TryParseChannel(string? value, out ulong result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < 3 || value[0] != '<' || value[1] != '#' || value[^1] != '>')
        {
            return false;
        }

        value = value.Substring(2, value.Length - 3); // <#123>
        return ulong.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    ///     Parses a provided role mention string to a decimal value representing the role ID. A return value indicates whether
    ///     the parse succeeded.
    /// </summary>
    /// <param name="value">A string containing a mention string to parse, in the format <c>&lt;@&amp;123&gt;</c>.</param>
    /// <param name="result">
    ///     When this method returns, contains the decimal value representing the role ID contained within
    ///     <paramref name="value" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the
    ///     <paramref name="value" /> parameter is <see langword="null" /> or <see cref="string.Empty" />, is not of the correct
    ///     format, or represents a number less than <see cref="ulong.MinValue" /> or greater than <see cref="ulong.MaxValue" />.
    /// </param>
    /// <returns><see langword="true" /> if the parse was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryParseRole(string? value, out decimal result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < 4 || value[0] != '<' || value[1] != '@' || value[2] != '&' || value[^1] != '>')
        {
            return false;
        }

        value = value.Substring(3, value.Length - 4); // <@&123>
        if (!ulong.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out ulong actual))
        {
            return false;
        }

        result = actual;
        return true;
    }

    /// <summary>
    ///     Parses a provided role mention string to a 64-bit unsigned integer representing the role ID. A return value indicates
    ///     whether the parse succeeded.
    /// </summary>
    /// <param name="value">A string containing a mention string to parse, in the format <c>&lt;@&amp;123&gt;</c>.</param>
    /// <param name="result">
    ///     When this method returns, contains the 64-bit unsigned integer value representing the role ID contained within
    ///     <paramref name="value" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the
    ///     <paramref name="value" /> parameter is <see langword="null" /> or <see cref="string.Empty" />, is not of the correct
    ///     format, or represents a number less than <see cref="ulong.MinValue" /> or greater than <see cref="ulong.MaxValue" />.
    /// </param>
    /// <returns><see langword="true" /> if the parse was successful; otherwise, <see langword="false" />.</returns>
    [CLSCompliant(false)]
    public static bool TryParseRole(string? value, out ulong result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < 4 || value[0] != '<' || value[1] != '@' || value[2] != '&' || value[^1] != '>')
        {
            return false;
        }

        value = value.Substring(3, value.Length - 4); // <@&123>
        return ulong.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    ///     Parses a provided user mention string to a decimal value representing the user ID. A return value indicates whether
    ///     the parse succeeded.
    /// </summary>
    /// <param name="value">
    ///     A string containing a mention string to parse, in the format <c>&lt;@123&gt;</c> or <c>&lt;@!123&gt;</c>.
    /// </param>
    /// <param name="result">
    ///     When this method returns, contains the decimal value representing the user ID contained within
    ///     <paramref name="value" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the
    ///     <paramref name="value" /> parameter is <see langword="null" /> or <see cref="string.Empty" />, is not of the correct
    ///     format, or represents a number less than <see cref="ulong.MinValue" /> or greater than <see cref="ulong.MaxValue" />.
    /// </param>
    /// <returns><see langword="true" /> if the parse was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryParseUser(string? value, out decimal result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < 3 || value[0] != '<' || value[1] != '@' || value[^1] != '>')
        {
            return false;
        }

        if (value.Length >= 4 && value[2] == '!')
        {
            value = value.Substring(3, value.Length - 4); // <@!123>
        }
        else
        {
            value = value.Substring(2, value.Length - 3); // <@123>
        }

        if (!ulong.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out ulong actual))
        {
            return false;
        }

        result = actual;
        return true;
    }

    /// <summary>
    ///     Parses a provided user mention string to a 64-bit unsigned integer representing the user ID. A return value indicates
    ///     whether the parse succeeded.
    /// </summary>
    /// <param name="value">
    ///     A string containing a mention string to parse, in the format <c>&lt;@123&gt;</c> or <c>&lt;@!123&gt;</c>.
    /// </param>
    /// <param name="result">
    ///     When this method returns, contains the 64-bit unsigned integer value representing the user ID contained within
    ///     <paramref name="value" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the
    ///     <paramref name="value" /> parameter is <see langword="null" /> or <see cref="string.Empty" />, is not of the correct
    ///     format, or represents a number less than <see cref="ulong.MinValue" /> or greater than <see cref="ulong.MaxValue" />.
    /// </param>
    /// <returns><see langword="true" /> if the parse was successful; otherwise, <see langword="false" />.</returns>
    [CLSCompliant(false)]
    public static bool TryParseUser(string? value, out ulong result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Length < 3 || value[0] != '<' || value[1] != '@' || value[^1] != '>')
        {
            return false;
        }

        if (value.Length >= 4 && value[2] == '!')
        {
            value = value.Substring(3, value.Length - 4); // <@!123>
        }
        else
        {
            value = value.Substring(2, value.Length - 3); // <@123>
        }

        return ulong.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out result);
    }
}
