using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="SizeF" />.
/// </summary>
public static class SizeFExtensions
{
    /// <summary>
    ///     Converts the current <see cref="SizeF" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToUnityVector2(this SizeF size)
    {
        return UnsafeUtility.As<SizeF, Vector2>(ref size);
    }
}
