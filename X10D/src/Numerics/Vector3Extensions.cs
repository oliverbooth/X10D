using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector3" />.
/// </summary>
public static class Vector3Extensions
{
    /// <summary>
    ///     Returns a vector whose Y and Z components are the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3" /> whose <see cref="Vector3.Y" /> and <see cref="Vector3.Z" /> components are
    ///     the same as that of <paramref name="vector" />, and whose <see cref="Vector3.Y" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector3 WithX(this Vector3 vector, float x)
    {
        return vector with {X = x};
    }

    /// <summary>
    ///     Returns a vector whose X and Z components are the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3" /> whose <see cref="Vector3.X" /> and <see cref="Vector3.Z" /> components are
    ///     the same as that of <paramref name="vector" />, and whose <see cref="Vector3.Y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector3 WithY(this Vector3 vector, float y)
    {
        return vector with {Y = y};
    }

    /// <summary>
    ///     Returns a vector whose X and Y components are the same as the specified vector, and whose Z component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="z">The new Z component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector3" /> whose <see cref="Vector3.X" /> and <see cref="Vector3.Y" /> components are
    ///     the same as that of <paramref name="vector" />, and whose <see cref="Vector3.Z" /> component is <paramref name="z" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector3 WithZ(this Vector3 vector, float z)
    {
        return vector with {Z = z};
    }
}
