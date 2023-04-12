using UnityEngine;
using X10D.Core;
using Random = System.Random;

#pragma warning disable CA5394

namespace X10D.Unity.Drawing;

/// <summary>
///     Extension methods for <see cref="System.Random" />.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    ///     Returns an HDR color of random components for red, green, and blue.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose red, green, and blue components are all random, and whose alpha is 255</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color NextColorRgb(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int seed = random.Next();
        var seededRandom = new Random(seed);
        float r = seededRandom.NextSingle();
        float g = seededRandom.NextSingle();
        float b = seededRandom.NextSingle();
        return new Color(r, g, b, 1.0f);
    }

    /// <summary>
    ///     Returns an HDR color composed of random components for apha, red, green, and blue.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose alpha, red, green, and blue components are all random.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color NextColorArgb(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int seed = random.Next();
        var seededRandom = new Random(seed);
        float a = seededRandom.NextSingle();
        float r = seededRandom.NextSingle();
        float g = seededRandom.NextSingle();
        float b = seededRandom.NextSingle();
        return new Color(r, g, b, a);
    }

    /// <summary>
    ///     Returns a color of random components for red, green, and blue.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose red, green, and blue components are all random, and whose alpha is 255</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color32 NextColor32Rgb(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int rgb = random.Next();
        var r = (byte)(rgb >> 16 & 0xFF);
        var g = (byte)(rgb >> 8 & 0xFF);
        var b = (byte)(rgb & 0xFF);
        return new Color32(r, g, b, 0xFF);
    }

    /// <summary>
    ///     Returns a color composed of random components for apha, red, green, and blue.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose alpha, red, green, and blue components are all random.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color32 NextColor32Argb(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int argb = random.Next();
        var a = (byte)(argb >> 24 & 0xFF);
        var r = (byte)(argb >> 16 & 0xFF);
        var g = (byte)(argb >> 8 & 0xFF);
        var b = (byte)(argb & 0xFF);
        return new Color32(r, g, b, a);
    }
}
