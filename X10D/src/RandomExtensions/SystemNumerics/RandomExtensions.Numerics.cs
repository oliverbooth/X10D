using System.Numerics;

namespace X10D.SystemNumerics
{
    public static partial class RandomExtensions
    {
        /// <summary>
        ///     Returns a randomly generated rotation as represented by a <see cref="Quaternion" />.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>
        ///     A <see cref="Quaternion" /> constructed from 3 random single-precision floating point numbers representing the
        ///     yaw, pitch, and roll.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static Quaternion NextRotation(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var seed = random.Next();
            var seededRandom = new Random(seed);

            var x = seededRandom.NextSingle(0, 360);
            var y = seededRandom.NextSingle(0, 360);
            var z = seededRandom.NextSingle(0, 360);

            return Quaternion.CreateFromYawPitchRoll(y, x, z);
        }

        /// <summary>
        ///     Returns a randomly generated rotation with uniform distribution.
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance.</param>
        /// <returns>A <see cref="Quaternion" /> constructed with uniform distribution.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="random" /> is <see langword="null" />.</exception>
        public static Quaternion NextRotationUniform(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var seed = random.Next();
            var seededRandom = new Random(seed);
            float normal, w, x, y, z;

            do
            {
                w = seededRandom.NextSingle(-1f, 1f);
                x = seededRandom.NextSingle(-1f, 1f);
                y = seededRandom.NextSingle(-1f, 1f);
                z = seededRandom.NextSingle(-1f, 1f);
                normal = w * w + x * x + y * y + z * z;
            }
            while (normal > 1f || normal == 0f);

            normal = MathF.Sqrt(normal);
            return new Quaternion(x / normal, y / normal, z / normal, w / normal);
        }

        /// <summary>
        ///     Returns a <see cref="Vector2" /> with magnitude 1 whose components indicate a random point on the unit circle. 
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance</param>
        /// <returns>
        ///     A <see cref="Vector2" /> whose <see cref="Vector2.Length()" /> returns 1, and whose components indicate a random
        ///     point on the unit circle.
        /// </returns>
        public static Vector2 NextUnitVector2(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var seed = random.Next();
            var seededRandom = new Random(seed);

            var angle = seededRandom.NextSingle(0, 360).DegreesToRadians();
            var x = MathF.Cos(angle);
            var y = MathF.Sin(angle);

            return new Vector2(x, y);
        }

        /// <summary>
        ///     Returns a <see cref="Vector3" /> with magnitude 1 whose components indicate a random point on the unit sphere. 
        /// </summary>
        /// <param name="random">The <see cref="System.Random" /> instance</param>
        /// <returns>
        ///     A <see cref="Vector3" /> whose <see cref="Vector3.Length()" /> returns 1, and whose components indicate a random
        ///     point on the unit sphere.
        /// </returns>
        public static Vector3 NextUnitVector3(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            var seed = random.Next();
            var seededRandom = new Random(seed);

            var angle = seededRandom.NextSingle(0, 360).DegreesToRadians();
            var z = seededRandom.NextSingle(-1, 1);
            var mp = MathF.Sqrt(1 - z * z);
            var x = mp * MathF.Cos(angle);
            var y = mp * MathF.Sin(angle);

            return new Vector3(x, y, z);
        }
    }
}
