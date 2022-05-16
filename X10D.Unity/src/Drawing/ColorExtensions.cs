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

    /// <summary>
    ///     Converts the current color to a <see cref="System.Drawing.Color" />.
    /// </summary>
    /// <param name="color">The color to convert.</param>
    /// <returns>The converted color.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Drawing.Color ToSystemDrawingColor(this Color color)
    {
        return System.Drawing.Color.FromArgb(
            (int)(color.a * 255f),
            (int)(color.r * 255f),
            (int)(color.g * 255f),
            (int)(color.b * 255f)
        );
    }

    /// <summary>
    ///     Converts the current color to a <see cref="Color" />.
    /// </summary>
    /// <param name="color">The color to convert.</param>
    /// <returns>The converted color.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ToUnityColor(this System.Drawing.Color color)
    {
        return new Color(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
    }

    /// <summary>
    ///     Returns a vector whose red, green, and blue components are the same as the specified color, and whose alpha component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="a">The new alpha component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.r" />, <see cref="Color.g" />, and
    ///     <see cref="Color.b" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.a" /> component is <paramref name="a" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color WithA(this Color color, float a)
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
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.r" />, <see cref="Color.g" />, and
    ///     <see cref="Color.a" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.b" /> component is <paramref name="b" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color WithB(this Color color, float b)
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
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.r" />, <see cref="Color.b" />, and
    ///     <see cref="Color.a" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.g" /> component is <paramref name="g" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color WithG(this Color color, float g)
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
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.g" />, <see cref="Color.b" />, and
    ///     <see cref="Color.a" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.r" /> component is <paramref name="r" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color WithR(this Color color, float r)
    {
        return color with {r = r};
    }
}
