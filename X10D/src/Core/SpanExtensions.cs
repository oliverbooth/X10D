using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
#endif

namespace X10D.Core;

/// <summary>
/// Extension methods for <see cref="Span{T}"/> and <see cref="ReadOnlySpan{T}"/>.
/// </summary>
public static class SpanExtensions
{
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
    public static byte PackByte(this ReadOnlySpan<bool> source)
    {
        switch (source.Length)
        {
            case > 8: throw new ArgumentException("Source cannot contain more than 8 elements.", nameof(source));
            case 8:
#if NETSTANDARD2_1
                // TODO: Think of a way to do fast boolean correctness.
                goto default;
#else
                unsafe
                {
                    ulong reinterpret;

                    // Boolean correctness.
                    if (Sse2.IsSupported)
                    {
                        fixed (bool* pSource = source)
                        {
                            var vec = Sse2.LoadScalarVector128((ulong*)pSource).AsByte();
                            var cmp = Sse2.CompareEqual(vec, Vector128<byte>.Zero);
                            var correctness = Sse2.AndNot(cmp, Vector128.Create((byte)1));

                            reinterpret = correctness.AsUInt64().GetElement(0);
                        }
                    }
                    else if (AdvSimd.IsSupported)
                    {
                        // Haven't tested since March 6th 2023 (Reason: Unavailable hardware).
                        fixed (bool* pSource = source)
                        {
                            var vec = AdvSimd.LoadVector64((byte*)pSource);
                            var cmp = AdvSimd.CompareEqual(vec, Vector64<byte>.Zero);
                            var correctness = AdvSimd.BitwiseSelect(cmp, vec, Vector64<byte>.Zero);

                            reinterpret = Unsafe.As<Vector64<byte>, ulong>(ref correctness);
                        }
                    }
                    else
                    {
                        goto default;
                    }

                    if (BitConverter.IsLittleEndian)
                    {
                        const ulong magic = 0b0000_0001_0000_0010_0000_0100_0000_1000_0001_0000_0010_0000_0100_0000_1000_0000;

                        return unchecked((byte)(magic * reinterpret >> 56));
                    }
                    else
                    {
                        // Haven't tested since March 6th 2023 (Reason: Unavailable hardware).
                        const ulong magic = 0b1000_0000_0100_0000_0010_0000_0001_0000_0000_1000_0000_0100_0000_0010_0000_0001;
                        return unchecked((byte)(magic * reinterpret >> 56));
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
}
