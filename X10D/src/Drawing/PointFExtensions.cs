using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace X10D.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="PointF" />.
/// </summary>
public static class PointFExtensions
{
    /// <summary>
    ///     Converts the current <see cref="PointF" /> to a <see cref="SizeF" />.
    /// </summary>
    /// <param name="point">The point to convert.</param>
    /// <returns>The resulting <see cref="SizeF" />.</returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static SizeF ToSizeF(this PointF point)
    {
        return new SizeF(point.X, point.Y);
    }
}
