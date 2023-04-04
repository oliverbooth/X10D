using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;
using X10D.Math;

namespace X10D.Numerics;

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
        x = vector.X;
        y = vector.Y;
        z = vector.Z;
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="Vector3" /> to the nearest integer.
    /// </summary>
    /// <param name="vector">The vector whose components to round.</param>
    /// <returns>The rounded vector.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Vector3 Round(this Vector3 vector)
    {
        return vector.Round(1.0f);
    }

    /// <summary>
    ///     Rounds the components in the current <see cref="Vector3" /> to the nearest multiple of a specified number.
    /// </summary>
    /// <param name="vector">The vector whose components to round.</param>
    /// <param name="nearest">The nearest multiple to which the components should be rounded.</param>
    /// <returns>The rounded vector.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Vector3 Round(this Vector3 vector, float nearest)
    {
        float x = vector.X.Round(nearest);
        float y = vector.Y.Round(nearest);
        float z = vector.Z.Round(nearest);
        return new Vector3(x, y, z);
    }

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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
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
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static Vector3 WithZ(this Vector3 vector, float z)
    {
        return vector with {Z = z};
    }
}
