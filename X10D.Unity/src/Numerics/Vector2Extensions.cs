using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using X10D.Drawing;
using X10D.Math;
using X10D.Numerics;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector2" />.
/// </summary>
public static class Vector2Extensions
{
    /// <summary>
    ///     Deconstructs the current <see cref="Vector2" /> into its components.
    /// </summary>
    /// <param name="vector">The vector to deconstruct.</param>
    /// <param name="x">The X component value.</param>
    /// <param name="y">The Y component value.</param>
    public static void Deconstruct(this Vector2 vector, out float x, out float y)
    {
        x = vector.x;
        y = vector.y;
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2" /> lies on the specified <see cref="LineF" />.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="line">The line on which the point may lie.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="point" /> lies on the line defined by <paramref name="line" />; otherwise
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOnLine(this Vector2 point, LineF line)
    {
        return point.ToSystemVector().IsOnLine(line);
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2" /> lies on the specified line.
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
    public static bool IsOnLine(this Vector2 point, PointF start, PointF end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2" /> lies on the specified line.
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
    public static bool IsOnLine(this Vector2 point, Vector2 start, Vector2 end)
    {
        return point.ToSystemVector().IsOnLine(start.ToSystemVector(), end.ToSystemVector());
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="Vector2" /> to the nearest integer.
    /// </summary>
    /// <param name="vector">The vector whose components to round.</param>
    /// <returns>The rounded vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Round(this Vector2 vector)
    {
        return vector.Round(1.0f);
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="Vector2" /> to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="vector">The vector whose components to round.</param>
    /// <param name="nearest">The nearest multiple to which the components should be rounded.</param>
    /// <returns>The rounded vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Round(this Vector2 vector, float nearest)
    {
        float x = vector.x.Round(nearest);
        float y = vector.y.Round(nearest);
        return new Vector2(x, y);
    }

    /// <summary>
    ///     Converts the current <see cref="Vector2" /> into a <see cref="PointF" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting <see cref="PointF" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PointF ToSystemPointF(this Vector2 vector)
    {
        return new PointF(vector.x, vector.y);
    }

    /// <summary>
    ///     Converts the current <see cref="Vector2" /> into a <see cref="SizeF" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting <see cref="SizeF" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF ToSystemSizeF(this Vector2 vector)
    {
        return new SizeF(vector.x, vector.y);
    }

    /// <summary>
    ///     Converts the current vector to a <see cref="System.Numerics.Vector2" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Numerics.Vector2 ToSystemVector(this Vector2 vector)
    {
        return UnsafeUtility.As<Vector2, System.Numerics.Vector2>(ref vector);
    }

    /// <summary>
    ///     Converts the current vector to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToUnityVector(this System.Numerics.Vector2 vector)
    {
        return UnsafeUtility.As<System.Numerics.Vector2, Vector2>(ref vector);
    }

    /// <summary>
    ///     Returns a vector whose Y component is the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2" /> whose <see cref="Vector2.y" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2.x" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 WithX(this Vector2 vector, float x)
    {
        return vector with {x = x};
    }

    /// <summary>
    ///     Returns a vector whose X component is the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2" /> whose <see cref="Vector2.x" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2.y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 WithY(this Vector2 vector, float y)
    {
        return vector with {y = y};
    }
}
