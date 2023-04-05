using System;
using System.Drawing;
using NUnit.Framework;
using X10D.Core;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class PointFTests
    {
        [Test]
        public void ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var point = new PointF(random.NextSingle(), random.NextSingle());
            var vector = point.ToUnityVector2();

            Assert.AreEqual(point.X, vector.x, 1e-6f);
            Assert.AreEqual(point.Y, vector.y, 1e-6f);
        }
    }
}
