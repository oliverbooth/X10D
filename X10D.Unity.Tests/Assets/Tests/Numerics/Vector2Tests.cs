using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Numerics;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector2Tests
    {
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
