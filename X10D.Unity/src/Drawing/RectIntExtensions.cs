using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="RectInt" />.
/// </summary>
public static class RectIntExtensions
{
    /// <summary>
    ///     Converts the current <see cref="RectInt" /> to a <see cref="Rectangle" />.
    /// </summary>
    /// <param name="rectangle">The rectangle to convert.</param>
    /// <returns>The converted rectangle.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Rectangle ToSystemRectangle(this RectInt rectangle)
    {
        return UnsafeUtility.As<RectInt, Rectangle>(ref rectangle);
    }

    /// <summary>
    ///     Converts the current <see cref="RectInt" /> to a <see cref="RectangleF" />.
    /// </summary>
    /// <param name="rectangle">The rectangle to convert.</param>
    /// <returns>The converted rectangle.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RectangleF ToSystemRectangleF(this RectInt rectangle)
    {
        // REMARKS: implicit conversion already exists, this method is largely pointless
        return rectangle.ToSystemRectangle();
    }
}
