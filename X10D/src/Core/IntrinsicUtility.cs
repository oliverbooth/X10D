#if NETCOREAPP3_0_OR_GREATER

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace X10D.Core;

/// <summary>
///     Provides utility methods for SIMD vector that is currently missing on common hardware instruction set.
/// </summary>
public static class IntrinsicUtility
{
    // NOTE:
    // ANY METHOD THAT OPERATE ON ANYTHING THAT ISN'T FLOAT IS NOT SSE COMPATIBLE, MUST BE SSE2 AND BEYONDS
    // FOR API CONSISTENCY.

    /// <summary>
    ///     <para>
    ///     Multiply packed 64-bit unsigned integer elements in a and b and truncate the results to 64-bit integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
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

        // TODO: AdvSimd implementation.
        // TODO: WasmSimd implementation.

        var output = GetUninitializedVector128<ulong>();

        Unsafe.As<Vector128<ulong>, ulong>(ref output) =
            Unsafe.As<Vector128<ulong>, ulong>(ref lhs) * Unsafe.As<Vector128<ulong>, ulong>(ref rhs);

        Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref output), 1) =
            Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref lhs), 1) *
            Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref rhs), 1);

        return output;
    }

    /// <summary>
    ///     <para>
    ///     Multiply packed 64-bit unsigned integer elements in a and b and truncate the results to 64-bit integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     dest[2] = lhs[2] * rhs[2];
    ///     dest[3] = lhs[3] * rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector256{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
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
                Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref lhs), i) *
                Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref rhs), i);
        }

        return output;
    }

    /// <summary>
    ///     <para>
    ///     Multiply packed 64-bit signed integer elements in a and b and truncate the results to 64-bit integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="long"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<long> Multiply(Vector128<long> lhs, Vector128<long> rhs)
    {
        return Multiply(lhs.AsUInt64(), rhs.AsUInt64()).AsInt64();
    }

    /// <summary>
    ///     <para>
    ///     Multiply packed 64-bit signed integer elements in a and b and truncate the results to 64-bit integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] * rhs[0];
    ///     dest[1] = lhs[1] * rhs[1];
    ///     dest[2] = lhs[2] * rhs[2];
    ///     dest[3] = lhs[3] * rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector256{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector256<long> Multiply(Vector256<long> lhs, Vector256<long> rhs)
    {
        return Multiply(lhs.AsUInt64(), rhs.AsUInt64()).AsInt64();
    }

    /// <summary>
    ///     <para>
    ///     Horizontally apply OR operation on adjacent pairs of single-precision (32-bit) floating-point elements in lhs and
    ///     rhs.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] | lhs[1];
    ///     dest[1] = lhs[2] | lhs[3];
    ///     dest[2] = rhs[0] | rhs[1];
    ///     dest[3] = rhs[2] | rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="float"/> with all elements is result of OR operation on adjacent pairs of
    /// elements in lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<float> HorizontalOr(Vector128<float> lhs, Vector128<float> rhs)
    {
        if (Sse.IsSupported)
        {
            var s1 = Sse.Shuffle(lhs, rhs, 0b10_00_10_00); // s1 = { lhs[0] ; lhs[2] ; rhs[0] ; rhs[2] }
            var s2 = Sse.Shuffle(lhs, rhs, 0b11_01_11_01); // s2 = { lhs[1] ; lhs[3] ; rhs[1] ; rhs[3] }

            return Sse.Or(s1, s2);
        }

        // TODO: AdvSimd implementation.
        // TODO: WasmSimd implementation. (?)

        Vector128<float> output = GetUninitializedVector128<float>();

        Unsafe.As<Vector128<float>, uint>(ref output) =
            Unsafe.As<Vector128<float>, uint>(ref lhs) |
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref lhs), 1);

        Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref output), 1) =
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref lhs), 2) |
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref lhs), 3);

        Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref output), 2) =
            Unsafe.As<Vector128<float>, uint>(ref rhs) |
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref rhs), 1);

        Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref output), 3) =
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref rhs), 2) |
            Unsafe.Add(ref Unsafe.As<Vector128<float>, uint>(ref rhs), 3);

        return output;
    }

    /// <summary>
    ///     <para>
    ///     Horizontally apply OR operation on adjacent pairs of 32-bit integer elements in lhs and rhs.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] | lhs[1];
    ///     dest[1] = lhs[2] | lhs[3];
    ///     dest[2] = rhs[0] | rhs[1];
    ///     dest[3] = rhs[2] | rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="int"/> with all elements is result of OR operation on adjacent pairs of
    /// elements in lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<int> HorizontalOr(Vector128<int> lhs, Vector128<int> rhs)
    {
        return HorizontalOr(lhs.AsSingle(), rhs.AsSingle()).AsInt32();
    }

    /// <summary>
    ///     <para>
    ///     Horizontally apply OR operation on adjacent pairs of 32-bit unsigned integer elements in lhs and rhs.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = lhs[0] | lhs[1];
    ///     dest[1] = lhs[2] | lhs[3];
    ///     dest[2] = rhs[0] | rhs[1];
    ///     dest[3] = rhs[2] | rhs[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="uint"/> with all elements is result of OR operation on adjacent pairs of
    /// elements in lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    [CLSCompliant(false)]
    public static Vector128<uint> HorizontalOr(Vector128<uint> lhs, Vector128<uint> rhs)
    {
        return HorizontalOr(lhs.AsSingle(), rhs.AsSingle()).AsUInt32();
    }

    // Helper methods
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector64<T> GetUninitializedVector64<T>() where T : struct
    {
#if NET6_0_OR_GREATER
        Unsafe.SkipInit(out Vector64<T> output);
        return output;
#else
        return default;
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector128<T> GetUninitializedVector128<T>() where T : struct
    {
#if NET6_0_OR_GREATER
        Unsafe.SkipInit(out Vector128<T> output);
        return output;
#else
        return default;
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector256<T> GetUninitializedVector256<T>() where T : struct
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
