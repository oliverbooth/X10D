using System.Diagnostics.Contracts;

namespace X10D.Core;

/// <summary>
///     Extension methods which apply to all types.
/// </summary>
public static class Extensions
{
    /// <summary>
    ///     Returns an array containing the specified value.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <returns>
    ///     An array of type <typeparamref name="T" /> with length 1, whose only element is <paramref name="value" />.
    /// </returns>
    [Pure]
    public static T?[] AsArrayValue<T>(this T? value)
    {
        return new[] {value};
    }

    /// <summary>
    ///     Returns an enumerable collection containing the specified value.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <returns>
    ///     An enumerable collection of type <typeparamref name="T" />, whose only element is <paramref name="value" />.
    /// </returns>
    [Pure]
    public static IEnumerable<T?> AsEnumerableValue<T>(this T? value)
    {
        yield return value;
    }

    /// <summary>
    ///     Returns an enumerable collection containing the current value repeated a specified number of times.
    /// </summary>
    /// <param name="value">The value to repeat.</param>
    /// <param name="count">The number of times to repeat <paramref name="value" />.</param>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <returns>An enumerable collection containing <paramref name="value" /> repeated <paramref name="count" /> times.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count" /> is less than 0.</exception>
    [Pure]
    public static IEnumerable<T> RepeatValue<T>(this T value, int count)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), ExceptionMessages.CountMustBeGreaterThanOrEqualTo0);
        }

        for (var i = 0; i < count; i++)
        {
            yield return value;
        }
    }
}
