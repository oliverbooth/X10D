using System;
using System.Drawing;
using NUnit.Framework;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class PointTests
    {
        [Test]
        public void ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var point = new Point(random.Next(), random.Next());
            var vector = point.ToUnityVector2();

            Assert.That(vector.x, Is.EqualTo(point.X));
            Assert.That(vector.y, Is.EqualTo(point.Y));
        }

        [Test]
        public void ToUnityVector2Int_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var point = new Point(random.Next(), random.Next());
            var vector = point.ToUnityVector2Int();

            Assert.That(vector.x, Is.EqualTo(point.X));
            Assert.That(vector.y, Is.EqualTo(point.Y));
        }
    }
}
