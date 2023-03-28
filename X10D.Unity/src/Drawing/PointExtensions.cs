using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Point" />.
/// </summary>
public static class PointExtensions
{
    /// <summary>
    ///     Converts the current <see cref="Point" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToUnityVector2(this Point point)
    {
        return new Vector2(point.X, point.Y);
    }

    /// <summary>
    ///     Converts the current <see cref="Point" /> to a <see cref="Vector3" />.
    /// </summary>
    /// <param name="value">The point to convert.</param>
    /// <returns>The resulting <see cref="Vector2Int" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2Int ToUnityVector2Int(this Point value)
    {
        return UnsafeUtility.As<Point, Vector2Int>(ref value);
    }
}
