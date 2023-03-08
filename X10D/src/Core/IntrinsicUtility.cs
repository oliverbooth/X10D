#if NETCOREAPP3_0_OR_GREATER

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace X10D.Core;

/// <summary>
///     Provides utility methods for SIMD vector that is currently missing on common hardware instruction set.
/// </summary>
public static class IntrinsicUtility
{
    // NOTE:
    // ANYTHING OPERATION OPERATION ON ANYTHING THAT ISN'T FLOAT IS NOT SSE COMPATIBLE, MUST BE SSE2 AND BEYOND VERSION
    // FOR API CONSISTENCY.

    /// <summary>
    ///     <br>Correcting <see cref="Vector64{T}"/> of <see langword="byte"/> into 0 and 1 depend on their boolean truthiness.</br>
    ///     <br>Operation (raw):</br>
    ///     <code>
    ///     for (int i = 0; i &lt; 8; i++) {
    ///         dest[i] = ~(vector[i] == 0 ? 0xFF : 0x00) &amp; 1;
    ///     }
    ///     </code>
    ///     <br>Operation (simplified):</br>
    ///     <code>
    ///     for (int i = 0; i &lt; 8; i++) {
    ///         dest[i] = vector[i] == 0 ? 0 : 1;
    ///     }
    ///     </code>
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on ARM NEON (untested) hardware.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector64<byte> CorrectBoolean(Vector64<byte> vector)
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
    ///     <br>Correcting <see cref="Vector128{T}"/> of <see langword="byte"/> into 0 and 1 depend on their boolean truthiness.</br>
    ///     <br>Operation (raw):</br>
    ///     <code>
    ///     for (int i = 0; i &lt; 16; i++) {
    ///         dest[i] = ~(vector[i] == 0 ? 0xFF : 0x00) &amp; 1;
    ///     }
    ///     </code>
    ///     <br>Operation (simplified):</br>
    ///     <code>
    ///     for (int i = 0; i &lt; 16; i++) {
    ///         dest[i] = vector[i] == 0 ? 0 : 1;
    ///     }
    ///     </code>
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM NEON (untested) hardwares.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<byte> CorrectBoolean(Vector128<byte> vector)
    {
        if (Sse2.IsSupported)
        {
            var cmp = Sse2.CompareEqual(vector, Vector128<byte>.Zero);
            var result = Sse2.AndNot(cmp, Vector128.Create((byte)1));

            return result;
        }
        if (AdvSimd.IsSupported)
        {
            // Haven't tested since March 6th 2023 (Reason: Unavailable hardware).
            var cmp = AdvSimd.CompareEqual(vector, Vector128<byte>.Zero);
            var result = AdvSimd.BitwiseSelect(cmp, vector, Vector128<byte>.Zero);

            return result;
        }

        throw new PlatformNotSupportedException("Unknown Intrinsic platform.");
    }

    /// <summary>
    ///     <br>Correcting <see cref="Vector256{T}"/> of <see langword="byte"/> into 0 and 1 depend on their boolean truthiness.</br>
    ///     <br>Operation (raw):</br>
    ///     <code>
    ///     for (int i = 0; i &lt; 16; i++) {
    ///         dest[i] = ~(vector[i] == 0 ? 0xFF : 0x00) &amp; 1;
    ///     }
    ///     </code>
    ///     <br>Operation (simplified):</br>
    ///     <code>
    ///     for (int i = 0; i &lt; 16; i++) {
    ///         dest[i] = vector[i] == 0 ? 0 : 1;
    ///     }
    ///     </code>
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on AVX2 hardware.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector256<byte> CorrectBoolean(Vector256<byte> vector)
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

    /// <summary>
    ///     <br>Multiply packed 64-bit unsigned integer elements in a and b and truncate the results to 64-bit integer.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM NEON (untested) hardwares.</remarks>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<ulong> Multiply(Vector128<ulong> lhs, Vector128<ulong> rhs)
    {
        if (Sse2.IsSupported)
        {
            // https://stackoverflow.com/questions/17863411/sse-multiplication-of-2-64-bit-integers

            Vector128<ulong> ac = Sse2.Multiply(lhs.AsUInt32(), rhs.AsUInt32());
            Vector128<uint> b = Sse2.ShiftRightLogical(lhs, 32).AsUInt32();
            Vector128<ulong> bc = Sse2.Multiply(b, rhs.AsUInt32());
            Vector128<uint> d = Sse2.ShiftRightLogical(rhs, 32).AsUInt32();
            Vector128<ulong> ad = Sse2.Multiply(lhs.AsUInt32(), d);
            Vector128<ulong> high = Sse2.Add(bc, ad);
            high = Sse2.ShiftLeftLogical(high, 32);

            return Sse2.Add(high, ac);
        }
        if (AdvSimd.IsSupported)
        {
            // https://stackoverflow.com/questions/60236627/facing-problem-in-implementing-multiplication-of-64-bit-variables-using-arm-neon

            // Hasn't been tested since March 7th 2023 (Reason: Unavailable hardware)
            var a = AdvSimd.ExtractNarrowingLower(lhs);
            var b = AdvSimd.ExtractNarrowingLower(rhs);

            var mul = AdvSimd.Multiply(rhs.AsUInt32(), AdvSimd.ReverseElement32(lhs).AsUInt32());

            return AdvSimd.MultiplyWideningLowerAndAdd(AdvSimd.ShiftLeftLogical(mul.AsUInt64(), 32), a, b);
        }

        throw new PlatformNotSupportedException("Unsupported SIMD platform.");
    }

    /// <summary>
    ///     <br>Multiply packed 64-bit unsigned integer elements in a and b and truncate the results to 64-bit integer.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     dest[2] = lhs[2] * rhs[2];
    ///     dest[3] = lhs[3] * rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on AVX2 hardware.</remarks>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector256<ulong> Multiply(Vector256<ulong> lhs, Vector256<ulong> rhs)
    {
        if (Avx2.IsSupported)
        {
            // https://stackoverflow.com/questions/17863411/sse-multiplication-of-2-64-bit-integers

            Vector256<ulong> ac = Avx2.Multiply(lhs.AsUInt32(), rhs.AsUInt32());
            Vector256<uint> b = Avx2.ShiftRightLogical(lhs, 32).AsUInt32();
            Vector256<ulong> bc = Avx2.Multiply(b, rhs.AsUInt32());
            Vector256<uint> d = Avx2.ShiftRightLogical(rhs, 32).AsUInt32();
            Vector256<ulong> ad = Avx2.Multiply(lhs.AsUInt32(), d);
            Vector256<ulong> high = Avx2.Add(bc, ad);
            high = Avx2.ShiftLeftLogical(high, 32);

            return Avx2.Add(high, ac);
        }

        throw new PlatformNotSupportedException("Unsupported SIMD platform.");
    }

    /// <summary>
    ///     <br>Multiply packed 64-bit signed integer elements in a and b and truncate the results to 64-bit integer.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM NEON (untested) hardwares.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<long> Multiply(Vector128<long> lhs, Vector128<long> rhs)
    {
        return Multiply(lhs.AsUInt64(), rhs.AsUInt64()).AsInt64();
    }

    /// <summary>
    ///     <br>Multiply packed 64-bit signed integer elements in a and b and truncate the results to 64-bit integer.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     dest[2] = lhs[2] * rhs[2];
    ///     dest[3] = lhs[3] * rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on AVX2 hardware.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector256<long> Multiply(Vector256<long> lhs, Vector256<long> rhs)
    {
        return Multiply(lhs.AsUInt64(), rhs.AsUInt64()).AsInt64();
    }

    /// <summary>
    ///     <br>Horizontally apply OR operation on adjacent pairs of single-precision (32-bit) floating-point elements in lhs and rhs.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] | lhs[1];
    ///     dest[1] = lhs[2] | lhs[3];
    ///     dest[2] = rhs[0] | rhs[1];
    ///     dest[3] = rhs[2] | rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on SSE, SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM64 NEON (untested) hardwares.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<float> HorizontalOr(Vector128<float> lhs, Vector128<float> rhs)
    {
        if (Sse.IsSupported)
        {
            var s1 = Sse.Shuffle(lhs, rhs, 0b10_00_10_00);  // s1 = { lhs[0] ; lhs[2] ; rhs[0] ; rhs[2] }
            var s2 = Sse.Shuffle(lhs, rhs, 0b11_01_11_01);  // s2 = { lhs[1] ; lhs[3] ; rhs[1] ; rhs[3] }

            return Sse.Or(s1, s2);
        }
        if (AdvSimd.Arm64.IsSupported)
        {
            // Hasn't been tested since March 7th 2023 (Reason: Unavailable hardware).
            var s1 = AdvSimd.Arm64.UnzipEven(lhs, rhs);
            var s2 = AdvSimd.Arm64.UnzipOdd(lhs, rhs);

            return AdvSimd.Or(s1, s2);
        }

        throw new PlatformNotSupportedException("Unsupported SIMD platform.");
    }

    /// <summary>
    ///     <br>Horizontally apply OR operation on adjacent pairs of 32-bit integer elements in lhs and rhs.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] | lhs[1];
    ///     dest[1] = lhs[2] | lhs[3];
    ///     dest[2] = rhs[0] | rhs[1];
    ///     dest[3] = rhs[2] | rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM64 NEON (untested) hardwares.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<int> HorizontalOr(Vector128<int> lhs, Vector128<int> rhs)
    {
        return HorizontalOr(lhs.AsSingle(), rhs.AsSingle()).AsInt32();
    }

    /// <summary>
    ///     <br>Horizontally apply OR operation on adjacent pairs of 32-bit unsigned integer elements in lhs and rhs.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     dest[0] = lhs[0] | lhs[1];
    ///     dest[1] = lhs[2] | lhs[3];
    ///     dest[2] = rhs[0] | rhs[1];
    ///     dest[3] = rhs[2] | rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns></returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM64 NEON (untested) hardwares.</remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    [CLSCompliant(false)]
    public static Vector128<uint> HorizontalOr(Vector128<uint> lhs, Vector128<uint> rhs)
    {
        return HorizontalOr(lhs.AsSingle(), rhs.AsSingle()).AsUInt32();
    }

    /// <summary>
    ///     <br>Reverse position of 2 64-bit unsigned integer.</br>
    ///     <br>Operation:</br>
    ///     <code>
    ///     ulong tmp = vector[0];
    ///     vector[0] = vector[1];
    ///     vector[1] = tmp;
    ///     </code>
    /// </summary>
    /// <param name="vector">Input vector.</param>
    /// <returns></returns>
    /// <remarks>API available on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2 hardwares.</remarks>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<ulong> ReverseElements(Vector128<ulong> vector)
    {
        if (Sse2.IsSupported)
        {
            return Sse2.Shuffle(vector.AsDouble(), vector.AsDouble(), 0b01).AsUInt64();
        }
        
        //  No idea how to implement this in ARM NEON (Reason: Unavailable hardware)

        throw new PlatformNotSupportedException("Unsupported SIMD platform.");
    }
}

#endif
