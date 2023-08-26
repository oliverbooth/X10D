#if NET7_0_OR_GREATER
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using X10D.CompilerServices;

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="IBinaryInteger{T}" />.
/// </summary>
public static class BinaryIntegerExtensions
{
    /// <summary>
    ///     Unpacks this integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <returns>An array of <see cref="bool" /> with a length equal to the size of <typeparamref name="TInteger" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static bool[] Unpack<TInteger>(this TInteger value)
        where TInteger : unmanaged, IBinaryInteger<TInteger>
    {
        unsafe
        {
            var buffer = new bool[sizeof(TInteger) * 8];
            value.Unpack(buffer);
            return buffer;
        }
    }

    /// <summary>
    ///     Unpacks this integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    [MethodImpl(CompilerResources.MethodImplOptions)]
    public static void Unpack<TInteger>(this TInteger value, Span<bool> destination)
        where TInteger : unmanaged, IBinaryInteger<TInteger>
    {
        unsafe
        {
            if (destination.Length < sizeof(TInteger) * 8)
            {
                throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
            }
        }

        switch (value)
        {
            case byte valueByte when Sse3.IsSupported:
                valueByte.UnpackInternal_Ssse3(destination);
                break;

            case int valueInt32 when Avx2.IsSupported:
                valueInt32.UnpackInternal_Ssse3(destination);
                break;

            case int valueInt32 when Sse3.IsSupported:
                valueInt32.UnpackInternal_Ssse3(destination);
                break;

            case short valueInt16 when Sse3.IsSupported:
                valueInt16.UnpackInternal_Ssse3(destination);
                break;

            default:
                UnpackInternal_Fallback(value, destination);
                break;
        }
    }

    [MethodImpl(CompilerResources.MethodImplOptions)]
    internal static void UnpackInternal_Fallback<TInteger>(this TInteger value, Span<bool> destination)
        where TInteger : unmanaged, IBinaryInteger<TInteger>
    {
        unsafe
        {
            int bitCount = sizeof(TInteger) * 8;
            for (var index = 0; index < bitCount; index++)
            {
                destination[index] = (value & (TInteger.One << index)) != TInteger.Zero;
            }
        }
    }
}
#endif
