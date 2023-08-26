using NUnit.Framework;
using UnityEngine;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RectIntTests
    {
        [Test]
        public void ToSystemRectangle_ShouldReturnRectangleF_WithEquivalentMembers()
        {
            var random = new Random();
            var rect = new RectInt(random.Next(), random.Next(), random.Next(), random.Next());
            var rectangle = rect.ToSystemRectangle();

            Assert.That(rectangle.X, Is.EqualTo(rect.x));
            Assert.That(rectangle.Y, Is.EqualTo(rect.y));
            Assert.That(rectangle.Width, Is.EqualTo(rect.width));
            Assert.That(rectangle.Height, Is.EqualTo(rect.height));
        }

        [Test]
        public void ToSystemRectangleF_ShouldReturnRectangleF_WithEquivalentMembers()
        {
            var random = new Random();
            var rect = new RectInt(random.Next(), random.Next(), random.Next(), random.Next());
            var rectangle = rect.ToSystemRectangleF();

            Assert.That(rectangle.X, Is.EqualTo(rect.x));
            Assert.That(rectangle.Y, Is.EqualTo(rect.y));
            Assert.That(rectangle.Width, Is.EqualTo(rect.width));
            Assert.That(rectangle.Height, Is.EqualTo(rect.height));
        }
    }
}
