using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics.Arm;
#endif

#if NET7_0_OR_GREATER
using System.Diagnostics;
#endif

namespace X10D.Core;

/// <summary>
/// Extension methods for <see cref="Span{T}"/> and <see cref="ReadOnlySpan{T}"/>.
/// </summary>
public static class SpanExtensions
{
#if NETCOREAPP3_0_OR_GREATER
    private const ulong IntegerPackingMagic = 0x0102040810204080;

    [ExcludeFromCodeCoverage]
    private static Vector64<ulong> IntegerPackingMagicV64
    {
        get => Vector64.Create(IntegerPackingMagic);
    }

    [ExcludeFromCodeCoverage]
    private static Vector128<ulong> IntegerPackingMagicV128
    {
        get => Vector128.Create(IntegerPackingMagic);
    }

    [ExcludeFromCodeCoverage]
    private static Vector256<ulong> IntegerPackingMagicV256
    {
        get => Vector256.Create(IntegerPackingMagic);
    }
#endif

    /// <summary>
    ///     Returns a value indicating whether a specific enumeration value is contained with the current span of elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements in <paramref name="span" />.</typeparam>
    /// <param name="span">The span of elements.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is contained with <paramref name="span" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentException">The size of <typeparamref name="T" /> is unsupported.</exception>
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool Contains<T>(this Span<T> span, T value) where T : struct, Enum
    {
        return Contains((ReadOnlySpan<T>)span, value);
    }

    /// <summary>
    ///     Returns a value indicating whether a specific enumeration value is contained with the current readonly span of
    ///     elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements in <paramref name="span" />.</typeparam>
    /// <param name="span">The readonly span of elements.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is contained with <paramref name="span" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentException">The size of <typeparamref name="T" /> is unsupported.</exception>
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool Contains<T>(this ReadOnlySpan<T> span, T value) where T : struct, Enum
    {
#if NET6_0_OR_GREATER
        // Use MemoryMarshal.CreateSpan instead of using creating new Span instance from pointer will trim down a lot of
        // instructions on Release mode.

        // Also use reference instead of MemoryMarshal.Cast to remove boundary check (or something, it just result in something
        // like that).

        // TODO: Figure out some kind of way to directly pass the Span directly into Contains call, which make method smaller and
        // more prone to inlining...
        unsafe
        {
#pragma warning disable CS8500
            switch (sizeof(T))
#pragma warning restore CS8500
            {
                case 1:
                    {
                        ref byte enums = ref Unsafe.As<T, byte>(ref MemoryMarshal.GetReference(span));
                        return MemoryMarshal.CreateSpan(ref enums, span.Length).Contains(Unsafe.As<T, byte>(ref value));
                    }

                case 2:
                    {
                        ref ushort enums = ref Unsafe.As<T, ushort>(ref MemoryMarshal.GetReference(span));
                        return MemoryMarshal.CreateSpan(ref enums, span.Length).Contains(Unsafe.As<T, ushort>(ref value));
                    }

                case 4:
                    {
                        ref uint enums = ref Unsafe.As<T, uint>(ref MemoryMarshal.GetReference(span));
                        return MemoryMarshal.CreateSpan(ref enums, span.Length).Contains(Unsafe.As<T, uint>(ref value));
                    }

                case 8:
                    {
                        ref ulong enums = ref Unsafe.As<T, ulong>(ref MemoryMarshal.GetReference(span));
                        return MemoryMarshal.CreateSpan(ref enums, span.Length).Contains(Unsafe.As<T, ulong>(ref value));
                    }

                // dotcover disable
                //NOSONAR
                default:
#if NET7_0_OR_GREATER
                    throw new UnreachableException($"Enum with the size of {Unsafe.SizeOf<T>()} bytes is unexpected.");
#else
                    throw new ArgumentException($"Enum with the size of {Unsafe.SizeOf<T>()} bytes is unexpected.");
#endif
                //NOSONAR
                // dotcover enable
            }
        }
#else
        foreach (var it in span)
        {
            if (EqualityComparer<T>.Default.Equals(it, value))
            {
                return true;
            }
        }

        return false;
#endif
    }

    /// <summary>
    ///     Packs a <see cref="Span{T}"/> of booleans into a <see cref="byte" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>An 8-bit unsigned integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 8 elements.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte PackByte(this Span<bool> source)
    {
        return PackByte((ReadOnlySpan<bool>)source);
    }

    /// <summary>
    ///     Packs a <see cref="ReadOnlySpan{T}"/> of booleans into a <see cref="byte" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>An 8-bit unsigned integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 8 elements.</exception>
    [Pure]
    public static unsafe byte PackByte(this ReadOnlySpan<bool> source)
    {
        switch (source.Length)
        {
            case > 8: throw new ArgumentException("Source cannot contain more than 8 elements.", nameof(source));
            case 8:
#if NETSTANDARD2_1
                // TODO: Think of a way to do fast boolean correctness without using SIMD API.
                goto default;
#else
                // TODO: Acceleration in Big Endian environment.
                if (!BitConverter.IsLittleEndian)
                {
                    goto default;
                }

                fixed (bool* pSource = source)
                {
                    // TODO: .NET 8.0 Wasm support.

                    if (Sse2.IsSupported)
                    {
                        Vector128<byte> load = Sse2.LoadScalarVector128((ulong*)pSource).AsByte();

                        return unchecked((byte)(IntegerPackingMagic * load.CorrectBoolean().AsUInt64().GetElement(0) >> 56));
                    }

                    // Probably should remove this piece of code because it is untested, but I see no reason why it should fail
                    // unless vld1_u8 reverse positions of 8 bytes for some reason.

                    if (AdvSimd.IsSupported)
                    {
                        // Hasn't been tested since March 6th 2023 (Reason: Unavailable hardware).
                        Vector64<byte> load = AdvSimd.LoadVector64((byte*)pSource);

                        return unchecked((byte)(IntegerPackingMagic * load.CorrectBoolean().AsUInt64().GetElement(0) >> 56));
                    }

                    goto default;
                }
#endif
            default:
                byte result = 0;

                for (var index = 0; index < source.Length; index++)
                {
                    result |= (byte)(source[index] ? 1 << index : 0);
                }

                return result;
        }
    }

    /// <summary>
    ///     Packs a <see cref="Span{T}"/> of booleans into a <see cref="short" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>A 16-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 16 elements.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short PackInt16(this Span<bool> source)
    {
        return PackInt16((ReadOnlySpan<bool>)source);
    }

    /// <summary>
    ///     Packs a <see cref="ReadOnlySpan{T}"/> of booleans into a <see cref="short" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>A 16-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 16 elements.</exception>
    [Pure]
    public static unsafe short PackInt16(this ReadOnlySpan<bool> source)
    {
        switch (source.Length)
        {
            case > 16: throw new ArgumentException("Source cannot contain more than than 16 elements.", nameof(source));
            case 8: return PackByte(source); // Potential optimization

            case 16:
#if NETSTANDARD2_1
                // TODO: Think of a way to do fast boolean correctness without using SIMD API.
                goto default;
#else
                // TODO: Acceleration in Big Endian environment.
                if (!BitConverter.IsLittleEndian)
                {
                    goto default;
                }

                // TODO: AdvSimd implementation.
                // TODO: WasmSimd implementation.

                if (Sse2.IsSupported)
                {
                    fixed (bool* pSource = source)
                    {
                        Vector128<byte> load = Sse2.LoadVector128((byte*)pSource);
                        Vector128<ulong> correct = load.CorrectBoolean().AsUInt64();
                        Vector128<ulong> multiply = IntrinsicUtility.Multiply(IntegerPackingMagicV128, correct);
                        Vector128<ulong> shift = Sse2.ShiftRightLogical(multiply, 56);

                        return (short)(shift.GetElement(0) | (shift.GetElement(1) << 8));
                    }
                }

                goto default;
#endif

            default:
                short result = 0;

                for (var index = 0; index < source.Length; index++)
                {
                    result |= (short)(source[index] ? 1 << index : 0);
                }

                return result;
        }
    }

    /// <summary>
    ///     Packs a <see cref="Span{T}"/> of booleans into a <see cref="int" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>A 32-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 32 elements.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int PackInt32(this Span<bool> source)
    {
        return PackInt32((ReadOnlySpan<bool>)source);
    }

    /// <summary>
    ///     Packs a <see cref="ReadOnlySpan{T}"/> of booleans into a <see cref="int" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>A 32-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 32 elements.</exception>
    [Pure]
    public static unsafe int PackInt32(this ReadOnlySpan<bool> source)
    {
        switch (source.Length)
        {
            case > 32: throw new ArgumentException("Source cannot contain more than than 32 elements.", nameof(source));
            case 8: return PackByte(source);
            case 16: return PackInt16(source);

            case 32:
#if NETSTANDARD2_1
                // TODO: Think of a way to do fast boolean correctness without using SIMD API.
                goto default;
#else
                // TODO: Acceleration in Big Endian environment.
                if (!BitConverter.IsLittleEndian)
                {
                    goto default;
                }

                fixed (bool* pSource = source)
                {
                    if (Avx2.IsSupported)
                    {
                        Vector256<byte> load = Avx.LoadVector256((byte*)pSource);
                        Vector256<ulong> correct = load.CorrectBoolean().AsUInt64();

                        Vector256<ulong> multiply = IntrinsicUtility.Multiply(IntegerPackingMagicV256, correct);
                        Vector256<ulong> shift = Avx2.ShiftRightLogical(multiply, 56);
                        shift = Avx2.ShiftLeftLogicalVariable(shift, Vector256.Create(0UL, 8, 16, 24));

                        Vector256<ulong> p1 = Avx2.Permute4x64(shift, 0b10_11_00_01);
                        Vector256<ulong> or1 = Avx2.Or(shift, p1);
                        Vector256<ulong> p2 = Avx2.Permute4x64(or1, 0b00_00_10_10);
                        Vector256<ulong> or2 = Avx2.Or(or1, p2);

                        return (int)or2.GetElement(0);
                    }

                    if (Sse2.IsSupported)
                    {
                        Vector128<byte> load = Sse2.LoadVector128((byte*)pSource);
                        Vector128<ulong> correct = load.CorrectBoolean().AsUInt64();

                        Vector128<ulong> multiply = IntrinsicUtility.Multiply(IntegerPackingMagicV128, correct);
                        Vector128<ulong> shift1 = Sse2.ShiftRightLogical(multiply, 56);
                        shift1 = Sse2.ShiftLeftLogical(shift1, Vector128.Create(0UL, 8UL));

                        load = Sse2.LoadVector128((byte*)(pSource + 16));
                        correct = load.CorrectBoolean().AsUInt64();

                        multiply = IntrinsicUtility.Multiply(IntegerPackingMagicV128, correct);
                        Vector128<ulong> shift2 = Sse2.ShiftRightLogical(multiply, 56);
                        shift2 = Sse2.ShiftLeftLogical(shift2, Vector128.Create(16UL, 24UL));

                        Vector128<ulong> or1 = Sse2.Or(shift1, shift2);
                        Vector128<ulong> or2 = Sse2.Or(or1, or1.ReverseElements());

                        return (int)or2.GetElement(0);
                    }

                    if (AdvSimd.IsSupported)
                    {
                        // Hasn't been tested since March 6th 2023 (Reason: Unavailable hardware).
                        Vector128<ulong> vector1 = AdvSimd.LoadVector128((byte*)pSource).CorrectBoolean().AsUInt64();
                        Vector128<ulong> vector2 = AdvSimd.LoadVector128((byte*)(pSource + 16)).CorrectBoolean().AsUInt64();

                        Vector128<ulong> calc1 = IntrinsicUtility.Multiply(IntegerPackingMagicV128, vector1);
                        Vector128<ulong> calc2 = IntrinsicUtility.Multiply(IntegerPackingMagicV128, vector2);

                        calc1 = AdvSimd.ShiftRightLogical(calc1, 56);
                        calc2 = AdvSimd.ShiftRightLogical(calc2, 56);

                        Vector128<ulong> shift1 = AdvSimd.ShiftLogical(calc1, Vector128.Create(0, 8));
                        Vector128<ulong> shift2 = AdvSimd.ShiftLogical(calc2, Vector128.Create(16, 24));

                        return (int)(shift1.GetElement(0) | shift1.GetElement(1) | shift2.GetElement(0) | shift2.GetElement(1));
                    }
                    else
                    {
                        goto default;
                    }
                }
#endif

            default:
                int result = 0;

                for (var i = 0; i < source.Length; i++)
                {
                    result |= source[i] ? 1 << i : 0;
                }

                return result;
        }
    }

    /// <summary>
    ///     Packs a <see cref="Span{T}"/> of booleans into a <see cref="long" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>A 64-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 64 elements.</exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long PackInt64(this Span<bool> source)
    {
        return PackInt64((ReadOnlySpan<bool>)source);
    }

    /// <summary>
    ///     Packs a <see cref="ReadOnlySpan{T}"/> of booleans into a <see cref="long" />.
    /// </summary>
    /// <param name="source">The span of booleans to pack.</param>
    /// <returns>A 64-bit signed integer containing the packed booleans.</returns>
    /// <exception cref="ArgumentException"><paramref name="source" /> contains more than 64 elements.</exception>
    [Pure]
    public static unsafe long PackInt64(this ReadOnlySpan<bool> source)
    {
        switch (source.Length)
        {
            case > 64: throw new ArgumentException("Source cannot contain more than than 64 elements.", nameof(source));
            case 8: return PackByte(source);
            case 16: return PackInt16(source);
            case 32: return PackInt32(source);
            case 64:
                // TODO: Reimplement when Vector512 is in standard API.
                return (long)PackInt32(source[..32]) | ((long)PackInt32(source[32..]) << 32);

            default:
                long result = 0;

                for (var index = 0; index < source.Length; index++)
                {
                    result |= source[index] ? 1U << index : 0;
                }

                return result;
        }
    }
}
