using System;
using System.Runtime.CompilerServices;

namespace X10D.ComparableExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="IComparable{T}" />.
    /// </summary>
    public static class ComparableExtensions
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

        /// <summary>
        ///     Determines if the current value is greater than another value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <typeparam name="T1">An <see cref="IComparable{T2}" /> type.</typeparam>
        /// <typeparam name="T2">The comparison operand type.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is greater than <paramref name="other" />
        ///     -or-
        ///     <see langword="false"/> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int first = 5;
        /// int second = 10;
        ///
        /// bool result = first.GreaterThan(second);
        /// // result will be False
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterThan<T1, T2>(this T1 value, T2 other)
            where T1 : IComparable<T2>
        {
            return value.CompareTo(other) > 0;
        }

        /// <summary>
        ///     Determines if the current value is greater than or equal to another value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <typeparam name="T1">An <see cref="IComparable{T2}" /> type.</typeparam>
        /// <typeparam name="T2">The comparison operand type.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is greater than or equal to <paramref name="other" />
        ///     -or-
        ///     <see langword="false"/> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int first = 5;
        /// int second = 10;
        ///
        /// bool result = first.GreaterThanOrEqualTo(second);
        /// // result will be False
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterThanOrEqualTo<T1, T2>(this T1 value, T2 other)
            where T1 : IComparable<T2>
        {
            return value.CompareTo(other) >= 0;
        }

        /// <summary>
        ///     Determines if the current value is less than another value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <typeparam name="T1">An <see cref="IComparable{T2}" /> type.</typeparam>
        /// <typeparam name="T2">The comparison operand type.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is less than <paramref name="other" />
        ///     -or-
        ///     <see langword="false"/> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int first = 5;
        /// int second = 10;
        ///
        /// bool result = first.LessThan(second);
        /// // result will be True
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessThan<T1, T2>(this T1 value, T2 other)
            where T1 : IComparable<T2>
        {
            return value.CompareTo(other) < 0;
        }

        /// <summary>
        ///     Determines if the current value is less than or equal to another value.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <typeparam name="T1">An <see cref="IComparable{T2}" /> type.</typeparam>
        /// <typeparam name="T2">The comparison operand type.</typeparam>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is less than or equal to <paramref name="other" />
        ///     -or-
        ///     <see langword="false"/> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int first = 5;
        /// int second = 10;
        ///
        /// bool result = first.LessThanOrEqualTo(second);
        /// // result will be True
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessThanOrEqualTo<T1, T2>(this T1 value, T2 other)
            where T1 : IComparable<T2>
        {
            return value.CompareTo(other) <= 0;
        }

        /// <summary>
        ///     Returns the maximum of two values.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <typeparam name="T">A type which implements <see cref="IComparable{T}" />.</typeparam>
        /// <returns>
        ///     <paramref name="value" /> if <paramref name="value" /> is greater than <paramref name="other" />
        ///     -or-
        ///     <paramref name="other" /> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int first = 5;
        /// int second = 10;
        ///
        /// int max = first.Max(second);
        /// // max will be 10
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.GreaterThan(other) ? value : other;
        }

        /// <summary>
        ///     Returns the minimum of two values.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <typeparam name="T">A type which implements <see cref="IComparable{T}" />.</typeparam>
        /// <returns>
        ///     <paramref name="value" /> if <paramref name="value" /> is less than <paramref name="other" />
        ///     -or-
        ///     <paramref name="other" /> otherwise.
        /// </returns>
        /// <example>
        /// <code lang="csharp">
        /// int first = 5;
        /// int second = 10;
        ///
        /// int min = first.Min(second);
        /// // min will be 5
        /// </code>
        /// </example>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.LessThan(other) ? value : other;
        }
    }
}
