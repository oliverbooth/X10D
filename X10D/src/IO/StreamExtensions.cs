using System.Collections.Concurrent;
using System.Reflection;
using System.Security.Cryptography;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="Stream" />.
/// </summary>
public static partial class StreamExtensions
{
    private static readonly ConcurrentDictionary<Type, HashAlgorithm> HashAlgorithmCache = new();

    /// <summary>
    ///     Returns the hash of the current stream as an array of bytes using the specified hash algorithm.
    /// </summary>
    /// <param name="stream">The stream whose hash is to be computed.</param>
    /// <typeparam name="T">
    ///     The type of the <see cref="HashAlgorithm" /> whose <see cref="HashAlgorithm.ComputeHash(Stream)" /> is to be used for
    ///     computing the hash.
    /// </typeparam>
    /// <returns>The hash of <paramref name="stream" /> represented as an array of bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="IOException"><paramref name="stream" /> does not support reading.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
    public static byte[] GetHash<T>(this Stream stream)
        where T : HashAlgorithm
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new IOException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        if (HashAlgorithmCache.TryGetValue(typeof(T), out HashAlgorithm? cachedHashAlgorithm))
        {
            return cachedHashAlgorithm.ComputeHash(stream);
        }

        Type type = typeof(T);

        MethodInfo? createMethod = type.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .FirstOrDefault(c => c.Name == "Create" && c.GetParameters().Length == 0);
        if (createMethod is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod);
        }

        using var crypt = createMethod.Invoke(null, null) as T;
        if (crypt is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull);
        }

        HashAlgorithmCache.TryAdd(type, crypt);
        return crypt.ComputeHash(stream);
    }

    /// <summary>
    ///     Returns the hash of the current stream as an array of bytes using the specified hash algorithm.
    /// </summary>
    /// <param name="stream">The stream whose hash is to be computed.</param>
    /// <param name="destination">When this method returns, contains the computed hash of <paramref name="stream" />.</param>
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
    /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" /></exception>
    /// <exception cref="IOException"><paramref name="stream" /> does not support reading.</exception>
    /// <exception cref="TypeInitializationException">
    ///     The specified <see cref="HashAlgorithm" /> does not offer a public, static. parameterless <c>Create</c> method, or its
    ///     <c>Create</c> method returns a type that is not assignable to <typeparamref name="T" />.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
    public static bool TryWriteHash<T>(this Stream stream, Span<byte> destination, out int bytesWritten)
        where T : HashAlgorithm
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanRead)
        {
            throw new IOException(ExceptionMessages.StreamDoesNotSupportReading);
        }

        Span<byte> buffer = stackalloc byte[(int)stream.Length];
        if (HashAlgorithmCache.TryGetValue(typeof(T), out HashAlgorithm? cachedHashAlgorithm))
        {
            _ = stream.Read(buffer); // we don't care about the number of bytes read. we can ignore MustUseReturnValue
            return cachedHashAlgorithm.TryComputeHash(buffer, destination, out bytesWritten);
        }

        Type type = typeof(T);

        MethodInfo? createMethod = type.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .FirstOrDefault(c => c.Name == "Create" && c.GetParameters().Length == 0);
        if (createMethod is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod);
        }

        using var crypt = createMethod.Invoke(null, null) as T;
        if (crypt is null)
        {
            throw new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull);
        }

        if (stream.Length > int.MaxValue)
        {
            throw new ArgumentException(ExceptionMessages.StreamTooLarge);
        }

        HashAlgorithmCache.TryAdd(type, crypt);
        _ = stream.Read(buffer); // we don't care about the number of bytes read. we can ignore MustUseReturnValue
        return crypt.TryComputeHash(buffer, destination, out bytesWritten);
    }
}
