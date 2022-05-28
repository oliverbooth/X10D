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
