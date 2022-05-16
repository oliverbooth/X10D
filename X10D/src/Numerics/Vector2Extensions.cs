using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace X10D.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Vector2" />.
/// </summary>
public static class Vector2Extensions
{
    /// <summary>
    ///     Deconstructs the current <see cref="Vector2" /> into its components.
    /// </summary>
    /// <param name="vector">The vector to deconstruct.</param>
    /// <param name="x">The X component value.</param>
    /// <param name="y">The Y component value.</param>
    public static void Deconstruct(this Vector2 vector, out float x, out float y)
    {
        x = vector.X;
        y = vector.Y;
    }

    /// <summary>
    ///     Returns a vector whose Y component is the same as the specified vector, and whose X component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="x">The new X component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2" /> whose <see cref="Vector2.Y" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2.X" /> component is <paramref name="x" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector2 WithX(this Vector2 vector, float x)
    {
        return vector with {X = x};
    }

    /// <summary>
    ///     Returns a vector whose X component is the same as the specified vector, and whose Y component is a new value.
    /// </summary>
    /// <param name="vector">The vector to copy.</param>
    /// <param name="y">The new Y component value.</param>
    /// <returns>
    ///     A new instance of <see cref="Vector2" /> whose <see cref="Vector2.X" /> components is the same as that of
    ///     <paramref name="vector" />, and whose <see cref="Vector2.Y" /> component is <paramref name="y" />.
    /// </returns>
    [Pure]
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static Vector2 WithY(this Vector2 vector, float y)
    {
        return vector with {Y = y};
    }
}
