namespace X10D.Core;

/// <summary>
///     Extension methods for <see cref="Nullable{T}" />
/// </summary>
public static class NullableExtensions
{
    /// <summary>
    ///     Attempts to get the value of a <see cref="Nullable{T}" />, and returns a value indicating the success of the
    ///     operation. 
    /// </summary>
    /// <param name="value">The nullable value.</param>
    /// <param name="result">
    ///     When this method returns, contains the result of <see cref="Nullable{T}.Value" />, if
    ///     <see cref="Nullable{T}.HasValue" /> is <see langword="true" />; otherwise, returns the default value for
    ///     <typeparamref name="T" />.
    /// </param>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <returns>
    ///     <see langword="true" /> if the value's <see cref="Nullable{T}.HasValue" /> is <see langword="true" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool TryGetValue<T>(this T? value, out T result)
        where T : struct
    {
        if (value.HasValue)
        {
            result = value.Value;
            return true;
        }

        result = default;
        return false;
    }
}
