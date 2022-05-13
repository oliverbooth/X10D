using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="FileInfo" />.
/// </summary>
public static class FileInfoExtensions
{
    /// <summary>
    ///     Computes the hash of a file using the specified hash algorithm.
    /// </summary>
    /// <param name="value">The file whose hash to compute.</param>
    /// <typeparam name="T">
    ///     The type of the <see cref="HashAlgorithm" /> whose <see cref="HashAlgorithm.ComputeHash(Stream)" /> is to be used for
    ///     computing the hash.
    /// </typeparam>
    /// <returns>The hash of <paramref name="value" /> represented as an array of bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    /// <exception cref="FileNotFoundException">The specified file was not found.</exception>
    /// <exception cref="IOException">The opened file stream cannot be read.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
    [Pure]
    public static byte[] GetHash<T>(this FileInfo value)
        where T : HashAlgorithm
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value);
#else
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
#endif

        using FileStream stream = value.OpenRead();
        return stream.GetHash<T>();
    }

    /// <summary>
    ///     Computes the hash of a file using the specified hash algorithm.
    /// </summary>
    /// <param name="value">The file whose hash to compute.</param>
    /// <param name="destination">When this method returns, contains the computed hash of <paramref name="value" />.</param>
    /// <param name="bytesWritten">
    ///     When this method returns, the total number of bytes written into destination. This parameter is treated as
    ///     uninitialized.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the <see cref="HashAlgorithm" /> whose <see cref="HashAlgorithm.ComputeHash(Stream)" /> is to be used for
    ///     computing the hash.
    /// </typeparam>
    /// <returns>
    ///     <see langword="true" /> if the destination is long enough to receive the hash; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
    /// <exception cref="FileNotFoundException">The specified file was not found.</exception>
    /// <exception cref="IOException">The opened file stream cannot be read.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
    public static bool TryWriteHash<T>(this FileInfo value, Span<byte> destination, out int bytesWritten)
        where T : HashAlgorithm
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value);
#else
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
#endif

        using FileStream stream = value.OpenRead();
        return stream.TryWriteHash<T>(destination, out bytesWritten);
    }
}
