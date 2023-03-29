using System.Diagnostics.Contracts;

#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    private const int Size = sizeof(int) * 8;

    /// <summary>
    ///     Unpacks this 32-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <returns>An array of <see cref="bool" /> with length 32.</returns>
    [Pure]
    public static bool[] Unpack(this int value)
    {
        var ret = new bool[Size];
        value.Unpack(ret);
        return ret;
    }

    /// <summary>
    ///     Unpacks this 32-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    public static void Unpack(this int value, Span<bool> destination)
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException($"Destination must be at least {Size} in length.", nameof(destination));
        }

#if NETCOREAPP3_0_OR_GREATER
        // TODO: AdvSimd support.

        // https://stackoverflow.com/questions/24225786/fastest-way-to-unpack-32-bits-to-a-32-byte-simd-vector
        if (Avx2.IsSupported)
        {
            Avx2Implementation(value, destination);
            return;
        }

        if (Ssse3.IsSupported)
        {
            Ssse3Implementation(value, destination);
            return;
        }
#endif

        FallbackImplementation(value, destination);

#if NETCOREAPP3_0_OR_GREATER
        unsafe static void Avx2Implementation(int value, Span<bool> destination)
        {
            fixed (bool* pDestination = destination)
            {
                var mask1 = Vector256.Create(
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
                    0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
                    0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03
                ).AsByte();
                var mask2 = Vector256.Create(
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
                );

                var vec = Vector256.Create(value).AsByte();
                var shuffle = Avx2.Shuffle(vec, mask1);
                var and = Avx2.AndNot(shuffle, mask2);
                var cmp = Avx2.CompareEqual(and, Vector256<byte>.Zero);
                var correctness = Avx2.And(cmp, Vector256.Create((byte)0x01));

                Avx.Store((byte*)pDestination, correctness);
            }
        }

        unsafe static void Ssse3Implementation(int value, Span<bool> destination)
        {
            fixed (bool* pDestination = destination)
            {
                var mask2 = Vector128.Create(
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
                );
                var mask1Lo = Vector128.Create((byte)0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1);
                var mask1Hi = Vector128.Create((byte)2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3);

                var one = Vector128.Create((byte)0x01);

                var vec = Vector128.Create(value).AsByte();
                var shuffle = Ssse3.Shuffle(vec, mask1Lo);
                var and = Sse2.AndNot(shuffle, mask2);
                var cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
                var correctness = Sse2.And(cmp, one);

                Sse2.Store((byte*)pDestination, correctness);

                shuffle = Ssse3.Shuffle(vec, mask1Hi);
                and = Sse2.AndNot(shuffle, mask2);
                cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
                correctness = Sse2.And(cmp, one);

                Sse2.Store((byte*)pDestination + 16, correctness);
            }
        }
#endif
        static void FallbackImplementation(int value, Span<bool> destination)
        {
            for (var index = 0; index < Size; index++)
            {
                destination[index] = (value & (1 << index)) != 0;
            }
        }
    }
}
