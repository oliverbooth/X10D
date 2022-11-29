using DSharpPlus;
using DSharpPlus.Entities;

namespace X10D.DSharpPlus;

/// <summary>
///     Extension methods for <see cref="DiscordMember" />.
/// </summary>
public static class DiscordMemberExtensions
{
    /// <summary>
    ///     Returns a value indicating whether this member has the specified role.
    /// </summary>
    /// <param name="member">The member whose roles to search.</param>
    /// <param name="role">The role for which to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="member" /> has the role; otherwise, <see langword="false" />.
    /// </returns>
    public static bool HasRole(this DiscordMember member, DiscordRole role)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(member);
        ArgumentNullException.ThrowIfNull(role);
#else
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        if (role is null)
        {
            throw new ArgumentNullException(nameof(role));
        }
#endif

        return member.Roles.Contains(role);
    }

    /// <summary>
    ///     Normalizes a <see cref="DiscordMember" /> so that the internal client is assured to be a specified value.
    /// </summary>
    /// <param name="member">The <see cref="DiscordMember" /> to normalize.</param>
    /// <param name="client">The target client.</param>
    /// <returns>
    ///     A <see cref="DiscordMember" /> whose public values will match <paramref name="member" />, but whose internal client
    ///     is <paramref name="client" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="member" /> is <see langword="null" /></para>
    ///     -or-
    ///     <para><paramref name="client" /> is <see langword="null" /></para>
    /// </exception>
    public static async Task<DiscordMember> NormalizeClientAsync(this DiscordMember member, DiscordClient client)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(member);
        ArgumentNullException.ThrowIfNull(client);
#else
        if (member is null)
        {
            throw new ArgumentNullException(nameof(member));
        }

        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
#endif

        DiscordGuild guild = await member.Guild.NormalizeClientAsync(client).ConfigureAwait(true);
        return await guild.GetMemberAsync(member.Id).ConfigureAwait(true);
    }
}
