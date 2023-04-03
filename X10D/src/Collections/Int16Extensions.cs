using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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
#if NETCOREAPP3_1_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool[] Unpack(this short value)
    {
        var ret = new bool[Size];
        value.Unpack(ret);
        return ret;
    }

    /// <summary>
    ///     Unpacks this 16-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    [ExcludeFromCodeCoverage]
#if NETCOREAPP3_1_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static void Unpack(this short value, Span<bool> destination)
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

#if NETCOREAPP3_0_OR_GREATER
        if (Sse3.IsSupported)
        {
            UnpackInternal_Ssse3(value, destination);
            return;
        }
#endif

        UnpackInternal_Fallback(value, destination);
    }

#if NETCOREAPP3_1_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    internal static void UnpackInternal_Fallback(this short value, Span<bool> destination)
    {
        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }

#if NETCOREAPP3_0_OR_GREATER
#if NETCOREAPP3_1_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
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
#endif
}
