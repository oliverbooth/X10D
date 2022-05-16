using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector3" />.
/// </summary>
public static class Vector3Extensions
{
    /// <summary>
    ///     Deconstructs the current <see cref="Vector3" /> into its components.
    /// </summary>
    /// <param name="vector">The vector to deconstruct.</param>
    /// <param name="x">The X component value.</param>
    /// <param name="y">The Y component value.</param>
    /// <param name="z">The Z component value.</param>
    public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    /// <summary>
    ///     Converts the current vector to a <see cref="System.Numerics.Vector3" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Numerics.Vector3 ToSystemVector(this Vector3 vector)
    {
        return new System.Numerics.Vector3(vector.x, vector.y, vector.z);
    }

    /// <summary>
    ///     Converts the current vector to a <see cref="Vector3" />.
    /// </summary>
    /// <param name="vector">The vector to convert.</param>
    /// <returns>The converted vector.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 ToUnityVector(this System.Numerics.Vector3 vector)
    {
        return new Vector3(vector.X, vector.Y, vector.Z);
    }

    /// <summary>
    ///     Returns a vector whose Y and Z components are the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3" /> whose <see cref="Vector3.y" /> and <see cref="Vector3.z" /> components are
    ///     the same as that of <paramref name="vector" />, and whose <see cref="Vector3.x" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 WithX(this Vector3 vector, float x)
    {
        return vector with {x = x};
    }

    /// <summary>
    ///     Returns a vector whose X and Z components are the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3" /> whose <see cref="Vector3.x" /> and <see cref="Vector3.z" /> components are
    ///     the same as that of <paramref name="vector" />, and whose <see cref="Vector3.y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 WithY(this Vector3 vector, float y)
    {
        return vector with {y = y};
    }

    /// <summary>
    ///     Returns a vector whose X and Y components are the same as the specified vector, and whose Z component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="z">The new Z component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3" /> whose <see cref="Vector3.x" /> and <see cref="Vector3.y" /> components are
    ///     the same as that of <paramref name="vector" />, and whose <see cref="Vector3.z" /> component is <paramref name="z" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 WithZ(this Vector3 vector, float z)
    {
        return vector with {z = z};
    }
}
