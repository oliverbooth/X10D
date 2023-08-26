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

            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
            Assert.That(z, Is.EqualTo(3));
            Assert.That(w, Is.EqualTo(4));
        }

        [Test]
        public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
        {
            var vector = new Vector4(1.5f, 2.6f, -5.2f, 0.3f);
            var rounded = vector.Round();

            Assert.That(rounded.x, Is.EqualTo(2));
            Assert.That(rounded.y, Is.EqualTo(3));
            Assert.That(rounded.z, Is.EqualTo(-5));
            Assert.That(rounded.w, Is.EqualTo(0));
        }

        [Test]
        public void Round_ShouldRoundToNearest10_GivenPrecision10()
        {
            var vector = new Vector4(1.5f, 25.2f, -12.5f, 101.2f);
            var rounded = vector.Round(10);

            Assert.That(rounded.x, Is.EqualTo(0));
            Assert.That(rounded.y, Is.EqualTo(30));
            Assert.That(rounded.z, Is.EqualTo(-10));
            Assert.That(rounded.w, Is.EqualTo(100));
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

            Assert.That(systemVector.Length(), Is.EqualTo(vector.magnitude).Within(1e-6f));
            Assert.That(systemVector.X, Is.EqualTo(vector.x).Within(1e-6f));
            Assert.That(systemVector.Y, Is.EqualTo(vector.y).Within(1e-6f));
            Assert.That(systemVector.Z, Is.EqualTo(vector.z).Within(1e-6f));
            Assert.That(systemVector.W, Is.EqualTo(vector.w).Within(1e-6f));
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

            Assert.That(unityVector.magnitude, Is.EqualTo(vector.Length()).Within(1e-6f));
            Assert.That(unityVector.x, Is.EqualTo(vector.X).Within(1e-6f));
            Assert.That(unityVector.y, Is.EqualTo(vector.Y).Within(1e-6f));
            Assert.That(unityVector.z, Is.EqualTo(vector.Z).Within(1e-6f));
            Assert.That(unityVector.w, Is.EqualTo(vector.W).Within(1e-6f));
        }

        [Test]
        public void WithW_ShouldReturnVectorWithNewW_GivenVector()
        {
            Assert.That(Vector4.one.WithW(0), Is.EqualTo(new Vector4(1, 1, 1, 0)));
            Assert.That(Vector4.zero.WithW(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(0, 0, 0, 1).WithW(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(1, 0, 0, 0).WithW(0), Is.EqualTo(new Vector4(1, 0, 0, 0)));
            Assert.That(new Vector4(0, 1, 0, 0).WithW(0), Is.EqualTo(new Vector4(0, 1, 0, 0)));
            Assert.That(new Vector4(0, 0, 1, 0).WithW(0), Is.EqualTo(new Vector4(0, 0, 1, 0)));

            Assert.That(Vector4.one.WithW(1), Is.EqualTo(Vector4.one));
            Assert.That(Vector4.zero.WithW(1), Is.EqualTo(new Vector4(0, 0, 0, 1)));
            Assert.That(new Vector4(0, 0, 0, 1).WithW(1), Is.EqualTo(new Vector4(0, 0, 0, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithW(1), Is.EqualTo(new Vector4(1, 0, 0, 1)));
            Assert.That(new Vector4(0, 1, 0, 0).WithW(1), Is.EqualTo(new Vector4(0, 1, 0, 1)));
            Assert.That(new Vector4(0, 0, 1, 0).WithW(1), Is.EqualTo(new Vector4(0, 0, 1, 1)));
        }

        [Test]
        public void WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.That(Vector4.one.WithX(0), Is.EqualTo(new Vector4(0, 1, 1, 1)));
            Assert.That(Vector4.zero.WithX(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(0, 0, 0, 1).WithX(0), Is.EqualTo(new Vector4(0, 0, 0, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithX(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(0, 1, 0, 0).WithX(0), Is.EqualTo(new Vector4(0, 1, 0, 0)));
            Assert.That(new Vector4(0, 0, 1, 0).WithX(0), Is.EqualTo(new Vector4(0, 0, 1, 0)));

            Assert.That(Vector4.one.WithX(1), Is.EqualTo(Vector4.one));
            Assert.That(Vector4.zero.WithX(1), Is.EqualTo(new Vector4(1, 0, 0, 0)));
            Assert.That(new Vector4(0, 0, 0, 1).WithX(1), Is.EqualTo(new Vector4(1, 0, 0, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithX(1), Is.EqualTo(new Vector4(1, 0, 0, 0)));
            Assert.That(new Vector4(0, 1, 0, 0).WithX(1), Is.EqualTo(new Vector4(1, 1, 0, 0)));
            Assert.That(new Vector4(0, 0, 1, 0).WithX(1), Is.EqualTo(new Vector4(1, 0, 1, 0)));
        }

        [Test]
        public void WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.That(Vector4.one.WithY(0), Is.EqualTo(new Vector4(1, 0, 1, 1)));
            Assert.That(Vector4.zero.WithY(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(0, 0, 0, 1).WithY(0), Is.EqualTo(new Vector4(0, 0, 0, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithY(0), Is.EqualTo(new Vector4(1, 0, 0, 0)));
            Assert.That(new Vector4(0, 1, 0, 0).WithY(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(0, 0, 1, 0).WithY(0), Is.EqualTo(new Vector4(0, 0, 1, 0)));

            Assert.That(Vector4.one.WithY(1), Is.EqualTo(Vector4.one));
            Assert.That(Vector4.zero.WithY(1), Is.EqualTo(new Vector4(0, 1, 0, 0)));
            Assert.That(new Vector4(0, 0, 0, 1).WithY(1), Is.EqualTo(new Vector4(0, 1, 0, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithY(1), Is.EqualTo(new Vector4(1, 1, 0, 0)));
            Assert.That(new Vector4(0, 1, 0, 0).WithY(1), Is.EqualTo(new Vector4(0, 1, 0, 0)));
            Assert.That(new Vector4(0, 0, 1, 0).WithY(1), Is.EqualTo(new Vector4(0, 1, 1, 0)));
        }

        [Test]
        public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
        {
            Assert.That(Vector4.one.WithZ(0), Is.EqualTo(new Vector4(1, 1, 0, 1)));
            Assert.That(Vector4.zero.WithZ(0), Is.EqualTo(Vector4.zero));
            Assert.That(new Vector4(0, 0, 0, 1).WithZ(0), Is.EqualTo(new Vector4(0, 0, 0, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithZ(0), Is.EqualTo(new Vector4(1, 0, 0, 0)));
            Assert.That(new Vector4(0, 1, 0, 0).WithZ(0), Is.EqualTo(new Vector4(0, 1, 0, 0)));
            Assert.That(new Vector4(0, 0, 1, 0).WithZ(0), Is.EqualTo(Vector4.zero));

            Assert.That(Vector4.one.WithZ(1), Is.EqualTo(Vector4.one));
            Assert.That(Vector4.zero.WithZ(1), Is.EqualTo(new Vector4(0, 0, 1, 0)));
            Assert.That(new Vector4(0, 0, 0, 1).WithZ(1), Is.EqualTo(new Vector4(0, 0, 1, 1)));
            Assert.That(new Vector4(1, 0, 0, 0).WithZ(1), Is.EqualTo(new Vector4(1, 0, 1, 0)));
            Assert.That(new Vector4(0, 1, 0, 0).WithZ(1), Is.EqualTo(new Vector4(0, 1, 1, 0)));
            Assert.That(new Vector4(0, 0, 1, 0).WithZ(1), Is.EqualTo(new Vector4(0, 0, 1, 0)));
        }
    }
}
