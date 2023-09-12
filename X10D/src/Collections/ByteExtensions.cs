using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using X10D.CompilerServices;

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    private const int Size = sizeof(byte) * 8;

    /// <summary>
    ///     Unpacks this 8-bit unsigned integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <returns>An array of <see cref="bool" /> with length 8.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool[] Unpack(this byte value)
    {
        var buffer = new bool[Size];
        value.Unpack(buffer);
        return buffer;
    }

    /// <summary>
    ///     Unpacks this 8-bit unsigned integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    [ExcludeFromCodeCoverage]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static void Unpack(this byte value, Span<bool> destination)
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

        if (Sse3.IsSupported)
        {
            UnpackInternal_Ssse3(value, destination);
            return;
        }

        UnpackInternal_Fallback(value, destination);
    }

    [MethodImpl(CompilerResources.MethodImplOptions)]
    internal static void UnpackInternal_Fallback(this byte value, Span<bool> destination)
    {
        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }

    [MethodImpl(CompilerResources.MethodImplOptions)]
    internal unsafe static void UnpackInternal_Ssse3(this byte value, Span<bool> destination)
    {
        fixed (bool* pDestination = destination)
        {
            var mask2 = Vector128.Create(
                0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80,
                0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80
            );
            var mask1 = Vector128.Create((byte)0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1);

            Vector128<byte> vec = Vector128.Create(value).AsByte();
            Vector128<byte> shuffle = Ssse3.Shuffle(vec, mask1);
            Vector128<byte> and = Sse2.AndNot(shuffle, mask2);
            Vector128<byte> cmp = Sse2.CompareEqual(and, Vector128<byte>.Zero);
            Vector128<byte> correctness = Sse2.And(cmp, Vector128.Create((byte)0x01));

            Sse2.StoreScalar((long*)pDestination, correctness.AsInt64());
        }
    }
}
