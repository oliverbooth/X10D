using System.Diagnostics.Contracts;

namespace X10D.Core;

/// <summary>
///     Extension methods for <see langword="enum" /> types.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    ///     Returns the value which is defined proceeding this value in the enumeration.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="value">The value whose proceeding value to retrieve.</param>
    /// <returns>
    ///     A value of <typeparamref name="T" /> that is considered to be the next value defined after <paramref name="value" />,
    ///     or the first value if <paramref name="value" /> is the final field of the enumeration.
    /// </returns>
    [Pure]
    public static T Next<T>(this T value)
        where T : struct, Enum
    {
#if NET5_0_OR_GREATER
        T[] values = Enum.GetValues<T>();
#else
        T[] values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
#endif
        int index = Array.IndexOf(values, value) + 1;
        index %= values.Length;
        return values[index];
    }

    /// <summary>
    ///     Returns the value which is defined proceeding this value in the enumeration.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="value">The value whose proceeding value to retrieve.</param>
    /// <returns>
    ///     A value of <typeparamref name="T" /> that is considered to be the next value defined after
    ///     <paramref name="value" />.
    /// </returns>
    /// <exception cref="IndexOutOfRangeException"><paramref name="value" /> is the final field of the enumeration.</exception>
    [Pure]
    public static T NextUnchecked<T>(this T value)
        where T : struct, Enum
    {
#if NET5_0_OR_GREATER
        T[] values = Enum.GetValues<T>();
#else
        T[] values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
#endif
        int index = Array.IndexOf(values, value) + 1;
        return values[index];
    }

    /// <summary>
    ///     Returns the value which is defined preceeding this value in the enumeration.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="value">The value whose preceeding value to retrieve.</param>
    /// <returns>
    ///     A value of <typeparamref name="T" /> that is considered to be the previous value defined after
    ///     <paramref name="value" />, or the last value if <paramref name="value" /> is the first field of the enumeration.
    /// </returns>
    [Pure]
    public static T Previous<T>(this T value)
        where T : struct, Enum
    {
#if NET5_0_OR_GREATER
        T[] values = Enum.GetValues<T>();
#else
        T[] values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
#endif
        int index = Array.IndexOf(values, value) - 1;
        int length = values.Length;

        // negative modulo is not supported in C#. workaround: https://stackoverflow.com/a/1082938/1467293
        // sure, simply checking for index < 0 is enough, but this expression is so fucking cool!
        index = (index % length + length) % length;
        return values[index];
    }

    /// <summary>
    ///     Returns the value which is defined preceeding this value in the enumeration.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="value">The value whose preceeding value to retrieve.</param>
    /// <returns>
    ///     A value of <typeparamref name="T" /> that is considered to be the previous value defined after
    ///     <paramref name="value" />, or the last value if <paramref name="value" /> is the first field of the enumeration.
    /// </returns>
    /// <exception cref="IndexOutOfRangeException"><paramref name="value" /> is the first field of the enumeration.</exception>
    [Pure]
    public static T PreviousUnchecked<T>(this T value)
        where T : struct, Enum
    {
#if NET5_0_OR_GREATER
        T[] values = Enum.GetValues<T>();
#else
        T[] values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
#endif
        int index = Array.IndexOf(values, value) - 1;
        return values[index];
    }
}
