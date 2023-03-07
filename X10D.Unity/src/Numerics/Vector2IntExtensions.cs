using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using X10D.Drawing;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector2Int" />.
/// </summary>
public static class Vector2IntExtensions
{
    /// <summary>
    ///     Deconstructs the current <see cref="Vector2" /> into its components.
    /// </summary>
    /// <param name="vector">The vector to deconstruct.</param>
    /// <param name="x">The X component value.</param>
    /// <param name="y">The Y component value.</param>
    public static void Deconstruct(this Vector2Int vector, out int x, out int y)
    {
        x = vector.x;
        y = vector.y;
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2Int" /> lies on the specified <see cref="LineF" />.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="line">The line on which the point may lie.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="point" /> lies on the line defined by <paramref name="line" />; otherwise
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOnLine(this Vector2Int point, LineF line)
    {
        return point.ToSystemPoint().IsOnLine(line);
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2Int" /> lies on the specified line.
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
    public static bool IsOnLine(this Vector2Int point, PointF start, PointF end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2Int" /> lies on the specified line.
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
    public static bool IsOnLine(this Vector2Int point, Vector2Int start, Vector2Int end)
    {
        return point.ToSystemPoint().IsOnLine(new LineF(start.ToSystemVector(), end.ToSystemVector()));
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2Int" /> lies on the specified line.
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
    public static bool IsOnLine(this Vector2Int point, Vector2 start, Vector2 end)
    {
        return point.ToSystemPoint().IsOnLine(new LineF(start.ToSystemVector(), end.ToSystemVector()));
    }

    /// <summary>
    ///     Converts the current <see cref="Vector2Int" /> into a <see cref="Point" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting <see cref="Point" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point ToSystemPoint(this Vector2Int vector)
    {
        return new Point(vector.x, vector.y);
    }

    /// <summary>
    ///     Converts the current <see cref="Vector2Int" /> into a <see cref="Size" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting <see cref="Size" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size ToSystemSize(this Vector2Int vector)
    {
        return new Size(vector.x, vector.y);
    }

    /// <summary>
    ///     Converts the current vector to a <see cref="System.Numerics.Vector2" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Numerics.Vector2 ToSystemVector(this Vector2Int vector)
    {
        return new System.Numerics.Vector2(vector.x, vector.y);
    }

    /// <summary>
    ///     Returns a vector whose Y component is the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2Int" /> whose <see cref="Vector2Int.y" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2Int.x" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2Int WithX(this Vector2Int vector, int x)
    {
        return vector with {x = x};
    }

    /// <summary>
    ///     Returns a vector whose X component is the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2Int" /> whose <see cref="Vector2Int.x" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2Int.y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2Int WithY(this Vector2Int vector, int y)
    {
        return vector with {y = y};
    }
}
