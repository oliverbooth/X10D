using System.Text;

namespace X10D.IO;

/// <summary>
///     Extension methods for <see cref="byte" /> array.
/// </summary>
public static class ListOfByteExtensions
{
    /// <summary>
    ///     Converts the numeric value of each element of a specified list of bytes to its equivalent hexadecimal string
    ///     representation.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>
    ///     A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in
    ///     <paramref name="source" />; for example, "7F-2C-4A-00".
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static string AsString(this IReadOnlyList<byte> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToString(source.ToArray());
    }

    /// <summary>
    ///     Returns a double-precision floating point number converted from eight bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A double-precision floating point number formed by eight bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static double ToDouble(this IReadOnlyList<byte> source)
    {
        return ToDouble(source, 0);
    }

    /// <summary>
    ///     Returns a double-precision floating point number converted from eight bytes at a specified position in a list of
    ///     bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>
    ///     A double-precision floating point number formed by eight bytes beginning at <paramref name="startIndex" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static double ToDouble(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToDouble(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Returns a 16-bit signed integer converted from two bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A 16-bit signed integer formed by two bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static short ToInt16(this IReadOnlyList<byte> source)
    {
        return ToInt16(source, 0);
    }

    /// <summary>
    ///     Returns a 16-bit signed integer converted from two bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>A 16-bit signed integer formed by two bytes beginning at <paramref name="startIndex" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static short ToInt16(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToInt16(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Returns a 32-bit signed integer converted from four bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A 32-bit signed integer formed by four bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static int ToInt32(this IReadOnlyList<byte> source)
    {
        return ToInt32(source, 0);
    }

    /// <summary>
    ///     Returns a 32-bit signed integer converted from four bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>A 32-bit signed integer formed by four bytes beginning at <paramref name="startIndex" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static int ToInt32(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToInt32(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Returns a 64-bit signed integer converted from eight bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A 64-bit signed integer formed by eight bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static long ToInt64(this IReadOnlyList<byte> source)
    {
        return ToInt64(source, 0);
    }

    /// <summary>
    ///     Returns a 64-bit signed integer converted from eight bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>A 64-bit signed integer formed by eight bytes beginning at <paramref name="startIndex" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static long ToInt64(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        return BitConverter.ToInt64(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Returns a single-precision floating point number converted from four bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A single-precision floating point number formed by four bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static float ToSingle(this IReadOnlyList<byte> source)
    {
        return ToSingle(source, 0);
    }

    /// <summary>
    ///     Returns a single-precision floating point number converted from four bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>
    ///     A single-precision floating point number formed by four bytes beginning at <paramref name="startIndex" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    public static float ToSingle(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToSingle(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Decodes all the bytes within the current list of bytes to a string, using a specified encoding.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="encoding">The encoding which should be used to decode <paramref name="source" />.</param>
    /// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="source" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="encoding" /> is <see langword="null" />.</para>
    /// </exception>
    public static string ToString(this IReadOnlyList<byte> source, Encoding encoding)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (encoding is null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }

        return encoding.GetString(source.ToArray());
    }

    /// <summary>
    ///     Returns a 16-bit unsigned integer converted from two bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A 16-bit unsigned integer formed by two bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static ushort ToUInt16(this IReadOnlyList<byte> source)
    {
        return ToUInt16(source, 0);
    }

    /// <summary>
    ///     Returns a 16-bit unsigned integer converted from two bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>A 16-bit unsigned integer formed by two bytes beginning at <paramref name="startIndex" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static ushort ToUInt16(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToUInt16(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Returns a 32-bit unsigned integer converted from four bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A 32-bit unsigned integer formed by four bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static uint ToUInt32(this IReadOnlyList<byte> source)
    {
        return ToUInt32(source, 0);
    }

    /// <summary>
    ///     Returns a 32-bit unsigned integer converted from four bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>A 32-bit unsigned integer formed by four bytes beginning at <paramref name="startIndex" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static uint ToUInt32(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToUInt32(source.ToArray(), startIndex);
    }

    /// <summary>
    ///     Returns a 64-bit unsigned integer converted from eight bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <returns>A 64-bit unsigned integer formed by eight bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static ulong ToUInt64(this IReadOnlyList<byte> source)
    {
        return ToUInt64(source, 0);
    }

    /// <summary>
    ///     Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a list of bytes.
    /// </summary>
    /// <param name="source">The source list of bytes.</param>
    /// <param name="startIndex">The starting position within <paramref name="source" />.</param>
    /// <returns>A 64-bit unsigned integer formed by eight bytes beginning at <paramref name="startIndex" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [CLSCompliant(false)]
    public static ulong ToUInt64(this IReadOnlyList<byte> source, int startIndex)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return BitConverter.ToUInt64(source.ToArray(), startIndex);
    }
}
