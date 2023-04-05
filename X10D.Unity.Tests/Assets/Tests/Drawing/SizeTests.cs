using System;
using System.Drawing;
using NUnit.Framework;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class SizeTests
    {
        [Test]
        public void ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new Size(random.Next(), random.Next());
            var vector = size.ToUnityVector2();

            Assert.AreEqual(size.Width, vector.x);
            Assert.AreEqual(size.Height, vector.y);
        }

        [Test]
        public void ToUnityVector2Int_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new Size(random.Next(), random.Next());
            var vector = size.ToUnityVector2Int();

            Assert.AreEqual(size.Width, vector.x);
            Assert.AreEqual(size.Height, vector.y);
        }
    }
}
