﻿using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace X10D.Unity.Numerics;

/// <summary>
///     Numeric-extensions for <see cref="Quaternion" />.
/// </summary>
public static class QuaternionExtensions
{
    /// <summary>
    ///     Converts the current quaternion to a <see cref="System.Numerics.Quaternion" />.
    /// </summary>
    /// <param name="quaternion">The quaternion to convert.</param>
    /// <returns>The converted quaternion.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static System.Numerics.Quaternion ToSystemQuaternion(this Quaternion quaternion)
    {
        return UnsafeUtility.As<Quaternion, System.Numerics.Quaternion>(ref quaternion);
    }

    /// <summary>
    ///     Converts the current quaternion to a <see cref="Quaternion" />.
    /// </summary>
    /// <param name="quaternion">The quaternion to convert.</param>
    /// <returns>The converted quaternion.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Quaternion ToUnityQuaternion(this System.Numerics.Quaternion quaternion)
    {
        return UnsafeUtility.As<System.Numerics.Quaternion, Quaternion>(ref quaternion);
    }
}
