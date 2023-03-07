using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace X10D.DSharpPlus;

/// <summary>
///     Extension methods for <see cref="DiscordGuild" />.
/// </summary>
public static class DiscordGuildExtensions
{
    /// <summary>
    ///     Joins all active threads in the guild that this client has permission to view.
    /// </summary>
    /// <param name="guild">The guild whose active threads to join.</param>
    /// <exception cref="ArgumentNullException"><paramref name="guild" /> is <see langword="null" />.</exception>
    public static async Task JoinAllThreadsAsync(this DiscordGuild guild)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(guild);
#else
        if (guild is null)
        {
            throw new ArgumentNullException(nameof(guild));
        }
#endif

        await Task.WhenAll(guild.Threads.Values.Select(t => t.JoinThreadAsync())).ConfigureAwait(false);
    }

    /// <summary>
    ///     Gets a guild member by their ID. If the member is not found, <see langword="null" /> is returned instead of
    ///     <see cref="NotFoundException" /> being thrown.
    /// </summary>
    /// <param name="guild">The guild whose member list to search.</param>
    /// <param name="userId">The ID of the member to retrieve.</param>
    /// <exception cref="ArgumentNullException"><paramref name="guild" /> is <see langword="null" />.</exception>
    public static async Task<DiscordMember?> GetMemberOrNullAsync(this DiscordGuild guild, ulong userId)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(guild);
#else
        if (guild is null)
        {
            throw new ArgumentNullException(nameof(guild));
        }
#endif

        try
        {
            // we should never use exceptions for flow control but this is D#+ we're talking about.
            // NotFoundException isn't even documented, and yet it gets thrown when a member doesn't exist.
            // so this method should hopefully clearly express that - and at least using exceptions for flow control *here*,
            // removes the need to do the same in consumer code.
            // god I hate this.
            return await guild.GetMemberAsync(userId).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }

    /// <summary>
    ///     Normalizes a <see cref="DiscordGuild" /> so that the internal client is assured to be a specified value.
    /// </summary>
    /// <param name="guild">The <see cref="DiscordGuild" /> to normalize.</param>
    /// <param name="client">The target client.</param>
    /// <returns>
    ///     A <see cref="DiscordGuild" /> whose public values will match <paramref name="guild" />, but whose internal client is
    ///     <paramref name="client" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="guild" /> is <see langword="null" /></para>
    ///     -or-
    ///     <para><paramref name="client" /> is <see langword="null" /></para>
    /// </exception>
    public static async Task<DiscordGuild> NormalizeClientAsync(this DiscordGuild guild, DiscordClient client)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(guild);
        ArgumentNullException.ThrowIfNull(client);
#else
        if (guild is null)
        {
            throw new ArgumentNullException(nameof(guild));
        }

        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
#endif

        return await client.GetGuildAsync(guild.Id).ConfigureAwait(false);
    }
}
