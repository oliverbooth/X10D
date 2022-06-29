using System.Diagnostics.Contracts;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Point" />.
/// </summary>
public static class PointExtensions
{
    /// <summary>
    ///     Determines if the current <see cref="Point" /> lies on the specified <see cref="LineF" />.
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
    public static bool IsOnLine(this Point point, LineF line)
    {
        return ((PointF)point).IsOnLine(line);
    }

    /// <summary>
    ///     Determines if the current <see cref="Point" /> lies on the specified line.
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
    public static bool IsOnLine(this Point point, PointF start, PointF end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

    /// <summary>
    ///     Determines if the current <see cref="Point" /> lies on the specified line.
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
    public static bool IsOnLine(this Point point, Vector2 start, Vector2 end)
    {
        return point.IsOnLine(new LineF(start, end));
    }

    /// <summary>
    ///     Converts the current <see cref="Point" /> to a <see cref="Size" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="Size" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Size ToSize(this Point point)
    {
        return new Size(point.X, point.Y);
    }

    /// <summary>
    ///     Converts the current <see cref="Point" /> to a <see cref="SizeF" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="SizeF" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF ToSizeF(this Point point)
    {
        return new SizeF(point.X, point.Y);
    }

    /// <summary>
    ///     Converts the current <see cref="Point" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToVector2(this Point point)
    {
        return new Vector2(point.X, point.Y);
    }
}
