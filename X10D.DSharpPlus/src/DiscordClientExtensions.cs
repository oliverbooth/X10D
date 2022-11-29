using DSharpPlus;

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
}
