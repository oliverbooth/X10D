using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using X10D.Drawing;
using X10D.Unity.Numerics;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="PointF" />.
/// </summary>
public static class PointFExtensions
{
    /// <summary>
    ///     Determines if the current <see cref="PointF" /> lies on the specified <see cref="LineF" />.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="start">The starting point of the line.</param>
    /// <param name="end">The ending point of the line.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="point" /> lies on the line defined by <paramref name="start" /> and
    ///     <paramref name="end" />; otherwise <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOnLine(this PointF point, Vector2 start, Vector2 end)
    {
        return point.IsOnLine(start.ToSystemVector(), end.ToSystemVector());
    }

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
