namespace X10D.Core;

/// <summary>
///     Extension methods for <see cref="Range" />.
/// </summary>
public static class RangeExtensions
{
    /// <summary>
    ///     Allows the ability to use a <c>for</c> loop to iterate over the indices of a <see cref="Range" />. The indices of the
    ///     range are the inclusive lower and upper bounds of the enumeration.
    /// </summary>
    /// <param name="range">The range whose indices over which will be enumerated.</param>
    /// <returns>A <see cref="RangeEnumerator" /> that will enumerate over the indices of <paramref name="range" />.</returns>
    /// <remarks>
    ///     This method aims to implement Python-esque for loops in C# by taking advantage of the language syntax used to define
    ///     a <see cref="Range" /> value. Negative bounds may be specified using the C# <c>^</c> operator, or by providing an
    ///     <see cref="Index" /> whose <see cref="Index.IsFromEnd" /> property is <see langword="true" />.
    /// </remarks>
    /// <example>
    ///     The following example counts from 0 to 10 inclusive:
    ///     <code>
    ///         foreach (var i in 0..10)
    ///         {
    ///             Console.WriteLine(i);
    ///         }
    ///     </code>
    ///
    ///     To use negative bounds, use the <c>^</c> operator. The following example counts from -5 to 5 inclusive:
    ///     <code>
    ///         foreach (var i in ^5..5)
    ///         {
    ///             Console.WriteLine(i);
    ///         }
    ///     </code>
    ///
    ///     Decrementing enumeration is supported. The following example counts from 5 to -5 inclusive:
    ///     <code>
    ///         foreach (var i in 5..^5)
    ///         {
    ///             Console.WriteLine(i);
    ///         }
    ///     </code>
    /// </example>
    public static RangeEnumerator GetEnumerator(this Range range)
    {
        return new RangeEnumerator(range);
    }
}
