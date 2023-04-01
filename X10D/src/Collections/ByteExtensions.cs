using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

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
    public static void Unpack(this byte value, Span<bool> destination)
    {
#if NETCOREAPP3_0_OR_GREATER
        UnpackInternal(value, destination, new SystemSsse3SupportProvider());
#else
        UnpackInternal(value, destination);
#endif
    }

#if NETCOREAPP3_0_OR_GREATER
    internal static void UnpackInternal(this byte value, Span<bool> destination, ISsse3SupportProvider? ssse3SupportProvider)
#else
    internal static void UnpackInternal(this byte value, Span<bool> destination)
#endif
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

#if NETCOREAPP3_0_OR_GREATER
        ssse3SupportProvider ??= new SystemSsse3SupportProvider();

        if (ssse3SupportProvider.IsSupported)
        {
            UnpackInternal_Ssse3(value, destination);
            return;
        }
#endif

        UnpackInternal_Fallback(value, destination);
    }

    private static void UnpackInternal_Fallback(byte value, Span<bool> destination)
    {
        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }

#if NETCOREAPP3_0_OR_GREATER

    private unsafe static void UnpackInternal_Ssse3(byte value, Span<bool> destination)
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
#endif
}
