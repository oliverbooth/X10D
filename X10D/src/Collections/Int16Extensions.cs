using System.Diagnostics.Contracts;

#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    private const int Size = sizeof(short) * 8;

    /// <summary>
    ///     Unpacks this 16-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <returns>An array of <see cref="bool" /> with length 16.</returns>
    [Pure]
    public static bool[] Unpack(this short value)
    {
        bool[] ret = new bool[Size];
        value.Unpack(ret);
        return ret;
    }

    /// <summary>
    ///     Unpacks this 16-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    public static void Unpack(this short value, Span<bool> destination)
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException($"Destination must be at least {Size} in length.", nameof(destination));
        }

#if NETCOREAPP3_0_OR_GREATER
        if (Ssse3.IsSupported)
        {
            Ssse3Implementation(value, destination);
            return;
        }
#endif

        FallbackImplementation(value, destination);

#if NETCOREAPP3_0_OR_GREATER
        unsafe static void Ssse3Implementation(short value, Span<bool> destination)
        {
            fixed (bool* pDestination = destination)
            {
                var mask2 = Vector128.Create(
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                    0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
                );
                var mask1Lo = Vector128.Create((byte)0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1);

                var one = Vector128.Create((byte)0x01);

                var vec = Vector128.Create(value).AsByte();
                var shuffle = Ssse3.Shuffle(vec, mask1Lo);
                var and = Sse2.AndNot(shuffle, mask2);
                var cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
                var correctness = Sse2.And(cmp, one);

                Sse2.Store((byte*)pDestination, correctness);
            }
        }
#endif
        static void FallbackImplementation(short value, Span<bool> destination)
        {
            for (var index = 0; index < Size; index++)
            {
                destination[index] = (value & (1 << index)) != 0;
            }
        }
    }
}
