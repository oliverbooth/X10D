using System;
using System.Collections;
using System.Drawing;
using NUnit.Framework;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class PointTests
    {
        [UnityTest]
        public IEnumerator ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var point = new Point(random.Next(), random.Next());
            var vector = point.ToUnityVector2();

            Assert.AreEqual(point.X, vector.x);
            Assert.AreEqual(point.Y, vector.y);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityVector2Int_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var point = new Point(random.Next(), random.Next());
            var vector = point.ToUnityVector2Int();

            Assert.AreEqual(point.X, vector.x);
            Assert.AreEqual(point.Y, vector.y);

            yield break;
        }
    }
}
