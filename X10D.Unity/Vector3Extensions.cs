namespace X10D.Unity
{
    #region Using Directives

    using UnityEngine;

    #endregion

    /// <summary>
    /// A set of extension methods for <see cref="Vector3"/>.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Converts a vector normal to an Euler rotation.
        /// </summary>
        /// <param name="v">The vector normal.</param>
        /// <returns>Returns a <see cref="Vector3"/> representing the Euler rotation.</returns>
        public static Vector3 NormalToEulerAngles(this Vector3 v)
        {
            float x = v.x;
            v.x =  v.z;
            v.z =  x;
            v.z *= 2.0f * v.y;
            v.y =  0.0f;
            return v * 90.0f;
        }

        /// <summary>
        /// Rounds a vector to the nearest value.
        /// </summary>
        /// <param name="v">The vector to round.</param>
        /// <param name="nearest">The nearest value.</param>
        /// <returns>Returns a <see cref="Vector3"/> containing the rounded values.</returns>
        public static Vector3 Round(this Vector3 v, int nearest = 1)
        {
            return new Vector3(v.x.Round(nearest), v.y.Round(nearest), v.z.Round(nearest));
        }

        /// <summary>
        /// Inverts the X component of a vector.
        /// </summary>
        /// <param name="v">The vector to evaluate.</param>
        /// <returns>Returns a <see cref="Vector3"/> whose values are (-X, Y, Z).</returns>
        public static Vector3 InvertX(this Vector3 v)
        {
            return new Vector3(-v.x, v.y, v.z);
        }

        /// <summary>
        /// Inverts the Y component of a vector.
        /// </summary>
        /// <param name="v">The vector to evaluate.</param>
        /// <returns>Returns a <see cref="Vector3"/> whose values are (X, -Y, Z).</returns>
        public static Vector3 InvertY(this Vector3 v)
        {
            return new Vector3(v.x, -v.y, v.z);
        }

        /// <summary>
        /// Inverts the Z component of a vector.
        /// </summary>
        /// <param name="v">The vector to evaluate.</param>
        /// <returns>Returns a <see cref="Vector3"/> whose values are (X, Y, -Z).</returns>
        public static Vector3 InvertZ(this Vector3 v)
        {
            return new Vector3(v.x, v.y, -v.z);
        }
    }
}
