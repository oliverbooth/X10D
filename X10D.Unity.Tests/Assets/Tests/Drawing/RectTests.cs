using NUnit.Framework;
using UnityEngine;
using X10D.Core;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RectTests
    {
        [Test]
        public void ToSystemRectangleF_ShouldReturnRectangleF_WithEquivalentMembers()
        {
            var random = new Random();
            var rect = new Rect(random.NextSingle(), random.NextSingle(), random.NextSingle(), random.NextSingle());
            var rectangle = rect.ToSystemRectangleF();

            Assert.That(rectangle.X, Is.EqualTo(rect.x).Within(1e-6f));
            Assert.That(rectangle.Y, Is.EqualTo(rect.y).Within(1e-6f));
            Assert.That(rectangle.Width, Is.EqualTo(rect.width).Within(1e-6f));
            Assert.That(rectangle.Height, Is.EqualTo(rect.height).Within(1e-6f));
        }
    }
}
