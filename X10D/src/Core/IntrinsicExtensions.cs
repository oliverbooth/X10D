﻿#if NETCOREAPP3_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
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

        Vector64<byte> output = IntrinsicUtility.GetUninitializedVector64<byte>();

        for (var i = 0; i < Vector64<byte>.Count; i++)
        {
            ref byte writeElement = ref Unsafe.Add(ref Unsafe.As<Vector64<byte>, byte>(ref output), i);
#if NET7_0_OR_GREATER
            writeElement = vector[i] == 0 ? (byte)0 : (byte)1;
#else
            byte element = Unsafe.Add(ref Unsafe.As<Vector64<byte>, byte>(ref vector), i);
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
    [ExcludeFromCodeCoverage]
    public static Vector128<byte> CorrectBoolean(this Vector128<byte> vector)
    {
        return CorrectBooleanInternal(vector, new SystemSse2SupportProvider());
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
    [ExcludeFromCodeCoverage]
    public static Vector256<byte> CorrectBoolean(this Vector256<byte> vector)
    {
        return CorrectBooleanInternal(vector, new SystemAvx2SupportProvider());
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
    [ExcludeFromCodeCoverage]
    public static Vector128<ulong> ReverseElements(this Vector128<ulong> vector)
    {
        return ReverseElementsInternal(vector, new SystemSse2SupportProvider());
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector128<byte> CorrectBooleanInternal(this Vector128<byte> vector, ISse2SupportProvider? sse2SupportProvider)
    {
        sse2SupportProvider ??= new SystemSse2SupportProvider();

        if (sse2SupportProvider.IsSupported)
        {
            Vector128<byte> cmp = Sse2.CompareEqual(vector, Vector128<byte>.Zero);
            Vector128<byte> result = Sse2.AndNot(cmp, Vector128.Create((byte)1));

            return result;
        }

        // TODO: AdvSimd implementation.
        // TODO: WasmSimd implementation.

        Vector128<byte> output = IntrinsicUtility.GetUninitializedVector128<byte>();

        for (var index = 0; index < Vector128<byte>.Count; index++)
        {
            Unsafe.Add(ref Unsafe.As<Vector128<byte>, byte>(ref output), index) =
                Unsafe.Add(ref Unsafe.As<Vector128<byte>, byte>(ref vector), index) == 0 ? (byte)0 : (byte)1;
        }

        return output;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector256<byte> CorrectBooleanInternal(this Vector256<byte> vector, IAvx2SupportProvider? supportProvider)
    {
        supportProvider ??= new SystemAvx2SupportProvider();

        if (supportProvider.IsSupported)
        {
            Vector256<byte> cmp = Avx2.CompareEqual(vector, Vector256<byte>.Zero);
            Vector256<byte> result = Avx2.AndNot(cmp, Vector256.Create((byte)1));

            return result;
        }

        Vector256<byte> output = IntrinsicUtility.GetUninitializedVector256<byte>();

        for (var index = 0; index < Vector256<byte>.Count; index++)
        {
            Unsafe.Add(ref Unsafe.As<Vector256<byte>, byte>(ref output), index) =
                Unsafe.Add(ref Unsafe.As<Vector256<byte>, byte>(ref vector), index) == 0 ? (byte)0 : (byte)1;
        }

        return output;
    }

    [Pure]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static Vector128<ulong> ReverseElementsInternal(this Vector128<ulong> vector, ISse2SupportProvider? supportProvider)
    {
        supportProvider ??= new SystemSse2SupportProvider();

        if (supportProvider.IsSupported)
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
