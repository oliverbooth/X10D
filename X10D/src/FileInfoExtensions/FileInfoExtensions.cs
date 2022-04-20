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
    /// <exception cref="FileNotFoundException">The specified file was not found.</exception>
    /// <exception cref="IOException">The opened file stream cannot be read.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
    public static byte[] GetHash<T>(this FileInfo value)
        where T : HashAlgorithm
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        using FileStream stream = value.OpenRead();
        return stream.GetHash<T>();
    }
}
