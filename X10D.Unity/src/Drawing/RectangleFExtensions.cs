using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="RectangleF" />.
/// </summary>
public static class RectangleFExtensions
{
    /// <summary>
    ///     Converts the current <see cref="RectangleF" /> to a <see cref="Rect" />.
    /// </summary>
    /// <param name="rectangle">The rectangle to convert.</param>
    /// <returns>The converted rectangle.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Rect ToUnityRect(this RectangleF rectangle)
    {
        return new Rect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
    }
}
