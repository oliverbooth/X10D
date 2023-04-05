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

            Assert.AreEqual(rect.x, rectangle.X);
            Assert.AreEqual(rect.y, rectangle.Y);
            Assert.AreEqual(rect.width, rectangle.Width);
            Assert.AreEqual(rect.height, rectangle.Height);
        }

        [Test]
        public void ToSystemRectangleF_ShouldReturnRectangleF_WithEquivalentMembers()
        {
            var random = new Random();
            var rect = new RectInt(random.Next(), random.Next(), random.Next(), random.Next());
            var rectangle = rect.ToSystemRectangleF();

            Assert.AreEqual(rect.x, rectangle.X);
            Assert.AreEqual(rect.y, rectangle.Y);
            Assert.AreEqual(rect.width, rectangle.Width);
            Assert.AreEqual(rect.height, rectangle.Height);
        }
    }
}
