using DSharpPlus;
using DSharpPlus.Entities;

namespace X10D.DSharpPlus;

/// <summary>
///     Extension methods for <see cref="DiscordMessage" />.
/// </summary>
public static class DiscordMessageExtensions
{
    /// <summary>
    ///     Deletes this message after a specified delay.
    /// </summary>
    /// <param name="message">The message to delete.</param>
    /// <param name="delay">The delay before deletion.</param>
    /// <param name="reason">The reason for the deletion.</param>
    /// <exception cref="ArgumentNullException"><paramref name="message" /> is <see langword="null" />.</exception>
    public static async Task DeleteAfterAsync(this DiscordMessage message, TimeSpan delay, string? reason = null)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(message);
#else
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }
#endif

        await Task.Delay(delay);
        await message.DeleteAsync(reason);
    }

    /// <summary>
    ///     Deletes the message as created by this task after a specified delay.
    /// </summary>
    /// <param name="task">The task whose <see cref="DiscordMessage" /> result should be deleted.</param>
    /// <param name="delay">The delay before deletion.</param>
    /// <param name="reason">The reason for the deletion.</param>
    /// <exception cref="ArgumentNullException"><paramref name="task" /> is <see langword="null" />.</exception>
    public static async Task DeleteAfterAsync(this Task<DiscordMessage> task, TimeSpan delay, string? reason = null)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(task);
#else
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task));
        }
#endif

        DiscordMessage message = await task;
        await message.DeleteAfterAsync(delay, reason);
    }

    /// <summary>
    ///     Normalizes a <see cref="DiscordMessage" /> so that the internal client is assured to be a specified value.
    /// </summary>
    /// <param name="message">The <see cref="DiscordMessage" /> to normalize.</param>
    /// <param name="client">The target client.</param>
    /// <returns>
    ///     A <see cref="DiscordMessage" /> whose public values will match <paramref name="message" />, but whose internal client
    ///     is <paramref name="client" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="message" /> is <see langword="null" /></para>
    ///     -or-
    ///     <para><paramref name="client" /> is <see langword="null" /></para>
    /// </exception>
    public static async Task<DiscordMessage> NormalizeClientAsync(this DiscordMessage message, DiscordClient client)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(client);
#else
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
#endif

        DiscordChannel channel = await message.Channel.NormalizeClientAsync(client);
        return await channel.GetMessageAsync(message.Id);
    }
}
