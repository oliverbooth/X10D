using System.Diagnostics.Contracts;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector3Int" />.
/// </summary>
public static class Vector3IntExtensions
{
    /// <summary>
    ///     Deconstructs the current <see cref="Vector3Int" /> into its components.
    /// </summary>
    /// <param name="vector">The vector to deconstruct.</param>
    /// <param name="x">The X component value.</param>
    /// <param name="y">The Y component value.</param>
    /// <param name="z">The Z component value.</param>
    public static void Deconstruct(this Vector3Int vector, out int x, out int y, out int z)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    /// <summary>
    ///     Returns a vector whose Y and Z components are the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3Int" /> whose <see cref="Vector3Int.y" /> and <see cref="Vector3Int.z"/>
    ///     components are the same as that of <paramref name="vector" />, and whose <see cref="Vector3Int.x" /> component is
    ///     <paramref name="x" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int WithX(this Vector3Int vector, int x)
    {
        return vector with {x = x};
    }

    /// <summary>
    ///     Returns a vector whose X and Z components are the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3Int" /> whose <see cref="Vector3Int.x" /> and <see cref="Vector3Int.z"/>
    ///     components are the same as that of <paramref name="vector" />, and whose <see cref="Vector3Int.y" /> component is
    ///     <paramref name="y" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int WithY(this Vector3Int vector, int y)
    {
        return vector with {y = y};
    }

    /// <summary>
    ///     Returns a vector whose X and Y components are the same as the specified vector, and whose Z component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="z">The new Z component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3Int" /> whose <see cref="Vector3Int.x" /> and <see cref="Vector3Int.y"/>
    ///     components are the same as that of <paramref name="vector" />, and whose <see cref="Vector3Int.z" /> component is
    ///     <paramref name="z" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3Int WithZ(this Vector3Int vector, int z)
    {
        return vector with {z = z};
    }
}
