using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Drawing;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color Inverted(this Color color)
    {
        return new Color(1f - color.r, 1f - color.g, 1f - color.b, color.a);
    }
}
