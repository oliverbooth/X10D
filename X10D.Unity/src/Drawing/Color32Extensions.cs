using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extensions for <see cref="Color32" />.
/// </summary>
public static class Color32Extensions
{
    /// <summary>
    ///     Returns a new <see cref="Color32" /> with the red, green, and blue components inverted. Alpha is not affected.
    /// </summary>
    /// <param name="color">The color to invert.</param>
    /// <returns>The inverted color.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color32 Inverted(this Color32 color)
    {
        return new Color32((byte)(255 - color.r), (byte)(255 - color.g), (byte)(255 - color.b), color.a);
    }
}
