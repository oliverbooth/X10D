namespace X10D.Unity
{
    using System;
    using JetBrains.Annotations;
    using UnityEngine;

    /// <summary>
    ///     Extension methods for <see cref="Transform" />.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        ///     Rotates the current <see cref="Transform" /> such that is is facing another <see cref="GameObject" />.
        /// </summary>
        /// <param name="transform">The current transform.</param>
        /// <param name="other">The target.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="transform" /> is null
        ///     - or -
        ///     <paramref name="other" /> is null.
        /// </exception>
        public static void LookAt([NotNull] this Transform transform, [NotNull] GameObject other)
        {
            if (transform is null)
            {
                throw new ArgumentNullException(nameof(transform));
            }

            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            transform.LookAt(other.transform);
        }
    }
}
