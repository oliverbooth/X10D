using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector2Tests
    {
        [UnityTest]
        public IEnumerator Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector2(1, 2);
            (float x, float y) = vector;

            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);

            yield break;
        }

        [UnityTest]
        public IEnumerator Round_ShouldRoundToNearestInteger_GivenNoParameters()
        {
            var vector = new Vector2(1.5f, 2.6f);
            var rounded = vector.Round();

            Assert.AreEqual(2, rounded.x);
            Assert.AreEqual(3, rounded.y);

            yield break;
        }

        [UnityTest]
        public IEnumerator Round_ShouldRoundToNearest10_GivenPrecision10()
        {
            var vector = new Vector2(1.5f, 25.2f);
            var rounded = vector.Round(10);

            Assert.AreEqual(0, rounded.x);
            Assert.AreEqual(30, rounded.y);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemPointF_ShouldReturnPoint_WithEquivalentMembers()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new Vector2(x, y);
            var point = vector.ToSystemPointF();

            Assert.AreEqual(vector.x, point.X, 1e-6f);
            Assert.AreEqual(vector.y, point.Y, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemSizeF_ShouldReturnSize_WithEquivalentMembers()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new Vector2(x, y);
            var point = vector.ToSystemSizeF();

            Assert.AreEqual(vector.x, point.Width, 1e-6f);
            Assert.AreEqual(vector.y, point.Height, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new Vector2(x, y);
            var systemVector = vector.ToSystemVector();

            Assert.AreEqual(vector.magnitude, systemVector.Length(), 1e-6f);
            Assert.AreEqual(vector.x, systemVector.X, 1e-6f);
            Assert.AreEqual(vector.y, systemVector.Y, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();

            var vector = new System.Numerics.Vector2(x, y);
            var unityVector = vector.ToUnityVector();

            Assert.AreEqual(vector.Length(), unityVector.magnitude, 1e-6f);
            Assert.AreEqual(vector.X, unityVector.x, 1e-6f);
            Assert.AreEqual(vector.Y, unityVector.y, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.AreEqual(Vector2.up, Vector2.one.WithX(0));
            Assert.AreEqual(Vector2.zero, Vector2.zero.WithX(0));
            Assert.AreEqual(Vector2.zero, Vector2.right.WithX(0));
            Assert.AreEqual(Vector2.up, Vector2.up.WithX(0));

            Assert.AreEqual(Vector2.one, Vector2.one.WithX(1));
            Assert.AreEqual(Vector2.right, Vector2.zero.WithX(1));
            Assert.AreEqual(Vector2.right, Vector2.right.WithX(1));
            Assert.AreEqual(Vector2.one, Vector2.up.WithX(1));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.AreEqual(Vector2.right, Vector2.one.WithY(0));
            Assert.AreEqual(Vector2.zero, Vector2.zero.WithY(0));
            Assert.AreEqual(Vector2.right, Vector2.right.WithY(0));
            Assert.AreEqual(Vector2.zero, Vector2.up.WithY(0));

            Assert.AreEqual(Vector2.one, Vector2.one.WithY(1));
            Assert.AreEqual(Vector2.up, Vector2.zero.WithY(1));
            Assert.AreEqual(Vector2.one, Vector2.right.WithY(1));
            Assert.AreEqual(Vector2.up, Vector2.up.WithY(1));

            yield break;
        }
    }
}
