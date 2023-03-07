using System.Drawing;

#pragma warning disable CA5394

namespace X10D.Drawing;

/// <summary>
///     Extension methods for <see cref="Random" />.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    ///     Returns a color of random components for red, green, and blue.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose red, green, and blue components are all random, and whose alpha is 255</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color NextColorRgb(this Random random)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(random);
#else
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }
#endif

        int rgb = random.Next();
        return Color.FromArgb(0xFF, (byte)(rgb >> 16 & 0xFF), (byte)(rgb >> 8 & 0xFF), (byte)(rgb & 0xFF));
    }

    /// <summary>
    ///     Returns a color composed of random components for apha, red, green, and blue.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose alpha, red, green, and blue components are all random.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color NextColorArgb(this Random random)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(random);
#else
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }
#endif

        int argb = random.Next();
        return Color.FromArgb(argb);
    }
}
