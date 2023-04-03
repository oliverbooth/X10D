using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Rect" />.
/// </summary>
public static class RectExtensions
{
    /// <summary>
    ///     Converts the current <see cref="Rect" /> to a <see cref="RectangleF" />.
    /// </summary>
    /// <param name="rectangle">The rectangle to convert.</param>
    /// <returns>The converted rectangle.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RectangleF ToSystemRectangleF(this Rect rectangle)
    {
        return UnsafeUtility.As<Rect, RectangleF>(ref rectangle);
    }
}
