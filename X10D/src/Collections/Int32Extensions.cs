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
    public static bool[] Unpack(this int value)
    {
        Span<bool> buffer = stackalloc bool[Size];
        value.Unpack(buffer);
        return buffer.ToArray();
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

        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1 << index)) != 0;
        }
    }
}
