using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Numerics;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector3IntTests
    {
        [UnityTest]
        public IEnumerator Deconstruct_ShouldReturnCorrectValues()
        {
            var vector = new Vector3Int(1, 2, 3);
            (float x, float y, float z) = vector;

            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual(3, z);

            yield break;
        }

        [UnityTest]
        public IEnumerator WithX_ShouldReturnVectorWithNewX_GivenVector()
        {
            Assert.AreEqual(new Vector3Int(0, 1, 1), Vector3Int.one.WithX(0));
            Assert.AreEqual(Vector3Int.zero, Vector3Int.zero.WithX(0));
            Assert.AreEqual(Vector3Int.zero, Vector3Int.right.WithX(0));
            Assert.AreEqual(Vector3Int.up, Vector3Int.up.WithX(0));
            Assert.AreEqual(Vector3Int.forward, Vector3Int.forward.WithX(0));

            Assert.AreEqual(Vector3Int.one, Vector3Int.one.WithX(1));
            Assert.AreEqual(Vector3Int.right, Vector3Int.zero.WithX(1));
            Assert.AreEqual(Vector3Int.right, Vector3Int.right.WithX(1));
            Assert.AreEqual(new Vector3Int(1, 1, 0), Vector3Int.up.WithX(1));
            Assert.AreEqual(new Vector3Int(1, 0, 1), Vector3Int.forward.WithX(1));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithY_ShouldReturnVectorWithNewY_GivenVector()
        {
            Assert.AreEqual(new Vector3Int(1, 0, 1), Vector3Int.one.WithY(0));
            Assert.AreEqual(Vector3Int.zero, Vector3Int.zero.WithY(0));
            Assert.AreEqual(Vector3Int.right, Vector3Int.right.WithY(0));
            Assert.AreEqual(Vector3Int.zero, Vector3Int.up.WithY(0));
            Assert.AreEqual(Vector3Int.forward, Vector3Int.forward.WithY(0));

            Assert.AreEqual(Vector3Int.one, Vector3Int.one.WithY(1));
            Assert.AreEqual(Vector3Int.up, Vector3Int.zero.WithY(1));
            Assert.AreEqual(new Vector3Int(1, 1, 0), Vector3Int.right.WithY(1));
            Assert.AreEqual(Vector3Int.up, Vector3Int.up.WithY(1));
            Assert.AreEqual(new Vector3Int(0, 1, 1), Vector3Int.forward.WithY(1));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithZ_ShouldReturnVectorWithNewZ_GivenVector()
        {
            Assert.AreEqual(new Vector3Int(1, 1, 0), Vector3Int.one.WithZ(0));
            Assert.AreEqual(Vector3Int.zero, Vector3Int.zero.WithZ(0));
            Assert.AreEqual(Vector3Int.right, Vector3Int.right.WithZ(0));
            Assert.AreEqual(Vector3Int.up, Vector3Int.up.WithZ(0));
            Assert.AreEqual(Vector3Int.zero, Vector3Int.forward.WithZ(0));

            Assert.AreEqual(Vector3Int.one, Vector3Int.one.WithZ(1));
            Assert.AreEqual(Vector3Int.forward, Vector3Int.zero.WithZ(1));
            Assert.AreEqual(new Vector3Int(1, 0, 1), Vector3Int.right.WithZ(1));
            Assert.AreEqual(new Vector3Int(0, 1, 1), Vector3Int.up.WithZ(1));
            Assert.AreEqual(Vector3Int.forward, Vector3Int.forward.WithZ(1));

            yield break;
        }
    }
}
