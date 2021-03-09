#if NET5_0
using System;
using System.Numerics;
using X10D.SingleExtensions;

namespace X10D.RandomExtensions
{
    public static partial class RandomExtensions
    {
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
    }
}

#endif
