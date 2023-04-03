using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace X10D.DSharpPlus;

/// <summary>
///     Extension methods for <see cref="DiscordUser" />.
/// </summary>
public static class DiscordUserExtensions
{
    /// <summary>
    ///     Returns the current <see cref="DiscordUser" /> as a member of the specified guild.
    /// </summary>
    /// <param name="user">The user to transform.</param>
    /// <param name="guild">The guild whose member list to search.</param>
    /// <returns>
    ///     A <see cref="DiscordMember" /> whose <see cref="DiscordMember.Guild" /> is equal to <paramref name="guild" />, or
    ///     <see langword="null" /> if this user is not in the specified <paramref name="guild" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="user" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="guild" /> is <see langword="null" />.</para>
    /// </exception>
    public static async Task<DiscordMember?> GetAsMemberOfAsync(this DiscordUser user, DiscordGuild guild)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(guild);
#else
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (guild is null)
        {
            throw new ArgumentNullException(nameof(guild));
        }
#endif

        if (user is DiscordMember member && member.Guild == guild)
        {
            return member;
        }

        if (guild.Members.TryGetValue(user.Id, out member!))
        {
            return member;
        }

        try
        {
            return await guild.GetMemberAsync(user.Id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }

    /// <summary>
    ///     Returns the user's username with the discriminator, in the format <c>username#discriminator</c>.
    /// </summary>
    /// <param name="user">The user whose username and discriminator to retrieve.</param>
    /// <returns>A string in the format <c>username#discriminator</c></returns>
    /// <exception cref="ArgumentNullException"><paramref name="user" /> is <see langword="null" />.</exception>
    public static string GetUsernameWithDiscriminator(this DiscordUser user)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(user);
#else
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }
#endif

        return $"{user.Username}#{user.Discriminator}";
    }

    /// <summary>
    ///     Returns a value indicating whether the current user is in the specified guild.
    /// </summary>
    /// <param name="user">The user to check.</param>
    /// <param name="guild">The guild whose member list to search.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="user" /> is a member of <paramref name="guild" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static async Task<bool> IsInGuildAsync(this DiscordUser user, DiscordGuild guild)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(guild);
#else
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (guild is null)
        {
            throw new ArgumentNullException(nameof(guild));
        }
#endif

        if (guild.Members.TryGetValue(user.Id, out _))
        {
            return true;
        }

        try
        {
            DiscordMember? member = await guild.GetMemberAsync(user.Id).ConfigureAwait(false);
            return member is not null;
        }
        catch (NotFoundException)
        {
            return false;
        }
    }

    /// <summary>
    ///     Normalizes a <see cref="DiscordUser" /> so that the internal client is assured to be a specified value.
    /// </summary>
    /// <param name="user">The <see cref="DiscordUser" /> to normalize.</param>
    /// <param name="client">The target client.</param>
    /// <returns>
    ///     A <see cref="DiscordUser" /> whose public values will match <paramref name="user" />, but whose internal client is
    ///     <paramref name="client" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="user" /> is <see langword="null" /></para>
    ///     -or-
    ///     <para><paramref name="client" /> is <see langword="null" /></para>
    /// </exception>
    public static async Task<DiscordUser> NormalizeClientAsync(this DiscordUser user, DiscordClient client)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(client);
#else
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
#endif

        return await client.GetUserAsync(user.Id).ConfigureAwait(false);
    }
}
