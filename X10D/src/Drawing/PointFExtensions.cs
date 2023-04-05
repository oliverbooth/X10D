using System.Diagnostics.Contracts;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;
using X10D.Math;

namespace X10D.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="PointF" />.
/// </summary>
public static class PointFExtensions
{
    /// <summary>
    ///     Determines if the current <see cref="PointF" /> lies on the specified <see cref="LineF" />.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="line">The line on which the point may lie.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="point" /> lies on the line defined by <paramref name="line" />; otherwise
    ///     <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsOnLine(this PointF point, LineF line)
    {
        (float x1, float x2) = (line.Start.X, line.End.X);
        (float y1, float y2) = (line.Start.Y, line.End.Y);
        (float x, float y) = (point.X, point.Y);
        return System.Math.Abs((y2 - y1) * (x - x2) - (y - y2) * (x2 - x1)) < float.Epsilon;
    }

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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsOnLine(this PointF point, PointF start, PointF end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool IsOnLine(this PointF point, Vector2 start, Vector2 end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="PointF" /> to the nearest integer.
    /// </summary>
    /// <param name="point">The point whose components to round.</param>
    /// <returns>The rounded point.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static PointF Round(this PointF point)
    {
        return point.Round(1.0f);
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="PointF" /> to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="point">The point whose components to round.</param>
    /// <param name="nearest">The nearest multiple to which the components should be rounded.</param>
    /// <returns>The rounded point.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static PointF Round(this PointF point, float nearest)
    {
        float x = point.X.Round(nearest);
        float y = point.Y.Round(nearest);
        return new PointF(x, y);
    }

    /// <summary>
    ///     Converts the current <see cref="PointF" /> to a <see cref="SizeF" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="SizeF" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static SizeF ToSizeF(this PointF point)
    {
        return new SizeF(point.X, point.Y);
    }

#if !NET6_0_OR_GREATER
    /// <summary>
    ///     Converts the current <see cref="PointF" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToVector2(this PointF point)
    {
        return new Vector2(point.X, point.Y);
    }
#endif
}
