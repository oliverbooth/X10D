using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using X10D.CompilerServices;

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
    ///     dest[0] = left[0] * right[0];
    ///     dest[1] = left[1] * right[1];
    ///     </code>
    /// </summary>
    /// <param name="left">Left vector.</param>
    /// <param name="right">Right vector.</param>
    /// <returns>The truncated product vector.</returns>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(CompilerResources.MaxOptimization)]
    [ExcludeFromCodeCoverage]
    public static Vector128<ulong> Multiply(Vector128<ulong> left, Vector128<ulong> right)
    {
        if (Sse2.IsSupported)
        {
            return MultiplyInternal_Sse2(left, right);
        }

        return MultiplyInternal_Fallback(left, right);
    }

    /// <summary>
    ///     <para>
    ///     Multiply packed 64-bit unsigned integer elements in a and b and truncate the results to 64-bit integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = left[0] * right[0];
    ///     dest[1] = left[1] * right[1];
    ///     dest[2] = left[2] * right[2];
    ///     dest[3] = left[3] * right[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector256{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(CompilerResources.MaxOptimization)]
    [ExcludeFromCodeCoverage]
    public static Vector256<ulong> Multiply(Vector256<ulong> lhs, Vector256<ulong> rhs)
    {
        if (Avx2.IsSupported)
        {
            return MultiplyInternal_Avx2(lhs, rhs);
        }

        return MultiplyInternal_Fallback(lhs, rhs);
    }

    /// <summary>
    ///     <para>
    ///     Multiply packed 64-bit signed integer elements in a and b and truncate the results to 64-bit integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = left[0] * right[0];
    ///     dest[1] = left[1] * right[1];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="long"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    ///     dest[0] = left[0] * right[0];
    ///     dest[1] = left[1] * right[1];
    ///     dest[2] = left[2] * right[2];
    ///     dest[3] = left[3] * right[3];
    ///     </code>
    /// </summary>
    /// <param name="lhs">Left vector.</param>
    /// <param name="rhs">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector256{T}"/> of <see langword="ulong"/> whose elements is 64-bit truncated product of lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
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
    ///     dest[0] = left[0] | left[1];
    ///     dest[1] = left[2] | left[3];
    ///     dest[2] = right[0] | right[1];
    ///     dest[3] = right[2] | right[3];
    ///     </code>
    /// </summary>
    /// <param name="left">Left vector.</param>
    /// <param name="right">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="float"/> with all elements is result of OR operation on adjacent pairs of
    /// elements in lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    [ExcludeFromCodeCoverage]
    public static Vector128<int> HorizontalOr(Vector128<int> left, Vector128<int> right)
    {
        if (Sse.IsSupported)
        {
            return HorizontalOr_Sse(left, right);
        }

        return HorizontalOrInternal_Fallback(left, right);
    }

    /// <summary>
    ///     <para>
    ///     Horizontally apply OR operation on adjacent pairs of 32-bit unsigned integer elements in lhs and rhs.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[0] = left[0] | left[1];
    ///     dest[1] = left[2] | left[3];
    ///     dest[2] = right[0] | right[1];
    ///     dest[3] = right[2] | right[3];
    ///     </code>
    /// </summary>
    /// <param name="left">Left vector.</param>
    /// <param name="right">Right vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="uint"/> with all elements is result of OR operation on adjacent pairs of
    /// elements in lhs and rhs.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    [CLSCompliant(false)]
    public static Vector128<uint> HorizontalOr(Vector128<uint> left, Vector128<uint> right)
    {
        return HorizontalOr(left.AsInt32(), right.AsInt32()).AsUInt32();
    }

    // Helper methods
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector64<T> GetUninitializedVector64<T>() where T : struct
    {
        Unsafe.SkipInit(out Vector64<T> output);
        return output;
    }

    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector128<T> GetUninitializedVector128<T>() where T : struct
    {
        Unsafe.SkipInit(out Vector128<T> output);
        return output;
    }

    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector256<T> GetUninitializedVector256<T>() where T : struct
    {
        Unsafe.SkipInit(out Vector256<T> output);
        return output;
    }

    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector128<int> HorizontalOr_Sse(Vector128<int> left, Vector128<int> right)
    {
        Vector128<float> leftSingle = left.AsSingle();
        Vector128<float> rightSingle = right.AsSingle();

        // first = { left[0] ; left[2] ; right[0] ; right[2] }
        // second = { left[1] ; left[3] ; right[1] ; right[3] }
        Vector128<float> first = Sse.Shuffle(leftSingle, rightSingle, 0b10_00_10_00);
        Vector128<float> second = Sse.Shuffle(leftSingle, rightSingle, 0b11_01_11_01);

        return Sse.Or(first, second).AsInt32();
    }

    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector128<int> HorizontalOrInternal_Fallback(Vector128<int> left, Vector128<int> right)
    {
        Vector128<int> output = GetUninitializedVector128<int>();

        ref int outputInteger = ref Unsafe.As<Vector128<int>, int>(ref output);
        ref int leftInteger = ref Unsafe.As<Vector128<int>, int>(ref left);
        ref int rightInteger = ref Unsafe.As<Vector128<int>, int>(ref right);

        outputInteger = leftInteger | Unsafe.Add(ref leftInteger, 1);

        Unsafe.Add(ref outputInteger, 1) = Unsafe.Add(ref leftInteger, 2) | Unsafe.Add(ref leftInteger, 3);
        Unsafe.Add(ref outputInteger, 2) = rightInteger | Unsafe.Add(ref rightInteger, 1);
        Unsafe.Add(ref outputInteger, 3) = Unsafe.Add(ref rightInteger, 2) | Unsafe.Add(ref rightInteger, 3);

        return output;
    }

    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector128<ulong> MultiplyInternal_Fallback(Vector128<ulong> left, Vector128<ulong> right)
    {
        ulong leftInteger1 = Unsafe.As<Vector128<ulong>, ulong>(ref left);
        ulong rightInteger1 = Unsafe.As<Vector128<ulong>, ulong>(ref right);
        ulong result1 = leftInteger1 * rightInteger1;

        ulong leftInteger2 = Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref left), 1);
        ulong rightInteger2 = Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref right), 1);
        ulong result2 = leftInteger2 * rightInteger2;

        Vector128<ulong> output = Vector128.Create(result1, result2);

        return output;
    }

    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector128<ulong> MultiplyInternal_Sse2(Vector128<ulong> left, Vector128<ulong> right)
    {
        // https://stackoverflow.com/questions/17863411/sse-multiplication-of-2-64-bit-integers

        Vector128<ulong> ac = Sse2.Multiply(left.AsUInt32(), right.AsUInt32());
        Vector128<uint> b = Sse2.ShiftRightLogical(left, 32).AsUInt32();
        Vector128<ulong> bc = Sse2.Multiply(b, right.AsUInt32());
        Vector128<uint> d = Sse2.ShiftRightLogical(right, 32).AsUInt32();
        Vector128<ulong> ad = Sse2.Multiply(left.AsUInt32(), d);
        Vector128<ulong> high = Sse2.Add(bc, ad);
        high = Sse2.ShiftLeftLogical(high, 32);

        return Sse2.Add(high, ac);
    }

    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector256<ulong> MultiplyInternal_Fallback(Vector256<ulong> left, Vector256<ulong> right)
    {
        Vector256<ulong> output = GetUninitializedVector256<ulong>();

        for (var index = 0; index < Vector256<ulong>.Count; index++)
        {
            Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref output), index) =
                Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref left), index) *
                Unsafe.Add(ref Unsafe.As<Vector256<ulong>, ulong>(ref right), index);
        }

        return output;
    }

    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static Vector256<ulong> MultiplyInternal_Avx2(Vector256<ulong> left, Vector256<ulong> right)
    {
        // https://stackoverflow.com/questions/17863411/sse-multiplication-of-2-64-bit-integers

        Vector256<ulong> ac = Avx2.Multiply(left.AsUInt32(), right.AsUInt32());
        Vector256<uint> b = Avx2.ShiftRightLogical(left, 32).AsUInt32();
        Vector256<ulong> bc = Avx2.Multiply(b, right.AsUInt32());
        Vector256<uint> d = Avx2.ShiftRightLogical(right, 32).AsUInt32();
        Vector256<ulong> ad = Avx2.Multiply(left.AsUInt32(), d);
        Vector256<ulong> high = Avx2.Add(bc, ad);
        high = Avx2.ShiftLeftLogical(high, 32);

        return Avx2.Add(high, ac);
    }
}
