using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector4" />.
/// </summary>
public static class Vector4Extensions
{
    /// <summary>
    ///     Converts the current vector to a <see cref="System.Numerics.Vector4" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Numerics.Vector4 ToSystemVector(this Vector4 vector)
    {
        return UnsafeUtility.As<Vector4, System.Numerics.Vector4>(ref vector);

    }

    /// <summary>
    ///     Converts the current vector to a <see cref="Vector4" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 ToUnityVector(this System.Numerics.Vector4 vector)
    {
        return UnsafeUtility.As<System.Numerics.Vector4, Vector4>(ref vector);
    }

    /// <summary>
    ///     Returns a vector whose Y, Z, and W components are the same as the specified vector, and whose X component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.y" />, <see cref="Vector4.z" />, and
    ///     <see cref="Vector4.w" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.x" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 WithX(this Vector4 vector, float x)
    {
        return vector with {x = x};
    }

    /// <summary>
    ///     Returns a vector whose X, Z, and W components are the same as the specified vector, and whose Y component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.x" />, <see cref="Vector4.z" />, and
    ///     <see cref="Vector4.w" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 WithY(this Vector4 vector, float y)
    {
        return vector with {y = y};
    }

    /// <summary>
    ///     Returns a vector whose X, Y, and W components are the same as the specified vector, and whose Z component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="z">The new Z component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.x" />, <see cref="Vector4.y" />, and
    ///     <see cref="Vector4.w" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.z" /> component is <paramref name="z" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 WithZ(this Vector4 vector, float z)
    {
        return vector with {z = z};
    }

    /// <summary>
    ///     Returns a vector whose X, Y, and Z components are the same as the specified vector, and whose W component is a new
    ///     value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="w">The new W component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector4" /> whose <see cref="Vector4.x" />, <see cref="Vector4.y" />, and
    ///     <see cref="Vector4.z" /> components are the same as that of <paramref name="vector" />, and whose
    ///     <see cref="Vector4.w" /> component is <paramref name="w" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector4 WithW(this Vector4 vector, float w)
    {
        return vector with {w = w};
    }
}
