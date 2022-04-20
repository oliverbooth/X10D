namespace X10D;

/// <summary>
///     Extension methods which apply to all types.
/// </summary>
public static class Extensions
{
    /// <summary>
    ///     Returns an array containing the specified value.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    /// <typeparam name="T">The value type.</typeparam>
    /// <returns>
    ///     An array of type <typeparamref name="T" /> with length 1, whose only element is <paramref name="value" />.
    /// </returns>
    public static T[] AsArray<T>(this T value)
    {
        return new[] {value};
    }

    /// <summary>
    ///     Returns an enumerable collection containing the specified value.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    /// <typeparam name="T">The value type.</typeparam>
    /// <returns>
    ///     An enumerable collection of type <typeparamref name="T" />, whose only element is <paramref name="value" />.
    /// </returns>
    public static IEnumerable<T> AsEnumerable<T>(this T value)
    {
        yield return value;
    }
}
