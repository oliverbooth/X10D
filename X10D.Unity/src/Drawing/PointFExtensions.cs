using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="PointF" />.
/// </summary>
public static class PointFExtensions
{
    /// <summary>
    ///     Converts the current <see cref="Point" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToUnityVector2(this PointF point)
    {
        return new Vector2(point.X, point.Y);
    }
}
