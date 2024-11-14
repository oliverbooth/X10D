using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Math;

/// <summary>
///     Extension methods for <see cref="ulong" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt64Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the current value is a prime number.
    /// </summary>
    /// <param name="value">The value whose primality to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is prime; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsPrime(this ulong value)
    {
        switch (value)
        {
            case <= 1: return false;
            case <= 3: return true;
        }

        if ((value & 1) == 0 || value % 3 == 0)
        {
            return false;
        }

        for (var iterator = 5UL; iterator * iterator <= value; iterator += 6)
        {
            if (value % iterator == 0 || value % (iterator + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }
}
