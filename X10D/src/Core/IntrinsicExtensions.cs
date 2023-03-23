#if NETCOREAPP3_0_OR_GREATER

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace X10D.Core;

/// <summary>
///     Extension methods for SIMD vectors, namely <see cref="Vector64{T}"/>, <see cref="Vector128{T}"/> and
///     <see cref="Vector256{T}"/>.
/// </summary>
public static class IntrinsicExtensions
{
    /// <summary>
    ///     <para>
    ///     Correcting <see cref="Vector64{T}"/> of <see langword="byte"/> into 0 and 1 depend on their boolean truthiness.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     for (int i = 0; i &lt; 8; i++) {
    ///         dest[i] = vector[i] == 0 ? 0 : 1;
    ///     }
    ///     </code>
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns>
    /// A <see cref="Vector64{T}"/> of <see langword="byte"/> which remapped back to 0 and 1 based on boolean truthiness.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector64<byte> CorrectBoolean(this Vector64<byte> vector)
    {
        // TODO: AdvSimd implementation.
        // TODO: WasmSimd implementation. (?)

        var output = IntrinsicUtility.GetUninitializedVector64<byte>();

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
    ///     <para>
    ///     Correcting <see cref="Vector128{T}"/> of <see langword="byte"/> into 0 and 1 depend on their boolean truthiness.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     for (int i = 0; i &lt; 16; i++) {
    ///         dest[i] = vector[i] == 0 ? 0 : 1;
    ///     }
    ///     </code>
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="byte"/> which remapped back to 0 and 1 based on boolean truthiness.
    /// </returns>
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

        // TODO: AdvSimd implementation.
        // TODO: WasmSimd implementation.

        var output = IntrinsicUtility.GetUninitializedVector128<byte>();

        for (int i = 0; i < Vector128<byte>.Count; i++)
        {
            Unsafe.Add(ref Unsafe.As<Vector128<byte>, byte>(ref output), i) =
                Unsafe.Add(ref Unsafe.As<Vector128<byte>, byte>(ref vector), i) == 0 ? (byte)0 : (byte)1;
        }

        return output;
    }

    /// <summary>
    ///     <para>
    ///     Correcting <see cref="Vector256{T}"/> of <see langword="byte"/> into 0 and 1 depend on their boolean truthiness.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     for (int i = 0; i &lt; 32; i++) {
    ///         dest[i] = vector[i] == 0 ? 0 : 1;
    ///     }
    ///     </code>
    /// </summary>
    /// <param name="vector">Vector of byte to correct.</param>
    /// <returns>
    /// A <see cref="Vector256{T}"/> of <see langword="byte"/> which remapped back to 0 and 1 based on boolean truthiness.
    /// </returns>
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

        var output = IntrinsicUtility.GetUninitializedVector256<byte>();

        for (int i = 0; i < Vector256<byte>.Count; i++)
        {
            Unsafe.Add(ref Unsafe.As<Vector256<byte>, byte>(ref output), i) =
                Unsafe.Add(ref Unsafe.As<Vector256<byte>, byte>(ref vector), i) == 0 ? (byte)0 : (byte)1;
        }

        return output;
    }

    /// <summary>
    ///     <para>
    ///     Reverse position of 2 64-bit unsigned integer.
    ///     </para>
    ///     Operation:<br/>
    ///     <code>
    ///     dest[1] = vector[0];
    ///     dest[0] = vector[1];
    ///     </code>
    /// </summary>
    /// <param name="vector">Input vector.</param>
    /// <returns>
    /// A <see cref="Vector128{T}"/> of <see langword="ulong"/> with elements the same as input vector except their positions
    /// (or indices) are reversed.
    /// </returns>
    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector128<ulong> ReverseElements(this Vector128<ulong> vector)
    {
        if (Sse2.IsSupported)
        {
            return Sse2.Shuffle(vector.AsDouble(), vector.AsDouble(), 0b01).AsUInt64();
        }

        Vector128<ulong> output = IntrinsicUtility.GetUninitializedVector128<ulong>();

        Unsafe.As<Vector128<ulong>, ulong>(ref output) = Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref vector), 1);
        Unsafe.Add(ref Unsafe.As<Vector128<ulong>, ulong>(ref output), 1) = Unsafe.As<Vector128<ulong>, ulong>(ref vector);

        return output;
    }
}
#endif
