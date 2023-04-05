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

            Assert.That(vector.x, Is.EqualTo(size.Width));
            Assert.That(vector.y, Is.EqualTo(size.Height));
        }

        [Test]
        public void ToUnityVector2Int_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new Size(random.Next(), random.Next());
            var vector = size.ToUnityVector2Int();

            Assert.That(vector.x, Is.EqualTo(size.Width));
            Assert.That(vector.y, Is.EqualTo(size.Height));
        }
    }
}
