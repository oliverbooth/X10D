namespace X10D.ReExposed.IEnumerableExtensions;

/// <summary>
///     Extension methods for<see cref="IEnumerable{T}"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class EnumerableExtensions
{
    /// <inheritdoc cref="string.Concat{T}(IEnumerable{T})"/>
    public static string Concat<T>(this IEnumerable<T> values)
    {
        return string.Concat(values);
    }

    /// <inheritdoc cref="string.Concat(IEnumerable{string})"/>
    public static string Concat(this IEnumerable<string?> strings)
    {
        return string.Concat(strings);
    }
}