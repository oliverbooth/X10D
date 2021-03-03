using System;
using System.IO;
using System.Security.Cryptography;

namespace X10D.StreamExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="Stream" />.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        ///     Returns the hash of a stream using the specified hash algorithm.
        /// </summary>
        /// <typeparam name="T">A <see cref="HashAlgorithm" /> derived type.</typeparam>
        /// <param name="stream">The stream whose hash is to be computed.</param>
        /// <returns>A <see cref="byte" /> array representing the hash of the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">
        ///     <typeparamref name="T" /> does not offer a static <c>Create</c> method.
        ///     -or-
        ///     An invocation to the static <c>Create</c> method defined in <typeparamref name="T" /> returned
        ///     <see langword="null" />.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The stream has already been disposed.</exception>
        /// <remarks>This method consumes the stream from its current position!.</remarks>
        public static byte[] GetHash<T>(this Stream stream)
            where T : HashAlgorithm
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var type = typeof(T);
            var create = type.GetMethod("Create", Array.Empty<Type>());
            if (create is null)
            {
                throw new TypeInitializationException(type.FullName,
                    new ArgumentException(ExceptionMessages.HashAlgorithmNoCreateMethod));
            }

            using var crypt = create.Invoke(null, null) as T;
            if (crypt is null)
            {
                throw new TypeInitializationException(type.FullName,
                    new ArgumentException(ExceptionMessages.HashAlgorithmCreateReturnedNull));
            }

            return crypt.ComputeHash(stream);
        }
    }
}
