#if NETCOREAPP3_0_OR_GREATER

using System.Diagnostics.CodeAnalysis;
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
        else if (AdvSimd.IsSupported)
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
    ///     <para>Multiply packed 64-bit signed integer elements in a and b and truncate the results to 64-bit integer.</para>
    ///     <para>Operation:</para>
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
    ///     <para>Horizontally apply OR operation on adjacent pairs of single-precision (32-bit) floating-point elements in lhs and rhs.</para>
    ///     <para>Operation:</para>
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
            var s1 = Sse.Shuffle(lhs, rhs, 0b10_00_10_00);
            var s2 = Sse.Shuffle(lhs, rhs, 0b11_01_11_01);

            return Sse.Or(s1, s2);
        }
        else if (AdvSimd.Arm64.IsSupported)
        {
            // Hasn't been tested since March 7th 2023 (Reason: Unavailable hardware).
            var s1 = AdvSimd.Arm64.UnzipEven(lhs, rhs);
            var s2 = AdvSimd.Arm64.UnzipOdd(lhs, rhs);

            return AdvSimd.Or(s1, s2);
        }

        throw new PlatformNotSupportedException("Unsupported SIMD platform.");
    }

    /// <summary>
    ///     <para>Horizontally apply OR operation on adjacent pairs of 32-bit integer elements in lhs and rhs.</para>
    ///     <para>Operation:</para>
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
    public static Vector128<int> HorizontalOr(Vector128<int> lhs, Vector128<int> rhs)
    {
        return HorizontalOr(lhs.AsSingle(), rhs.AsSingle()).AsInt32();
    }

    /// <summary>
    ///     <para>Horizontally apply OR operation on adjacent pairs of 32-bit unsigned integer elements in lhs and rhs.</para>
    ///     <para>Operation:</para>
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
    [CLSCompliant(false)]
    public static Vector128<uint> HorizontalOr(Vector128<uint> lhs, Vector128<uint> rhs)
    {
        return HorizontalOr(lhs.AsSingle(), rhs.AsSingle()).AsUInt32();
    }
}

#endif
