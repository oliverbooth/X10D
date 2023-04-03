using System;
using System.Collections;
using System.Drawing;
using NUnit.Framework;
using UnityEngine.TestTools;
using X10D.Core;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class SizeFTests
    {
        [UnityTest]
        public IEnumerator ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new SizeF(random.NextSingle(), random.NextSingle());
            var vector = size.ToUnityVector2();

            Assert.AreEqual(size.Width, vector.x, 1e-6f);
            Assert.AreEqual(size.Height, vector.y, 1e-6f);

            yield break;
        }
    }
}
