using System;

namespace X10D.ComparableExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="IComparable{T}" />.
    /// </summary>
    public static class ComparableExtensions
    {
        /// <summary>
        ///     Determines if a specified value falls exclusively between a specified lower bound and upper bound.
        /// </summary>
        /// <typeparam name="T1">An <see cref="IComparable{T2}" /> type.</typeparam>
        /// <typeparam name="T2">The first comparison operand type.</typeparam>
        /// <typeparam name="T3">The second comparison operand type.</typeparam>
        /// <param name="value">The value to compare.</param>
        /// <param name="lower">The exclusive lower bound.</param>
        /// <param name="upper">The exclusive upper bound.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value" /> is between the <paramref name="lower"/> and
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
        public static bool Between<T1, T2, T3>(this T1 value, T2 lower, T3 upper)
            where T1 : IComparable<T2>, IComparable<T3>
        {
            return value.CompareTo(lower) > 0 && value.CompareTo(upper) < 0;
        }

        /// <summary>
        ///     Returns the current value clamped to the inclusive range of <paramref name="lower" /> and <paramref name="upper" />.
        /// </summary>
        /// <param name="value">The value to be clamped.</param>
        /// <param name="lower">The lower bound of the result.</param>
        /// <param name="upper">The upper bound of the result.</param>
        /// <typeparam name="T">An <see cref="IComparable" /> type.</typeparam>
        /// <returns>
        ///     <paramref name="value" /> if <paramref name="lower" /> ≤ <paramref name="value" /> ≤ <paramref name="upper" />.
        ///     -or-
        ///     <paramref name="lower" /> if <paramref name="value" /> &lt; <paramref name="lower" />.
        ///     -or-
        ///     <paramref name="upper" /> if <paramref name="upper" /> &lt; <paramref name="value" />.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="lower" /> is greater than <paramref name="upper" />.</exception>
        /// <example>
        /// <code lang="csharp">
        /// int value = 42;
        /// int lower = 0;
        /// int upper = 20;
        ///
        /// int clamped = value.Clamp(lower, upper);
        /// // clamped will be 20
        /// </code>
        /// </example>
        public static T Clamp<T>(this T value, T lower, T upper)
            where T : IComparable<T>
        {
            if (lower.GreaterThan(upper))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.LowerCannotBeGreaterThanUpper, lower, upper),
                    nameof(lower));
            }

            return value.Max(lower).Min(upper);
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
        public static T Min<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.LessThan(other) ? value : other;
        }
    }
}
