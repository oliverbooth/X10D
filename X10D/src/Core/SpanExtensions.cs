using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if NETCOREAPP3_0_OR_GREATER
using X10D.Core;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics.Arm;
#endif

namespace X10D.Core;

/// <summary>
/// Extension methods for <see cref="Span{T}"/> and <see cref="ReadOnlySpan{T}"/>.
/// </summary>
public static class SpanExtensions
{
#if NETCOREAPP3_0_OR_GREATER
    private const ulong IntegerPackingMagic = 0x0102040810204080;
#endif

    /// <summary>
    ///     Indicate whether a specific enumeration value is found in a span.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="span">The span to search from.</param>
    /// <param name="value">The enum to search for.</param>
    /// <returns><see langword="true"/> if found, <see langword="false"/> otherwise.</returns>
    /// <exception cref="ArgumentException">Unexpected enum memory size.</exception>
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
    ///     Indicate whether a specific enumeration value is found in a span.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="span">The span to search from.</param>
    /// <param name="value">The enum to search for.</param>
    /// <returns><see langword="true"/> if found, <see langword="false"/> otherwise.</returns>
    /// <exception cref="ArgumentException">Unexpected enum memory size.</exception>
#if NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    public static bool Contains<T>(this ReadOnlySpan<T> span, T value) where T : struct, Enum
    {
#if NET6_0_OR_GREATER
        // Use MemoryMarshal.CreateSpan instead of using creating new Span instance from pointer will trim down a lot of instructions
        // on Release mode.
        // https://sharplab.io/#v2:EYLgxg9gTgpgtADwGwBYA0AXEBDAzgWwB8ABABgAJiBGAOgCUBXAOwwEt8YaBJFmKCAA4BlPgDdWYGLgDcAWABQZSrUYt2nAMIR8A1gBs+IqOMkyFxAExVzFIQAtsUAQBlsweszYc588wGZyGCYGfHIAFSkMAFFg0JByVhZyAG8FcnTyAEE0cgAhHI0cgBE0BQBfBX9KC3INFLSMgG0AKVYMAHEgvgkACgwATwEYCAAzHojcaNiASmmAXQb0xoBZGAw7CAATLh09HtX1rZ2BPQB5ATYIJlwaTIBzO9hcXFZRGB49RMS78kJyA4221250u11uDyeLzeIPYrAAXthQfNFpQAtQkORmLhsCMYORgBAIHp/mtAVQADxhAB8PSEAmwTEpVPIuHpTByYXIomwegYMGm5AA7nY+HjOfEYiF6vIMrLyLARgkkkEQrhyABeeUwRUAVWuOM4mVwlJyiQwNIVJPw0H6y0cuAcehonQwdG1oqYkh6rIZsx8coyxAA7FabXaoA6eTQNLBETA6QyepaVfhcDkfUwaM4gnd1tNo1cMNhErgenrsbjbsawqaWBbtVyeXy/SiKjKMiiWm1OkxumA+oNhmMJlMQrMFu2lgCjrt9qSZycYVcbvdHlIoe8mJ8mN9fiTDkDFxdWMvwWvnq8YDD8PDESemMjJ6jlBisQb8YTidPNhYmbS2UyLJshyja8vyQoirA4TkBKsTSgG6TBuQvaCuQCaMmaNLlgaVYAAoQGafBJg2qzWlAtr2o6zprG6uKwJ6MDemyszpmyWY5nmBYsMW1xlvqlZGiaSrmsRircmBLZPm2ZRAA===

        // Also use reference instead of MemoryMarshal.Cast to remove boundary check (or something, it just result in something like that).

        // TODO: Figure out some kind of way to directly pass the Span directly into Contains call, which make method smaller and more prone to inlining...
        unsafe
        {
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
            switch (sizeof(T))
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

                default:
#if NET7_0_OR_GREATER
                    throw new UnreachableException($"Enum with the size of {Unsafe.SizeOf<T>()} bytes is unexpected.");
#else
                    throw new ArgumentException($"Enum with the size of {Unsafe.SizeOf<T>()} bytes is unexpected.");
#endif
            }
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
        }
#else   // NET6_0_OR_GREATER
        foreach (var it in span)
        {
            if (EqualityComparer<T>.Default.Equals(it, value))
            {
                return true;
            }
        }

        return false;
#endif  // NET6_0_OR_GREATER
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

                fixed (bool* pSource = source) {
                    // TODO: .NET 8.0 Wasm support.

                    if (Sse2.IsSupported)
                    {
                        var scalar = Sse2.LoadScalarVector128((ulong*)pSource).AsByte().CorrectBoolean().AsUInt64();
                        return unchecked((byte)(IntegerPackingMagic * scalar.GetElement(0) >> 56));
                    }
                    else if (AdvSimd.IsSupported)
                    {
                        // Hasn't been tested since March 6th 2023 (Reason: Unavailable hardware).
                        var scalar = AdvSimd.LoadVector64((byte*)pSource).CorrectBoolean().AsUInt64();
                        return unchecked((byte)(IntegerPackingMagic * scalar.GetElement(0) >> 56));
                    }
                    else
                    {
                        goto default;
                    }
                }
#endif
            default:
                byte result = 0;

                for (var i = 0; i < source.Length; i++)
                {
                    result |= (byte)(source[i] ? 1 << i : 0);
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
            case 8: return PackByte(source);    // Potential optimization

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

                fixed (bool* pSource = source)
                {
                    // TODO: .NET 8.0 Wasm support.
                    // TODO: Implement a replacement for UInt64 vector multiplication (there are no instruction for this built-in).

                    if (Sse2.IsSupported)
                    {
                        var vector = Sse2.LoadVector128((byte*)pSource).CorrectBoolean().AsUInt64();
                        var calc = Sse2.ShiftRightLogical(IntrinsicUtility.Multiply(Vector128.Create(IntegerPackingMagic), vector), 56);

                        return (short)(calc.GetElement(0) | (calc.GetElement(1) << 8));
                    }
                    else if (AdvSimd.IsSupported)
                    {
                        // Hasn't been tested since March 6th 2023 (Reason: Unavailable hardware).
                        var vector = AdvSimd.LoadVector128((byte*)pSource).CorrectBoolean().AsUInt64();
                        var calc = AdvSimd.ShiftRightLogical(IntrinsicUtility.Multiply(Vector128.Create(IntegerPackingMagic), vector), 56);

                        return (short)(calc.GetElement(0) | (calc.GetElement(1) << 8));
                    }
                    else
                    {
                        goto default;
                    }
                }
#endif

            default:
                short result = 0;

                for (var i = 0; i < source.Length; i++)
                {
                    result |= (short)(source[i] ? 1 << i : 0);
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
                    // TODO: .NET 8.0 Wasm support.
                    // TODO: Implement a replacement for UInt64 vector multiplication (there are no instruction for this built-in).

                    if (Avx2.IsSupported)
                    {
                        var vector = Avx.LoadVector256((byte*)pSource).CorrectBoolean().AsUInt64();

                        var calc = Avx2.ShiftRightLogical(IntrinsicUtility.Multiply(Vector256.Create(IntegerPackingMagic), vector), 56);
                        var shift = Avx2.ShiftLeftLogicalVariable(calc, Vector256.Create(0UL, 8, 16, 24));

                        var p1 = Avx2.Permute4x64(shift, 0b10_11_00_01);
                        var or1 = Avx2.Or(shift, p1);
                        var p2 = Avx2.Permute4x64(or1, 0b00_00_10_10);
                        var or2 = Avx2.Or(or1, p2);

                        return (int)or2.GetElement(0);
                    }
                    if (Sse2.IsSupported)
                    {
                        var vector1 = Sse2.LoadVector128((byte*)pSource).CorrectBoolean().AsUInt64();
                        var vector2 = Sse2.LoadVector128((byte*)(pSource + 16)).CorrectBoolean().AsUInt64();

                        var magic = Vector128.Create(IntegerPackingMagic);

                        var calc1 = Sse2.ShiftRightLogical(IntrinsicUtility.Multiply(magic, vector1), 56);
                        var calc2 = Sse2.ShiftRightLogical(IntrinsicUtility.Multiply(magic, vector2), 56);

                        var shift1 = Sse2.ShiftLeftLogical(calc1, Vector128.Create(0UL, 8UL));
                        var shift2 = Sse2.ShiftLeftLogical(calc2, Vector128.Create(16UL, 24UL));

                        return (int)(shift1.GetElement(0) | shift1.GetElement(1) | shift2.GetElement(0) | shift2.GetElement(1));
                    }
                    else if (AdvSimd.IsSupported)
                    {
                        // Hasn't been tested since March 6th 2023 (Reason: Unavailable hardware).
                        var vector1 = AdvSimd.LoadVector128((byte*)pSource).CorrectBoolean().AsUInt64();
                        var vector2 = AdvSimd.LoadVector128((byte*)(pSource + 16)).CorrectBoolean().AsUInt64();

                        var magic = Vector128.Create(IntegerPackingMagic);

                        var calc1 = AdvSimd.ShiftRightLogical(IntrinsicUtility.Multiply(magic, vector1), 56);
                        var calc2 = AdvSimd.ShiftRightLogical(IntrinsicUtility.Multiply(magic, vector2), 56);

                        var shift1 = AdvSimd.ShiftLogical(calc1, Vector128.Create(0, 8));
                        var shift2 = AdvSimd.ShiftLogical(calc2, Vector128.Create(16, 24));

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
            case 64:
                // TODO: Reimplement when Vector512 is in standard API.
                return (long)PackInt32(source[..32]) | ((long)PackInt32(source[32..]) << 32);

            default:
                long result = 0;

                for (var i = 0; i < source.Length; i++)
                {
                    result |= source[i] ? 1U << i : 0;
                }

                return result;
        }
    }
}
