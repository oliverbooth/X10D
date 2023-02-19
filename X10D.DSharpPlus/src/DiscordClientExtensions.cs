using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace X10D.DSharpPlus;

/// <summary>
///     Extension methods for <see cref="DiscordClient" />.
/// </summary>
public static class DiscordClientExtensions
{
    /// <summary>
    ///     Instructs the client to automatically join all existing threads, and any newly-created threads.
    /// </summary>
    /// <param name="client">The <see cref="DiscordClient" /> whose events should be subscribed.</param>
    /// <param name="rejoinIfRemoved">
    ///     <see langword="true" /> to automatically rejoin a thread if this client was removed; otherwise,
    ///     <see langword="false" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="client" /> is <see langword="null" />.</exception>
    public static void AutoJoinThreads(this DiscordClient client, bool rejoinIfRemoved = true)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(client);
#else
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
#endif

        client.GuildAvailable += (_, args) => args.Guild.JoinAllThreadsAsync();
        client.ThreadCreated += (_, args) => args.Thread.JoinThreadAsync();

        if (rejoinIfRemoved)
        {
            client.ThreadMembersUpdated += (_, args) =>
            {
                if (args.RemovedMembers.Any(m => m.Id == client.CurrentUser.Id))
                    return args.Thread.JoinThreadAsync();

                return Task.CompletedTask;
            };
        }
    }

    /// <summary>
    ///     Gets a user by their ID. If the user is not found, <see langword="null" /> is returned instead of
    ///     <see cref="NotFoundException" /> being thrown.
    /// </summary>
    /// <param name="client">The Discord client.</param>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <exception cref="ArgumentNullException"><paramref name="client" /> is <see langword="null" />.</exception>
    public static async Task<DiscordUser?> GetUserOrNullAsync(this DiscordClient client, ulong userId)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(client);
#else
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
#endif

        try
        {
            // we should never use exceptions for flow control but this is D#+ we're talking about.
            // NotFoundException isn't even documented, and yet it gets thrown when a user doesn't exist.
            // so this method should hopefully clearly express that - and at least using exceptions for flow control *here*,
            // removes the need to do the same in consumer code.
            // god I hate this.
            return await client.GetUserAsync(userId).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
