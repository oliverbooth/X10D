using System.Security.Cryptography;

namespace X10D;

/// <summary>
///     Extension methods for <see cref="FileInfo" />.
/// </summary>
public static class FileInfoExtensions
{
    /// <summary>
    ///     Computes the hash of a file using the specified hash algorithm.
    /// </summary>
    /// <param name="value">The file whose hash to compute.</param>
    /// <typeparam name="T">A <see cref="HashAlgorithm" /> derived type.</typeparam>
    /// <returns>A <see cref="byte" /> array representing the hash of the file.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    /// <exception cref="FileNotFoundException">The file pointed at by <paramref name="value" /> does not exist.</exception>
    /// <exception cref="IOException">The opened file stream cannot be read.</exception>
    /// <exception cref="ArgumentException">
    ///     <para><typeparamref name="T" /> does not offer a static <c>Create</c> method.</para>
    ///     -or-
    ///     <para>
    ///         An invocation to the static <c>Create</c> method defined in <typeparamref name="T" /> returned
    ///         <see langword="null" />.
    ///     </para>
    /// </exception>
    public static byte[] GetHash<T>(this FileInfo value)
        where T : HashAlgorithm
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!value.Exists)
        {
            throw new FileNotFoundException("Cannot get hash of non-existent file.", value.FullName);
        }

        using FileStream stream = value.OpenRead();
        return stream.GetHash<T>();
    }
}
