namespace X10D;

/// <summary>
///     Extension methods for <see langword="enum" /> types.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    ///     Returns the next member defined in a specified enum.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="source">The enum value which should be used as the starting point.</param>
    /// <param name="wrap">
    ///     Optional. <see langword="true" /> if the final value of <typeparamref name="T" /> should wrap around to the first
    ///     value; otherwise, <see langword="false" />. Defaults to <see langword="true" />.
    /// </param>
    /// <returns>
    ///     A value of <typeparamref name="T" /> that is considered to be the next value defined after
    ///     <paramref name="source" />.
    /// </returns>
    public static T Next<T>(this T source, bool wrap = true)
        where T : struct, Enum
    {
        var array = (T[])Enum.GetValues(source.GetType());
        int index = Array.IndexOf(array, source) + 1;
        return array.Length == index ? array[wrap ? 0 : index - 1] : array[index];
    }

    /// <summary>
    ///     Returns the previous member defined in a specified enum.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="source">The enum value which should be used as the starting point.</param>
    /// <param name="wrap">
    ///     Optional. <see langword="true" /> if the first value of <typeparamref name="T" /> should wrap around to the final
    ///     value; otherwise, <see langword="false" />. Defaults to <see langword="true" />.
    /// </param>
    /// <returns>
    ///     A value of <typeparamref name="T" /> that is considered to be the previous value defined before
    ///     <paramref name="source" />.
    /// </returns>
    public static T Previous<T>(this T source, bool wrap = true)
        where T : struct, Enum
    {
        var array = (T[])Enum.GetValues(source.GetType());
        int index = Array.IndexOf(array, source) - 1;
        return index < 0 ? array[wrap ? array.Length - 1 : 0] : array[index];
    }
}
