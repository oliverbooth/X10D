using System;
using System.Collections;
using System.Drawing;
using NUnit.Framework;
using UnityEngine.TestTools;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class SizeTests
    {
        [UnityTest]
        public IEnumerator ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new Size(random.Next(), random.Next());
            var vector = size.ToUnityVector2();

            Assert.AreEqual(size.Width, vector.x);
            Assert.AreEqual(size.Height, vector.y);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityVector2Int_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new Size(random.Next(), random.Next());
            var vector = size.ToUnityVector2Int();

            Assert.AreEqual(size.Width, vector.x);
            Assert.AreEqual(size.Height, vector.y);

            yield break;
        }
    }
}
