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
    /// <returns>A <see cref="Vector64{T}"/> of <see langword="byte"/> which remapped back to 0 and 1 based on boolean truthiness.</returns>
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

        var output = GetUninitializedVector64<byte>();

        for (int i = 0; i < Vector64<byte>.Count; i++)
        {
            ref var writeElement = ref Unsafe.Add(ref Unsafe.As<Vector64<byte>, byte>(ref output), i);
#if NET7_0_OR_GREATER
            writeElement = vector[i] == 0 ? (byte)0 : (byte)1;
#else
            var element = Unsafe.Add(ref Unsafe.As<Vector64<byte>, byte>(ref vector), i);
            writeElement = element == 0 ? (byte)0 : (byte)1;
#endif
        }

        return output;
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="byte"/> which remapped back to 0 and 1 based on boolean truthiness.</returns>
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

        var output = GetUninitializedVector128<byte>();

        for (int i = 0; i < Vector128<byte>.Count; i++)
        {
            ref var writeElement = ref Unsafe.Add(ref Unsafe.As<Vector128<byte>, byte>(ref output), i);
#if NET7_0_OR_GREATER
            writeElement = vector[i] == 0 ? (byte)0 : (byte)1;
#else
            var element = Unsafe.Add(ref Unsafe.As<Vector128<byte>, byte>(ref vector), i);
            writeElement = element == 0 ? (byte)0 : (byte)1;
#endif
        }

        return output;
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
    /// <returns>A <see cref="Vector256{T}"/> of <see langword="byte"/> which remapped back to 0 and 1 based on boolean truthiness.</returns>
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

        var output = GetUninitializedVector256<byte>();

        for (int i = 0; i < Vector256<byte>.Count; i++)
        {
            ref var writeElement = ref Unsafe.Add(ref Unsafe.As<Vector256<byte>, byte>(ref output), i);
#if NET7_0_OR_GREATER
            writeElement = vector[i] == 0 ? (byte)0 : (byte)1;
#else
            var element = Unsafe.Add(ref Unsafe.As<Vector256<byte>, byte>(ref vector), i);
            writeElement = element == 0 ? (byte)0 : (byte)1;
#endif
        }

        return output;
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.</returns>
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

        var output = GetUninitializedVector128<ulong>();

        Unsafe.As<Vector128<ulong>, ulong>(ref output) =
            Unsafe.As<Vector128<ulong>, ulong>(ref lhs) * Unsafe.As<Vector128<ulong>, ulong>(ref rhs);

        Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref output), 1) = 
            Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref lhs), 1) * Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref rhs), 1);

        return output;
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
    /// <returns>A <see cref="Vector256{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.</returns>
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

        var output = GetUninitializedVector256<ulong>();

        for (int i = 0; i < Vector256<ulong>.Count; i++)
        {
            Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref output), i) =
                Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref lhs), i) * Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref rhs), i);
        }

        return output;
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="long"/> whose elements is 64-bit truncated product of lhs and rhs.</returns>
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
    /// <returns>A <see cref="Vector256{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.</returns>
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="float"/> with all elements is result of OR operation on adjacent pairs of elements in lhs and rhs.</returns>
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

        Vector128<float> output = GetUninitializedVector128<float>();

        Unsafe.As<Vector128<float>, uint>(ref output) = 
            Unsafe.As<Vector128<float>, uint>(ref lhs) | Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref lhs), 1);

        Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref output), 1) =
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref lhs), 2) | Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref lhs), 3);

        Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref output), 2) =
            Unsafe.As<Vector128<float>, uint>(ref rhs) | Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref rhs), 1);

        Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref output), 3) =
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref rhs), 2) | Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref rhs), 3);

        return output;
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="int"/> with all elements is result of OR operation on adjacent pairs of elements in lhs and rhs.</returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM64 NEON (untested) hardwares.</remarks>
    /// <exception cref="PlatformNotSupportedException">Hardware doesn't support ARM64 NEON or SSE instruction set.</exception>
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="uint"/> with all elements is result of OR operation on adjacent pairs of elements in lhs and rhs.</returns>
    /// <remarks>API avaliable on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2, ARM64 NEON (untested) hardwares.</remarks>
    /// <exception cref="PlatformNotSupportedException">Hardware doesn't support ARM64 NEON or SSE2 instruction set.</exception>
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
    /// <returns>A <see cref="Vector128{T}"/> of <see langword="ulong"/> with elements the same as input vector except their positions/indices are reversed.</returns>
    /// <remarks>API available on SSE2, SSE3, SSSE3, SSE4.1, SSE4.2, AVX, AVX2 hardwares.</remarks>
    /// <exception cref="PlatformNotSupportedException">Hardware doesn't support SSE2 instruction set.</exception>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<ulong> ReverseElements(Vector128<ulong> vector)
    {
        if (Sse2.IsSupported)
        {
            return Sse2.Shuffle(vector.AsDouble(), vector.AsDouble(), 0b01).AsUInt64();
        }

        Vector128<ulong> output = GetUninitializedVector128<ulong>();

        Unsafe.As<Vector128<ulong>, ulong>(ref output) = Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref vector), 1);
        Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref output), 1) = Unsafe.As<Vector128<ulong>, ulong>(ref vector);

        return output;
    }

    // Helper methods
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static Vector64<T> GetUninitializedVector64<T>() where T : struct
    {
#if NET6_0_OR_GREATER
        Unsafe.SkipInit(out Vector64<T> output);
        return output;
#else
        return default;
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static Vector128<T> GetUninitializedVector128<T>() where T : struct
    {
#if NET6_0_OR_GREATER
        Unsafe.SkipInit(out Vector128<T> output);
        return output;
#else
        return default;
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static Vector256<T> GetUninitializedVector256<T>() where T : struct
    {
#if NET6_0_OR_GREATER
        Unsafe.SkipInit(out Vector256<T> output);
        return output;
#else
        return default;
#endif
    }
}

#endif
