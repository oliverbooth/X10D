using UnityEngine;

namespace X10D.Unity
{

    /// <summary>
    ///     Extension methods for <see cref="Vector3" />.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        ///     Rounds a <see cref="Vector3" /> by calling <see cref="SingleExtensions.Round" /> on each of the components.
        /// </summary>
        /// <param name="vector">The vector to round.</param>
        /// <param name="nearest">The nearest value.</param>
        /// <returns><paramref name="vector" /> rounded to the nearest <paramref name="nearest" />.</returns>
        public static Vector3 Round(this Vector3 vector, float nearest = 1)
        {
            return new Vector3(vector.x.Round(nearest), vector.y.Round(nearest), vector.z.Round(nearest));
        }

        /// <summary>
        ///     Returns a vector whose Y and Z components match that of a provided vector, and sets the X component to a provided value.
        /// </summary>
        /// <param name="vector">The input vector.</param>
        /// <param name="x">The new X value.</param>
        /// <returns>
        ///     Returns a <see cref="Vector3" /> whose Y and Z components match that of <paramref name="vector" />,
        ///     but with the <see cref="Vector3.x" /> component set to <paramref name="x" />.
        /// </returns>
        public static Vector3 WithX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        /// <summary>
        ///     Returns a vector whose Z component matches that of a provided vector, and sets the X and Y components to provided values.
        /// </summary>
        /// <param name="vector">The input vector.</param>
        /// <param name="x">The new X value.</param>
        /// <param name="y">The new Y value.</param>
        /// <returns>
        ///     Returns a <see cref="Vector3" /> whose Z component matches that of <paramref name="vector" />,
        ///     but with the <see cref="Vector3.x" /> and <see cref="Vector3.y" /> components set to <paramref name="x" /> and
        ///     <paramref name="y" /> respectively.
        /// </returns>
        public static Vector3 WithXY(this Vector3 vector, float x, float y)
        {
            return new Vector3(x, y, vector.z);
        }

        /// <summary>
        ///     Returns a vector whose Y component matches that of a provided vector, and sets the X and Z components to provided values.
        /// </summary>
        /// <param name="vector">The input vector.</param>
        /// <param name="x">The new X value.</param>
        /// <param name="z">The new Z value.</param>
        /// <returns>
        ///     Returns a <see cref="Vector3" /> whose Y component matches that of <paramref name="vector" />,
        ///     but with the <see cref="Vector3.x" /> and <see cref="Vector3.z" /> components set to <paramref name="x" /> and
        ///     <paramref name="z" /> respectively.
        /// </returns>
        public static Vector3 WithXZ(this Vector3 vector, float x, float z)
        {
            return new Vector3(x, vector.y, z);
        }

        /// <summary>
        ///     Returns a vector whose X and Z components match that of a provided vector, and sets the Y component to a provided value.
        /// </summary>
        /// <param name="vector">The input vector.</param>
        /// <param name="y">The new Y value.</param>
        /// <returns>
        ///     Returns a <see cref="Vector3" /> whose X and Z components match that of <paramref name="vector" />,
        ///     but with the <see cref="Vector3.y" /> component set to <paramref name="y" />.
        /// </returns>
        public static Vector3 WithY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        /// <summary>
        ///     Returns a vector whose X component matches that of a provided vector, and sets the Y and Z components to provided values.
        /// </summary>
        /// <param name="vector">The input vector.</param>
        /// <param name="y">The new Y value.</param>
        /// <param name="z">The new Z value.</param>
        /// <returns>
        ///     Returns a <see cref="Vector3" /> whose X component matches that of <paramref name="vector" />,
        ///     but with the <see cref="Vector3.y" /> and <see cref="Vector3.z" /> components set to <paramref name="y" /> and
        ///     <paramref name="z" /> respectively.
        /// </returns>
        public static Vector3 WithYZ(this Vector3 vector, float y, float z)
        {
            return new Vector3(vector.x, y, z);
        }

        /// <summary>
        ///     Returns a vector whose X and Y components match that of a provided vector, and sets the Z component to a provided value.
        /// </summary>
        /// <param name="vector">The input vector.</param>
        /// <param name="z">The new Z value.</param>
        /// <returns>
        ///     Returns a <see cref="Vector3" /> whose X and Y components match that of <paramref name="vector" />,
        ///     but with the <see cref="Vector3.z" /> component set to <paramref name="z" />.
        /// </returns>
        public static Vector3 WithZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }
    }
}
