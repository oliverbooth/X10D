using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector2" />.
/// </summary>
public static class Vector2Extensions
{
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
