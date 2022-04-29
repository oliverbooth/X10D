using System.Diagnostics.Contracts;

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
        Span<bool> buffer = stackalloc bool[Size];
        value.Unpack(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Unpacks this 8-bit unsigned integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    public static void Unpack(this byte value, Span<bool> destination)
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException($"Destination must be at least {Size} in length.", nameof(destination));
        }

        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }
}
