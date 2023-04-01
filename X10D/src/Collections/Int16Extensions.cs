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
    public static void Unpack(this short value, Span<bool> destination)
    {
#if NETCOREAPP3_0_OR_GREATER
        UnpackInternal(value, destination, new SystemSsse3SupportProvider());
#else
        UnpackInternal(value, destination);
#endif
    }

#if NETCOREAPP3_0_OR_GREATER
    internal static void UnpackInternal(this short value, Span<bool> destination, ISsse3SupportProvider? ssse3SupportProvider)
#else
    internal static void UnpackInternal(this short value, Span<bool> destination)
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

    private static void UnpackInternal_Fallback(short value, Span<bool> destination)
    {
        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }

#if NETCOREAPP3_0_OR_GREATER
    private struct SystemSsse3SupportProvider : ISsse3SupportProvider
    {
        /// <inheritdoc />
        public bool IsSupported
        {
            get => Sse3.IsSupported;
        }
    }

    private unsafe static void UnpackInternal_Ssse3(short value, Span<bool> destination)
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
