using System.Diagnostics.Contracts;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.Drawing;

namespace X10D.Numerics;

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
        x = vector.X;
        y = vector.Y;
    }

    /// <summary>
    ///     Determines if the current <see cref="Vector2" /> lies on the specified line.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="line">The line on which the point may lie.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="point" /> lies on the line defined by <paramref name="line" />; otherwise
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool IsOnLine(this Vector2 point, LineF line)
    {
        (float x1, float x2) = (line.Start.X, line.End.X);
        (float y1, float y2) = (line.Start.Y, line.End.Y);
        (float x, float y) = (point.X, point.Y);
        return System.Math.Abs((y2 - y1) * (x - x2) - (y - y2) * (x2 - x1)) < float.Epsilon;
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
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
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
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool IsOnLine(this Vector2 point, Vector2 start, Vector2 end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

    /// <summary>
    ///     Converts the current <see cref="Vector2" /> to a <see cref="PointF" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting <see cref="PointF" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static PointF ToPointF(this Vector2 vector)
    {
        return new PointF(vector.X, vector.Y);
    }

    /// <summary>
    ///     Converts the current <see cref="Vector2" /> to a <see cref="SizeF" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The resulting <see cref="SizeF" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static SizeF ToSizeF(this Vector2 vector)
    {
        return new SizeF(vector.X, vector.Y);
    }

    /// <summary>
    ///     Returns a vector whose Y component is the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2" /> whose <see cref="Vector2.Y" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2.X" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector2 WithX(this Vector2 vector, float x)
    {
        return vector with {X = x};
    }

    /// <summary>
    ///     Returns a vector whose X component is the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2" /> whose <see cref="Vector2.X" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2.Y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector2 WithY(this Vector2 vector, float y)
    {
        return vector with {Y = y};
    }
}
