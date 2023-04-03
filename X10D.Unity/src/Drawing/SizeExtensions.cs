using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Drawing;

/// <summary>
///     Drawing-related extension methods for <see cref="Size" />.
/// </summary>
public static class SizeExtensions
{
    /// <summary>
    ///     Converts the current <see cref="Size" /> to a <see cref="Vector2" />.
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>The resulting <see cref="Vector2" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 ToUnityVector2(this Size size)
    {
        // REMARKS: implicit conversion already exists, this method is largely pointless
        return size.ToUnityVector2Int();
    }

    /// <summary>
    ///     Converts the current <see cref="Size" /> to a <see cref="Vector2Int" />.
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>The resulting <see cref="Vector2Int" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2Int ToUnityVector2Int(this Size size)
    {
        return UnsafeUtility.As<Size, Vector2Int>(ref size);
    }
}
