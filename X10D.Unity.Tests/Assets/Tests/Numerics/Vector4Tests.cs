using NUnit.Framework;
using UnityEngine;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector4Tests
    {
        [Test]
        public void Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector4(1, 2, 3, 4);
            (float x, float y, float z, float w) = vector;

            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual(3, z);
            Assert.AreEqual(4, w);
        }

        [Test]
        public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
        {
            var vector = new Vector4(1.5f, 2.6f, -5.2f, 0.3f);
            var rounded = vector.Round();

            Assert.AreEqual(2, rounded.x);
            Assert.AreEqual(3, rounded.y);
            Assert.AreEqual(-5, rounded.z);
            Assert.AreEqual(0, rounded.w);
        }

        [Test]
        public void Round_ShouldRoundToNearest10_GivenPrecision10()
        {
            var vector = new Vector4(1.5f, 25.2f, -12.5f, 101.2f);
            var rounded = vector.Round(10);

            Assert.AreEqual(0, rounded.x);
            Assert.AreEqual(30, rounded.y);
            Assert.AreEqual(-10, rounded.z);
            Assert.AreEqual(100, rounded.w);
        }

        [Test]
        public void ToSystemVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();
            float w = random.NextSingle();

            var vector = new Vector4(x, y, z, w);
            var systemVector = vector.ToSystemVector();

            Assert.AreEqual(vector.magnitude, systemVector.Length(), 1e-6f);
            Assert.AreEqual(vector.x, systemVector.X, 1e-6f);
            Assert.AreEqual(vector.y, systemVector.Y, 1e-6f);
            Assert.AreEqual(vector.z, systemVector.Z, 1e-6f);
            Assert.AreEqual(vector.w, systemVector.W, 1e-6f);
        }

        [Test]
        public void ToUnityVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();
            float w = random.NextSingle();

            var vector = new System.Numerics.Vector4(x, y, z, w);
            var unityVector = vector.ToUnityVector();

            Assert.AreEqual(vector.Length(), unityVector.magnitude, 1e-6f);
            Assert.AreEqual(vector.X, unityVector.x, 1e-6f);
            Assert.AreEqual(vector.Y, unityVector.y, 1e-6f);
            Assert.AreEqual(vector.Z, unityVector.z, 1e-6f);
            Assert.AreEqual(vector.W, unityVector.w, 1e-6f);
        }

        [Test]
        public void WithW_ShouldReturnVectorWithNewW_GivenVector()
        {
            Assert.AreEqual(new Vector4(1, 1, 1, 0), Vector4.one.WithW(0));
            Assert.AreEqual(Vector4.zero, Vector4.zero.WithW(0));
            Assert.AreEqual(Vector4.zero, new Vector4(0, 0, 0, 1).WithW(0));
            Assert.AreEqual(new Vector4(1, 0, 0, 0), new Vector4(1, 0, 0, 0).WithW(0));
            Assert.AreEqual(new Vector4(0, 1, 0, 0), new Vector4(0, 1, 0, 0).WithW(0));
            Assert.AreEqual(new Vector4(0, 0, 1, 0), new Vector4(0, 0, 1, 0).WithW(0));

            Assert.AreEqual(Vector4.one, Vector4.one.WithW(1));
            Assert.AreEqual(new Vector4(0, 0, 0, 1), Vector4.zero.WithW(1));
            Assert.AreEqual(new Vector4(0, 0, 0, 1), new Vector4(0, 0, 0, 1).WithW(1));
            Assert.AreEqual(new Vector4(1, 0, 0, 1), new Vector4(1, 0, 0, 0).WithW(1));
            Assert.AreEqual(new Vector4(0, 1, 0, 1), new Vector4(0, 1, 0, 0).WithW(1));
            Assert.AreEqual(new Vector4(0, 0, 1, 1), new Vector4(0, 0, 1, 0).WithW(1));
        }

        [Test]
        public void WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.AreEqual(new Vector4(0, 1, 1, 1), Vector4.one.WithX(0));
            Assert.AreEqual(Vector4.zero, Vector4.zero.WithX(0));
            Assert.AreEqual(new Vector4(0, 0, 0, 1), new Vector4(0, 0, 0, 1).WithX(0));
            Assert.AreEqual(Vector4.zero, new Vector4(1, 0, 0, 0).WithX(0));
            Assert.AreEqual(new Vector4(0, 1, 0, 0), new Vector4(0, 1, 0, 0).WithX(0));
            Assert.AreEqual(new Vector4(0, 0, 1, 0), new Vector4(0, 0, 1, 0).WithX(0));

            Assert.AreEqual(Vector4.one, Vector4.one.WithX(1));
            Assert.AreEqual(new Vector4(1, 0, 0, 0), Vector4.zero.WithX(1));
            Assert.AreEqual(new Vector4(1, 0, 0, 1), new Vector4(0, 0, 0, 1).WithX(1));
            Assert.AreEqual(new Vector4(1, 0, 0, 0), new Vector4(1, 0, 0, 0).WithX(1));
            Assert.AreEqual(new Vector4(1, 1, 0, 0), new Vector4(0, 1, 0, 0).WithX(1));
            Assert.AreEqual(new Vector4(1, 0, 1, 0), new Vector4(0, 0, 1, 0).WithX(1));
        }

        [Test]
        public void WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.AreEqual(new Vector4(1, 0, 1, 1), Vector4.one.WithY(0));
            Assert.AreEqual(Vector4.zero, Vector4.zero.WithY(0));
            Assert.AreEqual(new Vector4(0, 0, 0, 1), new Vector4(0, 0, 0, 1).WithY(0));
            Assert.AreEqual(new Vector4(1, 0, 0, 0), new Vector4(1, 0, 0, 0).WithY(0));
            Assert.AreEqual(Vector4.zero, new Vector4(0, 1, 0, 0).WithY(0));
            Assert.AreEqual(new Vector4(0, 0, 1, 0), new Vector4(0, 0, 1, 0).WithY(0));

            Assert.AreEqual(Vector4.one, Vector4.one.WithY(1));
            Assert.AreEqual(new Vector4(0, 1, 0, 0), Vector4.zero.WithY(1));
            Assert.AreEqual(new Vector4(0, 1, 0, 1), new Vector4(0, 0, 0, 1).WithY(1));
            Assert.AreEqual(new Vector4(1, 1, 0, 0), new Vector4(1, 0, 0, 0).WithY(1));
            Assert.AreEqual(new Vector4(0, 1, 0, 0), new Vector4(0, 1, 0, 0).WithY(1));
            Assert.AreEqual(new Vector4(0, 1, 1, 0), new Vector4(0, 0, 1, 0).WithY(1));
        }

        [Test]
        public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
        {
            Assert.AreEqual(new Vector4(1, 1, 0, 1), Vector4.one.WithZ(0));
            Assert.AreEqual(Vector4.zero, Vector4.zero.WithZ(0));
            Assert.AreEqual(new Vector4(0, 0, 0, 1), new Vector4(0, 0, 0, 1).WithZ(0));
            Assert.AreEqual(new Vector4(1, 0, 0, 0), new Vector4(1, 0, 0, 0).WithZ(0));
            Assert.AreEqual(new Vector4(0, 1, 0, 0), new Vector4(0, 1, 0, 0).WithZ(0));
            Assert.AreEqual(Vector4.zero, new Vector4(0, 0, 1, 0).WithZ(0));

            Assert.AreEqual(Vector4.one, Vector4.one.WithZ(1));
            Assert.AreEqual(new Vector4(0, 0, 1, 0), Vector4.zero.WithZ(1));
            Assert.AreEqual(new Vector4(0, 0, 1, 1), new Vector4(0, 0, 0, 1).WithZ(1));
            Assert.AreEqual(new Vector4(1, 0, 1, 0), new Vector4(1, 0, 0, 0).WithZ(1));
            Assert.AreEqual(new Vector4(0, 1, 1, 0), new Vector4(0, 1, 0, 0).WithZ(1));
            Assert.AreEqual(new Vector4(0, 0, 1, 0), new Vector4(0, 0, 1, 0).WithZ(1));
        }
    }
}
