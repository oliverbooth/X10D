using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using X10D.CompilerServices;

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    private const int Size = sizeof(int) * 8;

    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static void UnpackInternal_Fallback(this int value, Span<bool> destination)
    {
        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }

    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static unsafe void UnpackInternal_Ssse3(this int value, Span<bool> destination)
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

            Vector128<byte> vec = Vector128.Create(value).AsByte();
            Vector128<byte> shuffle = Ssse3.Shuffle(vec, mask1Lo);
            Vector128<byte> and = Sse2.AndNot(shuffle, mask2);
            Vector128<byte> cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
            Vector128<byte> correctness = Sse2.And(cmp, one);

            Sse2.Store((byte*)pDestination, correctness);

            shuffle = Ssse3.Shuffle(vec, mask1Hi);
            and = Sse2.AndNot(shuffle, mask2);
            cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
            correctness = Sse2.And(cmp, one);

            Sse2.Store((byte*)pDestination + 16, correctness);
        }
    }

    internal static unsafe void UnpackInternal_Avx2(this int value, Span<bool> destination)
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

            Vector256<byte> vec = Vector256.Create(value).AsByte();
            Vector256<byte> shuffle = Avx2.Shuffle(vec, mask1);
            Vector256<byte> and = Avx2.AndNot(shuffle, mask2);
            Vector256<byte> cmp = Avx2.CompareEqual(and, Vector256<byte>.Zero);
            Vector256<byte> correctness = Avx2.And(cmp, Vector256.Create((byte)0x01));

            Avx.Store((byte*)pDestination, correctness);
        }
    }
}
