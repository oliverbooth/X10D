using System;
using JetBrains.Annotations;
using UnityEngine;

namespace X10D.Unity
{
    /// <summary>
    ///     Extension methods for <see cref="GameObject" />.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        ///     Rotates the <see cref="Transform" /> component on the current <see cref="GameObject" /> such that is is facing another
        ///     <see cref="GameObject" />.
        /// </summary>
        /// <param name="gameObject">The current game object.</param>
        /// <param name="other">The target.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="gameObject" /> is null
        ///     - or -
        ///     <paramref name="other" /> is null.
        /// </exception>
        public static void LookAt([NotNull] this GameObject gameObject, [NotNull] GameObject other)
        {
            if (gameObject is null)
            {
                throw new ArgumentNullException(nameof(gameObject));
            }

            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            gameObject.LookAt(other.transform);
        }

        /// <summary>
        ///     Rotates the <see cref="Transform" /> component on the current <see cref="GameObject" /> such that is is facing another
        ///     <see cref="Transform" />.
        /// </summary>
        /// <param name="gameObject">The current game object.</param>
        /// <param name="other">The target.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="gameObject" /> is null
        ///     - or -
        ///     <paramref name="other" /> is null.
        /// </exception>
        public static void LookAt([NotNull] this GameObject gameObject, [NotNull] Transform other)
        {
            if (gameObject is null)
            {
                throw new ArgumentNullException(nameof(gameObject));
            }

            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            gameObject.transform.LookAt(other);
        }
    }
}
