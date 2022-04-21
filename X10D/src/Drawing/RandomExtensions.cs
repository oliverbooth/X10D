using System.Drawing;

namespace X10D.Drawing;

/// <summary>
///     Extension methods for <see cref="Random" />.
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    ///     Returns a random color.
    /// </summary>
    /// <param name="random">The <see cref="System.Random" /> instance.</param>
    /// <returns>A <see cref="Color" /> whose red, green, and blue components are all random, and whose alpha is 255</returns>
    /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
    public static Color NextColor(this Random random)
    {
        if (random is null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        int seed = random.Next();
        var seededRandom = new Random(seed);

        var r = (byte)(seededRandom.Next() % (byte.MaxValue + 1));
        var g = (byte)(seededRandom.Next() % (byte.MaxValue + 1));
        var b = (byte)(seededRandom.Next() % (byte.MaxValue + 1));

        return Color.FromArgb(r, g, b);
    }
}
