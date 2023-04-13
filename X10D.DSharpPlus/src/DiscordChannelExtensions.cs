using DSharpPlus;
using DSharpPlus.Entities;

namespace X10D.DSharpPlus;

/// <summary>
///     Extension methods for <see cref="DiscordChannel" />.
/// </summary>
public static class DiscordChannelExtensions
{
    /// <summary>
    ///     Gets the category of this channel.
    /// </summary>
    /// <param name="channel">The channel whose category to retrieve.</param>
    /// <returns>
    ///     The category of <paramref name="channel" />, or <paramref name="channel" /> itself if it is already a category;
    ///     <see langword="null" /> if this channel is not defined in a category.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="channel" /> is <see langword="null" />.</exception>
    public static DiscordChannel? GetCategory(this DiscordChannel channel)
    {
        if (channel is null)
        {
            throw new ArgumentNullException(nameof(channel));
        }

        while (true)
        {
            if (channel.IsCategory)
            {
                return channel;
            }

            if (channel.Parent is not { } parent)
            {
                return null;
            }

            channel = parent;
        }
    }

    /// <summary>
    ///     Normalizes a <see cref="DiscordChannel" /> so that the internal client is assured to be a specified value.
    /// </summary>
    /// <param name="channel">The <see cref="DiscordChannel" /> to normalize.</param>
    /// <param name="client">The target client.</param>
    /// <returns>
    ///     A <see cref="DiscordChannel" /> whose public values will match <paramref name="channel" />, but whose internal client
    ///     is <paramref name="client" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="channel" /> is <see langword="null" /></para>
    ///     -or-
    ///     <para><paramref name="client" /> is <see langword="null" /></para>
    /// </exception>
    public static async Task<DiscordChannel> NormalizeClientAsync(this DiscordChannel channel, DiscordClient client)
    {
        if (channel is null)
        {
            throw new ArgumentNullException(nameof(channel));
        }

        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        return await client.GetChannelAsync(channel.Id).ConfigureAwait(false);
    }
}
