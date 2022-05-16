using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Core;
using X10D.Unity.Numerics;
using Random = System.Random;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector3Tests
    {
        [UnityTest]
        public IEnumerator Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector3(1, 2, 3);
            (float x, float y, float z) = vector;

            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual(3, z);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();

            var vector = new Vector3(x, y, z);
            var systemVector = vector.ToSystemVector();

            Assert.AreEqual(vector.magnitude, systemVector.Length(), 1e-6f);
            Assert.AreEqual(vector.x, systemVector.X, 1e-6f);
            Assert.AreEqual(vector.y, systemVector.Y, 1e-6f);
            Assert.AreEqual(vector.z, systemVector.Z, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityVector_ShouldReturnVector_WithEqualComponents()
        {
            var random = new Random();
            float x = random.NextSingle();
            float y = random.NextSingle();
            float z = random.NextSingle();

            var vector = new System.Numerics.Vector3(x, y, z);
            var unityVector = vector.ToUnityVector();

            Assert.AreEqual(vector.Length(), unityVector.magnitude, 1e-6f);
            Assert.AreEqual(vector.X, unityVector.x, 1e-6f);
            Assert.AreEqual(vector.Y, unityVector.y, 1e-6f);
            Assert.AreEqual(vector.Z, unityVector.z, 1e-6f);

            yield break;
        }

        [UnityTest]
        public IEnumerator WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.AreEqual(new Vector3(0, 1, 1), Vector3.one.WithX(0));
            Assert.AreEqual(Vector3.zero, Vector3.zero.WithX(0));
            Assert.AreEqual(Vector3.zero, Vector3.right.WithX(0));
            Assert.AreEqual(Vector3.up, Vector3.up.WithX(0));
            Assert.AreEqual(Vector3.forward, Vector3.forward.WithX(0));

            Assert.AreEqual(Vector3.one, Vector3.one.WithX(1));
            Assert.AreEqual(Vector3.right, Vector3.zero.WithX(1));
            Assert.AreEqual(Vector3.right, Vector3.right.WithX(1));
            Assert.AreEqual(new Vector3(1, 1, 0), Vector3.up.WithX(1));
            Assert.AreEqual(new Vector3(1, 0, 1), Vector3.forward.WithX(1));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.AreEqual(new Vector3(1, 0, 1), Vector3.one.WithY(0));
            Assert.AreEqual(Vector3.zero, Vector3.zero.WithY(0));
            Assert.AreEqual(Vector3.right, Vector3.right.WithY(0));
            Assert.AreEqual(Vector3.zero, Vector3.up.WithY(0));
            Assert.AreEqual(Vector3.forward, Vector3.forward.WithY(0));

            Assert.AreEqual(Vector3.one, Vector3.one.WithY(1));
            Assert.AreEqual(Vector3.up, Vector3.zero.WithY(1));
            Assert.AreEqual(new Vector3(1, 1, 0), Vector3.right.WithY(1));
            Assert.AreEqual(Vector3.up, Vector3.up.WithY(1));
            Assert.AreEqual(new Vector3(0, 1, 1), Vector3.forward.WithY(1));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithZ_ShouldReturnVectorWithNewZ_GivenVector()
        {
            Assert.AreEqual(new Vector3(1, 1, 0), Vector3.one.WithZ(0));
            Assert.AreEqual(Vector3.zero, Vector3.zero.WithZ(0));
            Assert.AreEqual(Vector3.right, Vector3.right.WithZ(0));
            Assert.AreEqual(Vector3.up, Vector3.up.WithZ(0));
            Assert.AreEqual(Vector3.zero, Vector3.forward.WithZ(0));

            Assert.AreEqual(Vector3.one, Vector3.one.WithZ(1));
            Assert.AreEqual(Vector3.forward, Vector3.zero.WithZ(1));
            Assert.AreEqual(new Vector3(1, 0, 1), Vector3.right.WithZ(1));
            Assert.AreEqual(new Vector3(0, 1, 1), Vector3.up.WithZ(1));
            Assert.AreEqual(Vector3.forward, Vector3.forward.WithZ(1));

            yield break;
        }
    }
}
