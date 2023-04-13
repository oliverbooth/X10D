namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Array" />.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    ///     Sets a range of elements in an array to the default value of each element type.
    /// </summary>
    /// <param name="array">The array whose elements need to be cleared.</param>
    /// <param name="range">A range defining the start index and number of elements to clear.</param>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
    public static void Clear<T>(this T?[] array, Range range)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(array);
#else
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
#endif

        (int offset, int length) = range.GetOffsetAndLength(array.Length);
        Array.Clear(array, offset, length);
    }
}
