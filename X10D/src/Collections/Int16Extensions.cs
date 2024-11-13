using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using X10D.CompilerServices;

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    private const int Size = sizeof(short) * 8;

    [MethodImpl(CompilerResources.MaxOptimization)]
    internal static void UnpackInternal_Fallback(this short value, Span<bool> destination)
    {
        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }

    [MethodImpl(CompilerResources.MaxOptimization)]
    internal unsafe static void UnpackInternal_Ssse3(this short value, Span<bool> destination)
    {
        fixed (bool* pDestination = destination)
        {
            var mask2 = Vector128.Create(
                0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
            );

            var mask1Lo = Vector128.Create((byte)0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1);
            var one = Vector128.Create((byte)0x01);

            Vector128<byte> vec = Vector128.Create(value).AsByte();
            Vector128<byte> shuffle = Ssse3.Shuffle(vec, mask1Lo);
            Vector128<byte> and = Sse2.AndNot(shuffle, mask2);
            Vector128<byte> cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
            Vector128<byte> correctness = Sse2.And(cmp, one);

            Sse2.Store((byte*)pDestination, correctness);
        }
    }
}
