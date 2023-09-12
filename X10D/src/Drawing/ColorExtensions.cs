using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Drawing;

/// <summary>
///     Drawing-related extensions for <see cref="Color" />.
/// </summary>
public static class ColorExtensions
{
    /// <summary>
    ///     Deconstructs the current color into its ARGB components.
    /// </summary>
    /// <param name="color">The source color.</param>
    /// <param name="a">
    ///     When this method returns, contains the <see cref="Color.A" /> component of <paramref name="color" />.
    /// </param>
    /// <param name="r">
    ///     When this method returns, contains the <see cref="Color.R" /> component of <paramref name="color" />.
    /// </param>
    /// <param name="g">
    ///     When this method returns, contains the <see cref="Color.G" /> component of <paramref name="color" />.
    /// </param>
    /// <param name="b">
    ///     When this method returns, contains the <see cref="Color.B" /> component of <paramref name="color" />.
    /// </param>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static void Deconstruct(this Color color, out byte a, out byte r, out byte g, out byte b)
    {
        a = color.A;
        (r, g, b) = color;
    }

    /// <summary>
    ///     Deconstructs the current color into its RGB components.
    /// </summary>
    /// <param name="color">The source color.</param>
    /// <param name="r">
    ///     When this method returns, contains the <see cref="Color.R" /> component of <paramref name="color" />.
    /// </param>
    /// <param name="g">
    ///     When this method returns, contains the <see cref="Color.G" /> component of <paramref name="color" />.
    /// </param>
    /// <param name="b">
    ///     When this method returns, contains the <see cref="Color.B" /> component of <paramref name="color" />.
    /// </param>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static void Deconstruct(this Color color, out byte r, out byte g, out byte b)
    {
        r = color.R;
        g = color.G;
        b = color.B;
    }

    /// <summary>
    ///     Returns a <see cref="ConsoleColor" /> which most closely resembles the current color.
    /// </summary>
    /// <param name="color">The source color.</param>
    /// <returns>The closest <see cref="ConsoleColor" />.</returns>
    /// <author>Glenn Slayden, https://stackoverflow.com/a/12340136/1467293</author>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static ConsoleColor GetClosestConsoleColor(this Color color)
    {
        ConsoleColor result = 0;
        double red = color.R;
        double green = color.G;
        double blue = color.B;
        var delta = double.MaxValue;

        foreach (ConsoleColor consoleColor in Enum.GetValues<ConsoleColor>())
        {
            string name = Enum.GetName(consoleColor)!;
            Color currentColor = Color.FromName(name == "DarkYellow" ? "Orange" : name); // bug fix
            double r = currentColor.R - red;
            double g = currentColor.G - green;
            double b = currentColor.B - blue;
            double t = r * r + g * g + b * b;

            if (t == 0.0)
            {
                return consoleColor;
            }

            if (t < delta)
            {
                delta = t;
                result = consoleColor;
            }
        }

        return result;
    }

    /// <summary>
    ///     Returns a new <see cref="Color" /> with the red, green, and blue components inverted. Alpha is not affected.
    /// </summary>
    /// <param name="color">The color to invert.</param>
    /// <returns>The inverted color.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Color WithR(this Color color, int r)
    {
        return Color.FromArgb(color.A, r, color.G, color.B);
    }
}
