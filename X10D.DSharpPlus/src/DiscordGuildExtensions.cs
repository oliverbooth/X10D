using DSharpPlus;
using DSharpPlus.Entities;

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

        await Task.WhenAll(guild.Threads.Values.Select(t => t.JoinThreadAsync())).ConfigureAwait(true);
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

        return await client.GetGuildAsync(guild.Id).ConfigureAwait(true);
    }
}
