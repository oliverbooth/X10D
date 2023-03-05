using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using X10D.Collections;

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

    /// <summary>
    ///     Returns a vector whose red, green, and blue components are the same as the specified color, and whose alpha component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="a">The new alpha component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.R" />, <see cref="Color.G" />, and
    ///     <see cref="Color.B" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.A" /> component is <paramref name="a" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Color WithA(this Color color, int a)
    {
        return Color.FromArgb(a, color.R, color.G, color.B);
    }

    /// <summary>
    ///     Returns a vector whose red, green, and alpha components are the same as the specified color, and whose blue component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="b">The new blue component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.R" />, <see cref="Color.G" />, and
    ///     <see cref="Color.A" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.B" /> component is <paramref name="b" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Color WithB(this Color color, int b)
    {
        return Color.FromArgb(color.A, color.R, color.G, b);
    }

    /// <summary>
    ///     Returns a vector whose red, blue, and alpha components are the same as the specified color, and whose green component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="g">The new green component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.R" />, <see cref="Color.B" />, and
    ///     <see cref="Color.A" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.G" /> component is <paramref name="g" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Color WithG(this Color color, int g)
    {
        return Color.FromArgb(color.A, color.R, g, color.B);
    }

    /// <summary>
    ///     Returns a vector whose green, blue, and alpha components are the same as the specified color, and whose red component
    ///     is a new value.
    /// </summary>
    /// <param name="color">The color to copy.</param>
    /// <param name="r">The new red component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Color" /> whose <see cref="Color.G" />, <see cref="Color.B" />, and
    ///     <see cref="Color.A" /> components are the same as that of <paramref name="color" />, and whose
    ///     <see cref="Color.R" /> component is <paramref name="r" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Color WithR(this Color color, int r)
    {
        return Color.FromArgb(color.A, r, color.G, color.B);
    }
}
