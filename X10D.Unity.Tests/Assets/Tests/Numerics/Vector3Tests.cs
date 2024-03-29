﻿using NUnit.Framework;
using UnityEngine;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector3Tests
    {
        [Test]
        public void Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector3(1, 2, 3);
            (float x, float y, float z) = vector;

            Assert.That(x, Is.EqualTo(1));
            Assert.That(y, Is.EqualTo(2));
            Assert.That(z, Is.EqualTo(3));
        }

        [Test]
        public void Round_ShouldRoundToNearestInteger_GivenNoParameters()
        {
            var vector = new Vector3(1.5f, 2.6f, -5.2f);
            var rounded = vector.Round();

            Assert.That(rounded.x, Is.EqualTo(2));
            Assert.That(rounded.y, Is.EqualTo(3));
            Assert.That(rounded.z, Is.EqualTo(-5));
        }

        [Test]
        public void Round_ShouldRoundToNearest10_GivenPrecision10()
        {
            var vector = new Vector3(1.5f, 25.2f, -12.5f);
            var rounded = vector.Round(10);

            Assert.That(rounded.x, Is.EqualTo(0));
            Assert.That(rounded.y, Is.EqualTo(30));
            Assert.That(rounded.z, Is.EqualTo(-10));
        }

        [Test]
        public void ToSystemVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();

            var vector = new Vector3(x, y, z);
            var systemVector = vector.ToSystemVector();

            Assert.That(systemVector.Length(), Is.EqualTo(vector.magnitude).Within(1e-6f));
            Assert.That(systemVector.X, Is.EqualTo(vector.x).Within(1e-6f));
            Assert.That(systemVector.Y, Is.EqualTo(vector.y).Within(1e-6f));
            Assert.That(systemVector.Z, Is.EqualTo(vector.z).Within(1e-6f));
        }

        [Test]
        public void ToUnityVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();

            var vector = new System.Numerics.Vector3(x, y, z);
            var unityVector = vector.ToUnityVector();

            Assert.That(unityVector.magnitude, Is.EqualTo(vector.Length()).Within(1e-6f));
            Assert.That(unityVector.x, Is.EqualTo(vector.X).Within(1e-6f));
            Assert.That(unityVector.y, Is.EqualTo(vector.Y).Within(1e-6f));
            Assert.That(unityVector.z, Is.EqualTo(vector.Z).Within(1e-6f));
        }

        [Test]
        public void WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.That(Vector3.one.WithX(0), Is.EqualTo(new Vector3(0, 1, 1)));
            Assert.That(Vector3.zero.WithX(0), Is.EqualTo(Vector3.zero));
            Assert.That(Vector3.right.WithX(0), Is.EqualTo(Vector3.zero));
            Assert.That(Vector3.up.WithX(0), Is.EqualTo(Vector3.up));
            Assert.That(Vector3.forward.WithX(0), Is.EqualTo(Vector3.forward));

            Assert.That(Vector3.one.WithX(1), Is.EqualTo(Vector3.one));
            Assert.That(Vector3.zero.WithX(1), Is.EqualTo(Vector3.right));
            Assert.That(Vector3.right.WithX(1), Is.EqualTo(Vector3.right));
            Assert.That(Vector3.up.WithX(1), Is.EqualTo(new Vector3(1, 1, 0)));
            Assert.That(Vector3.forward.WithX(1), Is.EqualTo(new Vector3(1, 0, 1)));
        }

        [Test]
        public void WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.That(Vector3.one.WithY(0), Is.EqualTo(new Vector3(1, 0, 1)));
            Assert.That(Vector3.zero.WithY(0), Is.EqualTo(Vector3.zero));
            Assert.That(Vector3.right.WithY(0), Is.EqualTo(Vector3.right));
            Assert.That(Vector3.up.WithY(0), Is.EqualTo(Vector3.zero));
            Assert.That(Vector3.forward.WithY(0), Is.EqualTo(Vector3.forward));

            Assert.That(Vector3.one.WithY(1), Is.EqualTo(Vector3.one));
            Assert.That(Vector3.zero.WithY(1), Is.EqualTo(Vector3.up));
            Assert.That(Vector3.right.WithY(1), Is.EqualTo(new Vector3(1, 1, 0)));
            Assert.That(Vector3.up.WithY(1), Is.EqualTo(Vector3.up));
            Assert.That(Vector3.forward.WithY(1), Is.EqualTo(new Vector3(0, 1, 1)));
        }

        [Test]
        public void WithZ_ShouldReturnVectorWithNewZ_GivenVector()
        {
            Assert.That(Vector3.one.WithZ(0), Is.EqualTo(new Vector3(1, 1, 0)));
            Assert.That(Vector3.zero.WithZ(0), Is.EqualTo(Vector3.zero));
            Assert.That(Vector3.right.WithZ(0), Is.EqualTo(Vector3.right));
            Assert.That(Vector3.up.WithZ(0), Is.EqualTo(Vector3.up));
            Assert.That(Vector3.forward.WithZ(0), Is.EqualTo(Vector3.zero));

            Assert.That(Vector3.one.WithZ(1), Is.EqualTo(Vector3.one));
            Assert.That(Vector3.zero.WithZ(1), Is.EqualTo(Vector3.forward));
            Assert.That(Vector3.right.WithZ(1), Is.EqualTo(new Vector3(1, 0, 1)));
            Assert.That(Vector3.up.WithZ(1), Is.EqualTo(new Vector3(0, 1, 1)));
            Assert.That(Vector3.forward.WithZ(1), Is.EqualTo(Vector3.forward));
        }
    }
}
