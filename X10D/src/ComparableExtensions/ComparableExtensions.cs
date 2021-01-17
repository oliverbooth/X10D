using System;
using System.Runtime.CompilerServices;

namespace X10D.ComparableExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="IComparable{T}" />.
    /// </summary>
    public static partial class ComparableExtensions
    {
        /// <summary>
        ///     Determines if <paramref name="actual" /> is between <paramref name="lower" /> and <paramref name="upper" />.
        /// </summary>
        /// <typeparam name="T1">An <see cref="IComparable{T2}" /> type.</typeparam>
        /// <typeparam name="T2">The first comparison operand type.</typeparam>
        /// <typeparam name="T3">The second comparison operand type.</typeparam>
        /// <param name="actual">The value to compare.</param>
        /// <param name="lower">The exclusive lower bound.</param>
        /// <param name="upper">The exclusive upper bound.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="actual" /> is between the <paramref name="lower"/> and
        ///     <paramref name="upper"/>
        ///     -or-
        ///     <see langword="false" /> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int firstValue = 42;
        /// int secondValue = 15;
        /// 
        /// int lower = 0;
        /// int upper = 20;
        ///
        /// Console.WriteLine($"{firstValue} between {lower} and {upper}?");
        /// Console.WriteLine(firstValue.Between(lower, upper));
        /// 
        /// Console.WriteLine($"{secondValue} between {lower} and {upper}?");
        /// Console.WriteLine(secondValue.Between(lower, upper));
        ///
        /// // This will output the following:
        /// //      42 between 0 and 20?
        /// //      False
        /// //      15 between 0 and 20?
        /// //      True
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Between<T1, T2, T3>(this T1 actual, T2 lower, T3 upper)
            where T1 : IComparable<T2>, IComparable<T3>
        {
            return actual.CompareTo(lower) > 0 && actual.CompareTo(upper) < 0;
        }
    }
}
