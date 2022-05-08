using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace X10D.Drawing;

/// <summary>
///     Drawing-related extensions for <see cref="Color" />.
/// </summary>
public static class ColorExtensions
{
    /// <summary>
    ///     Returns a new <see cref="Color" /> with the red, green, and blue components inverted. Alpha is not affected.
    /// </summary>
    /// <param name="color">The color to invert.</param>
    /// <returns>The inverted color.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Color Inverted(this Color color)
    {
        return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
    }
}
