using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;
using X10D.Drawing;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extensions for <see cref="Color32" />.
/// </summary>
public static class Color32Extensions
{
    /// <summary>
    ///     Returns a <see cref="ConsoleColor" /> which most closely resembles the current color.
    /// </summary>
    /// <param name="color">The source color.</param>
    /// <returns>The closest <see cref="ConsoleColor" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ConsoleColor GetClosestConsoleColor(this Color32 color)
    {
        return color.ToSystemDrawingColor().GetClosestConsoleColor();
    }

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

    /// <summary>
    ///     Converts the current color to a <see cref="System.Drawing.Color" />.
    /// </summary>
    /// <param name="color">The color to convert.</param>
    /// <returns>The converted color.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Drawing.Color ToSystemDrawingColor(this Color32 color)
    {
        return System.Drawing.Color.FromArgb(color.a, color.r, color.g, color.b);
    }

    /// <summary>
    ///     Converts the current color to a <see cref="Color32" />.
    /// </summary>
    /// <param name="color">The color to convert.</param>
    /// <returns>The converted color.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color32 ToUnityColor32(this System.Drawing.Color color)
    {
        return new Color32(color.R, color.G, color.B, color.A);
    }

    /// <summary>
    ///     Returns a vector whose red, green, and blue components are the same as the specified color, and whose alpha component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="a">The new alpha component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color32.r" />, <see cref="Color32.g" />, and
    ///     <see cref="Color32.b" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color32.a" /> component is <paramref name="a" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color32 WithA(this Color32 color, byte a)
    {
        return color with {a = a};
    }

    /// <summary>
    ///     Returns a vector whose red, green, and alpha components are the same as the specified color, and whose blue component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="b">The new blue component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color32.r" />, <see cref="Color32.g" />, and
    ///     <see cref="Color32.a" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color32.b" /> component is <paramref name="b" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color32 WithB(this Color32 color, byte b)
    {
        return color with {b = b};
    }

    /// <summary>
    ///     Returns a vector whose red, blue, and alpha components are the same as the specified color, and whose green component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="g">The new green component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color32" /> whose <see cref="Color32.r" />, <see cref="Color32.g" />, and
    ///     <see cref="Color32.b" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color32.g" /> component is <paramref name="g" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color32 WithG(this Color32 color, byte g)
    {
        return color with {g = g};
    }

    /// <summary>
    ///     Returns a vector whose green, blue, and alpha components are the same as the specified color, and whose red component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="r">The new red component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color32" /> whose <see cref="Color32.g" />, <see cref="Color32.b" />, and
    ///     <see cref="Color32.a" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color32.r" /> component is <paramref name="r" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color32 WithR(this Color32 color, byte r)
    {
        return color with {r = r};
    }
}
