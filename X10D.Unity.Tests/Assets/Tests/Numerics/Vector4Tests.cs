using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using X10D.Unity.Numerics;

namespace X10D.Unity.Tests.Numerics
{
    public class Vector4Tests
    {
        [UnityTest]
        public IEnumerator WithW_ShouldReturnVectorWithNewW_GivenVector()
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
            
            yield break;
        }

        [UnityTest]
        public IEnumerator WithX_ShouldReturnVectorWithNewX_GivenVector()
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
            
            yield break;
        }

        [UnityTest]
        public IEnumerator WithY_ShouldReturnVectorWithNewY_GivenVector()
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
            
            yield break;
        }

        [UnityTest]
        public IEnumerator WithZ_ShouldReturnVectorWithNewZ_GivenVector()
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
            
            yield break;
        }
    }
}
