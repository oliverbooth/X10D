using System.Net;
using X10D.Math;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="int" />.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    ///     Performs a circular bitwise left-shift on an integer, such that the most-significant bits that are truncated occupy
    ///     the least-significant bits.
    /// </summary>
    /// <param name="value">The value to shift.</param>
    /// <param name="shift">The shift amount.</param>
    /// <returns>The result of the shift.</returns>
    public static int CircularLeftShift(this int value, int shift)
    {
        shift = shift.Mod(32);
        if (shift == 0)
        {
            return value;
        }

        var pattern = 0;
        for (var i = 0; i < shift; i++)
        {
            pattern |= 1 << (32 - i);
        }

        int cache = value & pattern;
        cache >>= 32 - shift;
        return (value << shift) | cache;
    }

    /// <summary>
    ///     Performs a circular bitwise right-shift on an integer, such that the least-significant bits that are truncated occupy
    ///     the most-significant bits.
    /// </summary>
    /// <param name="value">The value to shift.</param>
    /// <param name="shift">The shift amount.</param>
    /// <returns>The result of the shift.</returns>
    public static int CircularRightShift(this int value, int shift)
    {
        shift = shift.Mod(32);
        if (shift == 0)
        {
            return value;
        }

        var pattern = 0;
        for (var i = 0; i < shift; i++)
        {
            pattern |= 1 << i;
        }

        int cache = value & pattern;
        cache <<= 32 - shift;
        return (value >> shift) | cache;
    }

    /// <summary>
    ///     Converts the current angle in degrees to its equivalent represented in radians.
    /// </summary>
    /// <param name="value">The angle in degrees to convert.</param>
    /// <returns>The result of π * <paramref name="value" /> / 180.</returns>
    public static float DegreesToRadians(this int value)
    {
        return ((float)value).DegreesToRadians();
    }

    /// <summary>
    ///     Converts an integer value from network byte order to host byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in network byte order.</param>
    /// <returns>An integer value, expressed in host byte order.</returns>
    public static int ToHostOrder(this int value)
    {
        return IPAddress.NetworkToHostOrder(value);
    }

    /// <summary>
    ///     Converts an integer value from host byte order to network byte order.
    /// </summary>
    /// <param name="value">The value to convert, expressed in host byte order.</param>
    /// <returns>An integer value, expressed in network byte order.</returns>
    public static int ToNetworkOrder(this int value)
    {
        return IPAddress.HostToNetworkOrder(value);
    }
}
