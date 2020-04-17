﻿namespace X10D
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Security.Cryptography;

    /// <summary>
    /// Extension methods for <see cref="Stream"/>.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Returns the hash of a stream using the specified hashing algorithm.
        /// </summary>
        /// <typeparam name="T">A <see cref="HashAlgorithm"/> derived type.</typeparam>
        /// <param name="stream">The stream whose hash is to be computed.</param>
        /// <returns>Returns a <see cref="Byte"/> array representing the hash of the stream.</returns>
        public static byte[] GetHash<T>(this Stream stream) where T : HashAlgorithm
        {
            MethodInfo create = typeof(T).GetMethod("Create", Array.Empty<Type>());
            using T    crypt  = (T)create?.Invoke(null, null);
            return crypt?.ComputeHash(stream);
        }
    }
}
