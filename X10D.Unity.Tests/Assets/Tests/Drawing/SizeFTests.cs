using System;
using System.Drawing;
using NUnit.Framework;
using X10D.Core;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class SizeFTests
    {
        [Test]
        public void ToUnityVector2_ShouldReturnVector_WithEquivalentMembers()
        {
            var random = new Random();
            var size = new SizeF(random.NextSingle(), random.NextSingle());
            var vector = size.ToUnityVector2();

            Assert.That(vector.x, Is.EqualTo(size.Width).Within(1e-6f));
            Assert.That(vector.y, Is.EqualTo(size.Height).Within(1e-6f));
        }
    }
}
