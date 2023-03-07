#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics.Arm;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace X10D.Core;

/// <summary>
///     Extension methods for SIMD vectors, namely <see cref="Vector64{T}"/>, <see cref="Vector128{T}"/> and <see cref="Vector256{T}"/>.
/// </summary>
public static class IntrinsicExtensions
{
    /// <summary>
    ///     Correcting <see cref="Vector64{T}"/> of <see langword="byte"/> into standard boolean values.
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns>Corrected boolean in form of <see cref="Vector64{T}"/> of bytes.</returns>
    /// <remarks>This method will ensure that every value can only be 0 or 1. Values of 0 will be kept, and others will be set to 1.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector64<byte> CorrectBoolean(this Vector64<byte> vector)
    {
        if (AdvSimd.IsSupported)
        {
            // Haven't tested since March 6th 2023 (Reason: Unavailable hardware).
            var cmp = AdvSimd.CompareEqual(vector, Vector64<byte>.Zero);
            var result = AdvSimd.BitwiseSelect(cmp, vector, Vector64<byte>.Zero);

            return result;
        }

        if (Sse.IsSupported)
        {
            throw new PlatformNotSupportedException("Cannot correct boolean of Vector64<byte> on SSE intrinsic set.");
        }

        throw new PlatformNotSupportedException("Unknown Intrinsic platform.");
    }

    /// <summary>
    ///     Correcting <see cref="Vector128{T}"/> of <see langword="byte"/> into standard boolean values.
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns>Corrected boolean in form of <see cref="Vector128{T}"/> of bytes.</returns>
    /// <remarks>This method will ensure that every values can only be either 0 to represent <see langword="false"/> and 1 to represent <see langword="true"/>. Values of 0 will be kept, and others will be mapped back to 1.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<byte> CorrectBoolean(this Vector128<byte> vector)
    {
        if (Sse2.IsSupported)
        {
            var cmp = Sse2.CompareEqual(vector, Vector128<byte>.Zero);
            var result = Sse2.AndNot(cmp, Vector128.Create((byte)1));

            return result;
        }
        else if (AdvSimd.IsSupported)
        {
            // Haven't tested since March 6th 2023 (Reason: Unavailable hardware).
            var cmp = AdvSimd.CompareEqual(vector, Vector128<byte>.Zero);
            var result = AdvSimd.BitwiseSelect(cmp, vector, Vector128<byte>.Zero);

            return result;
        }

        throw new PlatformNotSupportedException("Unknown Intrinsic platform.");
    }

    /// <summary>
    ///     Correcting <see cref="Vector256{T}"/> of <see langword="byte"/> into standard boolean values.
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns>Corrected boolean in form of <see cref="Vector256{T}"/> of bytes.</returns>
    /// <remarks>This method will ensure that every value can only be 0 or 1. Values of 0 will be kept, and others will be set to 1.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector256<byte> CorrectBoolean(this Vector256<byte> vector)
    {
        if (Avx2.IsSupported)
        {
            var cmp = Avx2.CompareEqual(vector, Vector256<byte>.Zero);
            var result = Avx2.AndNot(cmp, Vector256.Create((byte)1));

            return result;
        }

        if (AdvSimd.IsSupported)
        {
            throw new PlatformNotSupportedException("Cannot correct boolean of Vector256<byte> on ARM intrinsic set.");
        }

        throw new PlatformNotSupportedException("Unknown Intrinsic platform.");
    }
}
#endif
