using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="RectInt" />.
/// </summary>
public static class RectIntExtensions
{
    /// <summary>
    ///     Converts the current <see cref="RectInt" /> to a <see cref="Rectangle" />.
    /// </summary>
    /// <param name="rectangle">The rectangle to convert.</param>
    /// <returns>The converted rectangle.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Rectangle ToSystemRectangle(this RectInt rectangle)
    {
        return new Rectangle(rectangle.x, rectangle.y, rectangle.width, rectangle.height);
    }

    /// <summary>
    ///     Converts the current <see cref="RectInt" /> to a <see cref="RectangleF" />.
    /// </summary>
    /// <param name="rectangle">The rectangle to convert.</param>
    /// <returns>The converted rectangle.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RectangleF ToSystemRectangleF(this RectInt rectangle)
    {
        return new RectangleF(rectangle.x, rectangle.y, rectangle.width, rectangle.height);
    }
}
