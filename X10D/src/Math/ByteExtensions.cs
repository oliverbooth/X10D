using System.Diagnostics.Contracts;

namespace X10D.Math;

/// <summary>
///     Math-related extension methods for <see cref="byte" />.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Returns a value indicating whether the current value is a prime number.
    /// </summary>
    /// <param name="value">The value whose primality to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    public static bool IsPrime(this byte value)
    {
        return ((long)value).IsPrime();
    }
}
