using System.Drawing;
using NUnit.Framework;
using X10D.Unity.Drawing;
using Random = System.Random;

namespace X10D.Unity.Tests.Drawing
{
    public class RectangleTests
    {
        [Test]
        public void ToUnityRect_ShouldReturnRect_WithEquivalentMembers()
        {
            var random = new Random();
            var rectangle = new Rectangle(random.Next(), random.Next(), random.Next(), random.Next());
            var rect = rectangle.ToUnityRect();

            Assert.That(rect.x, Is.EqualTo(rectangle.X));
            Assert.That(rect.y, Is.EqualTo(rectangle.Y));
            Assert.That(rect.width, Is.EqualTo(rectangle.Width));
            Assert.That(rect.height, Is.EqualTo(rectangle.Height));
        }

        [Test]
        public void ToUnityRectInt_ShouldReturnRect_WithEquivalentMembers()
        {
            var random = new Random();
            var rectangle = new Rectangle(random.Next(), random.Next(), random.Next(), random.Next());
            var rect = rectangle.ToUnityRectInt();

            Assert.That(rect.x, Is.EqualTo(rectangle.X));
            Assert.That(rect.y, Is.EqualTo(rectangle.Y));
            Assert.That(rect.width, Is.EqualTo(rectangle.Width));
            Assert.That(rect.height, Is.EqualTo(rectangle.Height));
        }
    }
}
